using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.Services
{
    public class DoccumentValidationService
    {
        public DoccumentValidationService(string cPF_CNPJ)
        {
            CPF_CNPJ = cPF_CNPJ;
        }

        public string CPF_CNPJ { get; set; }




        public bool ValidarCPFeCNPJ()
        {

            string numeros = new string(CPF_CNPJ.Where(char.IsDigit).ToArray());

            switch (numeros.Length)
            {
                case 11:
                    return ValidarCPF(numeros);
                case 14:
                    return ValidarCNPJ(numeros);
                default:
                    return false;
            }


        }



        public bool ValidarCPF(string cpf)
        {
            if (cpf.Length != 11 || cpf.Distinct().Count() == 1)
                return false;

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * (10 - i);

            int resto = soma % 11;
            int digito1 = (resto < 2) ? 0 : 11 - resto;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (cpf[i] - '0') * (11 - i);

            resto = soma % 11;
            int digito2 = (resto < 2) ? 0 : 11 - resto;

            return cpf[9] - '0' == digito1 && cpf[10] - '0' == digito2;

        }



        public bool ValidarCNPJ(string cnpj)
        {
            if (cnpj.Length != 14 || cnpj.Distinct().Count() == 1)
                return false;

            int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string cnpjBase = cnpj.Substring(0, 12);
            int soma = 0;
            for (int i = 0; i < 12; i++)
                soma += (cnpjBase[i] - '0') * multiplicador1[i];

            int resto = soma % 11;
            int digito1 = (resto < 2) ? 0 : 11 - resto;

            cnpjBase += digito1;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += (cnpjBase[i] - '0') * multiplicador2[i];

            resto = soma % 11;
            int digito2 = (resto < 2) ? 0 : 11 - resto;

            return cnpj.EndsWith($"{digito1}{digito2}");

        }


    }
}
