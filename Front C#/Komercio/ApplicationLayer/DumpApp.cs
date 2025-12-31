using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komercio.ApplicationLayer
{
    public class DumpApp
    {
        private SalesApp _salesApp;



        public DumpApp(SalesApp salesApp)
        {
            _salesApp = salesApp;
        }



        public async Task<bool> ExcluirVendaApp(int id)
        {
           return  await _salesApp.DeletarVendaApp(id);

        }


    }
}
