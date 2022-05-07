using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class FileInformation : IFileInformation
    {
        public DateTime CreationDate
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name { get; set; }

        public string Path { get; set; }

        public bool ReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public decimal Size
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private string generateName(string path)
        {
            char slash = '\\';
            int position = path.LastIndexOf(slash);
            return path.Substring(position + 1, path.Length - (position + 1));
        }

        public FileInformation(string path)
        {
            this.Path = path;
            this.Name = generateName(path);

        }
    }
}
