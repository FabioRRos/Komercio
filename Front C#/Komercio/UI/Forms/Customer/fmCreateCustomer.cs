using Estoque.Entities;
using Estoque.Entities.Services;
using Komercio.Models;
using Komercio.Services;
using MeuProjetoWinForms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace Komercio.UI.Forms.Customer
{
    public partial class fmCreateCustomer : Form
    {
        private readonly CustomerService _customerService;
        public fmCreateCustomer(CustomerService service)
        {
            _customerService = service;
            InitializeComponent();
            InitializationTextBox();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fmCreateCustomer_Load(object sender, EventArgs e)
        {

        }

        private void InitializationTextBox()
        {
            mtbCustomerFirstName.Enabled = false;
            mtbCustomerLastName.Enabled = false;
            mtbCustomerDocument.Enabled = false;
            mtbCustomerPhone.Enabled = false;
            mtbCustomerMobile.Enabled = false;
            mtbCustomerZipcode.Enabled = false;
            mtbCustomerAdress.Enabled = false;
            mtbCustomerNeighborhood.Enabled = false;
            mtbCustomerCity.Enabled = false;
            mtbCustomerCountry.Enabled = false;
            mtbCustomerState.Enabled = false;
            mtbCustomerEmail.Enabled = false;
            mbtSaveCustomer.Enabled = false;
            mbtNewCustomer.Enabled = true;

        }


        private void NewCustomerFieldsEnabled()
        {
            mtbCustomerFirstName.Enabled = true;
            mtbCustomerLastName.Enabled = true;
            mtbCustomerDocument.Enabled = true;
            mtbCustomerPhone.Enabled = true;
            mtbCustomerMobile.Enabled = true;
            mtbCustomerZipcode.Enabled = true;
            mtbCustomerAdress.Enabled = true;
            mtbCustomerNeighborhood.Enabled = true;
            mtbCustomerCity.Enabled = true;
            mtbCustomerCountry.Enabled = true;
            mtbCustomerState.Enabled = true;
            mtbCustomerEmail.Enabled = true;
            mbtSaveCustomer.Enabled = true;
            
        }

        private void mtbCustomerFirstName_Enter(object sender, EventArgs e)
        {
            if (mtbCustomerFirstName.Text == "Nome")
            {
                mtbCustomerFirstName.Text = "";
            }
        }

        private void mtbCustomerFirstName_Leave(object sender, EventArgs e)
        {
            if (mtbCustomerFirstName.Text == "")
            {
                mtbCustomerFirstName.Text = "Nome";
            }
        }

        private void mtbCustomerLastName_Enter(object sender, EventArgs e)
        {
            if (mtbCustomerLastName.Text == "Sobrenome")
            {
                mtbCustomerLastName.Text = "";
            }
        }

        private void mtbCustomerLastName_Leave(object sender, EventArgs e)
        {
            if (mtbCustomerLastName.Text == "")
            {
                mtbCustomerLastName.Text = "Sobrenome";
            }
        }

        private void mtbCustomerDocument_Enter(object sender, EventArgs e)
        {
            if (mtbCustomerDocument.Text == "CPF")
            {
                mtbCustomerDocument.Text = "";
            }
        }

        private  async void mtbCustomerDocument_Leave(object sender, EventArgs e)
        {
            if (mtbCustomerDocument.Text == "")
            {
                mtbCustomerDocument.Text = "CPF";
                return;
            }

            try
            {
                bool isValid = await _customerService.GetValidationCustomerDocument(mtbCustomerDocument.Text);

                if (isValid == false)
                {
                    MessageBox.Show("CPF ou CNPJ inválido!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mtbCustomerDocument.Text = "CPF";

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao validar documento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (mtbCustomerDocument.Text.Length == 11)
            {
                    string cpf = mtbCustomerDocument.Text;
                    cpf = Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
                    mtbCustomerDocument.Text = cpf.ToString();

                return;
            }
            if (mtbCustomerDocument.Text.Length == 14)
            {
                    string cnpj = mtbCustomerDocument.Text;
                    cnpj = Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
                    mtbCustomerDocument.Text = cnpj.ToString();

                return;
            }
            if (mtbCustomerDocument.Text.Length != 14 && mtbCustomerDocument.Text.Length != 11)
            {
                MessageBox.Show("Documento inválido! Insira um CPF ou CNPJ válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbCustomerDocument.Text = "CPF";
                return;
            }


        }


        public async Task<bool> ValidationDocumentAsync(string document)
        {
            bool isValid = await _customerService.GetValidationCustomerDocument(document);
            return isValid;
        }


        private void mtbCustomerPhone_Enter(object sender, EventArgs e)
        {
            if (mtbCustomerPhone.Text == "Telefone Fixo")
            {
                mtbCustomerPhone.Text = "";
            }
        }

        private void mtbCustomerPhone_Leave(object sender, EventArgs e)
        {
            if (mtbCustomerPhone.Text == "" || mtbCustomerPhone.Text.Length!=10)
            {
                mtbCustomerPhone.Text = "Telefone Fixo";
            }

            if (mtbCustomerPhone.Text.Length == 10)
            {
                string phone = mtbCustomerPhone.Text;
                phone = Convert.ToUInt64(phone).ToString(@"\(00\) 0000\-0000");
                mtbCustomerPhone.Text = phone.ToString();
                return;
            }
        }

        private void mtbCustomerMobile_Enter(object sender, EventArgs e)
        {
            if (mtbCustomerMobile.Text == "Celular")
            {
                mtbCustomerMobile.Text = "";
            }
        }

        private void mtbCustomerMobile_Leave(object sender, EventArgs e)
        {
            if (mtbCustomerMobile.Text == "" || mtbCustomerMobile.Text.Length !=11)
            {
                mtbCustomerMobile.Text = "Celular";
                return;
            }

            if (mtbCustomerMobile.Text.Length == 11)
            {
                string mobile = mtbCustomerMobile.Text;
                mobile = Convert.ToUInt64(mobile).ToString(@"\(00\) 00000\-0000");
                mtbCustomerMobile.Text = mobile.ToString();
                return;
            }
        }

        private void mtbCustomerZipcode_Enter(object sender, EventArgs e)
        {
            if (mtbCustomerZipcode.Text == "CEP")
            {
                mtbCustomerZipcode.Text = "";
            }
        }
        private void mtbCustomerZipcode_Leave(object sender, EventArgs e)
        {
            if (mtbCustomerZipcode.Text == "")
            {
                mtbCustomerZipcode.Text = "CEP";
            }
        }

        private void mtbCustomerAdress_Enter(object sender, EventArgs e)
        {
            if (mtbCustomerAdress.Text == "Endereço")
            {
                mtbCustomerAdress.Text = "";
            }
        }
        private void mtbCustomerAdress_Leave(object sender, EventArgs e)
        {
            if (mtbCustomerAdress.Text == "")
            {
                mtbCustomerAdress.Text = "Endereço";
            }
        }

        private void mtbCustomerNeighborhood_Enter(object sender, EventArgs e)
        {
            if (mtbCustomerNeighborhood.Text == "Bairro")
            {
                mtbCustomerNeighborhood.Text = "";
            }
        }
        private void mtbCustomerNeighborhood_Leave(object sender, EventArgs e)
        {
            if (mtbCustomerNeighborhood.Text == "")
            {
                mtbCustomerNeighborhood.Text = "Bairro";
            }
        }

        private void mtbCustomerCity_Enter(object sender, EventArgs e)
        {
            if (mtbCustomerCity.Text == "Cidade")
            {
                mtbCustomerCity.Text = "";
            }
        }

        private void mtbCustomerCity_Leave(object sender, EventArgs e)
        {
            if (mtbCustomerCity.Text == "")
            {
                mtbCustomerCity.Text = "Cidade";
            }
        }

        private void mtbCustomerState_Enter(object sender, EventArgs e)
        {
            if (mtbCustomerState.Text == "Estado")
            {
                mtbCustomerState.Text = "";
            }
        }
        private void mtbCustomerState_Leave(object sender, EventArgs e)
        {
            if (mtbCustomerState.Text == "")
            {
                mtbCustomerState.Text = "Estado";
            }
        }

        private void mtbCustomerCountry_Enter(object sender, EventArgs e)
        {
            if (mtbCustomerCountry.Text == "País")
            {
                mtbCustomerCountry.Text = "";
            }
        }

        private void mtbCustomerCountry_Leave(object sender, EventArgs e)
        {
            if (mtbCustomerCountry.Text == "")
            {
                mtbCustomerCountry.Text = "País";
            }
        }

        private void mtbCustomerEmail_Enter(object sender, EventArgs e)
        {
            if (mtbCustomerEmail.Text == "E-mail")
            {
                mtbCustomerEmail.Text = "";
            }
        }

        private void mtbCustomerEmail_Leave(object sender, EventArgs e)
        {
            if (mtbCustomerEmail.Text == "")
            {
                mtbCustomerEmail.Text = "E-mail";
            }


        }

        private void mtbCustomerZipcode_Leave_1(object sender, EventArgs e)
        {
            if (mtbCustomerZipcode.Text == "" || mtbCustomerZipcode.Text.Length != 8)
            {
                mtbCustomerZipcode.Text = "CEP";
            }

            if (mtbCustomerZipcode.Text.Length == 8)
            {
                string zipcode = mtbCustomerZipcode.Text;
                zipcode = Convert.ToUInt64(zipcode).ToString(@"00000\-000");
                mtbCustomerZipcode.Text = zipcode.ToString();

                CustomerZipcodeForAdress();

                return;
            }

        }


        // Aqui preenchemos o endereço automaticamente ao inserir o CEP

        public async void CustomerZipcodeForAdress()
        {
            var zipCode = mtbCustomerZipcode.Text
                .Replace("-", "")
                .Replace(" ", "");

            RetornaCEPServices retornaCEP = new RetornaCEPServices();

            RetornaCEPEntitie retornaCEPEntitie = new RetornaCEPEntitie();

            retornaCEPEntitie = await retornaCEP.RetornaCEPAsync(zipCode);

            if (retornaCEPEntitie != null)
            {
                mtbCustomerAdress.Text = retornaCEPEntitie.Logradouro;
                mtbCustomerNeighborhood.Text = retornaCEPEntitie.Bairro;
                mtbCustomerCity.Text = retornaCEPEntitie.Localidade;
                mtbCustomerState.Text = retornaCEPEntitie.Uf;
                mtbCustomerCountry.Text = "Brasil";
            }
        }

        private void mtbCustomerAdress_Leave_1(object sender, EventArgs e)
        {
            if (mtbCustomerAdress.Text == "")
            {
                mtbCustomerAdress.Text = "Endereço";
            }

        }

        private void mtbCustomerNeighborhood_Leave_1(object sender, EventArgs e)
        {
            if (mtbCustomerNeighborhood.Text == "")
            {
                mtbCustomerNeighborhood.Text = "Bairro";
            }
        }

        private void mtbCustomerCity_Leave_1(object sender, EventArgs e)
        {
            if (mtbCustomerCity.Text == "")
            {
                mtbCustomerCity.Text = "Cidade";
            }

        }

        private void mtbCustomerState_Leave_1(object sender, EventArgs e)
        {
            if (mtbCustomerState.Text == "")
            {
                mtbCustomerState.Text = "Estado";
            }
        }

        private void mtbCustomerCountry_Leave_1(object sender, EventArgs e)
        {
            if (mtbCustomerCountry.Text == "")
            {
                mtbCustomerCountry.Text = "País";
            }
        }

        private void mtbCustomerEmail_Leave_1(object sender, EventArgs e)
        {
            if (mtbCustomerEmail.Text == "")
            {
                mtbCustomerEmail.Text = "E-mail";
            }

        }

        private void materialMaskedTextBox1_Click(object sender, EventArgs e)
        {
     
        }

        private void materialMaskedTextBox1_Leave(object sender, EventArgs e)
        {

        }

        private void mtbCustomerMobile_Click(object sender, EventArgs e)
        {
           
        }

        private void mbtNewCustomer_Click(object sender, EventArgs e)
        {
            NewCustomerFieldsEnabled();
            mbtNewCustomer.Enabled= false;
        }

        private async void mbtSaveCustomer_Click(object sender, EventArgs e)
        {

            CustomerDto customertemp = new CustomerDto
            {
                customer_first_name = mtbCustomerFirstName.Text,
                customer_last_name = mtbCustomerLastName.Text,
                customer_document = mtbCustomerDocument.Text,
                customer_phone = mtbCustomerPhone.Text,
                customer_mobile = mtbCustomerMobile.Text,
                customer_zip_code = mtbCustomerZipcode.Text,
                customer_address_line = mtbCustomerAdress.Text,
                customer_neighborhood = mtbCustomerNeighborhood.Text,
                customer_city = mtbCustomerCity.Text,
                customer_state = mtbCustomerState.Text,
                customer_country = mtbCustomerCountry.Text,
                customer_email = mtbCustomerEmail.Text
            };

            CustomerDto customer = CustomerDto.NormalizeCustomer(customertemp);

            if (customer == null)
            {
                return;
            }

            try
            {
                (bool success, string Message) = await _customerService.CreateCustomerAsync(customer);


                if (success)
                {
                    MessageBox.Show("Cliente cadastrado com sucesso!",
                                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InitializationTextBox();
                    clearFields();
                    return;
                }
                else
                {
                    MessageBox.Show(Message,
                                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}",
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return;
        }


      private void clearFields()
        {
            mtbCustomerFirstName.Text = "Nome";
            mtbCustomerLastName.Text = "Sobrenome";
            mtbCustomerDocument.Text = "CPF";
            mtbCustomerPhone.Text = "Telefone Fixo";
            mtbCustomerMobile.Text = "Celular";
            mtbCustomerZipcode.Text = "CEP";
            mtbCustomerAdress.Text = "Endereço";
            mtbCustomerNeighborhood.Text = "Bairro";
            mtbCustomerCity.Text = "Cidade";
            mtbCustomerCountry.Text = "País";
            mtbCustomerState.Text = "Estado";
            mtbCustomerEmail.Text = "E-mail";
        }


    }
}

