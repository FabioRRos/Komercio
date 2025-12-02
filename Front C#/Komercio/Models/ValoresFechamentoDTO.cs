using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.Models
{
    public class ValoresFechamentoDTO
    {
        public float Dinheiro { get; set; } = 0;
        public float Debito { get; set; } = 0;
        public float Credito { get; set; } = 0;
        public float Pix { get; set; } = 0;
        public float Conta { get; set; } = 0;
        public float Sangria { get; set; } = 0;
        public float Entrada { get; set; } = 0;
        public float Saida { get; set; } = 0;
        public float Restante { get; set; } = 0;

    }
}
