package routes

import (
	"github.com/fabioros/Komercio/controller"
	"github.com/gin-gonic/gin"
)

func CashmovementRoutes(r *gin.Engine, cashmovementController *controller.CashmovementController) {
	cashmovementGroup := r.Group("/cashmovements")
	cashmovementGroup.POST("/", cashmovementController.CreateCashmovement)
	cashmovementGroup.GET("/", cashmovementController.GetCashmovements)
}
