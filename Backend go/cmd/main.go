package main

import (
	"fmt"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
	"github.com/fabioros/Komercio/infrastructure/datastore"
	"github.com/fabioros/Komercio/service"
)

func main() {
	// Esse cara instancia a conexão do banco
	db := datastore.NewProductDataStore()
	defer db.Close()

	// Esse maluco instancia o repositório
	productRepo := repository.NewProductRepository(db)

	// Cria o service
	productService := service.NewProductService(productRepo)

	var opcao int

	fmt.Println("Para cadastrar, digite 1")
	fmt.Println("Para consultar, digite 2")
	fmt.Scan(&opcao)

	if opcao == 1 {

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
	} else if opcao == 2 {

		//Esse aqui inicia o processo que realiza o select dos produtos
		listaProduto, err := productService.SelectAllProducts()

		if err != nil {
			fmt.Println("Tive dificuldades em buscar a lista")
		}

		for _, k := range listaProduto {
			fmt.Println(k.Id, "-", k.ProductName)
		}
	} else {
		fmt.Println("Opcao invalida")
	}
}
