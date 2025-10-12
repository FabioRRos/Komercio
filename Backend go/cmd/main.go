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

	// Simula entrada do Json do produto
	produto := entity.Product{
		ProductName:     "Pastel",
		ProductPrice:    15,
		ProductCodBar:   "102030",
		ProductGroup:    "Comida",
		ProductSubGroup: "Fritura",
		ProductStock:    20,
	}

	//Inicia o processo de cadastro chamando o Service
	err := productService.CreateProduct(&produto)
	if err != nil {
		fmt.Println("Erro:", err)
		return
	}

	fmt.Println("Produto cadastrado com sucesso!")

	//Esse aqui inicia o processo que realiza o select dos produtos
	listaProduto, err := productService.SelectAllProducts()

	if err != nil {
		fmt.Println("Tive dificuldades em buscar a lista")
	}

	for _, k := range listaProduto {
		fmt.Println(k.Id, "-", k.ProductName)
	}
}
