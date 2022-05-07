using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileManager
{
    public class Directory : IDirectoryInformation
    {
        public int FilesNumber
        {
            get
            {
                int count = 0;
                List<string> files = System.IO.Directory.GetFiles(Path).ToList();
                List<string> directories = System.IO.Directory.GetDirectories(Path).ToList();

                foreach(string file in files)
                {
                    count++;
                }

                foreach(string directory in directories)
                {
                    count++;
                }

                return count;
            }
        }

        public decimal FilesSize
        {
            get
            {
                decimal totalSize = 0;
                int megabytes = 1024 * 1024;
                List<string> files = System.IO.Directory.GetFiles(Path).ToList();
                
                foreach(string file in files)
                {
                    var info = new FileInfo(file);
                    totalSize += info.Length / megabytes;
                }

                return totalSize;
            }
        }

        public string Name { get; set; }

        public string Path { get; set; }

        private string retrieveName(string path)
        {
            char slash = '\\';
            int position = path.LastIndexOf(slash);
            return path.Substring(position + 1, path.Length - (position + 1));
        }

        public Directory(string path)
        {
            this.Path = path;
            this.Name = retrieveName(path);

        }
    }
}
