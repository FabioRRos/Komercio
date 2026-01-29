package routes

import (
	"github.com/fabioros/Komercio/controller"
	"github.com/gin-gonic/gin"
)

func ListaCompraAPIRoutes(server *gin.Engine, listaCompraAPIController *controller.ListaCompraAPIController) {
	employeeRoutes := server.Group("/listacompra")
	{
		employeeRoutes.GET("", listaCompraAPIController.ListarListasCompras)
	}
}
