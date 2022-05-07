using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public interface IFileOperations
    {
        void open(IFileInformation file);
        void move(string pathFrom, string pathTo);
        void copy(string pathFrom, string pathTo);
        void delete(IFileInformation file);
        void rename(string path, string name);
        void displayProperties(string path, Form propertiesForm);
    }
}
