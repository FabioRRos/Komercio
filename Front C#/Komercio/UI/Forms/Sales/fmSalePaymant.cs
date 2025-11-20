using Komercio.Models;
using Komercio.Services;
using Komercio.UI.Forms.Customer;
using Komercio.UI.Forms.Product;
using MeuProjetoWinForms.Models;
using MeuProjetoWinForms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Komercio.Models.SalesDTO;

namespace Komercio.UI.Forms.Sales
{
    public partial class fmSalePaymant : Form
    {

        private readonly CustomerService _customerService;
        private readonly SaleService _saleService;
        private readonly BindingList<SalesItensDTO> _itensVenda;
        private readonly EmployeeService _employeeService;
        private readonly HttpClient _httpClient;


        public float total = 0;
        private string formaPagamento = "";
        private float subtotal = 0f;
        private float acrescimo = 0f;
        private float desconto = 0f;
        private float valorRecebido = 0f;
        private float troco = 0f;
        private CustomerDto _custmerDTO = new CustomerDto();
        private List<EmployeeDto> employeerList = new List<EmployeeDto>();


        private string _cupomText;

        public fmSalePaymant(EmployeeService employeeService, CustomerService customerService, SaleService saleService, BindingList<SalesItensDTO> itensVenda, float totalVenda, HttpClient baseUrl)
        {
            _httpClient = baseUrl;
            _customerService = customerService;
            _saleService = saleService;
            _itensVenda = itensVenda;
            _employeeService = employeeService;
            InitializeComponent();
            total = totalVenda;


        }

        private void fmSalePaymant_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            EmployeerList();
            printCupom.PrintPage += printCupom_PrintPage;
            Inicio();
        }

        // Inicializa valores padrão
        private void Inicio()
        {
            mtbSubTotal.Text = total.ToString("C2");
            mtbAddValue.Text = 0f.ToString("C2");
            mtbDesc.Text = 0f.ToString("C2");
            mtbTroco.Text = "R$ 0,00";
            mtbValorRecebido.Text = total.ToString("C2");
            mlbTotal.Text = total.ToString("C2");

        }

