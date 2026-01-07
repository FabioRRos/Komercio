package entity

type DifValue struct {
	Id_Valores  int     `Json:"id_valores"`
	Sale_id     int     `Json:"sale_id"`
	PrecoVenda  float32 `Json:"PrecoVenda"`
	PrecoCompra float32 `Json:"PrecoCompra"`
}
