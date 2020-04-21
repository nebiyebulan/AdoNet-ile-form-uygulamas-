﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }
        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new product {
                Name = tbxName.Text,
            UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
            StockAmount=Convert.ToInt32(tbxStockAmount.Text)
        });
            LoadProducts();
            MessageBox.Show("product added.");
        }



        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitePriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            product product = new product
            {
            Id=Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
            Name=tbxNameUpdate.Text,
            UnitPrice=Convert.ToDecimal(tbxUnitePriceUpdate.Text),
            StockAmount=Convert.ToInt32(tbxStockAmountUpdate.Text)
            
            };
            _productDal.Update(product);
            LoadProducts();
            MessageBox.Show("updated");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value);
            _productDal.Delete(id);
            LoadProducts();
            MessageBox.Show("Deleted");
        }
    }
}
