package routes

import (
	"github.com/fabioros/Komercio/controller"
	"github.com/gin-gonic/gin"
)

func ParametrosrRoutes(server *gin.Engine, parametros *controller.ParametrosController) {
	server.GET("/parametros", parametros.GetAllParametros)
	server.PUT("/parametros", parametros.UpdateParametros)
}
