package routes

import (
	"github.com/fabioros/Komercio/controller"
	"github.com/gin-gonic/gin"
)

func RegisterSaleRoutes(server *gin.Engine, salesController *controller.SalesController) {
	salesRouts := server.Group("/sales")
	{
		salesRouts.POST("/newsales", salesController.CreateNewSale)
		salesRouts.DELETE("/deletesalecascade/:saleId", salesController.DeleteSaleCascade)
	}
}
