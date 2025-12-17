using Komercio.Models;
using Komercio.UI.Forms;
using MeuProjetoWinForms.Models;
using MeuProjetoWinForms.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komercio.ApplicationLayer
{
    public class EmployeeServiceApp
    {
        private readonly EmployeeService _employeeService;



        public EmployeeServiceApp(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        //retorno de form criado.
        public (DialogResult,int) ValidaLogin()
        {
            using (frmLogin login = new frmLogin(_employeeService))
            {
                int id = 0;
                var retorno = login.ShowDialog();

                if (retorno == DialogResult.OK)
                {
                    id = login.employeersId;
                }
                return (retorno,id);

            }

            
            //aplicação: Basta colar isso no form que deseja aplicar

            //private void ValidationLogin()
            //{
            //    var (retorno, id) = _employeeServiceApp.ValidaLogin();
            //    if (retorno == DialogResult.OK)
            //    {
            //        descarteProdutoDTO.Id_funcionario = id;
            //    }
            //    else
            //    {
            //        MessageBox.Show("ACESSO NEGADO", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //        this.Close();
            //    }
            //}
        }



    }
}
