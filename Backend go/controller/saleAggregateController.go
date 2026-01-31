package controller

import (
	"net/http"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/service"
	"github.com/gin-gonic/gin"
)

type FullSaleController struct {
	service service.FullSaleService
}

// Construtor
func NewFullSaleController(fullSaleService service.FullSaleService) *FullSaleController {
	return &FullSaleController{
		service: fullSaleService,
	}
}

// POST /sales/fullsale
func (c *FullSaleController) CreateFullSale(ctx *gin.Context) {
	var saleAggregate entity.SaleAggregate

	// Faz o bind do JSON recebido
	if err := ctx.ShouldBindJSON(&saleAggregate); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "Parâmetros inválidos ou JSON mal formatado"})
		return
	}

	// Chama o service para processar tudo
	// Aqui usamos o contexto do request.
	saleID, err := c.service.CreateFullSale(ctx.Request.Context(), &saleAggregate)
	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}

	// Retorna sucesso
	ctx.JSON(http.StatusOK, gin.H{
		"message": "Venda completa registrada com sucesso",
		"sale_id": saleID,
	})
}
