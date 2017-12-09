//Cole Miller
//SqlTitleDatabase.cs
using Movie.Triogoles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Triogole.Sql
{
    public class SqlTitleDatabase : MovieDatabase
    {
        #region Construction 
        public SqlTitleDatabase(string connectionString)
        {
            _connectionString = connectionString; 
        }

        private readonly string _connectionString;
        #endregion

        protected override Titles AddCore(Titles title)
        {
            var id = 0;
            using (var conn = OpenDatabase())
            {
                var cmd = new SqlCommand("AddMovie", conn)
                { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = title.Title;
                cmd.Parameters.AddWithValue("@description", title.Episode);
                cmd.Parameters.AddWithValue("@Time", title.Time);
                cmd.Parameters.AddWithValue("@OWW", title.Own);

                id = Convert.ToInt32(cmd.ExecuteScalar());
            };

            return GetCore(id);
        }

        protected override IEnumerable<Titles> GetAllCore()
        {
            var titles = new List<Titles>();
            using (var connection = OpenDatabase())
            {
                var cmd = new SqlCommand("GetAlltitles", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var title = new Titles()
                        {
                            Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            Title = reader.GetFieldValue<string>(1),
                            Episode = reader.GetString(2),
                            Time = reader.GetDecimal(3),
                            Own = reader.GetBoolean(4)
                        };
                        titles.Add(title);
                    };
                };

                return titles;
            };
        }

        protected override Titles GetCore(int id)
        {
            using (var conn = OpenDatabase())
            {
                var cmd = new SqlCommand("GetMovie", conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id", id);

                var ds = new DataSet();
                var da = new SqlDataAdapter()
                {
                    SelectCommand = cmd,
                };

                da.Fill(ds);

                var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
                if (table != null)
                {
                    var row = table.AsEnumerable().FirstOrDefault();
                    if (row != null)
                    {
                        return new Titles()
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Title = row.Field<string>("Title"),
                            Episode = row.Field<string>("Episode"),
                            Time = row.Field<decimal>("time"),
                            Own = row.Field<bool>("isDiscontinued")
                        };
                    };
                };
            };
            return null; 
        }

        protected override void RemoveCore(int id)
        {
            using (var conn = OpenDatabase())
            {
                var cmd = conn.CreateCommand();

                cmd.CommandText = "RemoveMovie";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery(); 
            }
        }

        protected override Titles UpdateCore(Titles existing, Titles title)
        {
            using (var conn = OpenDatabase())
            {
                var cmd = new SqlCommand("UpdateMovie", conn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@id", existing.Id);
                    cmd.Parameters.AddWithValue("@Title", title.Title);
                    cmd.Parameters.AddWithValue("@Episode", title.Episode);
                    cmd.Parameters.AddWithValue("@Time", title.Time);
                    cmd.Parameters.AddWithValue("@Own", title.Own);

                    cmd.ExecuteNonQuery(); 
              
            };

            return GetCore(existing.Id); 
        }

        private SqlConnection OpenDatabase()
        {
            var connection = new SqlConnection(_connectionString);

            connection.Open();

            return connection; 
        }

    }
}
