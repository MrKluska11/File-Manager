using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public interface IDrivesInformations
    {
        List<string> DrivesNames { get; }
        string Name { get; set; }
        string Path { get; set; }
        decimal TotalSpace { get; }
        decimal FreeSpace { get; }
        string FileSystem { get; }
    }
}
