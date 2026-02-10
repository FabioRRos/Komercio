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
