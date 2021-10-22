using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using System.Data.SqlClient;


namespace DataLibrary.DataAccess
{
    /// <summary>
    /// Author Oujun Xu
    /// Class containing different methods/ functions to access and insert data to database.
    /// </summary>
    public static class SqlDataAccess
    {
        public static string GetConnectionString(string database = "", string Id = "", string password = "")
        {
            string connectionString = $"";

            return connectionString;
        }

        /**
         * Used as load function (delete and get functions).
         * @param sql queries for update of data stored inside the db.
         */
        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList(); //
            }
        }

        /**
         * Used as save function (insert to database).
         * @param sql queries for update of data stored inside the db.
         * @param data, also called the model in this case.
         */
        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data); //
            }
        }
    }
}