        // Atualiza total com base em desconto e acréscimo
        private void AtualizarTotal()
        {
            subtotal = ConverterTextoParaFloat(mtbSubTotal.Text);
            acrescimo = ConverterTextoParaFloat(mtbAddValue.Text);
            desconto = ConverterTextoParaFloat(mtbDesc.Text);

            // Validação simples
            if (desconto > subtotal)
            {
                MessageBox.Show("O desconto não pode ser maior que o subtotal.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                desconto = 0;
                mtbDesc.Text = 0f.ToString("C2");
            }

            total = subtotal + acrescimo - desconto;
            if (total < 0) total = 0;

            mlbTotal.Text = total.ToString("C2");
        }

        // Formata campo numérico para moeda
        private void FormatarCampoMonetario(MaterialSkin.Controls.MaterialTextBox2 campo)
        {
            if (string.IsNullOrWhiteSpace(campo.Text))
            {
                campo.Text = 0f.ToString("C2");
                return;
            }

            float valor = ConverterTextoParaFloat(campo.Text);
            campo.Text = valor.ToString("C2");
        }

        // Converte texto em float
        private float ConverterTextoParaFloat(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return 0f;

            texto = texto.Replace("R$", "").Replace(".", "").Replace(",", ".").Trim();

            try { 
                return float.Parse(texto)/100; 
            }
            catch { 
                return 0f; 
            }
        }

        // Botões de pagamento
        private void buttonschangecolor()
        {
            mtbcash.UseAccentColor = false;
            mbtCheque.UseAccentColor = false;
            mbtPix.UseAccentColor = false;
            mbtCarddeb.UseAccentColor = false;
            mtbcardcred.UseAccentColor = false;
            mbtAccount.UseAccentColor = false;
            if (formaPagamento == "Dinheiro" && valorRecebido > total)
            {
                troco = valorRecebido - total;
                mtbTroco.Text = troco.ToString("C2");

            }
            else
            {
                mtbTroco.Text = "R$ 0,00";
            }

        }

        private void mtbcash_Click(object sender, EventArgs e)
        {
            buttonschangecolor();
            formaPagamento = "Dinheiro";
            mtbcash.UseAccentColor = true;
            string texto = mtbValorRecebido.Text.Replace("R$", "").Replace(",", "").Replace(".", "").TrimStart('0');

            if (texto.Length == 0)
                texto = "0";

            float valor = float.Parse(texto) / 100;
            troco = valor - total;

            mtbTroco.Text = troco.ToString("C2");
        }

        private void mtbcardcred_Click(object sender, EventArgs e)
        {
            buttonschangecolor();
            formaPagamento = "Crédito";
            mtbcardcred.UseAccentColor = true;
        }

        private void mbtCarddeb_Click(object sender, EventArgs e)
        {
            buttonschangecolor();
            formaPagamento = "Débito";
            mbtCarddeb.UseAccentColor = true;
        }

        private void mbtPix_Click(object sender, EventArgs e)
        {
            buttonschangecolor();
            formaPagamento = "PIX";
            mbtPix.UseAccentColor = true;
        }

        private void mbtCheque_Click(object sender, EventArgs e)
        {
            buttonschangecolor();
            formaPagamento = "Cheque";
            mbtCheque.UseAccentColor = true;
        }

        private void mbtAccount_Click(object sender, EventArgs e)
        {
            buttonschangecolor();
            formaPagamento = "Conta";
            mbtAccount.UseAccentColor = true;
        }

        // Quando sai do campo de acréscimo ou desconto, atualiza o total
        private void mtbAddValue_Leave(object sender, EventArgs e)
        {
            if (mtbAddValue.Text == "")
            {
                mtbAddValue.Text = 0f.ToString("C2");
                return;
            }
            float temp = 0;
            try
            {
                temp = float.Parse(mtbAddValue.Text);
            }
            catch
            {
                MessageBox.Show("Formato de entrada invalido!");
            }


            mtbAddValue.Text = temp.ToString("C2");
            AtualizarTotal();
        }

        private void mtbDesc_Leave(object sender, EventArgs e)
        {
            if (mtbDesc.Text == "")
            {
                mtbDesc.Text = 0f.ToString("C2");
                return;
            }
            float temp = 0;
            try
            {
                temp = float.Parse(mtbDesc.Text);
            }
            catch
            {
                MessageBox.Show("Formato de entrada invalido!");
            }


            mtbDesc.Text = temp.ToString("C2");

            AtualizarTotal();
        }

        // Valor recebido e cálculo do troco
        private void mtbValorRecebido_Leave(object sender, EventArgs e)
        {/*
            valorRecebido = ConverterTextoParaFloat(mtbValorRecebido.Text);
            FormatarCampoMonetario(mtbValorRecebido);
            if (mtbValorRecebido.Text == "R$ 0,00")
            {
                LiberaCamposDeValores();
            }

            else
            {
                BloqueiaCamposDeValores();
                mtbFunc.Enabled = true;

                FormatarCampoMonetario(mtbValorRecebido);

                if (formaPagamento == "Dinheiro" && valorRecebido > total)
                {
                    troco = valorRecebido - total;
                    mtbTroco.Text = troco.ToString("C2");

                }
                else
                {
                    mtbTroco.Text = "R$ 0,00";
                }
                */
          //  }
        }

        // Busca cliente
        public async void SearchCustomer(string doccument)
        {
            DoccumentValidationService validation = new DoccumentValidationService(doccument);


            var numDoc = doccument.Length;

            switch (numDoc)
            {
                case 11:
                    {
                        var validate = validation.ValidarCPF(doccument);

                        if (!validate)
                        {
                            DialogResult mensagem = MessageBox.Show("CPF invalido. \nSeria CNPJ?", "CNPJ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (mensagem == DialogResult.No)
                            {
                                mtbDoccument.Text = string.Empty;
                                mtbFirstAndLastName.Text = string.Empty ;
                                return;
                            }
                            return;
                        }
                    }
                    ; break;
                case 14:
                    {
                        var validate = validation.ValidarCNPJ(doccument);

                        if (!validate)
                        {
                            DialogResult mensagem = MessageBox.Show("CNPJ invalido. \nTente novamente", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            mtbDoccument.Text = string.Empty;
                            mtbFirstAndLastName.Text = string.Empty;

                            return;
                        }
                    }
                    break;
                default:
                    {
                        mtbFirstAndLastName.Text = string.Empty;

                        return;
                    }
            }




                    var (customer, ok) = await _customerService.GetValidationCustomerDocument(doccument);
                    if (ok)
                    {
                        mtbFirstAndLastName.Text = customer.customer_first_name + " " + customer.customer_last_name;
                        _custmerDTO.customer_id = customer.customer_id;
                    }
                    else
                    {
                        DialogResult cadastro =  MessageBox.Show("Cliente não localizado, Gostaria de realizar o cadastro?","Não localizado",MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        
                        if (cadastro == DialogResult.Yes)
                            {
                                fmCreateCustomer createCustomer = new fmCreateCustomer(_customerService);
                                createCustomer.ShowDialog();
                            }
                
                        mtbFirstAndLastName.Text = "";
                    }           
        }







        // Monta objeto pronto pra enviar pro service
        private SalesDTO CriarObjetoVenda(List<SalesItensDTO> itens, CustomerDto cliente)
        {
            SalesDTO venda = new SalesDTO();

            venda.CustomerId = cliente.customer_id;

            float totalItens = 0f;
            for (int i = 0; i < itens.Count; i++)
            {
                totalItens += itens[i].Total;
            }

            venda.TotalAmount = totalItens;          // valor total bruto dos itens
            venda.DiscountAmount = desconto;         // desconto vindo do form
            venda.FinalAmount = totalItens - desconto; // total final
            venda.SaleDate = DateTime.Now;
            venda.SaleTime = DateTime.Now.ToString("HH:mm:ss"); // adiciona o horário
            venda.PaymentMethod = formaPagamento;
            venda.SellerId = 0;                      // ainda fixo, conforme seu fluxo atual
            venda.SaleNotes = mtbObservacao.Text;

            return venda;
        }

        private void mbtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mtbDesc_Leave_1(object sender, EventArgs e)
        {
          /*  if (mtbDesc.Text == "")
            {
                mtbDesc.Text = 0f.ToString("C2");
                return;
            }
            float temp = 0;
            try
            {
                temp = float.Parse(mtbDesc.Text);
            }
            catch
            {
                MessageBox.Show("Formato de entrada invalido!");
            }


            mtbDesc.Text = temp.ToString("C2");
          

            AtualizarTotal();*/
        }

        private void mtbAddValue_Leave_1(object sender, EventArgs e)
        {
/*
            if (mtbAddValue.Text == "")
            {
                mtbAddValue.Text = 0f.ToString("C2");
                return;
            }
            float temp = 0;
            try
            {
                temp = float.Parse(mtbAddValue.Text);
            }
            catch
            {
                MessageBox.Show("Formato de entrada invalido!");
            }


            mtbAddValue.Text = temp.ToString("C2");
            AtualizarTotal(); */
        }


        public void BloqueiaCamposDeValores()
        {
            mtbSubTotal.Enabled = false;
            mtbDesc.Enabled = false;
            mtbAddValue.Enabled = false;
        }

        public void LiberaCamposDeValores()
        {
            mtbSubTotal.Enabled = false;
            mtbDesc.Enabled = false;
            mtbAddValue.Enabled = false;
        }




        private void mtbDoccument_Leave(object sender, EventArgs e)
        {
          
               // SearchCustomer(mtbDoccument.Text.Replace(".", "").Replace("-", ""));

            
        }



        private void mtbDesc_TextChanged(object sender, EventArgs e)
        {
            string texto = mtbDesc.Text.Replace("R$", "").Replace(",", "").Replace(".", "").TrimStart('0');

            if (texto.Length == 0)
                texto = "0";

            decimal valor = Convert.ToDecimal(texto) / 100;
            mtbDesc.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valor);
            mtbDesc.SelectionStart = mtbDesc.Text.Length;
            AtualizarTotal();

            // retorno = regrasFechamentoVendas.RetornaValorComDesconto(valor);
            // lbTotalFinal.Text = retorno.ToString("C2")
        }

        private void mtbAddValue_TextChanged(object sender, EventArgs e)
        {
            string texto = mtbAddValue.Text.Replace("R$", "").Replace(",", "").Replace(".", "").TrimStart('0');

            if (texto.Length == 0)
                texto = "0";

            decimal valor = Convert.ToDecimal(texto) / 100;
            mtbAddValue.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valor);
            mtbAddValue.SelectionStart = mtbAddValue.Text.Length;

            AtualizarTotal();

        }

        private void mtbValorRecebido_TextChanged(object sender, EventArgs e)
        {
            string texto = mtbValorRecebido.Text.Replace("R$", "").Replace(",", "").Replace(".", "").TrimStart('0');

            if (texto.Length == 0)
                texto = "0";

            float valor = float.Parse(texto) / 100;
            mtbValorRecebido.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valor);
            mtbValorRecebido.SelectionStart = mtbValorRecebido.Text.Length;

            if (mtbValorRecebido.Text == "R$ 0,00")
            {
                LiberaCamposDeValores();
            }

            else
            {
             //   BloqueiaCamposDeValores();
                mtbFunc.Enabled = true;

                FormatarCampoMonetario(mtbValorRecebido);
                

                if (formaPagamento == "Dinheiro" && valor > total)
                {
                    troco = valor - total;
                    mtbTroco.Text = troco.ToString("C2");

                }
                else
                {
                    mtbTroco.Text = "R$ 0,00";
                }
            }
        }

        private void mtbDoccument_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer(mtbDoccument.Text.Replace(".", "").Replace("-", ""));
        }


