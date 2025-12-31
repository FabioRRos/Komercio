package controller

import (
	"fmt"
	"net/http"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/service"
	"github.com/gin-gonic/gin"
	"gorm.io/gorm"
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

// DELETE /Sales/DeleteSaleCascade/:saleId
func (c *SalesController) DeleteSaleCascade(ctx *gin.Context) {
	saleIdParam := ctx.Param("saleId")
	var saleId int
	_, err := fmt.Sscanf(saleIdParam, "%d", &saleId)
	if err != nil || saleId <= 0 {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "ID da venda inválido"}) //400
		return
	}
	err = c.service.DeleteSaleCascade(ctx, saleId)

	if err != nil {
		if err == gorm.ErrRecordNotFound {
			ctx.JSON(http.StatusNotFound, gin.H{"error": "Venda não encontrada"}) //404
		} else {
			ctx.JSON(http.StatusUnprocessableEntity, gin.H{"error": err.Error()}) //422
		}
		return
	}

	ctx.JSON(http.StatusOK, gin.H{"message": "Venda deletada com sucesso"}) //200
}
