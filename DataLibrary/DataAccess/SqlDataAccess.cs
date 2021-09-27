using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System;
using Microsoft.Extensions.Configuration;

namespace DataLibrary.DataAccess
{
    /**
     * This class is used for connection with the database.
     * 
     * "Server=XUOUJUN\\SQLEXPRESS;Trusted_Connection=false;User id=anders;password=anders96;MultipleActiveResultSets=true"
     */
    public static class SqlDataAccess
    {
        public static string GetConnectionString(string database="GenshinDB", string Id = "anders", string password = "anders96")
        {
            string connectionString = $"Server=XUOUJUN\\SQLEXPRESS;Database=GenshinDB;Trusted_Connection=false;User id = {Id}; password={password};MultipleActiveResultSets=true";

            return connectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }
    }
}
