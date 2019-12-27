using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataAccess
{
    public class DataAccess
    {
        public static string ConnectionString { get; set; } = GetConnectionString();
        private static string GetConnectionString(string connectionName = "test")
        {
            switch(connectionName.ToLower())
            {
                case "test":
                    {
                        return "testingConnectionString";
                    }

                default:
                    {
                        return "NormalConnectionString";
                    }
            }
        }

        public DataAccess(string connectionName = "test")
        {
            ConnectionString = GetConnectionString(connectionName);
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(ConnectionString))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(ConnectionString))
            {
                var response = cnn.Query<int>(sql, data).Single();
                return response;
                throw new Exception("Unexpected error while writing data");
            }
        }

        public static void ExecuteQuery(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(ConnectionString))
            {
                cnn.Query(sql);
            }
        }

        public static void UpdateQuery<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(ConnectionString))
            {
                cnn.Query<int>(sql, data);
            }
        }

        public static T GetSingleData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(ConnectionString))
            {
                return cnn.Query<T>(sql).ToList()[0];
            }
        }
    }
}
