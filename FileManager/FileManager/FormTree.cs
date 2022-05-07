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
    public partial class FormTree : Form
    {
        private ToolStripComboBox comboDrives;
        private ITree tree;
        private INodeOperations nodeOperations;
        private IDirectoryInformation directory;
        private ToolStripStatusLabel lblStatusFiles;
        public TreeView treeViewControl { get; }

        public FormTree(ToolStripComboBox combo, ToolStripStatusLabel label, INodeOperations nodeOperations)  //przekazanie comboBoksa do konstruktora z FormFileManager do FormTree ma być w opisie!!!
        {
            InitializeComponent();

            treeViewControl = this.treeView;
            tree = new Tree();
            this.nodeOperations = nodeOperations; 

            lblStatusFiles = label;
            comboDrives = combo;
            setTreeNodes(comboDrives.SelectedItem.ToString());
        }

        #region methods

        public void setTreeNodes(string path)
        {
            TreeNode node;

            if(comboDrives.SelectedIndex != -1)
            {
                node = tree.retrieveTreeNodes(path);

                treeView.Nodes.Clear();
                treeView.Nodes.Add(node);            
            }        
        }

        private void setDirectoryStatusLabel(string path)
        {
            directory = new Directory(path);
            string status = "Total " + directory.FilesNumber + " file(s) (" + directory.FilesSize + " MB)";
            lblStatusFiles.Text = status;
        }

        #endregion


        #region events

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            setDirectoryStatusLabel(nodeOperations.generateNodePath(e.Node));

            listView.Items.Clear();

            this.Text = nodeOperations.generateNodePath(e.Node); 

            //generates subnodes in treeView for selected nodes
            if (e.Node != null)
            {
                TreeNodeCollection childNodes = e.Node.Nodes; 

                foreach (TreeNode node in childNodes)
                {
                    nodeOperations.loadSubDirectories(node, nodeOperations.generateNodePath(node));
                }
            }

            //generates directories and files displayed in listView
            List<ListViewItem> list = nodeOperations.generateListViewItems(e.Node);
            
            foreach(ListViewItem item in list)
            {
                listView.Items.Add(item);
            }
        }

        #endregion

        private void treeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            //this.Text = nodeOperations.generateNodePath(treeView.SelectedNode);
        }

    }
}
