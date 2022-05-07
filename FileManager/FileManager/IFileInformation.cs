using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public interface IFileInformation
    {
        string Name { get; set; }
        string Path { get; set; }
        decimal Size { get; }
        string Type { get; }
        DateTime CreationDate { get; }
        bool ReadOnly { get; }
    }
}
