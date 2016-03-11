using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Internship.PeopleDbBrowser.DAL
{
    class DbCreator
    {
        
        DbManager _manager;
        Dictionary<string, string> _PrymeDict;
        List<string> column;

        public DbCreator(DbManager manager)
        {
            _PrymeDict = new Dictionary<string, string>();
            column.Add("name");
            _manager = manager;
        }
        public bool IsDbCreated()
        {
            
          var data =_manager.ExecuteQuery("Sys.Databases", column, null);
            return true;
        }

        public void CreateDb(string str)
        {
            string createQuery = $"CREATE DATABASE {str}";
            _manager.ExecuteCustomQuery(createQuery);
            this.CreateTable("Addresses", new List<DbColumn>() {
            new DbColumn {Name = "Id",Type = "INT",isIdentity = true,IsPrimary = true },
            new DbColumn { Name = "Street", Type = "NVARCHAR(MAX)", IsNull = false},
            new DbColumn { Name = "House", Type = "NVARCHAR(MAX)",IsNull = false},
            new DbColumn { Name = "Flat", Type = "NVARCHAR(MAX)", IsNull = false},
            });
            _PrymeDict.Add("Addresses", "Id");
            this.CreateTable("FullList", new List<DbColumn>() {
                new DbColumn {Name = "No", Type = "INT",isIdentity = true,IsPrimary = true },
                new DbColumn {Name = "LastName",Type = "NVARCHAR(MAX)",IsNull = false },
                new DbColumn {Name = "Name",Type = "NVARCHAR(MAX)",IsNull = false },
                new DbColumn {Name = "Patronymic",Type = "NVARCHAR(MAX)",IsNull = false },
                new DbColumn {Name = "BirthDay",Type = "DATETIME",IsNull = false },
                new DbColumn {Name = "Address",Type = "NVARCHAR(MAX)",IsNull = false },
                new DbColumn {Name = "Territory",Type = "INT",IsNull = false },
                new DbColumn {Name = "Section",Type = "NVARCHAR(20)",IsNull = false },
            });
            _PrymeDict.Add("FullList", "No");
            this.CreateTable("Regions", new List<DbColumn>() {
                new DbColumn { Name = "No", Type = "INT", IsNull = false },
                new DbColumn {Name = "RegionName", Type = "NVARCHAR(MAX)",IsNull = false }
            });

            this.CreateTable("Community", new List<DbColumn>() {
                new DbColumn { Name = "No", Type = "NVARCHAR(MAX)", IsNull = false },
                new DbColumn {Name = "CommunityName", Type = "NVARCHAR(MAX)",IsNull = false }
            });




        }


        public string CreateTable(string tableName, List<DbColumn> columnList)
        {
            string FirstPart = $"CREATE TABLE {tableName} (";
            string query = "";
            for (int i = 0; i < columnList.Count; i++)
            {


                if (columnList[i].Name != null)
                {
                    query += $" /n { columnList[i].Name} ";
                }
                if (columnList[i].Type != null)
                {
                    query += $"{columnList[i].Type} ";
                }

                if (columnList[i].isIdentity == true)
                {
                    query += $"IDENTITY(1,1) ";
                }
                if (columnList[i].IsNull != true)
                {
                    query += $"NOT NULL ";
                }
                else { query += ", /n"; }

                if (columnList[i].IsPrimary == true)
                {
                    query += $"PRIMARY KEY,/n";
                }
                else { query += ", /n"; }

            }
            query = query.Remove(query.Length - 1);
            query = query.Remove(query.Length - 1);
            query += $");";

            query = FirstPart + query;
            return query;
        }
        public string GetTablePrimaryKey(string str)
        {
            if (_PrymeDict.ContainsKey(str))
            {
                string value = _PrymeDict[str];

            }
            return str;
           
        }
    }
}
