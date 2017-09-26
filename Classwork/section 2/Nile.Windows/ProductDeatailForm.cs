using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nile.Windows
{
    public partial class ProductDeatailForm : Form
    {
        public ProductDeatailForm()
        {
            InitializeComponent();
        }
        public Product Product { get; set; }

        private void OnSave( object sender, EventArgs e )
        {
            var product = new Product();
            product.Name = _txtName.Text; 
            product.Description = _txtDescription.Text;
            product.Price = GetPrice();
            product.IsDiscontinued = _txtDisconnected.Checked; 
            Close();

            // TODO: Add Validation 
            Product = product;
            this.DialogResult = DialogResult.OK; 
        }
        private decimal GetPrice()
        {
            if (Decimal.TryParse(_txtPrice.Text, out decimal price))
                return price;

            //tooo: Validate price
           Product.Price = GetPrice();   
            return 0; 
        }
        private void OnCancel( object sender, EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel; 
            Close(); 

        }
    }
}
