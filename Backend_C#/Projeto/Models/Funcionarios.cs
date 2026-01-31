using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Projeto.Models
{
    public class Funcionario
    {
        public int EmployeeID { get; set; }
        public string? EmployeeFullName { get; set; }
        public string? EmployeeLogin { get; set; }
        public string? employeePassword { get; set; }



        public string? CriarLogin(string nomeCompleto)
        {
            string? login = null;
            var palavras = nomeCompleto.Split(' ');
      
            if (palavras.Length <=1)
            {
                return login;
            }

            var primeiraLetra = palavras[0][0];
            var ultimaPalavra = palavras[palavras.Length-1];

             login = primeiraLetra + "." + ultimaPalavra;

            return login; 
        }


        public bool ValidaTamanhoDaSenha(string password)
        {
            if (password.Length < 4)
            {
            return false;
            }

            return true;
        }
    }
}