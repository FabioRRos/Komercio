package clients

import (
	"bytes"
	"context"
	"encoding/json"
	"fmt"
	"io"
	"net/http"
	"strings"
	"time"

	"github.com/fabioros/Komercio/domain/dto"
	"github.com/fabioros/Komercio/domain/entity"
)

type ProdutosClient struct {
	baseURL    string
	httpClient *http.Client
}

func NewProdutosClient(baseURL string) *ProdutosClient {
	return &ProdutosClient{
		baseURL: baseURL,
		httpClient: &http.Client{
			Timeout: time.Second * 10,
		},
	}
}

// Seleciona todos os produtos
func (c *ProdutosClient) SelectAllProducts(ctx context.Context) ([]*entity.Product, error) {

	baseURL := strings.TrimRight(c.baseURL, "/")
	url := fmt.Sprintf("%s/api/Produtos", baseURL)

	req, err := http.NewRequestWithContext(ctx, http.MethodGet, url, nil)
	if err != nil {
		return nil, fmt.Errorf("erro ao criar request: %w", err)
	}
	resp, err := c.httpClient.Do(req)
	if err != nil {
		return nil, fmt.Errorf("falha na comunicacao: %w", err)
	}
	defer resp.Body.Close()

	switch resp.StatusCode {
	case http.StatusOK: // 200

		var produtos []*entity.Product
		if err := json.NewDecoder(resp.Body).Decode(&produtos); err != nil {
			return nil, fmt.Errorf("JSON inválido recebido do C#: %w", err)
		}
		return produtos, nil

	case http.StatusNotFound: // 404
		return nil, fmt.Errorf("nenhum produto encontrado (404)")

	case http.StatusUnauthorized, http.StatusForbidden: // 401 ou 403
		return nil, fmt.Errorf("acesso negado à API de Estoque (401/403)")

	case http.StatusInternalServerError: // 500
		return nil, fmt.Errorf("a API C# travou (erro interno no servidor)")

	default: // Qualquer outro erro (400, 502, 503, etc)
		return nil, fmt.Errorf("erro inesperado da API C#: código %d", resp.StatusCode)
	}

}

// Cria o protudo
func (c *ProdutosClient) Create(ctx context.Context, produto *entity.Product) error {
	baseURL := strings.TrimRight(c.baseURL, "/")
	url := fmt.Sprintf("%s/api/Produtos", baseURL)

	jsonData, err := json.Marshal(produto)
	if err != nil {
		return fmt.Errorf("erro ao serializar produto: %w", err)
	}
	req, err := http.NewRequestWithContext(ctx, http.MethodPost, url, bytes.NewBuffer(jsonData))
	if err != nil {
		return fmt.Errorf("erro ao criar request: %w", err)
	}

	req.Header.Set("Content-Type", "application/json")

	resp, err := c.httpClient.Do(req)
	if err != nil {
		return fmt.Errorf("falha na comunicacao: %w", err)
	}
	defer resp.Body.Close()

	switch resp.StatusCode {
	case http.StatusOK, http.StatusCreated:
		return nil

	case http.StatusBadRequest: // 400 - Geralmente erro de validação no C#
		erroBody, _ := io.ReadAll(resp.Body)
		return fmt.Errorf("dados inválidos (API C# diz: %s)", string(erroBody))

	case http.StatusUnauthorized: // 401
		return fmt.Errorf("sem permissao para criar o produto")
	case http.StatusInternalServerError: // 500
		return fmt.Errorf("erro interno no servidor C#")
	default:
		return fmt.Errorf("erro inesperado: codigo %d", resp.StatusCode)
	}

}

// Busca pelo ID
func (c *ProdutosClient) SelectProductById(ctx context.Context, id int) (*entity.Product, error) {
	baseURL := strings.TrimRight(c.baseURL, "/")
	url := fmt.Sprintf("%s/api/Produtos/%d", baseURL, id)

	req, err := http.NewRequestWithContext(ctx, http.MethodGet, url, nil)
	if err != nil {
		return nil, fmt.Errorf("erro ao criar requisicao: %w", err)
	}

	resp, err := c.httpClient.Do(req)
	if err != nil {
		return nil, fmt.Errorf("erro na comunicacao com API: %w", err)
	}
	defer resp.Body.Close()

	switch resp.StatusCode {
	case http.StatusOK:
		var produto entity.Product
		if err := json.NewDecoder(resp.Body).Decode(&produto); err != nil {
			return nil, fmt.Errorf("JSON inválido recebido do C#: %w", err)
		}

		return &produto, nil

	case http.StatusNotFound:
		return nil, fmt.Errorf("produto %d não encontrado (404)", id)

	case http.StatusUnauthorized, http.StatusForbidden:
		return nil, fmt.Errorf("sem permissão para consultar produto (401/403)")

	case http.StatusInternalServerError:
		return nil, fmt.Errorf("erro interno no servidor C# (500)")

	default:

		body, _ := io.ReadAll(resp.Body)
		return nil, fmt.Errorf("erro inesperado (%d): %s", resp.StatusCode, string(body))
	}
}

