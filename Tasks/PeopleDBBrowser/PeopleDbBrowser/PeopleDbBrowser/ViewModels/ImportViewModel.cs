using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.PeopleDbBrowser.ViewModels
{
    class ImportViewModel
    {
        List<FolderViewModel> RootFolder;
        public ImportViewModel()
        {
            string[] drives = System.IO.Directory.GetLogicalDrives();
            RootFolder = new List<FolderViewModel>();
            foreach (string str in drives)
            {
                RootFolder.Add(new FolderViewModel
                {
                    Name = str,
                    Path = str
                });
            }
        }
    }
}
