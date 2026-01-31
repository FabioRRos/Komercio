package routes

import (
	"github.com/fabioros/Komercio/controller"
	"github.com/gin-gonic/gin"
)

func ListaCompraAPIRoutes(server *gin.Engine, listaCompraAPIController *controller.ListaCompraAPIController) {
	employeeRoutes := server.Group("/listacompra")
	{
		employeeRoutes.GET("/ativas", listaCompraAPIController.ListarTodasAsListasAtivas)
		employeeRoutes.GET("/inativas", listaCompraAPIController.ListarTodasAsListasInativas)
		employeeRoutes.GET("", listaCompraAPIController.ListarListasCompras)
		employeeRoutes.GET("id/:id", listaCompraAPIController.ObterListaPorId)
		employeeRoutes.POST("", listaCompraAPIController.CriarListaCompras)
		employeeRoutes.PUT("", listaCompraAPIController.AlterarListaDeCompra)
	}
}
