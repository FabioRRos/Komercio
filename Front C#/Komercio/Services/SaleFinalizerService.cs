using Komercio.ApplicationLayer;
using Komercio.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        private HttpClient _httpClient;
        // private readonly CupomService _cupomService;
        //  private readonly ParametrosApp _parametrosApp;
        internal readonly string key = ConfigurationManager.AppSettings["ChavePrivada"];

        /// <summary>
        /// Esse cara aqui ele recebe os dados da venda, faz a validação e processa a venda.
        /// </summary>
       // /// <param name="itensVenda"></param>
        /// <param name="cupomService"></param>
        /// <param name="baseUrl"></param>
        /// <param name="parametrosApp"></param>
        public SaleFinalizerService(
            //     BindingList<SalesItensDTO> itensVenda,
            //CupomService cupomService,
            string baseUrl
            //ParametrosApp parametrosApp
            )
        {

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("X-Token-Secreto", $"{key}");


            //_cupomService = cupomService;
            //  _parametrosApp = parametrosApp;

        }


        /*

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

                public async Task<string> MontarVenda(
            SalesDTO venda,                  // agora recebe a venda criada no form
            BindingList<SalesItensDTO> itens,
            string metodoPagamento,
            int sellerId,
            List<FormaPagamentoDTO> formaPagamento)
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
                    SaleAggregateDTO vendaAggregate = new SaleAggregateDTO(salesHeader, itensLista, cash, formaPagamento);
                    string cupomForPrint = "";
                    bool retorno = false;
                    try
                    {
                    //cria o cupom
                     (retorno, cupomForPrint) = await CreateSaleAsync(vendaAggregate);

                    }
                    catch
                    {
                        MessageBox.Show("Não consegui criar o cupom - SALE FINALIZER SERVICE");
                    }

                    // Geração do JSON e salvamento para log
                     try
                     {
                         string conteudoJson = JsonConvert.SerializeObject(vendaAggregate, Formatting.Indented);

                        string diretorio = @"C:\Komercio\log\Json_Venda";
                        Directory.CreateDirectory(diretorio);

                        string nomeArquivo = "JSON_RES_VENDA_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".json";

                        string caminhoCompleto = Path.Combine(diretorio, nomeArquivo);

                        // desabilitar esse
                       var habilitaJson =  await VerificaStatusParametro(9);

                        if (habilitaJson)
                        {
                         File.WriteAllText(caminhoCompleto, conteudoJson, Encoding.UTF8);
                            MessageBox.Show("Arquivo salvo com sucesso!\n\n" + caminhoCompleto);
                        }


                     }
                     catch (Exception ex)
                     {
                         MessageBox.Show(ex.Message);
                     }

                    return cupomForPrint;

                }

                private async Task<bool> VerificaStatusParametro(int id)
                {
                    var status = await _parametrosApp.ConsultaStatusParametro(id);

                    return status;
                }



                public async Task<(bool Success, string CupomText)> CreateSaleAsync(SaleAggregateDTO saleAggregateDTO)
                {
                    var json = JsonConvert.SerializeObject(saleAggregateDTO);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PostAsync("sales/fullsale", content);

                    if (!response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Não foi possível salvar a venda. tente novamente");
                            return (false,"");
                        }



                    var body = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<SaleResponseDTO>(body);

                    int saleId = result.SaleId;


                    var cupomRetorno = await _cupomService.CupomSale(saleId);
                    string cupomForPrint = "";
                    try
                    {

                    cupomForPrint = _cupomService.GenerateReceiptText(cupomRetorno);
                    }
                    catch
                    {
                        MessageBox.Show("Não consegui gerar a variavel para impressão saleFinalizer | Função create");
                        return (false, "");
                    }

                    return (true, cupomForPrint);
                }
        */
        public class SaleResponseDTO
        {
            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("sale_id")]
            public int SaleId { get; set; }
        }

       


        ///////////////////////////////////////////// NOVAS REGRAS /////////////////////////////////////////
        
        
        /// <summary>
        /// Função para criar uma nova venda. Envie o obj contendo os dados da venda
        /// CREATE
        /// </summary>
        /// <param name="saleAggregateDTO"></param>
        /// <returns></returns>
        public async Task<(bool,int,string,int)> NovaVendaService(SaleAggregateDTO saleAggregateDTO)
        {
            var json = JsonConvert.SerializeObject(saleAggregateDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("sales/fullsale", content);

            //Agora vou pegar o status e a mensagem
            int statusCode = (int)response.StatusCode;
            bool success = response.IsSuccessStatusCode;
            string response_content = await response.Content.ReadAsStringAsync();
            string responseCompleto = $"{statusCode} - {response_content}";

            //o corpo da chamada
          //  var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SaleResponseDTO>(response_content);

            int idDaVenda = result.SaleId;

            return (success,statusCode,responseCompleto, idDaVenda);
        }


        /// <summary>
        /// Deleta a venda por completo em todas as tabelas. Basta passar o Id.
        /// DELET
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<(bool, int, string)> DeletarVendaService(int id)
        {
            var response = await _httpClient.DeleteAsync($"sales/deletesalecascade/{id}");

            var status_code = (int)response.StatusCode;
            var sucesso = response.IsSuccessStatusCode;
            var response_content = await response.Content.ReadAsStringAsync();

            string responseCompleto = $"{status_code} - {response_content}";

            return (sucesso, status_code, responseCompleto);

        }


    }

}


