using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileManager
{
    public class Tree : ITree
    {
        private INodeOperations nodeOperations;

        public Tree()
        {
            nodeOperations = new NodeOperations();
        }

        public TreeNode retrieveTreeNodes(string path)  
        {
            TreeNode driveNode = new TreeNode(path.Substring(0, 2));
            driveNode.Tag = "Drive";

                try
                {
                    string name;
                    char slash = '\\';
                    DriveInfo drive = DriveInfo.GetDrives().Where(a => a.Name == path).First();
                    driveNode.Text = path; //+ "(" + drive.DriveFormat + ")";

                    List<string> directories = System.IO.Directory.GetDirectories(path).ToList();

                    foreach (string s in directories)
                    {
                        if (s != path + "$RECYCLE.BIN" && s != path + "System Volume Information")
                        {
                            int position = s.LastIndexOf(slash);
                            name = s.Substring(position + 1, s.Length - (position + 1));
                            TreeNode node = new TreeNode(name);
                            node.Tag = "Directory";

                            nodeOperations.loadSubDirectories(node, s);
                            driveNode.Nodes.Add(node);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string description = "While loading directories occurred a problem: ";

                    FileStream stream = new FileStream(Path.Combine(Application.StartupPath, "log.txt"), FileMode.Append, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(stream);
                    sw.WriteLine("\r\nLog Entry: ");
                    sw.WriteLine(string.Format("Date: {0}, Action type: {1}", DateTime.Now.ToLongDateString(), "Error"));
                    sw.WriteLine(description + " " + ex.Message);
                    sw.WriteLine("-------------------------------------------------------------------------------");
                    sw.Close();

                    MessageBox.Show(description + ex.Message + "!!!!!!!!!!!!!!!!");
                }            

            return driveNode;

        }
    }
}
