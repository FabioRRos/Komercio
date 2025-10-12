package service

import "github.com/fabioros/Komercio/domain/model/entity"

type ProductService interface {
	CreateProduct(product *entity.Product) error
}
