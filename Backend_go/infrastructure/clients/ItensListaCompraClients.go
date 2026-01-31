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

type ItensListaCompraClients struct {
	baseURL    string
	httpClient *http.Client
}

func NewItensListaCompraClient(baseURL string) *ItensListaCompraClients {
	return &ItensListaCompraClients{
		baseURL: baseURL,
		httpClient: &http.Client{
			Timeout: time.Second * 10,
		},
	}
}

// GET LISTA DOS ITENS DA LISTA DE COMPRA

func (c *ItensListaCompraClients) ListarOsItensById(ctx context.Context, id int) (*[]dto.ItensListaCompraDTO, error) {
	url := fmt.Sprintf("%s/api/itenslistacompras/id/%d", c.baseURL, id)

	req, err := http.NewRequestWithContext(ctx, http.MethodGet, url, nil)

	resp, err := c.httpClient.Do(req)
	if err != nil {
		return nil, fmt.Errorf("falha na comunicacao: %w", err)
	}
	defer resp.Body.Close()

	switch resp.StatusCode {
	case http.StatusOK: // 200

		var envelope struct {
			Dados    []dto.ItensListaCompraDTO `json:"dados"`
			Mensagem string                    `json:"mensagem"`
			Sucesso  bool                      `json:"sucesso"`
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
		return nil, fmt.Errorf("Nenhum item encontrado com esse id.")

	case http.StatusUnauthorized, http.StatusForbidden: // 401 ou 403
		return nil, fmt.Errorf("o backend Go não tem permissão para acessar a API de Estoque")

	case http.StatusInternalServerError: // 500
		return nil, fmt.Errorf("a API C# travou (erro interno no servidor)")

	default: // Qualquer outro erro (400, 502, 503, etc)
		return nil, fmt.Errorf("%d", resp.StatusCode)
	}
}

//POST LISTA DOS ITENS DA LISTA DE COMPRA

func (c *ItensListaCompraClients) CriarItensListaDeCompra(ctx context.Context, item *dto.ItensListaCompraDTO) (*dto.ItensListaCompraDTO, error) {
	url := fmt.Sprintf("%s/api/ItensListaCompras/", c.baseURL)

	jsonData, err := json.Marshal(item)

	if err != nil {
		return nil, fmt.Errorf("erro ao serializar item: %w", err)
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
			Dados    dto.ItensListaCompraDTO `json:"dados"`
			Mensagem string                  `json:"mensagem"`
			Sucesso  bool                    `json:"sucesso"`
		}

		if err := json.NewDecoder(resp.Body).Decode(&envelope); err != nil {
			return nil, fmt.Errorf("erro ao decodificar resposta: %w", err)
		}

		if !envelope.Sucesso {
			return nil, fmt.Errorf("API erro: %s", envelope.Mensagem)
		}

		return &envelope.Dados, nil

	case http.StatusBadRequest: // 400 - Geralmente erro de validação no C#
		return nil, fmt.Errorf("itens invalidos")

	case http.StatusUnauthorized: // 401
		return nil, fmt.Errorf("sem permissao para criar item")

	case http.StatusInternalServerError: // 500
		return nil, fmt.Errorf("erro interno no servidor")

	default:
		return nil, fmt.Errorf("erro inesperado: codigo %d", resp.StatusCode)
	}
}

// PUT Alterar os itens da lista
func (c *ItensListaCompraClients) AlterarItensListaDeCompra(ctx context.Context, item *dto.ItensListaCompraDTO) (*dto.ItensListaCompraDTO, error) {
	url := fmt.Sprintf("%s/api/ItensListaCompras/", c.baseURL)

	jsonData, err := json.Marshal(item)

	if err != nil {
		return nil, fmt.Errorf("erro ao serializar item: %w", err)
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
			Dados    dto.ItensListaCompraDTO `json:"dados"`
			Mensagem string                  `json:"mensagem"`
			Sucesso  bool                    `json:"sucesso"`
		}

		if err := json.NewDecoder(resp.Body).Decode(&envelope); err != nil {
			return nil, fmt.Errorf("erro ao decodificar resposta: %w", err)
		}

		if !envelope.Sucesso {
			return nil, fmt.Errorf("API erro: %s", envelope.Mensagem)
		}

		return &envelope.Dados, nil

	case http.StatusBadRequest: // 400 - Geralmente erro de validação no C#
		return nil, fmt.Errorf("itens invalidos")

	case http.StatusUnauthorized: // 401
		return nil, fmt.Errorf("sem permissao para criar item")

	case http.StatusInternalServerError: // 500
		return nil, fmt.Errorf("erro interno no servidor")

	default:
		return nil, fmt.Errorf("erro inesperado: codigo %d", resp.StatusCode)
	}
}
