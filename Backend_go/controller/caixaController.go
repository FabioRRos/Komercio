package controller

import (
	"net/http"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/service"
	"github.com/gin-gonic/gin"
)

type CaixaController struct {
	service service.CaixaService
}

func NewCaixaController(caixaService service.CaixaService) *CaixaController {
	return &CaixaController{
		service: caixaService,
	}
}

// put
func (c *CaixaController) CaixaChange(ctx *gin.Context) {
	var caixa entity.Caixa
	if err := ctx.ShouldBindJSON(&caixa); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}

	if err := c.service.CaixaChange(ctx, &caixa); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}

}

// get
func (c *CaixaController) GetCaixa(ctx *gin.Context) {
	caixa, err := c.service.GetCaixa(ctx)

	if err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"erro": err.Error()})
		return
	}

	ctx.JSON(http.StatusOK, caixa)
}

func (c *CaixaController) GetStatusCaixa(ctx *gin.Context) {
	status, err := c.service.StatusCaixa(ctx)

	if err != nil {
		ctx.JSON(http.StatusBadRequest, "Não consegui bustar o status")
		return
	}
	ctx.JSON(200, status)
}
