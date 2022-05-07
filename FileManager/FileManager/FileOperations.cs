using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileManager
{
    public class FileOperations : IFileOperations
    {
        public void copy(string pathFrom, string pathTo)
        {
            try
            {
                File.Copy(pathFrom, pathTo);
                MessageBox.Show("File has been copied.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                string description = "While copying file occurred and error: ";
                MessageBox.Show(description + ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void delete(IFileInformation file)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this file from your hard disk?", "Question", 
                                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                try
                {
                    System.IO.File.Delete(file.Path);
                    MessageBox.Show("File '" + file.Name + " ' has been deleted from your hard disk.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    string description = "While deleting file occurred a problem: ";
                    MessageBox.Show(description + ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }          
        }

        public void displayProperties(string path, Form propertiesForm)
        {
            throw new NotImplementedException();
        }

        public void move(string pathFrom, string pathTo)
        {
            try
            {
                System.IO.File.Move(pathFrom, pathTo);
                MessageBox.Show("File has been moved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                string description = "While moving file occurred a problem: " + ex.Message;
                MessageBox.Show(description, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void open(IFileInformation file)
        {
            try
            {
                System.IO.File.Open(file.Path, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            }
            catch(Exception ex)
            {
                string description = "While opening file occurred a problem: ";
                MessageBox.Show(description + ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        public void rename(string path, string name)
        {
            throw new NotImplementedException();
        }
    }
}
