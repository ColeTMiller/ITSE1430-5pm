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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            _gridMovie.AutoGenerateColumns = false;

            UpdateList();

        }

        private Movie GetSelectedMovie()
        {
            if (_gridMovie.SelectedRows.Count > 0)
                return _gridMovie.SelectedRows[0].DataBoundItem as Movie;

            return null;
        }

        private void UpdateList()
        {
            _bsMovie.DataSource = _database.GetAll().ToList(); 
        }


        private void AddMovie( object sender, EventArgs e )
        {
            var child = new AddMovie("Add Movie");
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //save movie 
            _database.Add(child.Movie);
            UpdateList(); 
        }

        private void OnEditMovie( object sender, EventArgs e )
        {
            var product = GetSelectedMovie(); 
            if(product == null)
            {
                MessageBox.Show("No movie available.");
                return; 
            }

            EditMovie(Movie); 
        }

        private void EditMovie(Movie movie)
        {
            var child = new AddMovie("Movie Add");
            child.Movie = movie;

            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //Save product 
            _database.Update(child.Movie);
            UpdateList(); 
        }

        private void OnDeleteMovie( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;
            DeleteMovie(movie); 
        }
        private void DeleteMovie(Movie movie)
        {
            //Confirm 
            if (MessageBox.Show(this, $"Are you sure you wnat to delete '{movie.Title}'?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            //Delete product 
            _database.Remove(movie.Id);
            UpdateList(); 
        }
        private IProductDatabase _database = new Movieinformation.Database.SeedMemoryMovieDatabse(); 

        private void OnEditRow(object sender, DataGridViewCellEventArgs e)
        {
            var grid = sender as DataGridView;

            //Handle column clicks 
            if (e.RowIndex < 0)
                return;

            var row = grid.Rows[e.RowIndex];
            var item = row.DataBoundItem as Movie;

            if (item != null)
                EditMovie(item); 
        }

        private void OnKeyDownGrid(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                return;

            var movie = GetSelectedMovie();
            if (movie != null)
                DeleteMovie(movie); 
        }
        private void OnHelpAbout( object sender, EventArgs e )
        {

        }

        private void OnExit( object sender, EventArgs e )
        {
            Close(); 
        }
    }
}
