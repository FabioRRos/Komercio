using Komercio.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komercio.Services
{
    public class CupomService
    {
        private readonly HttpClient _httpClient;
        private string _receiptText = string.Empty;
        readonly string Printer = ConfigurationManager.AppSettings["Printer"];
        readonly string nomeFantasia = ConfigurationManager.AppSettings["NomeFantasia"];
        readonly string razaoSocial = ConfigurationManager.AppSettings["RazaoSocial"];
        readonly string cNPJ = ConfigurationManager.AppSettings["CNPJ"];
        readonly string endereco = ConfigurationManager.AppSettings["Endereco"];
        readonly string cidade = ConfigurationManager.AppSettings["Cidade"];
        readonly string contato = ConfigurationManager.AppSettings["Contato"];

        public CupomService(HttpClient baseUrl)
        {
            _httpClient = baseUrl;
        }

        public async Task<CupomDTO> CupomSale(int id)
        {
           var  response = await _httpClient.GetAsync($"/Cupom/{id}");
            for (int tentativas = 0; tentativas < 3; tentativas++)
            {
                try
                {
                    response = await _httpClient.GetAsync($"/Cupom/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        break; 
                    }
                }
                catch
                {
                    MessageBox.Show("ERRO DE REDE, NÃO CONSEGUI RETORNO", "ERR001");
                }

                var json = await response.Content.ReadAsStringAsync();
                MessageBox.Show(json);
                await Task.Delay(500); 
            }

            try
            {
               
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Erro ao consultar cupom (Status: {response.StatusCode})");
                    return new CupomDTO();
                }

                var json = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(json))
                {
                    Console.WriteLine("Cupom retornou JSON vazio.");
                    return new CupomDTO();
                }

                var cupom = JsonConvert.DeserializeObject<CupomDTO>(json);

                if (cupom == null)
                {
                    Console.WriteLine("Erro: cupom não pôde ser desserializado.");
                    return new CupomDTO();
                }

                return cupom;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gerar o cupom: {ex.Message}");
                return new CupomDTO();
            }
        }

        public string GenerateReceiptText(CupomDTO cupom)
        {
            var sale = cupom.SaleReport;
            var sb = new StringBuilder();
            sb.AppendLine("--------------------------------------");
            sb.AppendLine($"     *** {nomeFantasia} ***");
            sb.AppendLine("          CUPOM NAO FISCAL");
            sb.AppendLine("--------------------------------------");
            sb.AppendLine($"RAZAO SOCIAL: {razaoSocial}");
            sb.AppendLine($"CNPJ: {cNPJ}");
            sb.AppendLine($"ENDERECO:{endereco}");
            sb.AppendLine($"{cidade}");
            sb.AppendLine($"FONE/WHATSAPP:{contato}");
            sb.AppendLine("--------------------------------------");
            sb.AppendLine($"VENDA Nº: {sale.SaleId}");
            sb.AppendLine($"CLIENTE: {sale.CustomerName}");
            sb.AppendLine($"CPF: {sale.CustomerDocument}");
            sb.AppendLine($"VENDEDOR: {sale.SallerName}");
            sb.AppendLine($"PAGAMENTO: {sale.PaymantMethod}");
            sb.AppendLine($"DATA: {sale.SaleDate:dd/MM/yyyy}");
            sb.AppendLine("--------------------------------------");
            sb.AppendLine("QTD  DESCRICAO                VALOR");
            sb.AppendLine("--------------------------------------");




            if (cupom.SaleItens != null)
            {
                foreach (var item in cupom.SaleItens)
                {
                    string nome = item.ProductName.Length > 22
                        ? item.ProductName.Substring(0, 22)
                        : item.ProductName.PadRight(22);

                    sb.AppendLine($"{item.Quantity,-3} {nome} {item.Total,8:C2}");
                }
            }

            sb.AppendLine("--------------------------------------");
            sb.AppendLine($"TOTAL BRUTO:   {sale.TotalAmount,10:C2}");
            sb.AppendLine($"DESCONTO:      {sale.DiscountAmount,10:C2}");
            sb.AppendLine($"TOTAL FINAL:   {sale.FinalAmount,10:C2}");
            sb.AppendLine("--------------------------------------");
            sb.AppendLine($"OBS: {sale.SaleNotes}");
            sb.AppendLine("--------------------------------------");
            sb.AppendLine("    OBRIGADO PELA PREFERÊNCIA!");
            sb.AppendLine("         VOLTE SEMPRE :)");

            string textoFinal = sb.ToString();

            string directory = @"C:\Projeto Komercial\Komercio\Arquivos de teste\Cupom";
            string fileName = $"Cupom_{sale.SaleId}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            string fullPath = Path.Combine(directory, fileName);

            try
            {
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                File.WriteAllText(fullPath, textoFinal, Encoding.UTF8);
                Console.WriteLine($"Cupom salvo em: {fullPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar o cupom: {ex.Message}");
            }


            _receiptText = textoFinal;
            //PrintCupom(Printer);

            return textoFinal;
        }

        private void PrintCupom(string printerName)
        {
            try
            {
                PrintDocument pd = new PrintDocument();


                pd.PrinterSettings.PrinterName = printerName;


                PaperSize paper = new PaperSize("Cupom80mm", 300, 600);
                pd.DefaultPageSettings.PaperSize = paper;

                pd.PrintPage += new PrintPageEventHandler(PrintPage);
                pd.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao imprimir cupom: {ex.Message}");
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Consolas", 8);
            float yPos = 0;
            int leftMargin = 5;
            float lineHeight = font.GetHeight(e.Graphics);

            string[] lines = _receiptText.Split('\n');
            foreach (string line in lines)
            {
                e.Graphics.DrawString(line, font, Brushes.Black, leftMargin, yPos);
                yPos += lineHeight;
            }
        }
    }
}