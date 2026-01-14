package controller

import (
	"fmt"
	"strconv"
	"time"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/service"
	"github.com/gin-gonic/gin"
)

type CustomerTransactionController struct {
	customertransaction service.CustomertransactionService
}

func NewCustomerTransactioController(customerTransaction service.CustomertransactionService) *CustomerTransactionController {
	return &CustomerTransactionController{
		customertransaction: customerTransaction}
}

//get

func (c *CustomerTransactionController) GETTransaction(ctx *gin.Context) {
	customerTransactions, err := c.customertransaction.GETTransaction(ctx)

	if err != nil {
		ctx.JSON(500, gin.H{"error": err.Error()})
		return
	}
	ctx.JSON(200, customerTransactions)
}

// GET BY ID
func (c *CustomerTransactionController) GETTransactionById(ctx *gin.Context) {
	idParam := ctx.Param(("id"))
	id, err := strconv.Atoi(idParam)

	if err != nil {
		ctx.JSON(400, gin.H{"error": "ID inválido"})
		return
	}

	customerTransactions, err := c.customertransaction.GETTransactionById(ctx, id)

	if err != nil {
		ctx.JSON(500, gin.H{"error": err.Error()})
		return
	}
	ctx.JSON(200, customerTransactions)
}

//PUT

func (c *CustomerTransactionController) CreateTransaction(ctx *gin.Context) {
	var payment entity.CustomerTransaction
	payment.Transaction_date = time.Time{}

	if err := ctx.ShouldBindJSON(&payment); err != nil {
		ctx.JSON(400, gin.H{"error": "Parâmetros inválidos"})
		return
	}

	if err := c.customertransaction.CreateTransaction(ctx, &payment); err != nil {
		errReturnet := fmt.Errorf("Estou com dificuldades de salvar. Tente novamente mais tarde. %w", err)
		ctx.JSON(500, gin.H{"error": errReturnet.Error()})
		return
	}

	ctx.JSON(200, "Sucesso!")

}
