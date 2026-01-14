package controller

import (
	"github.com/fabioros/Komercio/service"
	"github.com/gin-gonic/gin"
)

type ProductDescriptionController struct {
	service service.ProductDescriptionService
}

func NewProductDescriptionController(productDescriptionService service.ProductDescriptionService) *ProductDescriptionController {
	return &ProductDescriptionController{
		service: productDescriptionService,
	}
}

func (c *ProductDescriptionController) GetAllProductDescription(ctx *gin.Context) {
	productDescription, err := c.service.FullListProductAndDescription(ctx)

	if err != nil {
		ctx.JSON(500, gin.H{"error": err.Error()})
	}
	ctx.JSON(200, productDescription)
}
