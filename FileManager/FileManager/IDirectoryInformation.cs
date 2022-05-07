using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public interface IDirectoryInformation
    {
        string Name { get; set; }
        string Path { get; set; }
        int FilesNumber { get; }
        decimal FilesSize { get; }
    }
}
