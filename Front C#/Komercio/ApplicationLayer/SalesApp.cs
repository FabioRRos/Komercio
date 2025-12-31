using Komercio.ApplicationLayer;
using Komercio.Models;
using Komercio.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Komercio.Services.SaleFinalizerService;

public class SalesApp
{
    private readonly CupomService _cupomService;
    private readonly ParametrosApp _parametrosApp;
    private readonly SaleFinalizerService _saleFinalizerService;

    internal readonly string key = ConfigurationManager.AppSettings["ChavePrivada"];

    //Lista retornada após realizar a venda.
    private int saleId;



    public SalesApp(CustomerService customerService,
        CupomService cupomService,
        string baseUrl,
        ParametrosApp parametrosApp,
        SaleFinalizerService saleFinalizerService)
    {
        _cupomService = cupomService;
        _parametrosApp = parametrosApp;
        _saleFinalizerService = saleFinalizerService;
    }

    //// Regras do negócio.


    /// <summary>
    /// Recebe os itens da venda e valida se está Ok.
    /// </summary>
    /// <param name="itens"></param>
    /// <returns></returns>
    public string ValidarItens(BindingList<SalesItensDTO> itens)
    {
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

    /// <summary>
    /// Calcula o total da venda.
    /// </summary>
    /// <param name="itens"></param>
    /// <returns></returns>
    public float CalcTotal(BindingList<SalesItensDTO> itens)
    {
        float soma = 0f;

        if (itens == null) return 0f;

        for (int i = 0; i < itens.Count; i++)
        {
            SalesItensDTO it = itens[i];
            if (it != null)
            {
                soma = soma + it.Total; // Total já deve ser UnitPrice * Quantidade
            }
        }

        return soma;
    }

    /// <summary>
    /// Aqui vou montar a venda toda. Vou chamar metodos já utilizados nesta classe.
    /// </summary>
    /// <param name="venda"></param>
    /// <param name="itens"></param>
    /// <param name="metodoPagamento"></param>
    /// <param name="sellerId"></param>
    /// <param name="formaPagamento"></param>
    /// <returns></returns>
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


        // Convertendo o BindingList para List
        List<SalesItensDTO> itensLista = new List<SalesItensDTO>();
        for (int i = 0; i < itens.Count; i++)
        {
            itensLista.Add(itens[i]);
        }


        //  Agora o aggregate recebe o cabeçalho real da venda
        SaleAggregateDTO vendaAggregate = new SaleAggregateDTO(salesHeader, itensLista, cash, formaPagamento);
        string cupomForPrint = "";
        bool retorno = false;

         // Eu chamo a função de criar venda e tenho o retorno TRUE ou FALSE.
         retorno = await CriarVendaApp(vendaAggregate);

        var cupom = await Cupom(saleId);

        // Geração do JSON e salvamento para log
        try
        {
            string conteudoJson = JsonConvert.SerializeObject(vendaAggregate, Formatting.Indented);

            string diretorio = @"C:\Komercio\log\Json_Venda";
            Directory.CreateDirectory(diretorio);

            string nomeArquivo = "JSON_RES_VENDA_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".json";

            string caminhoCompleto = Path.Combine(diretorio, nomeArquivo);

            // desabilitar esse
            var habilitaJson = await VerificaStatusParametro(9);

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


        return cupom;


    }
    /// <summary>
    /// Busca o parâmetro 9 referente a salvar o log desse cara.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private async Task<bool> VerificaStatusParametro(int id)
    {
        var status = await _parametrosApp.ConsultaStatusParametro(id);

        return status;
    }





    /// <summary>
    /// Cria o Cupom
    /// </summary>
    /// <param name="idDaVenda"></param>
    /// <returns></returns>
    public async Task<string> Cupom(int idDaVenda)
    {

        var cupomRetorno = await _cupomService.CupomSale(idDaVenda);
        var cupomForPrint = _cupomService.GenerateReceiptText(cupomRetorno);

        return cupomForPrint;


    }







    //// CREATE
    public async Task<bool> CriarVendaApp(SaleAggregateDTO saleAggregateDTO)
    {
        bool sucesso = false;
        int status = 0;
        string mensagem = string.Empty;

        (sucesso, status, mensagem, saleId) = await _saleFinalizerService.NovaVendaService(saleAggregateDTO);

        if (!sucesso)
        {
            switch (status)
            {
                case 400: return false;
                case 404: return false;
                case 422: return false;
                default: return false;
            }
            ;
        }

        return true;
    }


    //// READ




    //// UPTADE



    //// DELETE

    public async Task<bool> DeletarVendaApp(int id)
    {


        var (sucesso, status, mensagem) = await _saleFinalizerService.DeletarVendaService(id);

        if (!sucesso)
        {
            switch (status)
            {
                case 400: return false; 
                case 404: return false; 
                case 422: return false; 
                default: return false; 
            };           
        }

        return true;

    }



}

