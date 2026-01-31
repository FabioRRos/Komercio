package clients

import (
	"bytes"
	"context"
	"encoding/json"
	"fmt"
	"net/http"
	"time"

	"github.com/fabioros/Komercio/domain/dto"
)

type ListaCompraAPIClient struct {
	baseURL    string
	httpClient *http.Client
}

func NewListaCompraAPIClient(baseURL string) *ListaCompraAPIClient {
	return &ListaCompraAPIClient{
		baseURL: baseURL,
		httpClient: &http.Client{
			Timeout: time.Second * 10,
		},
	}
}

// GET LISTA DAS VENDAS.
func (c *ListaCompraAPIClient) ListarTodasAsListas(ctx context.Context) ([]dto.ListaComprasDTO, error) {
	url := fmt.Sprintf("%s/api/listacompras", c.baseURL)

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

		var envelope struct {
			Dados    []dto.ListaComprasDTO `json:"dados"`
			Mensagem string                `json:"mensagem"`
			Sucesso  bool                  `json:"sucesso"`
		}

		if err := json.NewDecoder(resp.Body).Decode(&envelope); err != nil {
			return nil, fmt.Errorf("erro ao decodificar envelope: %w", err)
		}

		// Verificamos se a API reportou sucesso na lógica interna
		if !envelope.Sucesso {
			return nil, fmt.Errorf("API C# reportou erro logico: %s", envelope.Mensagem)
		}

		return envelope.Dados, nil

	case http.StatusNotFound: // 404
		return nil, fmt.Errorf("nenhuma lista ativa foi encontrada no momento")

	case http.StatusUnauthorized, http.StatusForbidden: // 401 ou 403
		return nil, fmt.Errorf("o backend Go não tem permissão para acessar a API de Estoque")

	case http.StatusInternalServerError: // 500
		return nil, fmt.Errorf("a API C# travou (erro interno no servidor)")

	default: // Qualquer outro erro (400, 502, 503, etc)
		return nil, fmt.Errorf("erro inesperado da API C#: código %d", resp.StatusCode)
	}
}

// GET LISTA DAS VENDAS.
func (c *ListaCompraAPIClient) ListarTodasAsListasAtivas(ctx context.Context) ([]dto.ListaComprasDTO, error) {
	url := fmt.Sprintf("%s/api/listacompras/ativas", c.baseURL)

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

		var envelope struct {
			Dados    []dto.ListaComprasDTO `json:"dados"`
			Mensagem string                `json:"mensagem"`
			Sucesso  bool                  `json:"sucesso"`
		}

		if err := json.NewDecoder(resp.Body).Decode(&envelope); err != nil {
			return nil, fmt.Errorf("erro ao decodificar envelope: %w", err)
		}

		// Verificamos se a API reportou sucesso na lógica interna
		if !envelope.Sucesso {
			return nil, fmt.Errorf("API C# reportou erro logico: %s", envelope.Mensagem)
		}

		return envelope.Dados, nil

	case http.StatusNotFound: // 404
		return nil, fmt.Errorf("nenhuma lista ativa foi encontrada no momento")

	case http.StatusUnauthorized, http.StatusForbidden: // 401 ou 403
		return nil, fmt.Errorf("o backend Go não tem permissão para acessar a API de Estoque")

	case http.StatusInternalServerError: // 500
		return nil, fmt.Errorf("a API C# travou (erro interno no servidor)")

	default: // Qualquer outro erro (400, 502, 503, etc)
		return nil, fmt.Errorf("erro inesperado da API C#: código %d", resp.StatusCode)
	}
}

// GET LISTA DAS VENDAS.
func (c *ListaCompraAPIClient) ListarTodasAsListasInativas(ctx context.Context) ([]dto.ListaComprasDTO, error) {
	url := fmt.Sprintf("%s/api/listacompras/inativas", c.baseURL)

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

		var envelope struct {
			Dados    []dto.ListaComprasDTO `json:"dados"`
			Mensagem string                `json:"mensagem"`
			Sucesso  bool                  `json:"sucesso"`
		}

		if err := json.NewDecoder(resp.Body).Decode(&envelope); err != nil {
			return nil, fmt.Errorf("erro ao decodificar envelope: %w", err)
		}

		// Verificamos se a API reportou sucesso na lógica interna
		if !envelope.Sucesso {
			return nil, fmt.Errorf("API C# reportou erro logico: %s", envelope.Mensagem)
		}

		return envelope.Dados, nil

	case http.StatusNotFound: // 404
		return nil, fmt.Errorf("nenhuma lista ativa foi encontrada no momento")

	case http.StatusUnauthorized, http.StatusForbidden: // 401 ou 403
		return nil, fmt.Errorf("o backend Go não tem permissão para acessar a API de Estoque")

	case http.StatusInternalServerError: // 500
		return nil, fmt.Errorf("a API C# travou (erro interno no servidor)")

	default: // Qualquer outro erro (400, 502, 503, etc)
		return nil, fmt.Errorf("erro inesperado da API C#: código %d", resp.StatusCode)
	}
}

