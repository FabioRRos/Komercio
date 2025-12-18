using Komercio.ApplicationLayer;
using Komercio.Models;
using Komercio.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Komercio.UI.Forms.Product
{
    public partial class fmrCadastroSubGrupoProduto : Form
    {

        private List<ProductSubgroupDTO> productSubgroups = new List<ProductSubgroupDTO>();
        private List<ProductgroupDTO> productGroups = new List<ProductgroupDTO>();

        private ProductSubgroupDTO ProductDTOSave = new ProductSubgroupDTO();

        private readonly ProdutoApp _produtoApp;




        public fmrCadastroSubGrupoProduto(ProdutoApp produtoApp)
        {
            _produtoApp = produtoApp;

            InitializeComponent();
           
        }

        private void fmrCadastroSubGrupoProduto_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            GetGrupo();
           GetSubgroup();
        }


        public async void GetSubgroup()
        {
            productSubgroups.Clear();
            try
            {
                productSubgroups = await _produtoApp.GetListaDeSubGrupoDeProduto();
            }
            catch
            (Exception ex)
            {
                MessageBox.Show($"Não consegui baixar os subgrupos:\nERRO: {ex.Message}","ERROR!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
           
        }

        public async void GetGrupo()
        {
            
            try
                {
                productGroups = await _produtoApp.GetListaDeGrupoDeProduto();
                }
            catch(Exception ex)
                {
                    MessageBox.Show($"Não consegui baixar os subgrupos:\nERRO: {ex.Message}", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            AddLista();
        }

        

        public void LoadGrid(List<ProductSubgroupDTO> lista)
        {
            dgwSubgrupo.BackgroundColor = Color.White;
            dgwSubgrupo.BorderStyle = BorderStyle.None;
            dgwSubgrupo.RowHeadersVisible = false;

            dgwSubgrupo.DataSource = lista;

            dgwSubgrupo.Columns["ProductsubgroupId"].Visible = false;
            dgwSubgrupo.Columns["Product_group_id"].Visible = false;

            dgwSubgrupo.Columns["ProductsubgroupName"].HeaderText = "Subgrupo";
            dgwSubgrupo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



        }

        public void AddLista()
        {
            dggroup.DataSource = productGroups;

            dggroup.Columns["ProductgroupId"].Visible = false;
            dggroup.Columns["ProductgroupName"].HeaderText = "Grupo:";
            dggroup.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dggroup.BackgroundColor = Color.White;
            dggroup.BorderStyle = BorderStyle.None;
            dggroup.RowHeadersVisible = false;

        }


        private void dggroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

                RecarregarFormdeSubGrupo();
               

            
        }
        private void RecarregarFormdeSubGrupo()
        {
            if (dggroup.CurrentRow == null || dggroup.CurrentRow.Cells["ProductgroupId"].Value == null)
                return;

             var id = Convert.ToInt32(dggroup.CurrentRow.Cells["ProductgroupId"].Value);


            // Filtra os subgrupos que pertencem a esse grupo
            List<ProductSubgroupDTO> productSubgroupsFiltrado = productSubgroups
                    .Where(sub => sub.Product_group_id == id)
                    .ToList();

                // Atualiza o grid com os subgrupos filtrados
                LoadGrid(productSubgroupsFiltrado);

                // Salva o id do grupo selecionado no DTO
                ProductDTOSave.Product_group_id = id;

        }






        private void ReloadForm()
        {
            this.Controls.Clear();
            this.InitializeComponent();
            this.fmrCadastroSubGrupoProduto_Load(null, null);
        }


        private async void SalvarSubGrupo()
        {
            var retorno = await _produtoApp.SalvarSubGrupo(ProductDTOSave);


            if (retorno) MessageBox.Show("SubGrupo Criado com sucesso!");
            return ;

        }

        private void mbtCadastrar_Click_1(object sender, EventArgs e)
        {
            if (dggroup.CurrentRow == null)
            {
                MessageBox.Show("Selecione o grupo que deseja adicionar o subgrupo", "ATENÇÃO!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (mtbSubgrupo.Text == "")
            {
                MessageBox.Show("Por gentileza, digite o subgrupo", "ATENTÇÃO!");
                return;
            }
            ;


            ProductDTOSave.ProductsubgroupName = mtbSubgrupo.Text;
            SalvarSubGrupo();
            ReloadForm();



        }
    }
}
