package main

import (
	"context"
	"log"

	"github.com/fabioros/Komercio/controller"
	"github.com/fabioros/Komercio/domain/repository"
	"github.com/fabioros/Komercio/infrastructure/clients"
	"github.com/fabioros/Komercio/infrastructure/datastore"
	"github.com/fabioros/Komercio/routes"
	service "github.com/fabioros/Komercio/service"
	"github.com/gin-gonic/gin"
	"github.com/jackc/pgx/v5/pgxpool"
)

func main() {

	server := gin.Default()

	server.Use(func(c *gin.Context) {

		token := c.GetHeader("X-Token-Secreto")

		if token != "B@tata123!SegredoMaximo" {

			c.AbortWithStatusJSON(401, gin.H{"error": "Acesso negado: Token inválido ou ausente"})
			return
		}

		// 3. Se estiver certa, deixa passar para as rotas (Caixa, Produtos, etc)
		c.Next()
	})

	connStr := "postgresql://postgres:postgres@localhost:5432/komercio?sslmode=disable"
	urlEstoque := "http://localhost:7176"
	ctx := context.Background()

	pool, err := pgxpool.New(ctx, connStr)
	if err != nil {
		log.Fatal(err)
	}
	defer pool.Close()

	dbProduct := datastore.NewProductDataStore(pool)

	dbCustomer := datastore.NewCustomerDataStore(pool)

	dbEmployee := datastore.NewEmployeesDataStore(pool)

	dbSales := datastore.NewSalesDataStore(pool)

	dbproductGroupe := datastore.NewProductGroupDataStore(pool)

	dbproductSubgroup := datastore.NewProductSubgroupDatastore(pool)

	cashmovementDatastore := datastore.NewCashmovementsDatastore(pool)

	saleItemsDatastore := datastore.NewSaleItemsDatastore(pool)

	reportDatastore := datastore.NewConReportDataStore(pool)

	transationDatastore := datastore.NewCustomertransactionDatastore(pool)

	caixaDatastore := datastore.NewCaixaDatastore(pool)

	parametros := datastore.NewParametrosDatastore(pool)

	formaPagamento := datastore.NewFormaPagamentoDatastore(pool)

	precocompra := datastore.NewPrecoCompraDatastore(pool)

	//clientedb := clients.NewListaCompraAPIClient(urlEstoque)

	//#####################################################
	//Injeção de dependências
	/// ACESSO AS APIS
	estoqueapiController := controller.NewListaCompraController(
		service.NewListaCompraAPIService(
			repository.NewLListaCompraAPIRepository(
				clients.NewListaCompraAPIClient(urlEstoque))))

	listaProdutosCompra := controller.NewItensListaCompraController(
		service.NewItensListaCompraRepository(
			repository.NewItensListaCompraRepository(
				clients.NewItensListaCompraClient(urlEstoque))))

	/// ACESSO AO BANCO

	parametrosController := controller.NewParametroController(
		service.NewParametrosService(
			repository.NewParametrosRepository(parametros),
		),
	)

	precocompraService := service.NewPrecoCompraService(
		repository.NewPrecoCompraRepository(precocompra),
	)

	formaPagamentoController := controller.NewFormaPagamentoController(
		service.NewFormaPagamentoService(
			repository.NewFormaPagamentoRepository(formaPagamento),
		),
	)

	productController := controller.NewProductController(
		service.NewProductService(
			repository.NewProductRepository(dbProduct), precocompraService),
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
				repository.NewProductRepository(dbProduct), precocompraService),
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
				repository.NewProductRepository(dbProduct), precocompraService),
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
			repository.NewProductRepository(dbProduct), precocompraService),
		service.NewCustomertransactionService(
			repository.NewCustomertransactionRepository(transationDatastore),
			nil,
			nil),
		service.NewCaixaService(
			repository.NewCaixaRepository(caixaDatastore), nil),
		service.NewFormaPagamentoService(
			repository.NewFormaPagamentoRepository(formaPagamento)), precocompraService,
	)

	listProductDescription := service.NewProductDescriptionService(
		service.NewProductService(
			repository.NewProductRepository(dbProduct), precocompraService),
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
	routes.ListaCompraAPIRoutes(server, estoqueapiController)
	routes.ItensListaCompraRoutes(server, listaProdutosCompra)
	//server.Run("0.0.0.0:8000")

	//Minha antiga validação manual

	// Inicia o servidor com HTTPS na porta 8443
	err = server.RunTLS(":8443", "./server.crt", "./server.key")

	if err != nil {
		panic(err) // Se der erro ao subir (ex: senha errada), o programa avisa e para
	}

}
