package routes

import (
	"github.com/fabioros/Komercio/controller"
	"github.com/gin-gonic/gin"
)

func ItensListaCompraRoutes(server *gin.Engine, itensListaCompra *controller.ItensListaCompraController) {
	employeeRoutes := server.Group("/itenslista")
	{
		employeeRoutes.GET("id/:id", itensListaCompra.ListarOsItensById)
		employeeRoutes.POST("", itensListaCompra.CriarItensListaDeCompra)
		employeeRoutes.PUT("", itensListaCompra.AlterarListaDeCompra)
	}
}
