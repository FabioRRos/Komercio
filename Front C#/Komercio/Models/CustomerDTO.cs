using System.Windows.Forms;

namespace Komercio.Models
{
    public class CustomerDto
    {
        public int customer_id { get; set; }
        public string customer_first_name { get; set; }
        public string customer_last_name { get; set; }
        public string customer_document { get; set; }
        public string customer_phone { get; set; }
        public string customer_mobile { get; set; }
        public string customer_email { get; set; }
        public string customer_address_line { get; set; }
        public string customer_zip_code { get; set; }
        public string customer_neighborhood { get; set; }
        public string customer_city { get; set; }
        public string customer_state { get; set; }
        public string customer_country { get; set; }
        public int customer_account_id { get; set; } = 0;
        public bool customer_status { get; set; } = true;

        public CustomerDto() { }

        public CustomerDto(string firstName, string lastName, string document)
        {
            customer_first_name = firstName;
            customer_last_name = lastName;
            customer_document = document;
            customer_status = true;
        }



        public static CustomerDto NormalizeCustomer(CustomerDto customerin)
        {

            CustomerDto customer = new CustomerDto();

            bool status = customerin.customer_status;

            if (status == false)
            {
                customer.customer_status = false;
            }
            if (status == true)
            {
                customer.customer_status = true;
            }

            customer.customer_account_id = customerin.customer_account_id;

            customer.customer_id = customerin.customer_id;


            if (customerin.customer_first_name == "" || customerin.customer_first_name == "Nome")
            {
                MessageBox.Show("O campo 'Nome' é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            else
            {
                customer.customer_first_name = customerin.customer_first_name.Trim();
            }



            if (customerin.customer_last_name == "" || customerin.customer_last_name == "Sobrenome")
            {
                MessageBox.Show("O campo 'Sobrenome' é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;

            }
            else
            {
                customer.customer_last_name = customerin.customer_last_name.Trim();
            }



            if (customerin.customer_document == "" || customerin.customer_document =="CPF")
            {
                MessageBox.Show("O campo 'Documento' é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            else
            {

                customer.customer_document = customerin.customer_document
                    .Replace(".", "")
                    .Replace("-", "")
                    .Replace("/", "")
                    .Replace(" ", "");
            }



            if (customerin.customer_phone == "" || customerin.customer_phone == "Telefone Fixo")
            {
                customer.customer_phone = "";

            }
            else
            {
                customer.customer_phone = customerin.customer_phone
                    .Replace("(", "")
                    .Replace(")", "")
                    .Replace("-", "")
                    .Replace(" ", "");
            }

            if (customerin.customer_mobile == "" || customerin.customer_mobile == "Celular")
            {
                customer.customer_phone = "";

            }
            else
            {
                customer.customer_mobile = customerin.customer_mobile
                    .Replace("(", "")
                    .Replace(")", "")
                    .Replace("-", "")
                    .Replace(" ", "");
            }

            if (customerin.customer_zip_code == "" || customerin.customer_zip_code == "CEP")
            {
                customer.customer_zip_code = "";
            }
            else
            {
                customer.customer_zip_code = customerin.customer_zip_code
                    .Replace("-", "")
                    .Replace(" ", "");

            }


            if (customerin.customer_address_line == "" || customerin.customer_address_line == "Endereço")

            {
                customer.customer_address_line = "";
            }
            else
            {
                customer.customer_address_line = customerin.customer_address_line;
            }


            if (customerin.customer_neighborhood == "" || customerin.customer_neighborhood == "Bairro")
            {
                customer.customer_neighborhood = "";
            }
            else
            {
                customer.customer_neighborhood = customerin.customer_neighborhood;
            }


            if (customerin.customer_city == "" || customerin.customer_city == "Cidade")
            {
                customer.customer_city = "";
            }
            else
            {
                customer.customer_city = customerin.customer_city;
            }


            if (customerin.customer_state == "" || customerin.customer_state == "Estado")
            {
                customer.customer_state = "";
            }
            else
            {
                customer.customer_state = customerin.customer_state;
            }


            if (customerin.customer_country == "" || customerin.customer_country == "País")
            {
                customer.customer_country = "";
            }
            else
            {
                customer.customer_country = customerin.customer_country;
            }


            if (customerin.customer_email == "" || customerin.customer_email == "E-mail")
            {
                customer.customer_email = "";
            }
            else
            {
                customer.customer_email = customerin.customer_email;
            }


            return customer;

        }
    }
}