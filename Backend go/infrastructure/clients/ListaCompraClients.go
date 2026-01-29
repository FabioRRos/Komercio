package clients

import (
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
