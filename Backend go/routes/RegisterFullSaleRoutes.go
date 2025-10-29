package routes

import (
	"github.com/fabioros/Komercio/controller"
	"github.com/gin-gonic/gin"
)

// Aqui registramos as rotas relacionadas à venda completa (FullSale)
func RegisterFullSaleRoutes(server *gin.Engine, fullSaleController *controller.FullSaleController) {
	fullSaleRoutes := server.Group("/sales")
	{
		// POST /sales/fullsale → cria uma venda completa (venda + itens + movimentação de caixa)
		fullSaleRoutes.POST("/fullsale", fullSaleController.CreateFullSale)
	}
}
