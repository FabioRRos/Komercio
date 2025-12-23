package controller

import (
	"net/http"
	"strconv"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/service"
	"github.com/gin-gonic/gin"
)

type CustomerController struct {
	service service.CustomerService
}

func NewCustomerController(customerService service.CustomerService) *CustomerController {
	return &CustomerController{
		service: customerService,
	}
}

//Post /customer

func (c *CustomerController) CreateCustomer(ctx *gin.Context) {
	var customer entity.Customer

	if err := ctx.ShouldBindJSON(&customer); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "Parâmetros inválidos"})
		return
	}

	if err := c.service.CreateCustomer(ctx, &customer); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}

	ctx.JSON(http.StatusCreated, gin.H{"Message": "Cliente cadastrado com sucesso"})
}

// GET /customers
func (c *CustomerController) GetAllCustomers(ctx *gin.Context) {
	customers, err := c.service.SelectAllCustomers(ctx)
	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	ctx.JSON(http.StatusOK, customers)
}

// GET /customers/:id
func (c *CustomerController) GetCustomerById(ctx *gin.Context) {
	idParam := ctx.Param("id")
	id, err := strconv.Atoi(idParam)
	if err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "ID inválido"})
		return
	}

	customer, err := c.service.SelectCustomerById(ctx, id)
	if err != nil {
		ctx.JSON(http.StatusNotFound, gin.H{"error": err.Error()})
		return
	}
	ctx.JSON(http.StatusOK, customer)
}

// GET / Customer / name

func (c *CustomerController) GetCustomerByName(ctx *gin.Context) {
	name := ctx.Param("name")

	if name == "" {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "Parâmetro 'name' é obrigatório"})
		return
	}

	customer, err := c.service.SelectCustomerByName(ctx, name)
	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}

	if customer == nil {
		ctx.JSON(http.StatusNotFound, gin.H{"message": "Cliente não encontrado"})
		return
	}

	ctx.JSON(http.StatusOK, customer)
}

// GET / ValidationDocumentNumber / doc

func (c *CustomerController) GetValidateDocumentNumber(ctx *gin.Context) {
	doc := ctx.Param("doc")

	if len(doc) != 11 && len(doc) != 14 {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "Parâmetros inválidos"})
		return

	}

	customer, err := c.service.ValidateDocument(ctx, doc)

	if err != nil {
		ctx.JSON(http.StatusNotFound, gin.H{"message": "Cliente não encontrado"})
		return
	}

	ctx.JSON(http.StatusOK, customer)

}

// PUT /customers/:id
func (c *CustomerController) UpdateCustomer(ctx *gin.Context) {
	var customer entity.Customer
	if err := ctx.ShouldBindJSON(&customer); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "Parâmetros inválidos"})
		return
	}

	idParam := ctx.Param("id")
	id, err := strconv.Atoi(idParam)
	if err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "ID inválido"})
		return
	}

	customer.CustomerID = id

	updated, err := c.service.UpdateCustomer(ctx, &customer)
	if err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}

	ctx.JSON(http.StatusOK, updated)
}

// DELETE /customers/:id
// Na verdade ele não deleta o cliente, apenas desativa (CustomerStatus = false)
func (c *CustomerController) DeactivateCustomer(ctx *gin.Context) {
	idParam := ctx.Param("id")
	id, err := strconv.Atoi(idParam)
	if err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "ID inválido"})
		return
	}

	if err := c.service.DeactivateCustomer(ctx, id); err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}

	ctx.JSON(http.StatusOK, gin.H{"message": "Cliente desativado com sucesso"})
}
