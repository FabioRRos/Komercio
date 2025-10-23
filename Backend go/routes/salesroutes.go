package routes

import (
	"github.com/fabioros/Komercio/controller"
	"github.com/gin-gonic/gin"
)

func RegisterSaleRoutes(server *gin.Engine, salesController *controller.SalesController) {
	salesRouts := server.Group("/sales")
	{
		salesRouts.GET("/sales/newsales/:sale", salesController.CreateNewSale)
	}
}
