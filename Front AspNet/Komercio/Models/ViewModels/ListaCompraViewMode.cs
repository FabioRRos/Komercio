using Komercio.Models.DTO;
using System.Collections.Generic;

namespace Komercio.ViewModels
{
    public class ListaCompraViewModel
    {
        // Estado original vindo do banco (para comparação)
        private bool? _statusOriginal;

        // Estado atual modificado na tela
        private bool? _statusAtual;

        /// <summary>
        /// Armazena os cabeçalhos das listas (usado para montar as abas/guias)
        /// </summary>
        public List<ListaComprasDTO> ListasParaAbas { get; set; } = new List<ListaComprasDTO>();

        /// <summary>
        /// Armazena os itens da lista que foi selecionada para o grid
        /// </summary>
        public List<ItemListaCompraDTO> ItensParaGrid { get; set; } = new List<ItemListaCompraDTO>();

        /// <summary>
        /// Mantém o ID da lista ativa para destacar a aba selecionada na interface
        /// </summary>
        public int IdListaAtiva { get; set; }


        public string NomeListaSelecionada { get; set; }


        /// <summary>
        /// Status da lista selecionada: null (pendente), true (venda feita), false (cancelada)
        /// </summary>
        public bool? StatusLista
        {
            get => _statusAtual;
            set => _statusAtual = value;
        }

        /// <summary>
        /// Lógica para habilitar o botão de salvar: 
        /// Só retorna true se o status atual for diferente do que veio originalmente do backend.
        /// </summary>
        public bool PodeSalvar => _statusAtual != _statusOriginal;

        /// <summary>
        /// Chamado pelo Presenter ao carregar os dados para fixar o estado inicial
        /// </summary>
        public void CarregarStatusInicial(bool? status)
        {
            _statusOriginal = status;
            _statusAtual = status;
        }
    }
}