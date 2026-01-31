package routes

import (
	"github.com/fabioros/Komercio/controller"
	"github.com/gin-gonic/gin"
)

func CaixaRoute(server *gin.Engine, caixaController *controller.CaixaController) {
	server.POST("/Caixa", caixaController.CaixaChange)
	server.GET("/Caixa", caixaController.GetCaixa)
}
