package controller

import (
	"net/http"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/service"
	"github.com/gin-gonic/gin"
)

type ParametrosController struct {
	service service.ParametrosService
}

func NewParametroController(prametroService service.ParametrosService) *ParametrosController {

	return &ParametrosController{
		service: prametroService,
	}
}

func (c *ParametrosController) GetAllParametros(ctx *gin.Context) {
	parametros, err := c.service.GetAllParametros(ctx)

	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}

	ctx.JSON(200, parametros)
}

func (c *ParametrosController) UpdateParametros(ctx *gin.Context) {
	var parametros []*entity.Parametros

	if err := ctx.ShouldBindJSON(&parametros); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}

	updated, err := c.service.UpdateParametros(
		ctx.Request.Context(),
		parametros,
	)

	if err != nil {

		ctx.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return

	}

	ctx.JSON(http.StatusOK, updated)
}
