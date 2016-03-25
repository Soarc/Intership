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
        List<string> DbList;

        public DbCreator(DbManager manager)
        {
            _PrymeDict = new Dictionary<string, string>();
            column = new List<string>();
            column.Add("name");
            _manager = manager;
            DbList = new List<string>();
        }
        public bool IsDbCreated(string tableName)
        {
            bool gago = false; ;
          var data =_manager.ExecuteQuery("Sys.Databases", column, null);
            foreach (var item in data)
            {
                if (item.ToString() == tableName)
                    gago = true;


            }
            if (gago == true)
                return true;
            else
                return false;
        }

        public void CreateDb(string str)
        {
            string createQuery = $"CREATE DATABASE {str}";
            _manager.ExecuteCustomQuery(createQuery);
            this.CreateTable("Regions", new List<DbColumn>() {
                new DbColumn {Name = "RegionId",Type = "INT",isIdentity = true,IsPrimary = true  },
                new DbColumn {Name = "Reion",Type = "NVARCHAR(MAX)",IsNull = false }
            });
            _PrymeDict.Add("Regions", "RegionId");
            this.CreateTable("Cities", new List<DbColumn>() {
                new DbColumn {Name = "CityId",Type = "INT",isIdentity = true,IsPrimary = true  },
                new DbColumn {Name = "City",Type = "NVARCHAR(MAX)",IsNull = true }
            });
            _PrymeDict.Add("Cities", "CityId");
            this.CreateTable("Communities", new List<DbColumn>() {
                new DbColumn {Name = "CommunityId",Type = "INT",isIdentity = true,IsPrimary = true  },
                new DbColumn {Name = "Community",Type = "NVARCHAR(MAX)",IsNull = false }
            });
            _PrymeDict.Add("Communities", "CommunityId");
            this.CreateTable("Streets", new List<DbColumn>() {
                new DbColumn {Name = "StreetId",Type = "INT",isIdentity = true,IsPrimary = true  },
                new DbColumn {Name = "Street",Type = "NVARCHAR(MAX)",IsNull = false }
            });
            _PrymeDict.Add("Streets", "StreetId");
            this.CreateTable("Addresses", new List<DbColumn>() {
            new DbColumn {Name = "AddressId",Type = "INT",isIdentity = true,IsPrimary = true },
            new DbColumn { Name = "RegionId", Type = "INT", IsForeign = "Regions(RegionId)"},
            new DbColumn { Name = "CityId", Type = "INT",IsForeign = "Cities(CityId)"},
            new DbColumn { Name = "CommunityId", Type = "INT", IsForeign = "Communities(CommunityId)"},
            new DbColumn {Name = "StreetId",Type = "INT",IsForeign = "Streets(StreetId)" }
            //homeId
            });
            _PrymeDict.Add("Addresses", "AddressId");
            this.CreateTable("Persons", new List<DbColumn>() {
                new DbColumn {Name = "PersonId", Type = "INT",isIdentity = true,IsPrimary = true },
                new DbColumn {Name = "AddressId",Type = "INT", IsForeign = "Addresses(AddressId)"},
                new DbColumn {Name = "Name",Type = "NVARCHAR(MAX)",IsNull = false },
                new DbColumn {Name = "Surname",Type = "NVARCHAR(MAX)",IsNull = false },
                new DbColumn {Name = "Patronymic",Type = "NVARCHAR(MAX)",IsNull = false },
                new DbColumn {Name = "BirthDay",Type = "DATETIME",IsNull = false },
            });
            _PrymeDict.Add("Persons", "PersonId");
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
                if(columnList[i].IsForeign != null)
                {
                    query += $"FOREIGN KEY REFERENCES {columnList[i].IsForeign}";
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
            string value = "";
            if (_PrymeDict.ContainsKey(str))
            {
                 value = _PrymeDict[str];

            }
            return value;
           
        }
    }
}
