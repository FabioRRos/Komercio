package datastore

import (
	"context"
	"fmt"
	"log"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/jackc/pgx/v5"
)

// Aqui eu crio o ponteiro de pgx.Conn
type CashmovementsDatastore struct {
	Conn *pgx.Conn
}

// Aqui vou abrir a conexão. Eu crio a variavel com a string de conexão
// Depois eu abro com o Connect e passo o context.Background() + string de conexão)
// Por fim, eu trato o erro e se tudo der certo, retorno o ponteiro de datastore
// context é quem gerencia timeout e cancelamentos no GO.
func NewCashmovementsDatastore() *CashmovementsDatastore {
	connStr := "postgresql://postgres:postgres@localhost:5432/komercio?sslmode=disable"

	conn, err := pgx.Connect(context.Background(), connStr)

	if err != nil {

		log.Fatalf("Erro na conexão: %v", err)

	}

	return &CashmovementsDatastore{Conn: conn}
}

// Aqui eu crio a função para fechar.
// se o DATASTORE estiver com alguma coisa que é diferente de nulo, eu chamo o .CLOSE
// POREEEEM o .Close pede um retorno do contexto (pode ser um timeout, algo assim)
// como eu não quero retornar, o TODO é como um
// "Sei que você espera aguma coisa para retornar mas como não tenho nada, toma esse TODO ai
// só pra não dizer que eu não retornei nada"
func (d *CashmovementsDatastore) Close() {
	if d.Conn != nil {
		d.Conn.Close(context.TODO())
	}
}

// Aqui crio uma função que recebe o datastore para abrir a conexão
// depois crio a string com o comando de SQL
// Ignoro o retorno e salvo o "erro"
// ai abro o datastore (conexão), e executo a query.
// o EXEC precisa receber o contexto + query + parâmetros
// Trato possiveis erros e depois, por fim, retorno nulo sem erro (se for o caso)
func (d *CashmovementsDatastore) CreateNewCashmovement(ctx context.Context, cashmovements *entity.Cashmovements) error {
	//Querie melhorada
	query := `insert into cash_movements (
				sale_id,
				movement_type,
				description,
				amount,
				payment_method,
				movement_datetime,
				seller_id
				) VALUES($1 ,$2 ,$3 ,$4 ,$5 ,$6 ,$7 )`

	_, err := d.Conn.Exec(ctx, query,
		cashmovements.SalesId,
		cashmovements.Cashmovementstype,
		cashmovements.Cashmovementsdescription,
		cashmovements.Cashmovementsamount,
		cashmovements.Cashmovementspaymentmethod,
		cashmovements.Cashmovementsdatetime,
		cashmovements.SellerId,
	)

	if err != nil {
		return fmt.Errorf("erro ao inserir movimentação do caixa: %w", err)
	}
	return nil
}

// Essa função é igual à anterior, mas usa tx.Exec() em vez de d.Conn.Exec().
// Assim, ela faz parte da mesma transação do processo de venda.
func (d *CashmovementsDatastore) CreateNewCashmovementTx(ctx context.Context, tx pgx.Tx, cashmovements *entity.Cashmovements) error {
	//Querie melhorada

	query := `insert into cash_movements (
				sale_id,
				movement_type,
				description,
				amount,
				payment_method,
				movement_datetime,
				seller_id
				) VALUES($1 ,$2 ,$3 ,$4 ,$5 ,$6 ,$7 )`

	_, err := tx.Exec(ctx, query,
		cashmovements.SalesId,
		cashmovements.Cashmovementstype,
		cashmovements.Cashmovementsdescription,
		cashmovements.Cashmovementsamount,
		cashmovements.Cashmovementspaymentmethod,
		cashmovements.Cashmovementsdatetime,
		cashmovements.SellerId,
	)

	if err != nil {
		return fmt.Errorf("erro ao inserir movimentação do caixa (Tx): %w", err)
	}
	return nil
}

// Aqui criamos a função select. Lembrando que precisamos passar o datastore
// Crio a query, normal
// Dessa vez não ignoraremos o retorno. Salvaremos em "rows" (do tipo pgx.rows)
// rows salva as linhas retornadas no select
// trato o erro (se houver)
// Crio o Array que é o retorno que eu declarei
// Faço um for do rows.Next (que vai ler linha a linha)
// Crio a variavel (entidade, estrutura OU objeto, para os intimos), salvo os valores retornados nele.
// Se houver erro, eu retorno, caso não. Adiciono ao slice
// Por fim, retorno a entidade e o erro.
func (d *CashmovementsDatastore) SelectallCashmovements(ctx context.Context) ([]*entity.Cashmovements, error) {

	query := `SELECT * FROM cash_movements where DATE(movement_datetime ) = current_date `

	rows, err := d.Conn.Query(ctx, query)

	if err != nil {
		return nil, fmt.Errorf("Erro ao buscar as movimentações do caixa: %w", err)
	}
	defer rows.Close()

	var Cashmovements []*entity.Cashmovements

	for rows.Next() {
		var cm entity.Cashmovements
		err := rows.Scan(
			&cm.Cashmovementsid,
			&cm.SalesId,
			&cm.Cashmovementstype,
			&cm.Cashmovementsdescription,
			&cm.Cashmovementsamount,
			&cm.Cashmovementspaymentmethod,
			&cm.Cashmovementsdatetime,
			&cm.SellerId,
		)

		if err != nil {
			return nil, fmt.Errorf("erro ao ler linha da movimentação: %w", err)
		}
		Cashmovements = append(Cashmovements, &cm)
	}

	return Cashmovements, nil
}
