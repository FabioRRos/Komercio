using Komercio.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Komercio.Models.CashovementsDTO;
using static Komercio.Models.SalesDTO;

namespace Komercio.Services
{
    public class SaleFinalizerService
    {
        private readonly HttpClient _httpClient;

   

        private readonly CustomerService _customerService;
        private readonly SaleService _saleService;

        //Fabio do futuro, aqui eu faço a injeção da URL da API
        // Se o sabeFinalizerService vier com uma variavel nula, eu atribuo a que declarei acima
        //Se não for nula, eu utilizo a que recebi.
        //Parecido com o que fiz nos formulários mas aqui eu vou receber do antigo formulário, então dou prioridade a ela
        public SaleFinalizerService(CustomerService customerService, SaleService saleService, BindingList<SalesItensDTO> itensVenda, HttpClient baseUrl)
        {
            _customerService = customerService;
            _saleService = saleService;
            _httpClient = baseUrl;


        }


            // Vou receber a lista de itens da compra. Se a lista estiver Ok, retorno vazio. Se não retorno erro

         public string ValidarItens(BindingList<SalesItensDTO> itens) {

           

            if (itens == null || itens.Count == 0)
            {
                return "Não há itens na venda.";
            }

            for (int i = 0; i < itens.Count; i++)
            {
                SalesItensDTO it = itens[i];
                if (it == null)
                {
                    return "Item nulo na lista.";
                }
                if (it.Quantity <= 0)
                {
                    return "Quantidade inválida em um dos itens.";
                }
                if (it.UnitPrice < 0)
                {
                    return "Preço unitário inválido em um dos itens.";
                }
                if (it.Total < 0)
                {
                    return "Soma dos produtos não bate com o total";
                }

            }

          
            return string.Empty;
        }


        // Realizo a soma dos itens da lista de carrinho.
        // Poderia ter feito no andar de cima? Sim! Mas quero metodos separados para poder reutilizar se necessário no futuro.
        public float CalcTotal(BindingList<SalesItensDTO> itens)
        {
            float soma = 0f;

            if (itens == null) return 0f;

            for (int i = 0; i < itens.Count; i++)
            {
                SalesItensDTO it = itens[i];
                if (it != null)
                {
                    soma = soma + it.Total; // Total já deve ser UnitPrice * Quantity
                }
            }

            return soma;
        }



        //Agora vou montar o SaleFInalizerService para depois gerar o JSON

        public void MontarVenda(
    SalesDTO venda,                  // agora recebe a venda criada no form
    BindingList<SalesItensDTO> itens,
    string metodoPagamento,
    int sellerId)
        {
            // Validação nos metodos acima.
            string erro = ValidarItens(itens);
            if (erro != string.Empty)
            {
                throw new Exception(erro);
            }

            float total = venda.FinalAmount;


            venda.SellerId = sellerId;
            // Usa o objeto de venda vindo do form, não cria novo vazio
            SalesDTO salesHeader = venda;
            

            CashovementsDTO cash;
            cash = new CashovementsDTO();

            cash.movementType = "Entrada";
            cash.amount = total;
            cash.paymentMethod = metodoPagamento;
            cash.movementDatetime = DateTime.Now;
            cash.sellerId = sellerId;


            //salesHeader.SaleId = sellerId;


            // Convertendo o BindingList para List
            List <SalesItensDTO> itensLista = new List<SalesItensDTO>();
            for (int i = 0; i < itens.Count; i++)
            {
                itensLista.Add(itens[i]);
            }

            //  Agora o aggregate recebe o cabeçalho real da venda
            SaleAggregateDTO vendaAggregate = new SaleAggregateDTO(salesHeader, itensLista, cash);

            var retorno = CreateSaleAsync(vendaAggregate);

            // Geração do JSON e salvamento
             try
             {
                 string conteudoJson = JsonConvert.SerializeObject(vendaAggregate, Formatting.Indented);

                 string diretorio = @"C:\Projeto Komercial\Komercio\Arquivos de teste\JSON gerado";
                 Directory.CreateDirectory(diretorio);

                 string nomeArquivo = "JSON_RES_VENDA_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".json";

                 string caminhoCompleto = Path.Combine(diretorio, nomeArquivo);

                 File.WriteAllText(caminhoCompleto, conteudoJson, Encoding.UTF8);

                // MessageBox.Show("Arquivo salvo com sucesso!\n\n" + caminhoCompleto);
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }



        }



        public async Task<bool> CreateSaleAsync(SaleAggregateDTO saleAggregateDTO)
        {
            var json = JsonConvert.SerializeObject(saleAggregateDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("sales/fullsale", content);

            if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Não foi possível salvar a venda. tente novamente");
                    return true;
                }



            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SaleResponseDTO>(body);

            int saleId = result.SaleId;

            CupomService cupom = new CupomService();

            var cupomRetorno = await cupom.CupomSale(saleId);

            cupom.GenerateReceiptText(cupomRetorno);


            MessageBox.Show("Venda registrada com sucesso!", "SUCESSO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
        public class SaleResponseDTO
        {
            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("sale_id")]
            public int SaleId { get; set; }
        }

    }

}


