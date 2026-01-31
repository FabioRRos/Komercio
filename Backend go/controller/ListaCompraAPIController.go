package controller

import (
	"net/http"

	"github.com/fabioros/Komercio/service"
	"github.com/gin-gonic/gin"
)

type ListaCompraAPIController struct {
	// Aqui injetamos a interface do seu Service
	listaCompraService service.ListaCompraAPIService
}

func NewListaCompraController(s service.ListaCompraAPIService) *ListaCompraAPIController {
	return &ListaCompraAPIController{
		listaCompraService: s,
	}
}

func (c *ListaCompraAPIController) ListarListasCompras(ctx *gin.Context) {
	listas, err := c.listaCompraService.ListarTodasAsListas(ctx.Request.Context())
	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"erro": err.Error()})
		return
	}

	ctx.JSON(http.StatusOK, listas)
}
