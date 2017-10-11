using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_Cole_Miller
{
    public partial class Movie2 : Form
    {
        #region
        public Movie2() //: base 
        {
            InitializeComponent();
        }
        public Movie2( string title ) : this()
        {
            Text = title; 
        }
        public Movie2(string title, Program Program ) : this(title)
        {
            Program = Program;
        }
        #endregion
        private void Movie2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click( object sender, EventArgs e )
        {

        }
    }
}
