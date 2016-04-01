using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.PeopleDbBrowser.ViewModels
{
    class ImportViewModel
    {
        List<Folder> RootFolder;
        public ImportViewModel()
        {
            string[] drives = System.IO.Directory.GetLogicalDrives();
            RootFolder = new List<Folder>();
            foreach (string str in drives)
            {
                RootFolder.Add(new Folder
                {
                    Name = str,
                    Path = str
                });
            }
            /////
        }
    }
}
