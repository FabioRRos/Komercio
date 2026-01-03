package main

import (
	"github.com/fabioros/Komercio/controller"
	"github.com/fabioros/Komercio/domain/repository"
	"github.com/fabioros/Komercio/infrastructure/datastore"
	"github.com/fabioros/Komercio/routes"
	service "github.com/fabioros/Komercio/service"
	"github.com/gin-gonic/gin"
)

func main() {

	server := gin.Default()

	server.Use(func(c *gin.Context) {

		token := c.GetHeader("X-Token-Secreto")

		// 3. Se estiver certa, deixa passar para as rotas (Caixa, Produtos, etc)
		c.Next()
	})

	pool := datastore.NewPostgresPool()
	defer pool.Close()

	dbProduct := datastore.NewProductDataStore(pool)

	dbCustomer := datastore.NewCustomerDataStore()
	defer dbCustomer.Close()
	dbEmployee := datastore.NewEmployeesDataStore()
	defer dbEmployee.Close()
	dbSales := datastore.NewSalesDataStore()
	defer dbSales.Close()
	dbproductGroupe := datastore.NewProductGroupDataStore()
	defer dbproductGroupe.Close()
	dbproductSubgroup := datastore.NewProductSubgroupDatastore()
	defer dbproductSubgroup.Close()
	cashmovementDatastore := datastore.NewCashmovementsDatastore()
	defer cashmovementDatastore.Close()
	saleItemsDatastore := datastore.NewSaleItemsDatastore()
	defer saleItemsDatastore.Close()
	reportDatastore := datastore.NewConReportDataStore()
	defer reportDatastore.Close()
	transationDatastore := datastore.NewCustomertransactionDatastore()
	defer transationDatastore.Close()
	caixaDatastore := datastore.NewCaixaDatastore()
	defer caixaDatastore.Close()
	parametros := datastore.NewParametrosDatastore()
	defer parametros.Close()
	formaPagamento := datastore.NewFormaPagamentoDatastore()
	defer formaPagamento.Close()

	//#####################################################
	//Injeção de dependências

	parametrosController := controller.NewParametroController(
		service.NewParametrosService(
			repository.NewParametrosRepository(parametros),
		),
	)

	formaPagamentoController := controller.NewFormaPagamentoController(
		service.NewFormaPagamentoService(
			repository.NewFormaPagamentoRepository(formaPagamento),
		),
	)

	productController := controller.NewProductController(
		service.NewProductService(
			repository.NewProductRepository(dbProduct)),
	)

	customerController := controller.NewCustomerController(
		service.NewCustomerService(
			repository.NewCustomerRepository(dbCustomer)),
	)

	employeeController := controller.NewEmployeerController(
		service.NewEmployeeService(
			repository.NewEmployeesRepository(dbEmployee)),
	)

	salesController := controller.NewSalesController(
		service.NewSalesService(
			repository.NewSalesRepository(dbSales),
			service.NewProductService(
				repository.NewProductRepository(dbProduct)),
		),
	)
	productGroupController := controller.NewProductGroupController(
		service.NewProductGroupService(
			repository.NewProductGroupRepository(dbproductGroupe)),
	)

	productSubgroupController := controller.NewProductSubgroupController(
		service.NewProductSubgroupService(
			repository.NewProductSubgroupRepository(dbproductSubgroup)),
	)
	cashmovementController := controller.NewCashmovementController(
		service.NewCashmovementService(
			repository.NewCashmovementsRepository(cashmovementDatastore),
			repository.NewFormaPagamentoRepository(formaPagamento),
			service.NewFormaPagamentoService(
				repository.NewFormaPagamentoRepository(formaPagamento)),
		),
	)
	salesitensController := controller.NewSaleItemsController(
		service.NewSaleItemsService(
			repository.NewSaleItemsRepository(saleItemsDatastore)),
	)

	caixaController := controller.NewCaixaController(
		service.NewCaixaService(
			repository.NewCaixaRepository(caixaDatastore),
			service.NewCashmovementService(repository.NewCashmovementsRepository(cashmovementDatastore),
				repository.NewFormaPagamentoRepository(formaPagamento),
				service.NewFormaPagamentoService(
					repository.NewFormaPagamentoRepository(formaPagamento)),
			),
		),
	)

	transationController := controller.NewCustomerTransactioController(
		service.NewCustomertransactionService(

			repository.NewCustomertransactionRepository(transationDatastore),

			service.NewCashmovementService(repository.NewCashmovementsRepository(cashmovementDatastore),
				repository.NewFormaPagamentoRepository(formaPagamento),
				service.NewFormaPagamentoService(
					repository.NewFormaPagamentoRepository(formaPagamento))),

			repository.NewCaixaRepository(caixaDatastore),
		),
	)

	fullSaleService := service.NewFullSaleService(
		service.NewSalesService(
			repository.NewSalesRepository(dbSales),
			service.NewProductService(
				repository.NewProductRepository(dbProduct)),
		),
		service.NewSaleItemsService(
			repository.NewSaleItemsRepository(saleItemsDatastore)),
		service.NewCashmovementService(
			repository.NewCashmovementsRepository(cashmovementDatastore),
			repository.NewFormaPagamentoRepository(formaPagamento),
			service.NewFormaPagamentoService(
				repository.NewFormaPagamentoRepository(formaPagamento)),
		),

		service.NewProductService(
			repository.NewProductRepository(dbProduct)),
		service.NewCustomertransactionService(
			repository.NewCustomertransactionRepository(transationDatastore),
			nil,
			nil),
		service.NewCaixaService(
			repository.NewCaixaRepository(caixaDatastore), nil),
		service.NewFormaPagamentoService(
			repository.NewFormaPagamentoRepository(formaPagamento)),
	)

	listProductDescription := service.NewProductDescriptionService(
		service.NewProductService(
			repository.NewProductRepository(dbProduct)),
		service.NewProductGroupService(
			repository.NewProductGroupRepository(dbproductGroupe)),
		service.NewProductSubgroupService(
			repository.NewProductSubgroupRepository(dbproductSubgroup)),
	)

	reportController := controller.NewReportController(
		service.NewSaleReportService(
			repository.NewReportRepository(reportDatastore)),
	)

	cupomCoontroller := controller.NewCupomController(
		service.NewCupomService(service.NewSaleReportService(
			repository.NewReportRepository(reportDatastore)),
			service.NewSaleItemsService(
				repository.NewSaleItemsRepository(saleItemsDatastore)),
		),
	)

	fullSaleController := controller.NewFullSaleController(fullSaleService)
	fullListProductDescription := controller.NewProductDescriptionController(listProductDescription)

	// Rotas
	server.GET("/ping", func(ctx *gin.Context) { ctx.JSON(200, gin.H{"message": "pong"}) })

	routes.RegisterProductRoutes(server, productController)
	routes.RegisterCustomerRoutes(server, customerController)
	routes.RegisterEmployeeRoutes(server, employeeController)
	routes.RegisterSaleRoutes(server, salesController)
	routes.RegisterProductGroupRoutes(server, productGroupController)
	routes.RegisterProductSubgroupRoutes(server, productSubgroupController)
	routes.CashmovementRoutes(server, cashmovementController)
	routes.RegisterSaleItemsRoutes(server, salesitensController)
	routes.RegisterFullSaleRoutes(server, fullSaleController)
	routes.ReportProductRoutes(server, reportController)
	routes.ProductDescriptionList(server, fullListProductDescription)
	routes.CupomRoute(server, cupomCoontroller)
	routes.CustomertransactionControllerRoutes(server, transationController)
	routes.CaixaRoute(server, caixaController)
	routes.ParametrosrRoutes(server, parametrosController)
	routes.RegisterFormaPagamentoRoutes(server, formaPagamentoController)
	//server.Run("0.0.0.0:8000")

	//Minha antiga validação manual

	// Inicia o servidor com HTTPS na porta 8443
	err := server.RunTLS(":8443", "./server.crt", "./server.key")

	if err != nil {
		panic(err) // Se der erro ao subir (ex: senha errada), o programa avisa e para
	}

}
