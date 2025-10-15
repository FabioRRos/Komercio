package controller

import (
	"context"
	"net/http"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/service"
	"github.com/gin-gonic/gin"
)

type EmployeerController struct {
	service service.EmployeeService
}

func NewEmployeerController(employeeService service.EmployeeService) *EmployeerController {
	return &EmployeerController{
		service: employeeService,
	}
}

func (c *EmployeerController) CreateEmployee(ctx *gin.Context) {
	var employee entity.Employees
	if err := ctx.ShouldBindJSON(&employee); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "Parâmetros inválidos"})
		return
	}

	if err := c.service.CreateEmployee(ctx, &employee); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}

	ctx.JSON(http.StatusCreated, gin.H{"message": "Funcionário cadastrado com sucesso"})
}

type LoginRequest struct {
	Login    string `json:"login"`
	Password string `json:"password"`
}

func (c *EmployeerController) Login(ctx *gin.Context) {
	var req LoginRequest
	if err := ctx.ShouldBindJSON(&req); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "Parâmetros inválidos"})
		return
	}

	ok, err := c.service.ValidateLogin(context.Background(), req.Login, req.Password)
	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}

	if !ok {
		ctx.JSON(http.StatusUnauthorized, gin.H{"success": false})
		return
	}

	ctx.JSON(http.StatusOK, gin.H{"success": true})
}

func (c *EmployeerController) GetActiveEmployeeNames(ctx *gin.Context) {
	names, err := c.service.GetActiveEmployeeNames(context.Background())
	if err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	ctx.JSON(http.StatusOK, names)
}

type UpdatePasswordRequest struct {
	Login       string `json:"login"`
	NewPassword string `json:"newpassword"`
}

func (c *EmployeerController) UpdatePassword(ctx *gin.Context) {
	var req UpdatePasswordRequest
	if err := ctx.ShouldBindJSON(&req); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "Parâmetros inválidos"})
		return
	}

	if err := c.service.UpdateEmployeePassword(context.Background(), req.Login, req.NewPassword); err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}

	ctx.JSON(http.StatusOK, gin.H{"message": "Senha atualizada com sucesso"})
}

type UpdateNameRequest struct {
	Login   string `json:"login"`
	NewName string `json:"newname"`
}

func (c *EmployeerController) UpdateName(ctx *gin.Context) {
	var req UpdateNameRequest
	if err := ctx.ShouldBindJSON(&req); err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "Parâmetros inválidos"})
		return
	}

	if err := c.service.UpdateEmployeeName(context.Background(), req.Login, req.NewName); err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}

	ctx.JSON(http.StatusOK, gin.H{"message": "Nome atualizado com sucesso"})
}

func (c *EmployeerController) DeactivateEmployee(ctx *gin.Context) {
	login := ctx.Param("login")
	if login == "" {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "Login inválido"})
		return
	}

	if err := c.service.DeactivateEmployee(context.Background(), login); err != nil {
		ctx.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}

	ctx.JSON(http.StatusOK, gin.H{"message": "Funcionário desativado com sucesso"})
}
