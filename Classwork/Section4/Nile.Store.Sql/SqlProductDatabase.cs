using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Stores.Sql
{
    class SqlProductDatabase : ProductDatabase
    {
        protected override Product AddCore( Product product )
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<Product> GetAllCore()
        {
            var connString = @"Server=(localdb_\ProjectsV13;Databse=NileDatabse; Integrated Security=True;"; 
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();

                return new Product[0]; 
            }; 
            
        }

        protected override Product GetCore( int id )
        {
            throw new NotImplementedException();
        }

        protected override void RemoveCore( int id )
        {
            throw new NotImplementedException();
        }

        protected override Product UpdateCore( Product existing, Product newItem )
        {
            throw new NotImplementedException();
        }
    }
}
