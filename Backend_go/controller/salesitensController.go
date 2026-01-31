package controller

import (
	"net/http"
	"strconv"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/service"
	"github.com/gin-gonic/gin"
)

type SaleItemsController struct {
	service service.SaleItemsService
}

func NewSaleItemsController(s service.SaleItemsService) *SaleItemsController {
	return &SaleItemsController{
		service: s,
	}
}

func (c *SaleItemsController) CreateSaleItem(ctx *gin.Context) {
	var item entity.SalesItens

	if err := ctx.ShouldBindJSON(&item); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "Parâmetros inválidos"})
		return
	}

	err := c.service.CreateSaleItem(ctx.Request.Context(), &item)
	if err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}

	ctx.JSON(http.StatusCreated, gin.H{"message": "Item da venda criado com sucesso"})
}

func (c *SaleItemsController) GetAllSaleItems(ctx *gin.Context) {
	items, err := c.service.GetAllSaleItems(ctx.Request.Context())
	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}

	ctx.JSON(http.StatusOK, items)
}

func (c *SaleItemsController) GetItemsBySaleId(ctx *gin.Context) {
	saleIDParam := ctx.Param("sale_id")

	saleID, err := strconv.Atoi(saleIDParam)
	if err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "sale_id inválido"})
		return
	}

	items, err := c.service.GetItemsBySaleId(ctx.Request.Context(), saleID)
	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}

	ctx.JSON(http.StatusOK, items)
}
