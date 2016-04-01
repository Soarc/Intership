using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Internship.PeopleDbBrowser.Core;
namespace Internship.PeopleDbBrowser.DAL
{
    public class DbManager
    {

        


        string _connectionString;
        SqlConnection _connection;
        DbSettings _dbSetting;

        DbCreator DBCreator { get; }

        
        public void Initialize()
        {
            // Creating ConnectionString from DbSettings
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = _dbSetting.Datasource;
            builder.IntegratedSecurity = _dbSetting.IntegratedSecurity;

            if (!builder.IntegratedSecurity)
            {
                builder.UserID = _dbSetting.Login;
                builder.Password = _dbSetting.Password;
            }

            builder.InitialCatalog = _dbSetting.Initialcatalogue;
            _connectionString = builder.ConnectionString;

            _connection = new SqlConnection(_connectionString);
        }

        public IEnumerable ExecuteQuery(string table, List<string> col, string cond)
        {
            throw new NotImplementedException();

        }
        
        public int InsertData(string table, List<string> col, List<string> val)
        {
            string colNames = "(";
            string values = "(";

            for (int i = 0; i < col.Count; i++)
            {
                colNames += $"{col[i]}, ";
                values += $"{val[i]}, ";
            }

            int colNamesLen = colNames.Length;
            int valuesLen = values.Length;

            colNames = colNames.Substring(0, colNamesLen -2);
            values = values.Substring(0, valuesLen - 2);

            string query = $"INSERT INTO {table} {colNames}) VALUES {values})";

            return ExecuteCustomQuery(query);
        }

        public int Delete(string table, string cond)
        {
            string delString = $"DELETE FROM {table} WHERE {cond}";
            return ExecuteCustomQuery(delString);
        }

        public void Delete(string table, int primKey)
        {
            string primKeyCol = DBCreator.GetTablePrimaryKey(table);
            string query = $"DELETE FROM {table} WHERE {primKeyCol}={primKey}";
        }

        public int UpdateData(string table, List<object> col, List<object> val, string cond)
        {
            string query = $"UPDATE {table} SET ";

            string queryParts = "";

            for (int i = 0; i < col.Count; i++)
        {
                queryParts += $"{col[i]}={val[i]}, ";
            }

            queryParts = queryParts.Substring(0, queryParts.Length - 2);

            query += queryParts;
            query += $"WHERE {cond}";

            return ExecuteCustomQuery(query);
        }

        public Object ExecuteScalar(string table, string col, string agg)
        {
            string query = $"SELECT {agg}({col}) FROM {table}";

            object result = null;

            if (_connection != null)
            {
                _connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, _connection))
        {
                    result = cmd.ExecuteScalar();
        }

                _connection.Close();
            }
        
            return result;
        }




        public int ExecuteCustomQuery(string query)
        {
            int rowsAffected = 0;
            if (_connection != null)
            {
                _connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, _connection))
                {
                    rowsAffected = cmd.ExecuteNonQuery();
                }

                _connection.Close();
            }
            return rowsAffected;
        }

       



    }
}
