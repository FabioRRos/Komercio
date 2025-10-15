package routes

import (
	"github.com/fabioros/Komercio/controller"
	"github.com/gin-gonic/gin"
)

func RegisterProductRoutes(server *gin.Engine, productController *controller.ProductController) {
	server.GET("/products", productController.GetAllProducts)
	server.GET("/products/:id", productController.GetProductById)
	server.POST("/products", productController.CreateProduct)
	server.PUT("/products/:id", productController.UpdateProduct)
	server.DELETE("/products/:id", productController.DeactivateProduct)
}
