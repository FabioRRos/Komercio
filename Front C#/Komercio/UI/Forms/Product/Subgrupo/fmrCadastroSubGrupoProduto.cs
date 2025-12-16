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



        private readonly ProductGroupService _productGroupService;
        private readonly ProductSubgroupService _productSubgroupService;

        public fmrCadastroSubGrupoProduto(ProductSubgroupService productSubgroupService, ProductGroupService productGroupService)
        {
            _productGroupService = productGroupService;
            _productSubgroupService = productSubgroupService;


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
                productSubgroups = await _productSubgroupService.GetProductSubgroupAsync();
            }
            catch
            (Exception ex)
            {
                MessageBox.Show($"Não consegui baixar os subgrupos:\nERRO: {ex.Message}","ERROR!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            LoadGrid(productSubgroups);
        }

        public async void GetGrupo()
        {
            
            try
                {
                    productGroups = await _productGroupService.GetProductGroupAsync();
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
            dgwSubgrupo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;


        }

        public void AddLista()
        {
            productGroups = productGroups
    .OrderBy(p => p.ProductgroupName)
    .ToList();


            foreach (var item in productGroups)
            {
                mcbGrupo.Items.Add(item.ProductgroupName);
            }
        }

        private void mcbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
           List<ProductSubgroupDTO> productSubgroupsFiltrado = new List<ProductSubgroupDTO>();

        int id = 0;

            

            foreach (var item in productGroups)
            {
                if (mcbGrupo.Text == item.ProductgroupName)
                {
                    id = item.ProductgroupId;
                    break;
                }
            }

            foreach (var item in productSubgroups)
            {
                if (item.Product_group_id == id)
                {
                    productSubgroupsFiltrado.Add(item);
                }
            }

            LoadGrid(productSubgroupsFiltrado);
            ProductDTOSave.Product_group_id = id;

        }

        private void mbtCadastrar_Click(object sender, EventArgs e)
        {
            if(mcbGrupo.Text == "")
            {
                MessageBox.Show("Selecione o grupo que deseja adicionar o subgrupo", "ATENTÇÃO!");
                return;
            }

            if (mtbSubgrupo.Text == "")
            {
                MessageBox.Show("Por gentileza, digite o subgrupo", "ATENTÇÃO!");
                return;
            };


            ProductDTOSave.ProductsubgroupName = mtbSubgrupo.Text;
            SalvarSubGrupo();
            ReloadForm();
        }

        private void ReloadForm()
        {
            this.Controls.Clear();
            this.InitializeComponent();
            this.fmrCadastroSubGrupoProduto_Load(null, null);
        }


        private async void SalvarSubGrupo()
        {
            var retorno = await _productSubgroupService.CreateSubGroup(ProductDTOSave);


            if (retorno) MessageBox.Show("SubGrupo Criado com sucesso!");
            return ;

        }
    }
}
