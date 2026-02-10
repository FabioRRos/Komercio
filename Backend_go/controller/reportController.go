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

//get relatório de custos V2

func (c *ReportController) RelatorioLucros(ctx *gin.Context) {
	reportLucros, err := c.report.ReportSaleCoust(ctx)

	if err != nil {
		ctx.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
	}

	ctx.JSON(200, reportLucros)

}

// get margem
// func (c *ReportController) SelectMargemLucroVendas(ctx *gin.Context) {
// 	salereportMargem, err := c.report.SelectMargemLucroVendas(ctx)

// 	if err != nil {
// 		ctx.JSON(500, gin.H{"error": err.Error()})
// 		return
// 	}

// 	ctx.JSON(200, salereportMargem)

// }

// GET
func (c *ReportController) GetForHome(ctx *gin.Context) {

	saleReport, err := c.report.Homepage(ctx)

	if err != nil {
		ctx.JSON(500, gin.H{"error": err.Error()})
		return
	}

	ctx.JSON(200, saleReport)
}
