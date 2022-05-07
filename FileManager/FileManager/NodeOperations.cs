using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileManager
{
    class NodeOperations : INodeOperations
    {
        public List<IFileInformation> ListViewFiles { get; set; }

        public string generateNodePath(TreeNode node)
        {
            if(node != null)
            {
                    string path = node.FullPath;
                    path = path.Replace("(NTFS)", "");
                    path = path.Replace("(FAT-32)", "");
                    path = path.Replace("\\\\", "\\");
                    return path;
                
            }
            else
            {
                return "";
            }
        }

        public void loadSubDirectories(TreeNode node, string path)
        {
            try
            {
                string name;
                char slash = '\\';
                List<string> directories = System.IO.Directory.GetDirectories(path).ToList();

                foreach (string s in directories)
                {
                    int position = s.LastIndexOf(slash);
                    name = s.Substring(position + 1, s.Length - (position + 1));
                    TreeNode subNode = new TreeNode(name);
                    subNode.Tag = "Directory";
                    node.Nodes.Add(subNode);
                }

            }
            catch (Exception ex)
            {
                string description = "While loading directories occurred the problem: ";
                MessageBox.Show(description + ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public List<ListViewItem> generateListViewItems(TreeNode node)
        {
            List<ListViewItem> result = new List<ListViewItem>();
            ListViewFiles = new List<IFileInformation>();
            ListViewItem item;
            string name;
            char slash = '\\';
            int position;

            string path = generateNodePath(node);
            List<string> directories = System.IO.Directory.GetDirectories(path).ToList();
            List<string> files = System.IO.Directory.GetFiles(path).ToList();

            foreach(string s in directories)
            {
                position = s.LastIndexOf(slash);
                name = s.Substring(position + 1, s.Length - (position + 1));
                item = new ListViewItem(name);
                item.Tag = "Directory";
                item.ImageIndex = 0;
                result.Add(item);
            }

            foreach(string s in files)
            {
                position = s.LastIndexOf(slash);
                name = s.Substring(position + 1, s.Length - (position + 1));
                item = new ListViewItem(name);
                item.Tag = "File";
                item.ImageIndex = 1;
                result.Add(item);
                ListViewFiles.Add( new FileInformation(s));
            }

            return result;
        }

        public NodeOperations()
        {
            
        }
    }
}
