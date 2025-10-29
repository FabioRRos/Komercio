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

        public CustomerDto() 
        { 
        }

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


            if (customerin.customer_first_name == "")
            {
                MessageBox.Show("O campo 'Nome' é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            else
            {
                customer.customer_first_name = customerin.customer_first_name.Trim();
            }



            if (customerin.customer_last_name == "")
            {
                MessageBox.Show("O campo 'Sobrenome' é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;

            }
            else
            {
                customer.customer_last_name = customerin.customer_last_name.Trim();
            }

            if (customerin.customer_document == "")
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
                customer.customer_phone = customerin.customer_phone
                    .Replace("(", "")
                    .Replace(")", "")
                    .Replace("-", "")
                    .Replace(" ", "");        

                customer.customer_mobile = customerin.customer_mobile
                    .Replace("(", "")
                    .Replace(")", "")
                    .Replace("-", "")
                    .Replace(" ", "");
                       
                customer.customer_zip_code = customerin.customer_zip_code
                    .Replace("-", "")
                    .Replace(" ", "");

            customer.customer_address_line = customerin.customer_address_line; 
            customer.customer_neighborhood = customerin.customer_neighborhood;
            customer.customer_city = customerin.customer_city;
            customer.customer_state = customerin.customer_state;
            customer.customer_country = customerin.customer_country;
            customer.customer_email = customerin.customer_email;
           
            return customer;

        }
    }
}