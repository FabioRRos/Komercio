package controller

import (
	"net/http"
	"strconv"

	"github.com/fabioros/Komercio/domain/dto"
	"github.com/fabioros/Komercio/service"
	"github.com/gin-gonic/gin"
)

type ItensListaCompraController struct {
	service service.ItensListaCompraService
}

func NewItensListaCompraController(s service.ItensListaCompraService) *ItensListaCompraController {
	return &ItensListaCompraController{
		service: s,
	}
}

func (c *ItensListaCompraController) ListarOsItensById(ctx *gin.Context) {

	idStr := ctx.Param("id")
	id, err := strconv.Atoi(idStr)

	if err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"erro": "ID inválido. Deve ser um número."})
		return
	}

	listas, err := c.service.ListarOsItensById(ctx.Request.Context(), id)

	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"erro": err.Error()})
		return
	}

	ctx.JSON(http.StatusOK, listas)
}

func (c *ItensListaCompraController) CriarItensListaDeCompra(ctx *gin.Context) {
	var lista dto.ItensListaCompraDTO

	if err := ctx.ShouldBindJSON(&lista); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "Parâmetros inválidos"})
		return
	}

	listas, err := c.service.CriarItensListaDeCompra(ctx.Request.Context(), &lista)

	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"erro": err.Error()})
		return
	}

	ctx.JSON(http.StatusOK, listas)
}

func (c *ItensListaCompraController) AlterarListaDeCompra(ctx *gin.Context) {
	var lista dto.ItensListaCompraDTO

	if err := ctx.ShouldBindJSON(&lista); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "Parâmetros inválidos"})
		return
	}

	listas, err := c.service.AlterarItensListaDeCompra(ctx.Request.Context(), &lista)

	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"erro": err.Error()})
		return
	}

	ctx.JSON(http.StatusOK, listas)
}

func (c *ItensListaCompraController) TratamentoListaCompra(ctx *gin.Context) {
	var lista []dto.ItensListaCompraDTO

	if err := ctx.ShouldBindJSON(&lista); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "Parâmetros inválidos"})
		return
	}

	listas, err := c.service.TratamentoListaCompra(ctx.Request.Context(), lista)

	if err != nil {
		ctx.JSON(http.StatusInternalServerError, lista)
		return
	}

	ctx.JSON(http.StatusOK, listas)
}
