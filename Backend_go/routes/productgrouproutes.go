package routes

import (
	"github.com/fabioros/Komercio/controller"
	"github.com/gin-gonic/gin"
)

func RegisterProductGroupRoutes(server *gin.Engine, productGroupController *controller.ProductGroupController) {
	server.GET("/productGroup", productGroupController.GetAllProductGroup)
	server.POST("/productGroup", productGroupController.CreateProductGroup)
}
