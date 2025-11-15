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

	dbProduct := datastore.NewProductDataStore()
	defer dbProduct.Close()
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

	//#####################################################
	//Injeção de dependências

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
			repository.NewSalesRepository(dbSales)),
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
			repository.NewCashmovementsRepository(cashmovementDatastore)),
	)
	salesitensController := controller.NewSaleItemsController(
		service.NewSaleItemsService(
			repository.NewSaleItemsRepository(saleItemsDatastore)),
	)

	fullSaleService := service.NewFullSaleService(
		service.NewSalesService(
			repository.NewSalesRepository(dbSales)),
		service.NewSaleItemsService(
			repository.NewSaleItemsRepository(saleItemsDatastore)),
		service.NewCashmovementService(
			repository.NewCashmovementsRepository(cashmovementDatastore)),
		service.NewProductService(
			repository.NewProductRepository(dbProduct)),
		service.NewCashmovementsService(
			repository.NewCustomertransactionRepository(transationDatastore)),
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

	server.Run("0.0.0.0:8000")

	//Minha antiga validação manual

	/*var opcao int

	fmt.Println("Para cadastrar, digite 1")
	fmt.Println("Para consultar, digite 2")
	fmt.Println("Para buscar id, digite 3")
	fmt.Println("Para alterar, digite 4")
	fmt.Println("Para inativar produto, digite 5")
	fmt.Scan(&opcao)

	switch opcao {
	case 1:
		{

			// Simula entrada do Json do produto
			produto := entity.Product{
				ProductName:     "Coca cola zero",
				ProductPrice:    12,
				ProductCodBar:   "102060",
				ProductGroup:    "Bebida",
				ProductSubGroup: "Refrigerante",
				ProductStock:    4,
				ProductStatus:   false,
			}

			//Inicia o processo de cadastro chamando o Service
			err := productService.CreateProduct(&produto)
			if err != nil {
				fmt.Println("Erro:", err)
				return
			}

			fmt.Println("Produto cadastrado com sucesso!")
		}
	case 2:
		{

			//Esse aqui inicia o processo que realiza o select dos produtos
			listaProduto, err := productService.SelectAllProducts()

			if err != nil {
				fmt.Println("Tive dificuldades em buscar a lista")
			}

			for _, k := range listaProduto {
				fmt.Println(k.Id, "-", k.ProductName)
			}
		}
	case 3:
		{
			fmt.Println("Digite o código do produto")
			fmt.Scan(&opcao)

			produto, err := productService.SelectProductById(opcao)

			if err != nil {
				fmt.Println("Não consegui retornar, motivo é:", err)
				return
			}
			fmt.Println(produto)

		}
	case 4:
		{

			fmt.Println("Digite o id do produto que gostaria de alterar")
			fmt.Scan(&opcao)
			produtoChanged, err := productService.SelectProductById(opcao)

			if err != nil {
				fmt.Println("Não consegui retornar, motivo é:", err)
				return
			}
			fmt.Println("Vamos alterar o nome de", produtoChanged.ProductName, " Para:")
			_, err = fmt.Scan(&produtoChanged.ProductName)
			if err != nil {
				fmt.Println("Entrada invalida")
				return
			}

			fmt.Println("Vamos alterar o código de", produtoChanged.ProductCodBar, "Para:")
			_, err = fmt.Scan(&produtoChanged.ProductCodBar)
			if err != nil {
				fmt.Println("Entrada invalida")
				return
			}

			fmt.Println("Vamos alterar o grupo de", produtoChanged.ProductGroup, "Para:")
			_, err = fmt.Scan(&produtoChanged.ProductGroup)
			if err != nil {
				fmt.Println("Entrada invalida")
				return
			}

			fmt.Println("Vamos alterar o subgrupo de", produtoChanged.ProductSubGroup, "Para:")
			_, err = fmt.Scan(&produtoChanged.ProductSubGroup)
			if err != nil {
				fmt.Println("Entrada invalida")
				return
			}

			fmt.Println("Vamos alterar o preço de", produtoChanged.ProductPrice, "Para:")
			_, err = fmt.Scan(&produtoChanged.ProductPrice)
			if err != nil {
				fmt.Println("Entrada invalida")
				return
			}

			fmt.Println("Vamos alterar a quantidade no estoque de", produtoChanged.ProductStock, "Para:")
			_, err = fmt.Scan(&produtoChanged.ProductStock)
			if err != nil {
				fmt.Println("Entrada invalida")
				return
			}

			var status string

			if produtoChanged.ProductStatus == true {
				status = "Ativo"
			} else {
				status = "Inativo"
			}

			fmt.Println("Vamos alterar o status de", status, "\nPara:")
			fmt.Println("1 - Ativo")
			fmt.Println("2 - Innativo")
			fmt.Scan(&opcao)
			if err != nil {
				fmt.Println("Entrada invalida")
				return
			}

			if opcao == 1 {
				produtoChanged.ProductStatus = true
			} else {
				produtoChanged.ProductStatus = false
			}

			produto, err := productService.UpdateProduct(produtoChanged)

			if err != nil {
				fmt.Println("Não consegui retornar, motivo é:", err)
				return
			}
			fmt.Println(produto.ProductName, "Alterado com sucesso!")

		}
	case 5:
		{

			fmt.Println("Digite o ID do produto para inativar")
			_, err := fmt.Scan(&opcao)

			if err != nil {
				fmt.Println("Opção invalida!")
			}

			err = productService.DeactivateProduct(opcao)

			if err != nil {
				fmt.Println("Não consegui inativar, motivo:", err)
			}

			fmt.Print("Produto inativado com sucesso!")

		}
	default:
		fmt.Println("Opcao invalida")
	}
	*/

	server.Run(":8000")

}
