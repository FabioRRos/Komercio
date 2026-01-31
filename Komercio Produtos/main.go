package main

import (
	"context"
	"fmt"
	"log"

	datastore "github.com/fabioros/komercio/DataStore"
	repository "github.com/fabioros/komercio/Repository"
	service "github.com/fabioros/komercio/Service"
	"github.com/jackc/pgx/v5/pgxpool"
)

func main() {
	ctx := context.Background()

	connStrLocal := "postgresql://postgres:postgres@localhost:5432/komercio?sslmode=disable"
	//connStrAzure := "postgresql://postgres:postgres@68.211.112.109:5432/komercio?sslmode=disable"

	poolLocal, err := pgxpool.New(ctx, connStrLocal)
	if err != nil {
		log.Fatal(err)
	}
	defer poolLocal.Close()

	var texto string

	fmt.Println("Gostaria de iniciar?\ns - Sim\nn - Não")
	fmt.Scan(&texto)

	if texto != "s" {
		fmt.Println("Ok")
		return
	}

	// 1️⃣ Datastore
	productDatastore := datastore.NewProductDataStore(poolLocal)

	// 2️⃣ Repository
	productRepo := repository.NewProductRepository(productDatastore)

	// 3️⃣ Service
	productService := service.NewProductService(productRepo)

	// 4️⃣ Executar processo
	if err := productService.SelectAllProducts(ctx); err != nil {
		log.Println("deu ruim:", err)
		return
	}

	fmt.Println("deu bom!")
}
