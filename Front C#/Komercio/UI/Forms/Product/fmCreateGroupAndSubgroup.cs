using Komercio.Models;
using Komercio.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Komercio.UI.Forms.Product
{
    public partial class fmCreateGroupAndSubgroup : Form
    {
        public List<ProductgroupDTO> productgroup = new List<ProductgroupDTO>();
        public List<ProductSubgroupDTO> productsubgroup = new List<ProductSubgroupDTO>();
        public fmCreateGroupAndSubgroup()
        {
            InitializeComponent();
            ListGroup();
            Listsubgroup();
        }

        private void fmCreateGroupAndSubgroup_Load(object sender, EventArgs e)
        {

        }

        private void btNewGroup_Click(object sender, EventArgs e)
        {

            btSaveNewGroup.Enabled = true;
            mtbGroup.Enabled = true;
            btNewGroup.Enabled = false;

        }

        private void btNewSubgroup_Click(object sender, EventArgs e)
        {
            btSaveSubGroup.Enabled = true;
            mtbSubgroup.Enabled = true;
            btNewSubgroup.Enabled = false;
        }

        public async void ListGroup()
        {
            ProductGroupService productlist = new ProductGroupService("http://localhost:8000/");

            productgroup = await productlist.GetProductGroupAsync();

        }


        public async void Listsubgroup()
        {
            ProductSubgroupService productlist = new ProductSubgroupService("http://localhost:8000/");

            productsubgroup = await productlist.GetProductSubgroupAsync();

        }

    }
}