// GET BY ID
func (c *ListaCompraAPIClient) ObterListaPorId(ctx context.Context, id int) (*dto.ListaComprasDTO, error) {
	url := fmt.Sprintf("%s/api/listacompras/id/%d", c.baseURL, id)

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

		var envelope struct {
			Dados    dto.ListaComprasDTO `json:"dados"`
			Mensagem string              `json:"mensagem"`
			Sucesso  bool                `json:"sucesso"`
		}

		if err := json.NewDecoder(resp.Body).Decode(&envelope); err != nil {
			return nil, fmt.Errorf("erro ao decodificar objeto: %w", err)
		}

		// Verificamos se a API reportou sucesso na lógica interna
		if !envelope.Sucesso {
			return nil, fmt.Errorf("Erro inesperado na API: %s", envelope.Mensagem)
		}

		return &envelope.Dados, nil
	case http.StatusNotFound: // 404
		return nil, fmt.Errorf("nenhuma lista ativa foi encontrada no momento")

	case http.StatusUnauthorized, http.StatusForbidden: // 401 ou 403
		return nil, fmt.Errorf("o backend Go não tem permissão para acessar a API de Estoque")

	case http.StatusInternalServerError: // 500
		return nil, fmt.Errorf("a API C# travou (erro interno no servidor)")

	default: // Qualquer outro erro (400, 502, 503, etc)
		return nil, fmt.Errorf("%d", resp.StatusCode)
	}
}

//POST

func (c *ListaCompraAPIClient) CriarListaCompras(ctx context.Context, lista *dto.ListaComprasDTO) (*dto.ListaComprasDTO, error) {

	url := fmt.Sprintf("%s/api/listacompras/", c.baseURL)

	jsonData, err := json.Marshal(lista)
	if err != nil {
		return nil, fmt.Errorf("erro ao serializar lista: %w", err)
	}

	req, err := http.NewRequestWithContext(ctx, http.MethodPost, url, bytes.NewBuffer(jsonData))
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
	case http.StatusOK, http.StatusCreated: // 200 ou 201

		var envelope struct {
			Dados    dto.ListaComprasDTO `json:"dados"`
			Mensagem string              `json:"mensagem"`
			Sucesso  bool                `json:"sucesso"`
		}

		if err := json.NewDecoder(resp.Body).Decode(&envelope); err != nil {
			return nil, fmt.Errorf("erro ao decodificar resposta: %w", err)
		}

		if !envelope.Sucesso {
			return nil, fmt.Errorf("API erro: %s", envelope.Mensagem)
		}

		return &envelope.Dados, nil

	case http.StatusBadRequest: // 400 - Geralmente erro de validação no C#
		return nil, fmt.Errorf("dados da lista invalidos")

	case http.StatusUnauthorized: // 401
		return nil, fmt.Errorf("sem permissao para criar lista")

	case http.StatusInternalServerError: // 500
		return nil, fmt.Errorf("erro interno no servidor")

	default:
		return nil, fmt.Errorf("erro inesperado: codigo %d", resp.StatusCode)
	}

}

func (c *ListaCompraAPIClient) AlterarListaDeCompra(ctx context.Context, lista *dto.ListaComprasDTO) (*dto.ListaComprasDTO, error) {

	url := fmt.Sprintf("%s/api/listacompras/", c.baseURL)

	jsonData, err := json.Marshal(lista)
	if err != nil {
		return nil, fmt.Errorf("erro ao serializar lista: %w", err)
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
	case http.StatusOK, http.StatusCreated: // 200 ou 201

		var envelope struct {
			Dados    dto.ListaComprasDTO `json:"dados"`
			Mensagem string              `json:"mensagem"`
			Sucesso  bool                `json:"sucesso"`
		}

		if err := json.NewDecoder(resp.Body).Decode(&envelope); err != nil {
			return nil, fmt.Errorf("erro ao decodificar resposta: %w", err)
		}

		if !envelope.Sucesso {
			return nil, fmt.Errorf("API erro: %s", envelope.Mensagem)
		}

		return &envelope.Dados, nil

	case http.StatusBadRequest: // 400 - Geralmente erro de validação no C#
		return nil, fmt.Errorf("dados da lista invalidos")

	case http.StatusUnauthorized: // 401
		return nil, fmt.Errorf("sem permissao para criar lista")

	case http.StatusInternalServerError: // 500
		return nil, fmt.Errorf("erro interno no servidor")

	default:
		return nil, fmt.Errorf("erro inesperado: codigo %d", resp.StatusCode)
	}

}
