package controller

import (
	"net/http"
	"strconv"

	"github.com/fabioros/Komercio/domain/entity"
	service "github.com/fabioros/Komercio/service"

	"github.com/gin-gonic/gin"
)

type ProductController struct {
	service service.ProductService
}

func NewProductController(productService service.ProductService) *ProductController {
	return &ProductController{
		service: productService,
	}
}

// GET /products
func (c *ProductController) GetAllProducts(ctx *gin.Context) {
	products, err := c.service.SelectAllProducts(ctx)
	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	ctx.JSON(http.StatusOK, products)
}

// GET /products/:id
func (c *ProductController) GetProductById(ctx *gin.Context) {
	idParam := ctx.Param("id")
	id, err := strconv.Atoi(idParam)
	if err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "ID inválido"})
		return
	}

	product, err := c.service.SelectProductById(ctx, id)
	if err != nil {
		ctx.JSON(http.StatusNotFound, gin.H{"error": err.Error()})
		return
	}
	ctx.JSON(http.StatusOK, product)
}

// POST /products
func (c *ProductController) CreateProduct(ctx *gin.Context) {
	var product entity.Product
	if err := ctx.ShouldBindJSON(&product); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "Parâmetros inválidos"})
		return
	}

	if err := c.service.CreateProduct(ctx, &product); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}

	ctx.JSON(http.StatusCreated, gin.H{"message": "Produto criado com sucesso"})
}

// PUT /products/:id
func (c *ProductController) UpdateProduct(ctx *gin.Context) {
	var product entity.Product
	if err := ctx.ShouldBindJSON(&product); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "Parâmetros inválidos"})
		return
	}

	idParam := ctx.Param("id")
	id, err := strconv.Atoi(idParam)
	if err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "ID inválido"})
		return
	}

	product.Id = id

	updated, err := c.service.UpdateProduct(ctx, &product)
	if err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}

	ctx.JSON(http.StatusOK, updated)
}

// #### Na vdd ele não deleta o protudo, apenas deixa desabilitado no banco ####
// DELETE /products/:id
func (c *ProductController) DeactivateProduct(ctx *gin.Context) {
	idParam := ctx.Param("id")
	id, err := strconv.Atoi(idParam)
	if err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "ID inválido"})
		return
	}

	if err := c.service.DeactivateProduct(ctx, id); err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}

	ctx.JSON(http.StatusOK, gin.H{"message": "Produto desativado com sucesso"})
}
