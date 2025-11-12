package routes

import (
	"github.com/fabioros/Komercio/controller"
	"github.com/gin-gonic/gin"
)

func CupomRoute(server *gin.Engine, cupomController *controller.CupomController) {
	server.GET("/Cupom/:id", cupomController.GetCupomById)
}
