package controller

import (
	"net/http"
	"strconv"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/service"
	"github.com/gin-gonic/gin"
)

type FormaPagamentoController struct {
	service service.FormaPagamentoService
}

func NewFormaPagamentoController(formaPagamentoService service.FormaPagamentoService) *FormaPagamentoController {
	return &FormaPagamentoController{
		service: formaPagamentoService,
	}
}

//Create forma de pagamento

func (c *FormaPagamentoController) CreateFormaPagamento(ctx *gin.Context) {
	var formaPagamentoInput entity.FormaPagamento
	if err := ctx.ShouldBindJSON(&formaPagamentoInput); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}

	err := c.service.CreateFormaPagamento(ctx, &formaPagamentoInput)
	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	ctx.JSON(http.StatusCreated, gin.H{"message": "Forma de pagamento criada com sucesso"})
}

// Read formas de pagamento
func (c *FormaPagamentoController) GetAllFormaPagamento(ctx *gin.Context) {
	formasPagamento, err := c.service.ReadAllFormaPagamento(ctx)
	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	ctx.JSON(http.StatusOK, formasPagamento)
}

// read forma de pagamento com id

func (c *FormaPagamentoController) GetFormaPagamentoById(ctx *gin.Context) {
	id := ctx.Param("id")

	idParam, err := strconv.Atoi(id)

	formasPagamento, err := c.service.ReadFormaPagamentoById(ctx, idParam)
	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	ctx.JSON(http.StatusOK, formasPagamento)
}

// update forma de pagamento
func (c *FormaPagamentoController) UpdateFormaPagamento(ctx *gin.Context) {
	var formaPagamentoInput entity.FormaPagamento
	if err := ctx.ShouldBindJSON(&formaPagamentoInput); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}
	updatedFormaPagamento, err := c.service.UpdateFormaPagamento(ctx, &formaPagamentoInput)
	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	ctx.JSON(http.StatusOK, updatedFormaPagamento)
}
