package routes

import (
	"github.com/fabioros/Komercio/controller"
	"github.com/gin-gonic/gin"
)

func RegisterSaleItemsRoutes(server *gin.Engine, saleItemsController *controller.SaleItemsController) {
	routes := server.Group("/sale_items")
	{
		routes.POST("/", saleItemsController.CreateSaleItem)
		routes.GET("/", saleItemsController.GetAllSaleItems)
		routes.GET("/:sale_id", saleItemsController.GetItemsBySaleId)
	}
}
