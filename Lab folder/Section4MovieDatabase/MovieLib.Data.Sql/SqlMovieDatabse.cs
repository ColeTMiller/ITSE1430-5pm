using Movie;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Data.Sql
{
    public class SqlMovieDatabse : IMovieDatabase 
    {
        #region Construction
        public SqlMovieDatabase (string connectionString)
        {
            _connectionStirng = connectionString;
        }

        private readonly string _connectionString;
        #endregion
        protected override Movie (Movie movie)
        {
            var id = 0;
            using (var CONN = OpenDatabse())
            {
                var cmd = new SqlCommand("AddMovie", CONN) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = movie.Title;
                cmd.Parameters.AddWithValue("@Episode", movie.Episode);
                cmd.Parameters.AddWithValue("@Time", movie.Time);
                cmd.Parameters.AddWithValue("@Own", movie.Own);

                id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return GetCore(id);
        }

        protected override IEnumerable<Movie> GetAllCore()
        {
            var movies = new List<Movie>();
            using (var connection = OpenDatabse())
            {
                var cmd = new SqlCommand("GetAllMovies", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var movie = new Movie()
                        {
                            Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            Title = reader.GetFieldValue<string>(1),
                            Episode = reader.GetString(2),
                            Time = reader.GetDecimal(3),
                            Own = reader.GetBoolean(4)
                        };
                        movie.Add(movie);
                    };
                };

                return movies;
            };
        }

        protected override Movie GetCore(int id)
        {
            using (var conn = OpenDatabse())
            {
                var cmd = new SqlCommand("GetMOvie", conn) { CommandType = CommandType.StoredMovie };
                cmd.Parameters.AddWithValue("@id", id);

                var ds = new DataSet();
                var da = new SqlDataAdapter()
                {
                    SelectCommand = cmd
                };

                da.Fill(ds);

                var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
                if (table != null)
                {
                    var row = table.AsEnumerable().FirstOrDefault();
                    if (row != null)
                    {
                        return new Movie()
                        {
                            id = Convert.ToInt32(row["Id"]),
                            Title = row.Field<string>("Title"),
                            Episode = row.Field<string>("Episode"),
                            Time = row.Field<decimal>("Time"),
                            Own = row.Field<bool>("Own")

                        };
                    };
                };
            }
            return null;
        }
        protected override void RemoveCore(int id)
        {
            using (var conn = OpenDatabse())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "RemoveMovie";
                cmd.CommandType = CommandType.StoredProcedure;

                var parameter = new SqlParameter("@id", id);
                cmd.Parameters.Add(parameter);

                cmd.ExecuteNonQuery();
            }

        }

        protected override Movie upDateCore(Movie existing, Movie movie)
        {
            using (var conn = OpenDatabse())
            {
                var cmd = new SqlCommand("UpdateMovie", conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id", existing.id);
                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@Episode", movie.Episode);
                cmd.Parameters.AddWithValue("@Time", movie.Time);
                cmd.Parameters.AddWithValue("@Own", movie.Own);

                cmd.ExecuteNonQuery();


            }
            return GetCore(existing.id);
        }

        private SqlConnection OpenDatabse()
        {
            var connection = new SqlConnection(_connectionString);

            connection.Open();

            return connection;
        }
    }
}
