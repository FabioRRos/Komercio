package entity

type ProductSubGroup struct {
	ProductSubGroup_id  int    `json:"subgroup_id"`
	ProducSubGroup_name string `json:"subgroup_name"`
	Product_group_id    int    `json:"product_group_id"`
}
