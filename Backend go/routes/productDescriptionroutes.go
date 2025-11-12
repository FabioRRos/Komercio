package routes

import (
	"github.com/fabioros/Komercio/controller"
	"github.com/gin-gonic/gin"
)

func ProductDescriptionList(server *gin.Engine, productDescriptionList *controller.ProductDescriptionController) {
	productDescription := server.Group("/ProductDescription")
	{
		productDescription.GET("", productDescriptionList.GetAllProductDescription)
	}
}
