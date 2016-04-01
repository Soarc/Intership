using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.PeopleDbBrowser.ViewModels
{
    class Folder
    {
        List<Folder> _subFolder;
        public List<Folder> SubFolder
        {
            get
            {
                if (_subFolder == null)
                    LoadSubFolders();
                return _subFolder;
            }
        }

        private void LoadSubFolders()
        {
            _subFolder = new List<Folder>();
            var currentFolderInfo = new DirectoryInfo(this.Path);
            var subfolderInfo = currentFolderInfo.GetDirectories();
            foreach (var sf in subfolderInfo)
                _subFolder.Add(new Folder
                {
                    Name = sf.Name,
                    Path = sf.FullName

                });


        }

        List<File> _files;
        public List<File> Files
        {
            get
            {
                if (_files == null)
                    LoadFiles();
                return _files;
            }
        }

        private void LoadFiles()
        {
            var directoryInfo = new DirectoryInfo(this.Name);
            var filesInfo = directoryInfo.GetFiles();
            _files = new List<File>();

            foreach (var files in filesInfo)
                _files.Add(new File
                {
                    Name = files.Name,
                    Path = files.FullName

                });
        }

        public string Name { get; set; }
        public string Path { get; set; }


    }
}
