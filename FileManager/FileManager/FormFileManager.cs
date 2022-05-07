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
    public partial class FormFileManager : Form
    {
        private FormTree treeForm;
        private ToolStripComboBox comboDrives;
        private IDrivesInformations drivesInfo;
        private IDrivesInformations drive;
        private IFileOperations fileOperations;
        private INodeOperations nodeOperations;
        private FormFileMoving formFileMoving;

        public FormFileManager()
        {
            InitializeComponent();

            comboDrives = toolComboDrives;
            drivesInfo = new Drive();
            fileOperations = new FileOperations();  //we set this here for nearest time
            nodeOperations = new NodeOperations();

            setComboDrive();
            setTreeForm();
        }

        #region methods

        private void setTreeForm()
        {
            treeForm = new FormTree(comboDrives, lblStatusFiles, nodeOperations);  //przekazanie comboBoksa do konstruktora z FormFileManager do FormTree ma być w opisie!!!
            treeForm.MdiParent = this;
            treeForm.Show();
        }

        private void setComboDrive()
        {
            List<string> names = drivesInfo.DrivesNames;

            foreach(string name in names)
            {
                comboDrives.Items.Add(name);
            }

            comboDrives.SelectedIndex = 1;   //zmien pozniej na 0
        }

        private void setDriveStatusLabel(string path)
        {
            drive = new Drive(path);
            string status = drive.Name + " Total: " + drive.TotalSpace + " GB, Free: " + drive.FreeSpace + " GB";
            lblStatusFreeTotal.Text = status;
        }

        private void refreshListViewItems()
        {
            List<ListViewItem> items = nodeOperations.generateListViewItems(treeForm.treeViewControl.SelectedNode);
            treeForm.listView.Items.Clear();

            foreach (ListViewItem item in items)
            {
                treeForm.listView.Items.Add(item);
            }
        }

        #endregion


        #region events

        private void toolComboDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            setDriveStatusLabel(comboDrives.SelectedItem.ToString());
        
            //set nodes in treeView for selected drive in comboBox and select a root node
            if (treeForm != null)
            {
                if (comboDrives.SelectedIndex != -1)
                {
                    treeForm.setTreeNodes(comboDrives.SelectedItem.ToString());
                    treeForm.treeViewControl.SelectedNode = treeForm.treeViewControl.Nodes[0];
                }
            }
            
        }

        #endregion

        #region menu

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            if(treeForm.listView.SelectedItems.Count > 0)
            {

                    if (treeForm.listView.SelectedItems[0].Tag.ToString() == "File")
                    {
                        string name = treeForm.listView.SelectedItems[0].Text;
                        fileOperations.open(nodeOperations.ListViewFiles.Where(a => a.Name == name).First());
                    }
                    else if (treeForm.listView.SelectedItems[0].Tag.ToString() == "Directory")
                    {

                    }
                
            }
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
       {
            if (treeForm.listView.SelectedItems.Count > 0)
            {
                string name = treeForm.listView.SelectedItems[0].Text;
                fileOperations.delete(nodeOperations.ListViewFiles.Where(a => a.Name == name).First());
                refreshListViewItems();
            }
        }

        private void copyMenuItem_Click(object sender, EventArgs e)
        {
            if(treeForm.listView.SelectedItems.Count > 0)
            {
                string path = nodeOperations.generateNodePath(treeForm.treeViewControl.SelectedNode) + "\\" + treeForm.listView.SelectedItems[0].Text;
                formFileMoving = new FormFileMoving(path, MovingOperations.Copy);
                formFileMoving.ShowDialog();
            }
        }

        private void moveMenuItem_Click(object sender, EventArgs e)
        {
            if(treeForm.listView.SelectedItems.Count > 0)
            {
                string path = nodeOperations.generateNodePath(treeForm.treeViewControl.SelectedNode) + "\\" + treeForm.listView.SelectedItems[0].Text;
                formFileMoving = new FormFileMoving(path, MovingOperations.Move);
                formFileMoving.ShowDialog();
                refreshListViewItems();
            }
        }

        #endregion

    }
}
