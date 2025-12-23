package controller

import (
	"net/http"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/service"
	"github.com/gin-gonic/gin"
)

type CashmovementController struct {
	service service.CashmovementService
}

func NewCashmovementController(cashmovementService service.CashmovementService) *CashmovementController {
	return &CashmovementController{
		service: cashmovementService,
	}
}

// put
func (c *CashmovementController) CreateCashmovement(ctx *gin.Context) {
	var cashmovements entity.Cashmovements

	if err := ctx.ShouldBindJSON(&cashmovements); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}
	if err := c.service.CreateCashmovement(ctx, &cashmovements); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
	}

}

// get
func (c *CashmovementController) GetCashmovements(ctx *gin.Context) {
	cashmovement, err := c.service.SelectCashmovement(ctx)

	if err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"erro": err.Error()})
		return
	}
	ctx.JSON(http.StatusOK, cashmovement)
}
