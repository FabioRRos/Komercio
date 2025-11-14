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

// rota GET da configuração de notificação
func (c *ProductController) GetAllProductsSettings(ctx *gin.Context) {
	products, err := c.service.SelectProductSettings(ctx)
	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	ctx.JSON(200, products)
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

// GET /products/getbycodbar/:codbar
func (c *ProductController) GetProductByCodbar(ctx *gin.Context) {
	productCodBar := ctx.Param("productcodbar")

	if productCodBar == "" {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "Código de barras não informado"})
		return
	}

	product, err := c.service.SelectProductByCodBar(ctx, productCodBar)
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

type StockUpdateRequest struct {
	ProductStock int `json:"product_stock"`
}

// put /updateStock/:productcodbar
func (c *ProductController) UpdateProductInputStock(ctx *gin.Context) {
	var productStock StockUpdateRequest

	if err := ctx.ShouldBindJSON(&productStock); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "Parâmetros inválidos"})
		return
	}

	idParam := ctx.Param("productcodbar")
	productcodbar := idParam

	updated, err := c.service.UpdateProductInputStock(ctx, productcodbar, productStock.ProductStock)
	if err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
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

//PUT lista de produtos para notificar baixa estoque

func (c *ProductController) UpdateProductNotification(ctx *gin.Context) {
	var productList []*entity.ProductNotification

	if err := ctx.ShouldBindJSON(&productList); err != nil {
		ctx.JSON(400, gin.H{
			"error": "JSON inválido: " + err.Error(),
		})
		return
	}

	if err := c.service.UpdateProductNotification(ctx, productList); err != nil {
		ctx.JSON(500, gin.H{
			"error": err.Error(),
		})
		return
	}

	ctx.JSON(200, gin.H{
		"message": "Notificações atualizadas com sucesso!",
	})
}