        private async void EmployeerList()
        {
            employeerList = await _employeeService.GetActiveEmployeeNamesAsync();


            foreach (var employee in employeerList)
            {
            mtbFunc.Items.Add(employee.EmployeeFullName);

            }
        }
    private int BuscaIdEmployeer()
        {
            var name = mtbFunc.SelectedItem.ToString();

            foreach (var employee in employeerList)
            {
                if (employee.EmployeeFullName == name)
                {
                    return employee.Id;
                }
            }

            return 0;
        }

        private void fmSalePaymant_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                fmCreateCustomer createCustomer = new fmCreateCustomer(_customerService);
                createCustomer.ShowDialog();

            }

            if (e.KeyCode == Keys.F5)
            {
                fmChangeCustomer changeCustomer = new fmChangeCustomer(_customerService);
                changeCustomer.ShowDialog();
               
            }

            if (e.KeyCode == Keys.Escape) {
           DialogResult yes =  MessageBox.Show("Deseja realmente sair?","Cancelar venda?",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (yes == DialogResult.Yes)
                {
                    this.Close();
                    Owner.Close();
                }
                else
                {
                    return;
                }
            }

        }


        private void printCupom_PrintPage(object sender, PrintPageEventArgs e)
        {

            Font fonte = new Font("Consolas", 8);
            float y = 0;
            float margem = 5;
            float alturaLinha = fonte.GetHeight(e.Graphics);

            // evita erros
            if (string.IsNullOrWhiteSpace(_cupomText))
                return;

            string[] linhas = _cupomText.Split('\n');

            foreach (var linha in linhas)
            {
                e.Graphics.DrawString(linha, fonte, Brushes.Black, margem, y);
                y += alturaLinha;
            }

        }

        private async void mbtConfirm_Click(object sender, EventArgs e)
        {
            if (_itensVenda == null || _itensVenda.Count == 0)
            {
                MessageBox.Show("Nenhum item na venda.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(formaPagamento))
            {
                MessageBox.Show("Selecione a forma de pagamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (string.IsNullOrEmpty(mtbFunc.Text))
            {
                MessageBox.Show("Selecione o funcionário responsavel pela venda", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (formaPagamento == "Conta" && _custmerDTO.customer_id == 0)
            {
                MessageBox.Show("Para salvar na conta, identifique o cliente!", "Identifique o cliente!!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int func = BuscaIdEmployeer();

            // Cria a venda pronta
            var venda = CriarObjetoVenda(new List<SalesItensDTO>(_itensVenda), _custmerDTO);

            // Mostra resumo rápido
            string resumo = $"Total: {total:C2}\nRecebido: {valorRecebido:C2}\nTroco: {troco:C2}\nForma: {formaPagamento}";
            if (MessageBox.Show(resumo, "Confirmar venda?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            // Salva JSON pra validação
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(venda, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText("venda.json", json);

            // MessageBox.Show("Venda salva como venda.json", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);


            SaleFinalizerService finalizer = new SaleFinalizerService(_customerService, _saleService, _itensVenda, _httpClient);

            try
            {
            var cupom = await finalizer.MontarVenda(venda, _itensVenda, formaPagamento, func);
            _cupomText = cupom;

            printCupom.Print();
            //    MessageBox.Show("Venda formalizada e arquivo JSON gerado com sucesso!",
            //    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //  o form atual
            this.Close();

            }
            catch
            {
                MessageBox.Show("Não consegui imprimir - fmSalePayment");
            }

            if (this.Owner != null)
            {
                this.Owner.Close();
            }
        }
    }



}
