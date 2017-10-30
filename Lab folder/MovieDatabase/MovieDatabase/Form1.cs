using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _gridMovies.AutoGeneratieColums = false;

            UpdateList();
        }

        private Movie GetSelectedMovie()
        {
            if (_gridMovie.SelectedRow.Count > 0)
                return _gridMovie.SelectedRows[0].DataBoundItem as Movie;

            return null;
        }

        private void UpdateList()
        {
            _bsMovies.DataSource = _database.GetAll().ToList();
        }

        private void OnFileExit(object sender, EventArgs e)
        {
            Close();
        }
        
    }
}
