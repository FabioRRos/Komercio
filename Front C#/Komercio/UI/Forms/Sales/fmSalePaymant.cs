using Komercio.Models;
using Komercio.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using static Komercio.Models.SalesDTO;

namespace Komercio.UI.Forms.Sales
{
    public partial class fmSalePaymant : Form
    {

        private readonly CustomerService _customerService;
        private readonly SaleService _saleService;
        private readonly BindingList<SalesItensDTO> _itensVenda;




        public float total = 0;
        private string formaPagamento = "";
        private float subtotal = 0f;
        private float acrescimo = 0f;
        private float desconto = 0f;
        private float valorRecebido = 0f;
        private float troco = 0f;
        private CustomerDto _custmerDTO = new CustomerDto();

        public fmSalePaymant(CustomerService customerService, SaleService saleService, BindingList<SalesItensDTO> itensVenda, float totalVenda)
        {

            _customerService = customerService;
            _saleService = saleService;
            _itensVenda = itensVenda;
            InitializeComponent();
            total = totalVenda;


        }

        private void fmSalePaymant_Load(object sender, EventArgs e)
        {
            Inicio();

            // Teste simples: exibe a quantidade de itens recebidos
            MessageBox.Show("Itens recebidos: " + _itensVenda.Count.ToString(),
                            "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);





            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
           
        }

        // Inicializa valores padrão
        private void Inicio()
        {
            mtbSubTotal.Text = total.ToString("C2");
            mtbAddValue.Text = 0f.ToString("C2");
            mtbDesc.Text = 0f.ToString("C2");
            mtbTroco.Text = "R$ 0,00";
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
        {
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
            }
        }

        // Busca cliente
        public async void SearchCustomer(string doccument)
        {
            var (customer, ok) = await _customerService.GetValidationCustomerDocument(doccument);
            if (ok)
            {
                mtbFirstAndLastName.Text = customer.customer_first_name + " " + customer.customer_last_name;
                _custmerDTO.customer_id = customer.customer_id;



            }
            else
            {
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

        private void mtbAddValue_Leave_1(object sender, EventArgs e)
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

        private void mtbFunc_Leave(object sender, EventArgs e)
        {
            if (mtbFunc.Text != "")
            {
               // mtbDoccument.Enabled = true;
                SearchCustomer(mtbDoccument.Text.Replace(".", "").Replace("-", ""));

            }
        }

        private void mtbDoccument_TextChanged(object sender, EventArgs e)
        {

        }

        private void mtbDoccument_Leave(object sender, EventArgs e)
        {
            if (mtbFunc.Text != "")
            {
               // mtbDoccument.Enabled = true;
                SearchCustomer(mtbDoccument.Text.Replace(".", "").Replace("-", ""));

            }
        }

        private void mbtConfirm_Click(object sender, EventArgs e)
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

            
            // Cria a venda pronta
            var venda = CriarObjetoVenda(new List<SalesItensDTO>(_itensVenda), _custmerDTO);

            // Mostra resumo rápido
            string resumo = $"Total: {total:C2}\nRecebido: {valorRecebido:C2}\nTroco: {troco:C2}\nForma: {formaPagamento}";
            if (MessageBox.Show(resumo, "Confirmar venda?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            // Salva JSON pra validação
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(venda, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText("venda.json", json);

            MessageBox.Show("Venda salva como venda.json", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);


            SaleFinalizerService finalizer = new SaleFinalizerService(_customerService, _saleService, _itensVenda);


            finalizer.MontarVenda(venda, _itensVenda, formaPagamento, 1);

            MessageBox.Show("Venda formalizada e arquivo JSON gerado com sucesso!",
                            "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);







            //  o form atual
            this.Close();

            if (this.Owner != null)
            {
                this.Owner.Close();
            }


        }



    }
}
