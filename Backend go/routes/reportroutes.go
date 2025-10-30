package routes

import (
	"github.com/fabioros/Komercio/controller"
	"github.com/gin-gonic/gin"
)

func ReportProductRoutes(server *gin.Engine, reportController *controller.ReportController) {
	server.GET("/Report/Sales", reportController.SelectSaleReport)
}
