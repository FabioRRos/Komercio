using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KomercioPlus.Model.Entity
{
    public class ServiceResponse<T>
    {
        public T? Dados {get;set;}
        public bool Status {get;set;}
        public string? Mensagem {get;set;}
    }
}