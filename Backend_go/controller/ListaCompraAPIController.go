package controller

import (
	"net/http"
	"strconv"

	"github.com/fabioros/Komercio/domain/dto"
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

func (c *ListaCompraAPIController) ListarTodasAsListasAtivas(ctx *gin.Context) {
	listas, err := c.listaCompraService.ListarTodasAsListasAtivas(ctx.Request.Context())
	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"erro": err.Error()})
		return
	}

	ctx.JSON(http.StatusOK, listas)
}

func (c *ListaCompraAPIController) ListarTodasAsListasInativas(ctx *gin.Context) {
	listas, err := c.listaCompraService.ListarTodasAsListasInativas(ctx.Request.Context())
	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"erro": err.Error()})
		return
	}

	ctx.JSON(http.StatusOK, listas)
}

func (c *ListaCompraAPIController) ObterListaPorId(ctx *gin.Context) {

	idStr := ctx.Param("id")
	id, err := strconv.Atoi(idStr)

	if err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"erro": "ID inválido. Deve ser um número."})
		return
	}

	listas, err := c.listaCompraService.ObterListaPorId(ctx.Request.Context(), id)

	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"erro": err.Error()})
		return
	}

	ctx.JSON(http.StatusOK, listas)
}

func (c *ListaCompraAPIController) CriarListaCompras(ctx *gin.Context) {
	var lista dto.ListaComprasDTO

	if err := ctx.ShouldBindJSON(&lista); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "Parâmetros inválidos"})
		return
	}

	listas, err := c.listaCompraService.CriarListaCompras(ctx.Request.Context(), &lista)

	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"erro": err.Error()})
		return
	}

	ctx.JSON(http.StatusOK, listas)
}

func (c *ListaCompraAPIController) AlterarListaDeCompra(ctx *gin.Context) {
	var lista dto.ListaComprasDTO

	if err := ctx.ShouldBindJSON(&lista); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "Parâmetros inválidos"})
		return
	}

	listas, err := c.listaCompraService.AlterarListaDeCompra(ctx.Request.Context(), &lista)

	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"erro": err.Error()})
		return
	}

	ctx.JSON(http.StatusOK, listas)
}
