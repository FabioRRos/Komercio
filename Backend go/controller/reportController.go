package controller

import (
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
