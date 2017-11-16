using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Section4MovieDatabase
{
    public partial class MovieDetailForm : Form
    {
        #region Construction

        public MovieDetailForm()
        {
            InitializeComponent();
        }
        public MovieDetailForm(string title) : this()
        {
            Text = title;
        }
        #endregion

        public Movie Movie { get; set; }

        private void _txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void _txtEpisode_TextChanged(object sender, EventArgs e)
        {

        }

        private void _txtTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void _chkOwn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void OnSave(object sender, EventArgs e)
        {
            if(!ValidateChildren())
            {
                return;
            }
            // Create a new Movie
            var movie = new Movie()
            {
                Id = Movie?.Id ?? 0,
                Title = _txtTitle.Text,
                Episode = _txtEpisode.Text,
                Time = GetTime(_txtTime),
                Own? = _chkOwn.Checked,
            }; 

            // Validte 
            if(!ObjectValidator. TryValidate(movie, out var errors))
            {
                // show the error
                ShowError("Not valid", "Validation Error");
                return; 
            };
            Movie = movie;
            DialogResult = DialogResult.OK;
            Close(); 
        }

        private void OnCancel(object sender, EventArgs e)
        {

        }

        private decimal GetTime(TextBox control)
        {
            if (Decimal.TryParse(control.Text, out decimal time))
                return time;

            return -1; 
        }
     private void ShowError( string message, string title)
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }
    }
}
