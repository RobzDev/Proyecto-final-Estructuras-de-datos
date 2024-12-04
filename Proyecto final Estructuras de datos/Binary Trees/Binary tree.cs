using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_Estructuras_de_datos
{
   //8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13
        public class Node
        {
            public Node? left;
            public Node? right;
            public int? value;

            public Node(int value)
            {
                this.value = value;
                left = null;
                right = null;

            }
            public Node()
            {
                this.value = null;
                left = null;
                right = null;

            }

            public void Insert(int value)
            {
                if (this.value == null)
                {
                    this.value = value;
                    return;
                }
                if (value < this.value)
                {
                    if (this.left == null)
                    {
                        this.left = new Node(value);

                    }
                    else
                    {
                        this.left.Insert(value);
                    }

                }
                else
                {
                    if (this.right == null)
                    {
                        this.right = new Node(value);

                    }
                    else
                    {
                        this.right.Insert(value);
                    }
                }




            }




            public Node? Search(int value)
            {
                if (this.value == null) return null;

                if (this.value == value) return this;

                if (value < this.value)
                {
                    if (this.left != null) return this.left.Search(value);
                    else return null;
                }
                else
                {
                    if (this.right != null) return this.right.Search(value);
                    else return null;
                }
            }

            public Node? Delete(Node? root, int value)
            {
                if (root == null) return null;

                if (value < root.value)
                {
                    root.left = Delete(root.left, value);
                }
                else if (value > root.value)
                {
                    root.right = Delete(root.right, value);
                }
                else
                {

                    if (root.left == null && root.right == null)
                    {
                        return null;
                    }
                    else if (root.left == null)
                    {
                        return root.right;
                    }
                    else if (root.right == null)
                    {
                        return root.left;
                    }
                    else
                    {
                        Node? minNode = FindMin(root.right);
                        root.value = minNode.value;
                        root.right = Delete(root.right, (int)minNode.value);
                    }
                }

                return root;
            }

            private Node? FindMin(Node? node)
            {
                while (node?.left != null)
                {
                    node = node.left;
                }
                return node;
            }

            public string GetNodeInfo(Node? node, string action)
            {


                if (node == null)
                {
                    return "Node with value not found.";
                }

                int height = GetNodeHeight(node);



                bool isLeaf = node.left == null && node.right == null;

                string leafStatus = isLeaf ? "is a leaf node" : "is not a leaf node";

                return $"The {action} Node with value {node.value.ToString()} was found at the height {height} and {leafStatus}.";
            }
            public int GetNodeHeight(Node? node)
            {

                if (this == null) return 0;
                int height = 1;
                if (this.value == node?.value)
                    return height;

                if (node?.value < this.value)
                {


                    if (this.left != null)
                    {

                        if (this.left.value == node?.value)
                        {
                            return height + 1;
                        }
                        int temp = this.left.GetNodeHeight(node);
                        return height + temp;
                    }
                    else return 0;
                }
                else
                {
                    if (this.right != null)
                    {


                        if (this.right.value == node?.value)
                        {
                            return height + 1;
                        }
                        return height + this.right.GetNodeHeight(node);

                    }
                    else return 0;
                }
            }


            public int CountNodes()
            {
                int count = 1;
                if (this.left != null)
                {
                    count += this.left.CountNodes();
                }
                if (this.right != null)
                {
                    count += this.right.CountNodes();
                }
                return count;
            }

            public int GetHeight()
            {
                if (this == null) return 0;

                int leftHeight = this.left?.GetHeight() ?? 0;
                int rightHeight = this.right?.GetHeight() ?? 0;

                return Math.Max(leftHeight, rightHeight) + 1;
            }




            public void TreeInfo()
            {
                int heightt = GetHeight();
                int nodeCount = CountNodes();
                int height = heightt;
                int levels = height;

                MessageBox.Show($"Tree Information:\nNodes: {nodeCount}\nHeight: {height}\nLevels: {levels}");
            }

            public void ExportarGraphviz(Node? nodo, StreamWriter writer)
            {
                if (nodo == null)
                    return;

                if (nodo.left != null)
                {
                    writer.WriteLine($"    \"{nodo.value}\" -> \"{nodo.left.value}\";");
                }

                if (nodo.right != null)
                {
                    writer.WriteLine($"    \"{nodo.value}\" -> \"{nodo.right.value}\";");
                }


                ExportarGraphviz(nodo.left, writer);
                ExportarGraphviz(nodo.right, writer);
            }


        }


    
}
