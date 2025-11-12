package routes

import (
	"github.com/fabioros/Komercio/controller"
	"github.com/gin-gonic/gin"
)

func RegisterProductRoutes(server *gin.Engine, productController *controller.ProductController) {
	server.GET("/products", productController.GetAllProducts)
	server.GET("/products/codbar/:productcodbar", productController.GetProductByCodbar)
	server.GET("/products/notification/", productController.GetAllProductsSettings)
	server.GET("/products/:id", productController.GetProductById)
	server.POST("/products", productController.CreateProduct)
	server.PUT("/products/:id", productController.UpdateProduct)
	server.PUT("/products/updateStock/:productcodbar", productController.UpdateProductInputStock)
	server.DELETE("/products/:id", productController.DeactivateProduct)
}
