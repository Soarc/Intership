using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.PeopleDbBrowser.DAL
{
    class DbManager
    {
        public IEnumerable ExecuteQuery(string table, List<string> col, string cond)
        {
            throw new NotImplementedException();
        }
        public void Delete (string table, int primKey)
        {
            //string delString = $"DELETE FROM {table} WHERE {db.name(table) = primKey }";
           // ExecuteCustomQuery(delString);
        }
        public void UpdateData(string table, List <object>val, string cond)
        {

        }
        public void ExecuteScalar(string table, string col, string agg)
        {

        }

    }
}
