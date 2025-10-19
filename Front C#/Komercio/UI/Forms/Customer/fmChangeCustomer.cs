using Estoque.Entities;
using Estoque.Entities.Services;
using Komercio.Models;
using Komercio.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komercio.UI.Forms.Customer
{

    public partial class fmChangeCustomer : Form
    {
        private readonly CustomerService _customerService;

        public fmChangeCustomer(CustomerService service)
        {
            _customerService = service;
            InitializeComponent();
           InitializationTextBox();
            LoadDataGridView();
            
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
            mbtChangeCustomer.Enabled = true;
            mcbActive.Enabled = false;

        }

        private void mbtNewCustomer_Click(object sender, EventArgs e)
        {
            if (mtbCustomerDocument.Text == "CPF")
            {
                MessageBox.Show("Selecione o cliente antes de realizar a alteração!!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            mtbCustomerFirstName.Enabled = false;
            mtbCustomerLastName.Enabled = false;
            mtbCustomerDocument.Enabled = false;
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
            mbtChangeCustomer.Enabled = false;
            mcbActive.Enabled = true;

        }

        private void fmChangeCustomer_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }

        public async void AttDataGridView(List<CustomerDto> customersList)
        {
            try
            {
                

                dgvCustomerList.DataSource = customersList;
                dgvCustomerList.Columns["customer_id"].HeaderText = "ID";
                dgvCustomerList.Columns["customer_first_name"].HeaderText = "Nome";
                dgvCustomerList.Columns["customer_last_name"].HeaderText = "Sobrenome";
                dgvCustomerList.Columns["customer_document"].Visible = false;
                dgvCustomerList.Columns["customer_phone"].Visible = false;
                dgvCustomerList.Columns["customer_mobile"].Visible = false;
                dgvCustomerList.Columns["customer_email"].Visible = false;
                dgvCustomerList.Columns["customer_address_line"].Visible = false;
                dgvCustomerList.Columns["customer_zip_code"].Visible = false;
                dgvCustomerList.Columns["customer_neighborhood"].Visible = false;
                dgvCustomerList.Columns["customer_city"].Visible = false;
                dgvCustomerList.Columns["customer_state"].Visible = false;
                dgvCustomerList.Columns["customer_country"].Visible = false;
                dgvCustomerList.Columns["customer_account_id"].Visible = false;
                dgvCustomerList.Columns["customer_status"].Visible = false;




            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}",
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadDataGridView()
        {
            var customersList = await _customerService.GetAllCustomersAsync();

            
            await Task.Delay(50);
            AttDataGridView(customersList);
        }
        public static CustomerDto customer = new CustomerDto();

        private async void LoadCustomer(string customerId)
        {
            customer = await _customerService.GetCustomerByIdAsync(int.Parse(customerId));

            if (customer == null)
            {
                MessageBox.Show("Tive dificuldades de localizar, tente novamente");
                return;
            }
            mtbCustomerId.Text = customerId;
            mtbCustomerFirstName.Text = customer.customer_first_name;
            mtbCustomerLastName.Text = customer.customer_last_name;
            mtbCustomerDocument.Text = customer.customer_document;
            mtbCustomerPhone.Text = customer.customer_phone;
            mtbCustomerMobile.Text = customer.customer_mobile;
            mtbCustomerZipcode.Text = customer.customer_zip_code;
            mtbCustomerAdress.Text = customer.customer_address_line;
            mtbCustomerNeighborhood.Text = customer.customer_neighborhood;
            mtbCustomerCity.Text = customer.customer_city;
            mtbCustomerState.Text = customer.customer_state;
            mtbCustomerCountry.Text = customer.customer_country;
            mtbCustomerEmail.Text = customer.customer_email;
           

            if (customer.customer_status == true)
            {
                mcbActive.Checked = true;
            }else mcbActive.Checked = false;
            

        }



        private void materialTextBox22_Click(object sender, EventArgs e)
        {
            if (mtbCustomerFirstName.Text == "Nome")
            {
                mtbCustomerFirstName.Text = "";
            }

        }

        private void materialTextBox21_Click(object sender, EventArgs e)
        {

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

        private void mtbCustomerDocument_Leave(object sender, EventArgs e)
        {
            if (mtbCustomerDocument.Text == "")
            {
                mtbCustomerDocument.Text = "CPF";
                return;
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

        private void mtbCustomerPhone_Enter(object sender, EventArgs e)
        {
            if (mtbCustomerPhone.Text == "Telefone Fixo")
            {
                mtbCustomerPhone.Text = "";
            }
        }

        private void mtbCustomerPhone_Leave(object sender, EventArgs e)
        {
            if (mtbCustomerPhone.Text == "" || mtbCustomerPhone.Text.Length != 10)
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
            if (mtbCustomerMobile.Text == "" || mtbCustomerMobile.Text.Length != 11)
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


            CustomerZipcodeForAdress();

        }


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

        private void mtbSeachName_Enter(object sender, EventArgs e)
        {
            if (mtbSeachName.Text == "Buscar Cliente")
            {
                mtbSeachName.Text = "";
            }
        }

        private void mtbSeachName_Leave(object sender, EventArgs e)
        {
            if (mtbSeachName.Text == "")
            {
                mtbSeachName.Text = "Buscar Cliente";               
            }
        }

        private void mtbSearchLastName_Enter(object sender, EventArgs e)
        {

        }

        private void mtbSearchLastName_Leave(object sender, EventArgs e)
        {

        }

        private async void mtbSeachName_TextChanged(object sender, EventArgs e)
        {
            var texto = mtbSeachName.Text; 
            
           if (texto =="" || texto == "Buscar Cliente")
            {
                LoadDataGridView();
                return;
            }

            var customersList = await _customerService.GetCustomersByNameAsync(texto);
            await Task.Delay(50);
            AttDataGridView(customersList);
        }

        private void dgvCustomerList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mcbActive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCustomerList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var idCustomer = dgvCustomerList.Rows[e.RowIndex].Cells["customer_id"].Value.ToString();

            LoadCustomer(idCustomer);
        }

        private async void mbtSaveCustomer_Click(object sender, EventArgs e)
        {

            bool status;

            if(mcbActive.Checked == true)
            {
                status = true;
            }
            else
            {
                status = false;
            }            

                CustomerDto customertemp = new CustomerDto
                {
                    customer_id = int.Parse(mtbCustomerId.Text),
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
                    customer_email = mtbCustomerEmail.Text,
                    customer_status = status,
                    customer_account_id = customer.customer_account_id
                };

            CustomerDto  customerNormalized = CustomerDto.NormalizeCustomer(customertemp);

            if (customerNormalized == null)
            {
                return;
            }

            try
            {
                bool success = await _customerService.UpdateCustomerAsync(customerNormalized);


                if (success)
                {
                    MessageBox.Show("Cliente atualizado com sucesso!",
                                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InitializationTextBox();                   
                    return;
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar o cliente!",
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
    }


}
