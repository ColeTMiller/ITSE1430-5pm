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
        #region Construction 

        public ProductDeatailForm() //: base()
        {
            InitializeComponent();
        }
        public ProductDeatailForm( string title ) : this()
        {
            Text = title;
        }

        public ProductDeatailForm( string title, Product product ) : this(title)
        {
            Product = product;
        }
        #endregion 


        protected override void OnLoad( EventArgs e )
        { 
            base.OnLoad(e);
        
            if (Product !=null)
            {
                _txtName.Text = Product.Name;
                _txtDescription.Text = Product.Description;
                _txtPrice.Text = Product.Price.ToString();
                _txtDisconnected.Checked = Product.IsDiscontinued; 
            };
        }
        /// <summary>
        /// Gets or sets the product being shown. 
        /// </summary>
        public Product Product { get; set; }
        private void showError( string message, string title )
        {
            MessageBox.Show(this, message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void OnSave( object sender, EventArgs e )
        {
            var product = new Product();
            product.Name = _txtName.Text; 
            product.Description = _txtDescription.Text;
            product.Price = GetPrice();
            product.IsDiscontinued = _txtDisconnected.Checked; 
            Close();

            // Add Validation 
            var error = product.Validate();
            if (!String.IsNullOrEmpty(error))
            {
                // Show the error
                MessageBox.Show (error, "Validation Error"); 
                return; 
            }; 

            Product = product;
            this.DialogResult = DialogResult.OK; 
        }
        private decimal GetPrice()
        {
            if (Decimal.TryParse(_txtPrice.Text, out decimal price))
                return price;

            //tooo: Validate price
            //Product.Price = GetPrice();   
            return 0; 
        }
        private void ProductDetailForm_FormCanceling( object sender, FormClosingEventArgs e)
        {
            // Please no
            // var form = (Form)sender;
            //Please yes
            var form = sender as Form; 

            // casting for vlaue types
            if (sender is int)
            {
                var intValue2 = (int)sender; 
            };
            // Pattern matching
            if (sender is int intValue)
            {

            }; 

            if (MessageBox.Show(this, "Are you sure?", "Closing", MessageBoxButtons.YesNo) == DialogResult.No)
            e.Cancel = true; 
        }
        private void OnCancel( object sender, EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel; 
            Close(); 

        }
    }
}
