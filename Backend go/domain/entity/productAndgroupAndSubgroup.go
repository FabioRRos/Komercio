package entity

type ProductDescription struct {
	Product  []Product         `Json: "Product`
	Group    []ProductGroup    `Json:"group"`
	Subgroup []ProductSubGroup `Json "subgroup"`
}
