using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public interface INodeOperations
    {
        List<IFileInformation> ListViewFiles { get; set; }
        void loadSubDirectories(TreeNode node, string path);
        string generateNodePath(TreeNode node);
        List<ListViewItem> generateListViewItems(TreeNode node);
    }
}
