package routes

import (
	"github.com/fabioros/Komercio/controller"
	"github.com/gin-gonic/gin"
)

func RegisterCustomerRoutes(server *gin.Engine, customerController *controller.CustomerController) {
	customerRoutes := server.Group("/customer")
	{
		customerRoutes.POST("", customerController.CreateCustomer)
		customerRoutes.GET("", customerController.GetAllCustomers)

		customerRoutes.GET("/name/:name", customerController.GetCustomerByName)
		customerRoutes.GET("/ValidationDocumentNumber/:doc", customerController.GetValidateDocumentNumber)

		customerRoutes.GET("/:id", customerController.GetCustomerById)

		customerRoutes.PUT("/:id", customerController.UpdateCustomer)
		customerRoutes.DELETE("/:id", customerController.DeactivateCustomer)
	}
}
