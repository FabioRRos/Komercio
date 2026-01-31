package routes

import (
	"github.com/fabioros/Komercio/controller"
	"github.com/gin-gonic/gin"
)

func CustomertransactionControllerRoutes(server *gin.Engine, transation *controller.CustomerTransactionController) {
	server.GET("/transaction", transation.GETTransaction)
	server.GET("/transaction/:id", transation.GETTransactionById)
	server.POST("/transaction", transation.CreateTransaction)
}
