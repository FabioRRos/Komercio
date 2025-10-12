package main

import (
	"fmt"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
	"github.com/fabioros/Komercio/infrastructure/datastore"
	"github.com/fabioros/Komercio/service"
)

func main() {
	// 1. Cria a conexão com o banco
	db := datastore.NewProductDataStore()
	defer db.Close()

	// 2. Cria o Repository
	productRepo := repository.NewProductRepository(db)

	// 3. Cria o Service
	productService := service.NewProductService(productRepo)

	// 4. Cria o produto
	produto := entity.Product{
		ProductName:     "Batata Frita",
		ProductPrice:    10,
		ProductCodBar:   "",
		ProductGroup:    "Comida",
		ProductSubGroup: "Fritura",
		ProductStock:    20,
	}

	err := productService.CreateProduct(&produto)
	if err != nil {
		fmt.Println("Erro:", err)
		return
	}

	fmt.Println("Produto cadastrado com sucesso!")
}
