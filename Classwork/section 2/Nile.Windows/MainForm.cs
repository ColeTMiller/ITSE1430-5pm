/**
 * Cole Miller
 * class Example 
 */
using System;
using System.Windows.Forms;

namespace Nile.Windows
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click( object sender, EventArgs e )
        {
            var child = new ProductDeatailForm();
            if ( child.ShowDialog(this) != DialogResult.OK)
                return; 

            //TODO: Save product
            var product = child.Product; 

        }
    }
}
