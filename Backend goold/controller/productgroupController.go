package controller

import (
	"net/http"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/service"
	"github.com/gin-gonic/gin"
)

type ProductGroupController struct {
	service service.ProductGroupService
}

func NewProductGroupController(productGroupService service.ProductGroupService) *ProductGroupController {
	return &ProductGroupController{
		service: productGroupService,
	}
}

func (c *ProductGroupController) GetAllProductGroup(ctx *gin.Context) {
	productGroup, err := c.service.SelectallProductGroup(ctx)
	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	ctx.JSON(http.StatusOK, productGroup)
}

func (c *ProductGroupController) CreateProductGroup(ctx *gin.Context) {
	var productGroup entity.ProductGroup
	if err := ctx.ShouldBindJSON(&productGroup); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "Parâmetros inválidos"})
		return
	}

	if err := c.service.CreateProductGroup(ctx, &productGroup); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}

	ctx.JSON(http.StatusCreated, gin.H{"message": "Grupo de produto criado com sucesso"})

}
