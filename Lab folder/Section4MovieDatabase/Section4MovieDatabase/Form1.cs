
using Movie;
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
    public partial class Form1 : Form
    {
        #region Constructions 
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _miFileExit.Click += (o, ea) => Close();

            var connString = ConfigurationManager.ConnecitonStrings["MovieDatabase"].ConnectionString;
            _database = new Movie.Films.Sql.SqlMovieDatabase(connString);

            _gridMovies.AutoGenerateColumns = false;

            UpdateList();
        }
        private void eitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void OnMovieDelete(object sender, EventArgs e)
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

           DeleteMovie(movie);
        }

        private void OnMovieAdd(object sender, EventArgs e)
        {
            var child = new MovieDetailForm("Movie Details");
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                _database.Add(child.Movie);
            } catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {
                DisplayError(ex, "Validation Failed");
            } catch (Exception ex)
            {
                DisplayError(ex, "Add Failed");
            };
            UpdateList();
        }

        private void OnMovieEdit(object sender, EventArgs e)
        {
            var movie = GetSelectedMovie();
            if (movie == null)
            {
                MessageBox.Show("No movies available");
                return;
            }

            EditMovie(movie);
        }

        private void OnEditRow(object sender, DataGridViewCellEventArgs e)
        {
            var grid = sender as DataGridView;

            if (e.RowIndex < 0)
                return;

            var row = grid.Rows[e.RowIndex];
            var item = row.DataBoundItem as Movie;

            if(item != null)
                EditMovie(item); 
        }

        private void OnKeyDownGrid(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            var movie = GetSelectedMovie();
            if (movie != null)
                DeleteMovie(movie);

            e.SuppressKeyPress = true; 
        }
        #region shh Private

        private void DeleteMovie( Movie movie)
        {
            if (MessageBox.Show(this, $"Are you sure you want to delete'{Movie.Title}'?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                _database.Remove(movie.Id);
            } catch (Exception e)
            {
                DisplayError(e, "DeleteFailed");
            };
            UpdateList();
        }

        private void DisplayError(Exception error, string title = "Error")
        {
            DisplayError(error.Message, title);
        }

        private void DisplayError(string message, string title = "Error")
        {
            MessageBox.Show(this, message, title ?? "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EditMovie( Movie movie)
        {
            var child = new MovieDetailForm("Movie Detail");
            child.Movie = movie;
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                _database.Update(child.ProductName);
            } catch (Exception ex)
            {
                DisplayError(ex, "Update Failed");
            };

            UpdateList();
        }

        private MovieDetailForm GetSelectedMovie()
        {
            if (_gridMovies.SelectedRows.Count > 0)
                return _gridMovies.SelectedRows[0].DataBoundItem as Movie;

            return null;
        }

        private UpdateList()
        {
            try
            {
                _bsMovie.DataSource = _database.GetAll().ToList();
            } catch (Exception e)
            {
                DisplayError(e, "Refresh Failed");
                _bsMovies.DataSource = null;
            };
        }

        private IMovieDatabase _database;
        #endregion
    }
}
