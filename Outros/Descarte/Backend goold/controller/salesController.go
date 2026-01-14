package controller

import (
	"net/http"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/service"
	"github.com/gin-gonic/gin"
)

type SalesController struct {
	service service.SalesService
}

func NewSalesController(salesController service.SalesService) *SalesController {
	return &SalesController{
		service: salesController,
	}
}

// post /Sales/NewSale

func (c *SalesController) CreateNewSale(ctx *gin.Context) {
	var sale entity.Sales

	if err := ctx.ShouldBindJSON(&sale); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "Parâmetros inválidos"})
		return
	}

	idSale, err := c.service.CreateNewSale(ctx, &sale)

	if err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}

	ctx.JSON(http.StatusOK, idSale)

}
