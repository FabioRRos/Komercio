package routes

import (
	"github.com/fabioros/Komercio/controller"
	"github.com/gin-gonic/gin"
)

func RegisterProductSubgroupRoutes(server *gin.Engine, productSubgroupController *controller.ProductSubgroupController) {
	server.GET("/productSubgroup", productSubgroupController.GetAllProductSubgroup)
	server.POST("/productSubgroup", productSubgroupController.CreateProductSubgroup)
}
