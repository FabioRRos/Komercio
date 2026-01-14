package controller

import (
	"net/http"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/service"
	"github.com/gin-gonic/gin"
)

type ProductSubgroupController struct {
	service service.ProductSubgroupService
}

func NewProductSubgroupController(productSubgroupService service.ProductSubgroupService) *ProductSubgroupController {
	return &ProductSubgroupController{
		service: productSubgroupService,
	}
}

func (c *ProductSubgroupController) GetAllProductSubgroup(ctx *gin.Context) {
	productSubgroup, err := c.service.SelectallProductSubgroup(ctx)
	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	ctx.JSON(http.StatusOK, productSubgroup)
}

func (c *ProductSubgroupController) CreateProductSubgroup(ctx *gin.Context) {
	var productSubgroup entity.ProductSubGroup
	if err := ctx.ShouldBindJSON(&productSubgroup); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "Parâmetros inválidos"})
		return
	}

	if err := c.service.CreateProductSubgroup(ctx, &productSubgroup); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}

	ctx.JSON(http.StatusCreated, gin.H{"message": "Subgrupo de produto criado com sucesso"})

}
