using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieUI
{
    public partial class MovieDetailFormcs : Form
    {
        #region Construction 
        public MovieDetailFormcs() //: base() 
        {
            InitializeComponent();
        }
        public MovieDetailFormcs (string title) : this()
        {
            Text = title;
        }

        public MovieDetailFormcs(string title, Movie movie) : this(title)
        {
            movie = movie; 
        }
        #endregion

        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad(e);

            if (Movie != null)
            {
                _txtTitle.Text = Movie.Title;
                _txtEpisode.Text = Movie.Episode;
                _txtPrice.Text = Movie.Price;
                _chkOwn.Checked = Movie.Own; 
            }
            ValidateChildren(); 
        }

        public Movie movie { get; set; } 

        private void textBox1_TextChanged( object sender, EventArgs e )
        {

        }

        private void _txtEpisode_TextChanged( object sender, EventArgs e )
        {

        }

        private void _txtTime_TextChanged( object sender, EventArgs e )
        {

        }

        private void _chkOwn_CheckedChanged( object sender, EventArgs e )
        {

        }

        private void _btSave_Click( object sender, EventArgs e )
        {

        }

        private void _btnCancel_Click( object sender, EventArgs e )
        {

        }
    }
}
