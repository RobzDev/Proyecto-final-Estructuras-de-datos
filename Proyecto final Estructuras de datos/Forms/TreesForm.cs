using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 

namespace Proyecto_final_Estructuras_de_datos.Forms
{
    public partial class TreesForm : zBase
    {
        public TreesForm()
        {
            InitializeComponent();
        }
        Node root = new Node();
        string currentpath = "";
        string currentfile = "";

        Node Insert_array(int[] array)
        {
            Node root = new Node();
            for (int i = 0; i < array.Length; i++)
            {
                root.Insert(array[i]);
            }


            return root;
        }

        private void btn_Creator_Click(object sender, EventArgs e)
        {
            try
            {
                string text = txtbx_array.Text;
                int[] ints = text.Split(',')
                                 .Select(n => int.Parse(n.Trim()))
                                 .ToArray();

                if (ints.Length != ints.Distinct().Count())
                {
                    ints = ints.Distinct().ToArray();
                }
                root = Insert_array(ints);

                txtbx_array.Text = "";
            }
            catch
            {
                txtbx_array.Text = "";
                return;
            }
        }



        private async void cbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (root.value != null)
            {
                switch (cbOrder.SelectedIndex)
                {
                    case 0:
                      
                         In_Order(root);
                        break;
                    case 1:
                       
                         Pre_Order(root);
                        break;
                    case 2:
                       
                         Post_Order(root);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                cbOrder.SelectedIndex = -1;
                return;
            }
        }

        private void btnContains_Click(object sender, EventArgs e)
        {
            try
            {
                Node? node = root.Search(Convert.ToInt32(txtbx_array.Text));
                if (node != null)
                {
                    string action = "Sought";
                    MessageBox.Show(root.GetNodeInfo(node, action));
                }
                else if (root.value == null)
                {
                    MessageBox.Show("Create a tree first");
                    txtbx_array.Text = "";
                }
                else
                {
                    MessageBox.Show(" Value Not Found");
                }
            }
            catch
            {
                txtbx_array.Text = "";
                return;
            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                string action = "Deleted";
                Node? node = root.Search(Convert.ToInt32(txtbx_array.Text));
                if (node != null)
                {
                    MessageBox.Show(root.GetNodeInfo(node, action));

                    root.Delete(root, Convert.ToInt32(txtbx_array.Text));

                    GenerateTree();

                }
                else if (root.value == null)
                {
                    MessageBox.Show("Create a tree first");
                    txtbx_array.Text = "";
                }
                else
                {
                    MessageBox.Show(" Value Not Found");
                }
            }
            catch
            {
                txtbx_array.Text = "";
                return;
            }


        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Node? node = root.Search(Convert.ToInt32(txtbx_array.Text));
                if (node != null)
                {
                    MessageBox.Show("Value already exists");
                    txtbx_array.Text = "";
                }
                else if (root.value == null)
                {
                    MessageBox.Show("Create a tree first");
                    txtbx_array.Text = "";
                }
                else
                {
                    int number = Convert.ToInt32(txtbx_array.Text);
                    root.Insert(number);
                    txtbx_array.Text = "";
                    GenerateTree();
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void GenerateTree()
        {
            string userDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string directoryPath = Path.Combine(userDocuments, "Trees");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            if (string.IsNullOrWhiteSpace(currentfile) && string.IsNullOrWhiteSpace(currentpath))
            {
                string file = RandomPNGName();

                string filePath = Path.Combine(directoryPath, file + ".dot");
                currentfile = file + ".png";
                currentpath = filePath;
            }
            if (File.Exists(directoryPath + currentfile))
            {
                File.Delete(directoryPath + currentfile);
            }
            using (StreamWriter writer = new StreamWriter(currentpath))
            {
                writer.WriteLine("digraph G {");
                if (root != null)
                {
                    root.ExportarGraphviz(root, writer);
                }
                writer.WriteLine("}");
            }
            GeneratePngFromDot(currentpath, directoryPath + "\\" + currentfile);

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (root.value != null)
            {
                GenerateTree();
                root.TreeInfo();
            }
            else
            {
                MessageBox.Show("Create a tree first");
                return;
            }
        }
        public string RandomPNGName()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string randomString = new string(Enumerable.Repeat(chars, 5).Select(s => s[random.Next(s.Length)]).ToArray());
            StringBuilder sb = new StringBuilder("Tree");
            sb.Append(randomString);
            return sb.ToString();
        }

        public void GeneratePngFromDot(string dotFilePath, string outputImagePath)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"C:\Program Files\Graphviz\bin\dot.exe";
            startInfo.Arguments = $"-Tpng \"{dotFilePath}\" -o \"{outputImagePath}\"";
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;

            using (Process process = Process.Start(startInfo))
            {
                process.WaitForExit();
            }
            using (FileStream fs = new FileStream(outputImagePath, FileMode.Open, FileAccess.Read))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    ms.Position = 0;

                    using (Image image = Image.FromStream(ms))
                    {
                        pbTree.Image = (Image)image.Clone();
                    }
                }
            }

        }

        private void btnDrop_Click(object sender, EventArgs e)
        {
            root = new Node();
            pbTree.Image = null;
        }
        //In Order method to traverse the tree
        public void In_Order(Node? node)
        {
            if (node == null)
                return;

            In_Order(node.left);
            MessageBox.Show(node.value.ToString());
            In_Order(node.right);
        }
        //Pre Order method to traverse the tree
        public void Pre_Order(Node? node)
        {
            if (node == null)
                return;

            MessageBox.Show(node.value.ToString());
            Pre_Order(node.left);
            Pre_Order(node.right);
        }
        //Post Order method to traverse the tree

        public void Post_Order(Node? node)
        {
            if (node == null)
                return;

            Post_Order(node.left);
            Post_Order(node.right);
            MessageBox.Show(node.value.ToString());
        }


    }
}

