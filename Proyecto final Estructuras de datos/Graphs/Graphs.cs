using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Proyecto_final_Estructuras_de_datos.Graphs
{
    internal class Node
    {
        public string Name { get; set; }
        public List<Edge> Neighbors { get; set; }

        public Node(string name)
        {
            Name = name;
            Neighbors = new List<Edge>();
        }
    }
    internal class Edge
    {
        //public Node From { get; set; }
        public Node To { get; set; }
        public int Weight { get; set; }

        public Edge(/*Node from,*/ Node to, int weight)
        {
            //From = from;
            To = to;
            Weight = weight;
        }

        public Edge(/*Node from,*/ Node to)
        {
            //From = from;
            To = to;
        }
        internal class Graphs
        {

            public List<Node> Nodes { get; set; }
            public List<List<Edge>> AdjacencyList { get; set; }


            public Graphs()
            {
                Nodes = new List<Node>();
                AdjacencyList = new List<List<Edge>>();
            }

            public void AddNode(Node newNode)
            {
                Nodes.Add(newNode);
                AdjacencyList.Add(new List<Edge>());
            }

            public void AddEdge(Node fromNode, Node toNode)
            {
                if (Nodes.Contains(fromNode) && Nodes.Contains(toNode))
                {
                    Edge newEdge = new Edge(/*fromNode,*/ toNode);
                    fromNode.Neighbors.Add(newEdge);
                    AdjacencyList[Nodes.IndexOf(fromNode)].Add(newEdge);
                }
            }

            public void Clear()
            {
                Nodes.Clear();
                AdjacencyList.Clear();
            }

            //add a method to add an edge with a weight
            public void AddEdge(Node fromNode, Node toNode, int weight)
            {
                if (Nodes.Contains(fromNode) && Nodes.Contains(toNode))
                {
                    Edge newEdge = new Edge(/*fromNode,*/ toNode, weight);
                    fromNode.Neighbors.Add(newEdge);
                    AdjacencyList[Nodes.IndexOf(fromNode)].Add(newEdge);
                }
            }

            //add a method to add no directed edge with a weight
            public void AddNoDirectedEdge(Node node1, Node node2, int weight)
            {
                AddEdge(node1, node2, weight);
                AddEdge(node2, node1, weight);
            }

            //overload the method to add no directed edge without weight
            public void AddNoDirectedEdge(Node node1, Node node2)
            {
                AddEdge(node1, node2);
                AddEdge(node2, node1);
            }

            public void RemoveNode(Node nodeToRemove)
            {
                if (Nodes.Contains(nodeToRemove))
                {
                    int index = Nodes.IndexOf(nodeToRemove);
                    Nodes.RemoveAt(index);
                    AdjacencyList.RemoveAt(index);

                    // Remove edges to this node
                    foreach (Node node in Nodes)
                    {
                        node.Neighbors.RemoveAll(edge => edge.To == nodeToRemove);
                    }

                    // Remove edges in the adjacency list
                    foreach (var adjList in AdjacencyList)
                    {
                        adjList.RemoveAll(edge => edge.To == nodeToRemove);
                    }
                }
            }


            //add a method to remove no directed edge
            public void RemoveNoDirectedEdge(Node node1, Node node2)
            {
                RemoveEdge(node1, node2);
                RemoveEdge(node2, node1);
            }

            public void RemoveEdge(Node fromNode, Node toNode)
            {
                if (Nodes.Contains(fromNode) && Nodes.Contains(toNode))
                {
                    Edge edgeToRemove = fromNode.Neighbors.Find(e => e.To == toNode);
                    if (edgeToRemove != null)
                    {
                        fromNode.Neighbors.Remove(edgeToRemove);
                        AdjacencyList[Nodes.IndexOf(fromNode)].Remove(edgeToRemove);
                    }
                }
            }

            public void RemoveGraph()
            {
                Nodes.Clear();
                AdjacencyList.Clear();
            }

            public string ShowAdjacencyList()
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < Nodes.Count; i++)
                {
                    sb.Append($"{Nodes[i].Name}: ");
                    foreach (var edge in AdjacencyList[i])
                    {
                        sb.Append($"{edge.To.Name}, ");
                    }
                    sb.AppendLine();
                }

                return sb.ToString();
            }

            //add a method to show the graph with weights
            public string ShowAdjacencyListWithWeights()
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < Nodes.Count; i++)
                {
                    sb.Append($"{Nodes[i].Name}: ");
                    foreach (var edge in AdjacencyList[i])
                    {
                        sb.Append($"{edge.To.Name} ({edge.Weight}), ");
                    }
                    sb.AppendLine();
                }

                return sb.ToString();
            }



            public string DFS(Node startNode)
            {
                if (startNode == null || !Nodes.Contains(startNode)) return string.Empty;

                List<Node> visited = new List<Node>();  // Lista de nodos visitados
                StringBuilder result = new StringBuilder();  // Para acumular el resultado

                DFSRecursive(startNode, visited, result);

                return result.ToString();
            }

            private void DFSRecursive(Node currentNode, List<Node> visited, StringBuilder result)
            {
                // Marcar el nodo como visitado
                visited.Add(currentNode);

                // Agregar el nodo actual al resultado
                if (result.Length > 0)
                {
                    result.Append(" → ");  // Añadir flecha entre nodos
                }
                result.Append(currentNode.Name);

                // Recorrer los nodos adyacentes
                foreach (Edge edge in currentNode.Neighbors)
                {
                    Node adjacentNode = edge.To;
                    if (!visited.Contains(adjacentNode))
                    {
                        DFSRecursive(adjacentNode, visited, result);  // Llamada recursiva
                    }
                }
            }

            public string DFSIterative(Node startNode)
            {
                if (startNode == null || !Nodes.Contains(startNode)) return string.Empty;

                List<Node> visited = new List<Node>();  // Lista de nodos visitados
                Stack<Node> stack = new Stack<Node>();  // Pila para el recorrido
                StringBuilder result = new StringBuilder();  // Para acumular el resultado

                stack.Push(startNode);  // Agregar el nodo de inicio a la pila

                while (stack.Count > 0)
                {
                    Node currentNode = stack.Pop();  // Obtener el nodo en la cima de la pila

                    if (!visited.Contains(currentNode))
                    {
                        // Agregar el nodo actual al resultado
                        if (result.Length > 0)
                        {
                            result.Append(" → ");  // Añadir flecha entre nodos
                        }
                        result.Append(currentNode.Name);

                        visited.Add(currentNode);  // Marcar el nodo como visitado

                        List<Edge> reversedEdges = currentNode.Neighbors.OrderByDescending(e => e.To.Name).ToList();

                        // Apilar los nodos adyacentes no visitados
                        foreach (Edge edge in reversedEdges)
                        {
                            Node adjacentNode = edge.To;
                            if (!visited.Contains(adjacentNode))
                            {
                                stack.Push(adjacentNode);  // Agregar a la pila si no ha sido visitado
                            }
                        }
                    }
                }

                return result.ToString();
            }

            public string BFS(Node startNode)
            {
                if (startNode == null || !Nodes.Contains(startNode)) return string.Empty;

                List<Node> visited = new List<Node>();  // Lista de nodos visitados
                Queue<Node> queue = new Queue<Node>();  // Cola para el recorrido
                StringBuilder result = new StringBuilder();  // Para acumular el resultado

                queue.Enqueue(startNode);  // Agregar el nodo de inicio a la cola

                while (queue.Count > 0)
                {
                    Node currentNode = queue.Dequeue();  // Obtener el nodo al frente de la cola

                    if (!visited.Contains(currentNode))
                    {
                        // Agregar el nodo actual al resultado
                        if (result.Length > 0)
                        {
                            result.Append(" → ");  // Añadir flecha entre nodos
                        }
                        result.Append(currentNode.Name);

                        visited.Add(currentNode);  // Marcar el nodo como visitado

                        // Encolar los nodos adyacentes no visitados
                        foreach (Edge edge in currentNode.Neighbors)
                        {
                            Node adjacentNode = edge.To;
                            if (!visited.Contains(adjacentNode) && !queue.Contains(adjacentNode))
                            {
                                queue.Enqueue(adjacentNode);  // Agregar a la cola si no ha sido visitado
                            }
                        }
                    }
                }

                return result.ToString();
            }



        }
    }
}

