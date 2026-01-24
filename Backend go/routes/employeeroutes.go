package routes

import (
	"github.com/fabioros/Komercio/controller"
	"github.com/gin-gonic/gin"
)

func RegisterEmployeeRoutes(server *gin.Engine, employeeController *controller.EmployeerController) {
	employeeRoutes := server.Group("/employees")
	{
		employeeRoutes.POST("", employeeController.CreateEmployee)
		employeeRoutes.POST("/loginadmin", employeeController.LoginAdmin)
		employeeRoutes.POST("/login", employeeController.Login)

		employeeRoutes.GET("/names", employeeController.GetActiveEmployeeNames)
		employeeRoutes.POST("/password", employeeController.UpdatePassword)
		employeeRoutes.POST("/name", employeeController.UpdateName)
		employeeRoutes.DELETE("/:login", employeeController.DeactivateEmployee)
	}
}
