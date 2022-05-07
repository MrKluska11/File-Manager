using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public enum MovingOperations
    {
        Copy,
        Move
    }

    public partial class FormFileMoving : Form
    {
        private string pathFrom;
        private string pathTo;
        private IFileOperations fileOperations;
        private MovingOperations operation;

        public FormFileMoving(string path, MovingOperations operation)
        {
            InitializeComponent();

            this.pathFrom = path;
            this.operation = operation;
            fileOperations = new FileOperations();

            lblPath.Text = "Path: " + this.pathFrom;
            txtFrom.Text = this.pathTo;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(operation == MovingOperations.Copy)
            {
                fileOperations.copy(pathFrom, pathTo);
                this.Close();
            }
            else if(operation == MovingOperations.Move)
            {
                fileOperations.move(pathFrom, pathTo);
                this.Close();  
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTo_TextChanged(object sender, EventArgs e)
        {
            this.pathTo = txtTo.Text;
        }
    }
}
