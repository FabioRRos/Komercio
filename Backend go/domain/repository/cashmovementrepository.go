package repository

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/infrastructure/datastore"
	"github.com/jackc/pgx/v5"
)

// Aqui eu crio a interface que é o formato que eu preciso ter para poder utilizar
// Esse contrato é diretamente ligado a como a função feita no datastore funciona.
// Ex:
// Função create ela inicia com o ctx + o que ela recebe
type CashmovementRepository interface {
	CreateCashmovement(ctx context.Context, cashmovements *entity.Cashmovements) (int, error)
	SelectCashmovement(ctx context.Context) ([]*entity.Cashmovements, error)

	// Novo método com suporte à transação
	// Esse método permite que a movimentação de caixa seja criada dentro de uma transação (Tx)
	// junto com a venda e os itens. Assim, se der erro em qualquer etapa, o rollback cancela tudo.
	CreateCashmovementTx(ctx context.Context, tx pgx.Tx, cashmovements *entity.Cashmovements) (int, error)
}

//essa estrutura me garante que eu receba o datastore criado no Datastore
// então toda vez que eu utilizar o data store na vdd estou utilizando o:

// connStr := "postgres://komercio:komercio@localhost:5432/komercio?sslmode=disable"
// conn, err := pgx.Connect(context.Background(), connStr)
type cashmovementrepository struct {
	datastore *datastore.CashmovementsDatastore
}

// Aqui cria uma estrutura que implementa o cashmovementrepository
// o datastore guarda a referência do datastore
// E retorna o ponteiro. Isso garante que todos os pacotes utilizem o mesmo cara.
func NewCashmovementsRepository(ds *datastore.CashmovementsDatastore) CashmovementRepository {
	return &cashmovementrepository{
		datastore: ds,
	}
}

// Aqui eu implemento a criação da movimentação de caixa.
// Isso serve para que meu código cague para a implementação de banco.
// Um bom costume de DDD.
func (r *cashmovementrepository) CreateCashmovement(ctx context.Context, cashmovements *entity.Cashmovements) (int, error) {
	return r.datastore.CreateNewCashmovement(ctx, cashmovements)
}

// Aqui eu implemento a criação de movimentação de caixa dentro de uma transação.
// Isso garante que o caixa seja atualizado junto com a venda e os itens.
// Caso alguma parte falhe, o rollback cancela tudo automaticamente.
func (r *cashmovementrepository) CreateCashmovementTx(ctx context.Context, tx pgx.Tx, cashmovements *entity.Cashmovements) (int, error) {
	return r.datastore.CreateNewCashmovementTx(ctx, tx, cashmovements)
}

// O mesmo de cima, mas agora é o select no banco.
// Essa função retorna todas as movimentações de caixa cadastradas.
func (r *cashmovementrepository) SelectCashmovement(ctx context.Context) ([]*entity.Cashmovements, error) {
	return r.datastore.SelectallCashmovements(ctx)
}
