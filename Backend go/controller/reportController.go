package controller

import (
	"net/http"
	"strconv"

	"github.com/fabioros/Komercio/service"
	"github.com/gin-gonic/gin"
)

type ReportController struct {
	report service.ReportService
}

func NewReportController(reportservice service.ReportService) *ReportController {
	return &ReportController{
		report: reportservice,
	}
}

// GET
func (c *ReportController) SelectSaleReport(ctx *gin.Context) {

	saleReport, err := c.report.SelectSaleReport(ctx)

	if err != nil {
		ctx.JSON(500, gin.H{"error": err.Error()})
		return
	}

	ctx.JSON(200, saleReport)
}

// GET by id
func (c *ReportController) SelectSaleReportById(ctx *gin.Context) {
	idParam := ctx.Param("id")
	id, err := strconv.Atoi(idParam)

	if err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": "ID inválido"})
		return
	}

	saleReport, err := c.report.SelectSalesReportbyId(ctx, id)

	if err != nil {
		ctx.JSON(500, gin.H{"error": err.Error()})
		return
	}

	ctx.JSON(200, saleReport)
}
