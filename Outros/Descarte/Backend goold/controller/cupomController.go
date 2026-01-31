package controller

import (
	"strconv"

	"github.com/fabioros/Komercio/service"
	"github.com/gin-gonic/gin"
)

type CupomController struct {
	service service.CupomService
}

func NewCupomController(cupomService service.CupomService) *CupomController {
	return &CupomController{
		service: cupomService,
	}
}

//get /cupom/id

func (c *CupomController) GetCupomById(ctx *gin.Context) {
	idParam := ctx.Param("id")
	id, err := strconv.Atoi(idParam)

	if err != nil {
		ctx.JSON(500, gin.H{"error": err.Error()})
		return
	}

	cupom, err := c.service.GetCupom(ctx, id)

	if err != nil {
		ctx.JSON(500, gin.H{"error": err.Error()})
		return
	}

	ctx.JSON(200, cupom)

}
