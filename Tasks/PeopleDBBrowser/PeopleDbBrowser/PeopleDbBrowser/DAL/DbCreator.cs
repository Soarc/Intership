﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.PeopleDbBrowser.DAL
{
    class DbCreator
    {
        DbManager _manager;

        public DbCreator(DbManager manager)
        {
            _manager = manager;
        }
        public bool IsDbCreated()
        {
            return true;
        }

        public void CreateDb()
        {

        }

        public string CreateTable(string table,List<string> ColumnName, List<string> ColumnTypes)
        {
            return table;
        }

    }
}
