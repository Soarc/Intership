﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Internship.PeopleDbBrowser.Core;
using System.Collections;

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

      

        public void UpdateData(string table, List<object> col, List<object> val, string cond)
        {

        }

        public void ExecuteScalar(string table, string col, string agg)
        {
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

        public void Delete(string table, int primKey)
        {
           // string delString = $"DELETE FROM {table} WHERE {db.name(table) = primKey }";
            //ExecuteCustomQuery(delString);
        }


    }
}
