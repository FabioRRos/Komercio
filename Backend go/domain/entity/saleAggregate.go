package entity

import (
	"fmt"
	"math"
)

// SaleAggregate é o cara onde vou salvar os dados da venda no json
type SaleAggregate struct {
	Sale         Sales         `json:"sale"`
	Items        []SalesItens  `json:"items"`
	CashMovement Cashmovements `json:"cash_movement"`
}

// Função para validar cálculos da venda
func Valedatecalcofsale(aggregate *SaleAggregate) error {
	//aqui defino uma constante par marge de erro

	const epsilon = 0.001

	// primeiro preciso saber se os calculos dos produtos estão corretos.
	result := aggregate.Sale.TotalAmount - aggregate.Sale.DiscountAmount
	finalAmount := aggregate.Sale.FinalAmount

	if math.Abs(float64(result-finalAmount)) > epsilon {
		return fmt.Errorf("total final %.2f não bate com total %.2f - desconto %.2f", aggregate.Sale.FinalAmount, aggregate.Sale.TotalAmount, aggregate.Sale.DiscountAmount)
	}

	//return fmt.Errorf("Passou1")

	// Agora vou validar se os itens que estão dentro do array estão corretos
	totalItems := float32(0)
	for _, item := range aggregate.Items {

		calculatedTotal := round2(item.UnitPrice * float32(item.Quantity))

		if math.Abs(float64(calculatedTotal-item.Total)) > epsilon {
			return fmt.Errorf("total do item '%s' está incorreto: esperado %.2f, obtido %.2f", item.ProductName, calculatedTotal, item.Total)
		}
		totalItems += item.Total
	}
	//return fmt.Errorf("Passou2")

	// agora vou validar se o total que recebo dos itens bate com o total da venda
	if math.Abs(float64(totalItems-aggregate.Sale.TotalAmount)) > epsilon {
		return fmt.Errorf("total dos itens %.2f não bate com total da venda %.2f", totalItems, aggregate.Sale.TotalAmount)
	}

	//return fmt.Errorf("Passou3")

	// agora vou ver se o valor enviado para movimentação faz sentido.

	if math.Abs(float64(aggregate.CashMovement.Cashmovementsamount-aggregate.Sale.FinalAmount)) > epsilon {
		return fmt.Errorf("valor da movimentação de caixa %.2f não bate com o valor final da venda %.2f", aggregate.CashMovement.Cashmovementsamount, aggregate.Sale.FinalAmount)
	}

	//return fmt.Errorf("Passou4")

	// agora verficiar se o vendedor é o mesmo
	if aggregate.Sale.SellerId != aggregate.CashMovement.SellerId {
		return fmt.Errorf("o id do vendedor da venda (%d) não bate com o id do vendedor da movimentação de caixa (%d)", aggregate.Sale.SellerId, aggregate.CashMovement.SellerId)
	}

	//return fmt.Errorf("Passou5")

	return nil
}

// Função auxiliar para arredondar em duas casas decimais
func round2(val float32) float32 {
	return float32(math.Round(float64(val)*100) / 100)
}