// Busca pelo codigo de barras (mas retorna também a quantidade no estoque)
func (c *ProdutosClient) SelectProductByCodBar(ctx context.Context, codBar string) (*entity.Product, error) {
	baseURL := strings.TrimRight(c.baseURL, "/")
	url := fmt.Sprintf("%s/api/Produtos/cod/%s", baseURL, codBar)

	req, err := http.NewRequestWithContext(ctx, http.MethodGet, url, nil)
	if err != nil {
		return nil, fmt.Errorf("erro ao criar requisicao: %w", err)
	}

	resp, err := c.httpClient.Do(req)
	if err != nil {
		return nil, fmt.Errorf("erro na comunicacao com API: %w", err)
	}
	defer resp.Body.Close()

	switch resp.StatusCode {
	case http.StatusOK:
		var produto entity.Product
		if err := json.NewDecoder(resp.Body).Decode(&produto); err != nil {
			return nil, fmt.Errorf("JSON inválido recebido do C#: %w", err)
		}

		return &produto, nil

	case http.StatusNotFound:
		return nil, fmt.Errorf("produto %s não encontrado (404)", codBar)

	case http.StatusUnauthorized, http.StatusForbidden:
		return nil, fmt.Errorf("sem permissão para consultar produto (401/403)")

	case http.StatusInternalServerError:
		return nil, fmt.Errorf("erro interno no servidor C# (500)")

	default:

		body, _ := io.ReadAll(resp.Body)
		return nil, fmt.Errorf("erro inesperado (%d): %s", resp.StatusCode, string(body))
	}
}

// Manda os produtos para o serviço tratar

func (c *ProdutosClient) EntradaProdutosVenda(ctx context.Context, prod *dto.RealizarVendaDto) error {
	baseURL := strings.TrimRight(c.baseURL, "/")
	url := fmt.Sprintf("%s/api/Estoque/venda", baseURL)

	jsonData, err := json.Marshal(prod)
	if err != nil {
		return fmt.Errorf("erro ao serializar produto: %w", err)
	}
	req, err := http.NewRequestWithContext(ctx, http.MethodPost, url, bytes.NewBuffer(jsonData))
	if err != nil {
		return fmt.Errorf("erro ao criar request: %w", err)
	}

	req.Header.Set("Content-Type", "application/json")

	resp, err := c.httpClient.Do(req)
	if err != nil {
		return fmt.Errorf("falha na comunicacao: %w", err)
	}
	defer resp.Body.Close()

	switch resp.StatusCode {
	case http.StatusOK, http.StatusCreated:
		return nil

	case http.StatusBadRequest: // 400 - Geralmente erro de validação no C#
		erroBody, _ := io.ReadAll(resp.Body)
		return fmt.Errorf("dados inválidos (API C# diz: %s)", string(erroBody))

	case http.StatusUnauthorized: // 401
		return fmt.Errorf("sem permissao para criar o produto")
	case http.StatusInternalServerError: // 500
		return fmt.Errorf("erro interno no servidor C#")
	default:
		return fmt.Errorf("erro inesperado: codigo %d", resp.StatusCode)
	}

}

func (c *ProdutosClient) RegistrarEntradaAsync(ctx context.Context, produto *dto.RegistrarEntradaDto) error {

	//return fmt.Errorf("Aqui.")

	baseURL := strings.TrimRight(c.baseURL, "/")
	url := fmt.Sprintf("%s/api/Estoque/entrada", baseURL)

	jsonData, err := json.Marshal(produto)
	if err != nil {
		return fmt.Errorf("erro ao serializar produto: %w", err)
	}
	req, err := http.NewRequestWithContext(ctx, http.MethodPost, url, bytes.NewBuffer(jsonData))
	if err != nil {
		return fmt.Errorf("erro ao criar request: %w", err)
	}

	req.Header.Set("Content-Type", "application/json")

	resp, err := c.httpClient.Do(req)
	if err != nil {
		return fmt.Errorf("falha na comunicacao: %w", err)
	}
	defer resp.Body.Close()

	switch resp.StatusCode {
	case http.StatusOK, http.StatusCreated:
		return nil

	case http.StatusBadRequest: // 400 - Geralmente erro de validação no C#
		erroBody, _ := io.ReadAll(resp.Body)
		return fmt.Errorf("dados inválidos (API C# diz: %s)", string(erroBody))

	case http.StatusUnauthorized: // 401
		return fmt.Errorf("sem permissao para entrar o produto")
	case http.StatusInternalServerError: // 500
		return fmt.Errorf("erro interno no servidor C#")
	default:
		return fmt.Errorf("erro inesperado: codigo %d", resp.StatusCode)
	}

}

func (c *ProdutosClient) UpdateProduct(ctx context.Context, produto *entity.Product) (*entity.Product, error) {

	baseURL := strings.TrimRight(c.baseURL, "/")
	url := fmt.Sprintf("%s/api/Produtos/%d", baseURL, produto.Id)

	jsonData, err := json.Marshal(produto)
	if err != nil {
		return nil, fmt.Errorf("erro ao serializar produto: %w", err)
	}

	req, err := http.NewRequestWithContext(ctx, http.MethodPut, url, bytes.NewBuffer(jsonData))
	if err != nil {
		return nil, fmt.Errorf("erro ao criar request: %w", err)
	}

	req.Header.Set("Content-Type", "application/json")

	resp, err := c.httpClient.Do(req)
	if err != nil {
		return nil, fmt.Errorf("falha na comunicacao: %w", err)
	}
	defer resp.Body.Close()

	switch resp.StatusCode {
	case http.StatusOK: // 200

		var produtosReturn entity.Product
		if err := json.NewDecoder(resp.Body).Decode(&produtosReturn); err != nil {
			return nil, fmt.Errorf("JSON inválido recebido do C#: %w", err)
		}
		return &produtosReturn, nil

	case http.StatusNotFound: // 404
		return nil, fmt.Errorf("nenhum produto encontrado (404)")

	case http.StatusUnauthorized, http.StatusForbidden: // 401 ou 403
		return nil, fmt.Errorf("acesso negado à API de Estoque (401/403)")

	case http.StatusInternalServerError: // 500
		return nil, fmt.Errorf("a API C# travou (erro interno no servidor)")

	default: // Qualquer outro erro (400, 502, 503, etc)
		return nil, fmt.Errorf("erro inesperado da API C#: código %d", resp.StatusCode)
	}

}
