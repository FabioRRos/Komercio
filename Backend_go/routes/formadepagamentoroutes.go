package routes

import (
	"github.com/fabioros/Komercio/controller"
	"github.com/gin-gonic/gin"
)

func RegisterFormaPagamentoRoutes(server *gin.Engine, formaPagamentoController *controller.FormaPagamentoController) {
	server.POST("/formadepagamento", formaPagamentoController.CreateFormaPagamento)
	server.GET("/formadepagamento", formaPagamentoController.GetAllFormaPagamento)
	server.GET("/formadepagamento/:id", formaPagamentoController.GetFormaPagamentoById)
	server.PUT("/formadepagamento", formaPagamentoController.UpdateFormaPagamento)
}
