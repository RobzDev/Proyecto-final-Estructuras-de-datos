using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_Estructuras_de_datos.Forms.Lists
{
    public interface ILinkedList<T>
    {
        int Count { get; }
        void Add(T data);
        void InsertAt(int index, T data);
        bool Remove(T data);
        T RemoveAt(int index);
        bool Contains(T data);
        T GetAt(int index);
        void Clear();
        T[] ToArray();
    }

    public class Node<T> 
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class SimpleLinkedList<T> : ILinkedList<T>
    {
        // Head of the linked list
        public Node<T> head;

        
        public int Count { get; protected set; }

        // Constructor
        public SimpleLinkedList()
        {
            head = null;
            Count = 0;
        }


        public virtual void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            Count++;
        }


        public virtual void InsertAt(int index, T data)
        {
            if (index < 0 || index > Count)
                throw new IndexOutOfRangeException("Invalid index");

            Node<T> newNode = new Node<T>(data);

            if (index == 0)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
            }
            Count++;
        }

        public virtual bool Remove(T data)
        {
            if (head == null) return false;

            // Check if head needs to be removed
            if (head.Data.Equals(data))
            {
                head = head.Next;
                Count--;
                return true;
            }

            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    previous.Next = current.Next;
                    Count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }

            return false;
        }

        public virtual T RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("Invalid index");

            T removedData;

            if (index == 0)
            {
                removedData = head.Data;
                head = head.Next;
            }
            else
            {
                Node<T> current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                removedData = current.Next.Data;
                current.Next = current.Next.Next;
            }

            Count--;
            return removedData;
        }


        public virtual bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }


        public virtual T GetAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("Invalid index");

            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }


        public virtual void Clear()
        {
            head = null;
            Count = 0;
        }


        public virtual T[] ToArray()
        {
            T[] array = new T[Count];
            Node<T> current = head;
            for (int i = 0; i < Count; i++)
            {
                array[i] = current.Data;
                current = current.Next;
            }
            return array;
        }
    }


    public class CircularLinkedList<T> : SimpleLinkedList<T>
    {
     
        public override void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (head == null)
            {
                head = newNode;
                head.Next = head; // Point to itself to create circular structure
            }
            else
            {
                Node<T> current = head;
                while (current.Next != head)
                {
                    current = current.Next;
                }
                current.Next = newNode;
                newNode.Next = head; // Link back to head
            }
            Count++;
        }

        
        public override void InsertAt(int index, T data)
        {
            if (index < 0 || index > Count)
                throw new IndexOutOfRangeException("Invalid index");

            Node<T> newNode = new Node<T>(data);

            if (index == 0)
            {
                if (head == null)
                {
                    head = newNode;
                    head.Next = head;
                }
                else
                {
                    // Find the last node
                    Node<T> lastNode = head;
                    while (lastNode.Next != head)
                    {
                        lastNode = lastNode.Next;
                    }

                    newNode.Next = head;
                    lastNode.Next = newNode;
                    head = newNode;
                }
            }
            else
            {
                Node<T> current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
            }
            Count++;
        }

      
        public override bool Remove(T data)
        {
            if (head == null) return false;

            // Special case for removing head
            if (head.Data.Equals(data))
            {
                if (Count == 1)
                {
                    head = null;
                }
                else
                {
                    // Find last node
                    Node<T> lastNode = head;
                    while (lastNode.Next != head)
                    {
                        lastNode = lastNode.Next;
                    }

                    lastNode.Next = head.Next;
                    head = head.Next;
                }
                Count--;
                return true;
            }

            Node<T> current = head;
            Node<T> previous = null;

            do
            {
                if (current.Data.Equals(data))
                {
                    previous.Next = current.Next;
                    Count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            } while (current != head);

            return false;
        }

        
        public override T RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("Invalid index");

            T removedData;

            if (index == 0)
            {
                removedData = head.Data;
                if (Count == 1)
                {
                    head = null;
                }
                else
                {
                    // Find last node
                    Node<T> lastNode = head;
                    while (lastNode.Next != head)
                    {
                        lastNode = lastNode.Next;
                    }

                    lastNode.Next = head.Next;
                    head = head.Next;
                }
            }
            else
            {
                Node<T> current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                removedData = current.Next.Data;
                current.Next = current.Next.Next;
            }

            Count--;
            return removedData;
        }

        public override bool Contains(T data)
        {
            if (head == null) return false;

            Node<T> current = head;
            do
            {
                if (current.Data.Equals(data))
                    return true;

                current = current.Next;
            } while (current != head);

            return false;
        }
        public override void Clear()
        {
            head = null;
            Count = 0;
        }

        public override T GetAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("Invalid index");

            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Data;
        }
        public override T[] ToArray()
        {
            T[] array = new T[Count];
            if (Count == 0) return array;

            Node<T> current = head;
            for (int i = 0; i < Count; i++)
            {
                array[i] = current.Data;
                current = current.Next;
            }
            return array;
        }
    }

    public class DoublyNode<T>
    {
        public T Data { get; set; }
        public DoublyNode<T> Next { get; set; }
        public DoublyNode<T> Previous { get; set; }

        public DoublyNode(T data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }
    }


    public class DoublyLinkedList<T> : ILinkedList<T>
    {
        protected DoublyNode<T> head;
        protected DoublyNode<T> tail;

        public int Count { get; protected set; }

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            Count = 0;
        }


        public virtual void Add(T data)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(data);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
            Count++;
        }

        public virtual void InsertAt(int index, T data)
        {
            if (index < 0 || index > Count)
                throw new IndexOutOfRangeException("Invalid index");

            DoublyNode<T> newNode = new DoublyNode<T>(data);

            if (index == 0)
            {
                newNode.Next = head;
                if (head != null)
                    head.Previous = newNode;
                head = newNode;

                if (tail == null)
                    tail = newNode;
            }
            else if (index == Count)
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
            else
            {
                DoublyNode<T> current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                newNode.Previous = current;
                current.Next.Previous = newNode;
                current.Next = newNode;
            }
            Count++;
        }


        public virtual bool Remove(T data)
        {
            DoublyNode<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // If it's the head
                    if (current.Previous == null)
                    {
                        head = current.Next;
                        if (head != null)
                            head.Previous = null;
                        else
                            tail = null;
                    }
                    // If it's the tail
                    else if (current.Next == null)
                    {
                        tail = current.Previous;
                        tail.Next = null;
                    }
                    // If it's in the middle
                    else
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                    }

                    Count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }


        public virtual T RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("Invalid index");

            DoublyNode<T> current = head;
            T removedData;

            if (index == 0)
            {
                removedData = head.Data;
                head = head.Next;
                if (head != null)
                    head.Previous = null;
                else
                    tail = null;
            }
            else if (index == Count - 1)
            {
                current = tail;
                removedData = tail.Data;
                tail = tail.Previous;
                tail.Next = null;
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                removedData = current.Data;
                current.Previous.Next = current.Next;
                current.Next.Previous = current.Previous;
            }

            Count--;
            return removedData;
        }


        public virtual T GetAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("Invalid index");

            DoublyNode<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        public virtual bool Contains(T data)
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }


        public virtual void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public virtual T[] ToArray()
        {
            T[] array = new T[Count];
            DoublyNode<T> current = head;
            for (int i = 0; i < Count; i++)
            {
                array[i] = current.Data;
                current = current.Next;
            }
            return array;
        }
    }

    public class DoublyCircularLinkedList<T> : ILinkedList<T>
    {
        protected DoublyNode<T> head;
        public int Count { get; protected set; }

        public DoublyCircularLinkedList()
        {
            head = null;
            Count = 0;
        }

      
        public virtual void Add(T data)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(data);

            if (head == null)
            {
                head = newNode;
                head.Next = head;
                head.Previous = head;
            }
            else
            {
                DoublyNode<T> tail = head.Previous;

                tail.Next = newNode;
                newNode.Previous = tail;
                newNode.Next = head;
                head.Previous = newNode;
            }
            Count++;
        }

        
        public virtual void InsertAt(int index, T data)
        {
            if (index < 0 || index > Count)
                throw new IndexOutOfRangeException("Invalid index");

            DoublyNode<T> newNode = new DoublyNode<T>(data);

            if (index == 0)
            {
                if (head == null)
                {
                    head = newNode;
                    head.Next = head;
                    head.Previous = head;
                }
                else
                {
                    DoublyNode<T> tail = head.Previous;

                    newNode.Next = head;
                    newNode.Previous = tail;
                    head.Previous = newNode;
                    tail.Next = newNode;
                    head = newNode;
                }
            }
            else
            {
                DoublyNode<T> current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                newNode.Next = current;
                newNode.Previous = current.Previous;
                current.Previous.Next = newNode;
                current.Previous = newNode;
            }
            Count++;
        }

       
        public virtual bool Remove(T data)
        {
            if (head == null) return false;

            DoublyNode<T> current = head;

            do
            {
                if (current.Data.Equals(data))
                {
                    // If it's the only node
                    if (Count == 1)
                    {
                        head = null;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;

                        // If removing the head, update head
                        if (current == head)
                        {
                            head = current.Next;
                        }
                    }

                    Count--;
                    return true;
                }
                current = current.Next;
            } while (current != head);

            return false;
        }

    
        public virtual T RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("Invalid index");

            T removedData;

            // If it's the only node
            if (Count == 1)
            {
                removedData = head.Data;
                head = null;
            }
            else
            {
                DoublyNode<T> current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                removedData = current.Data;

                current.Previous.Next = current.Next;
                current.Next.Previous = current.Previous;

                // If removing the head, update head
                if (current == head)
                {
                    head = current.Next;
                }
            }

            Count--;
            return removedData;
        }

        
        public virtual T GetAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("Invalid index");

            DoublyNode<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        
        public virtual bool Contains(T data)
        {
            if (head == null) return false;

            DoublyNode<T> current = head;
            do
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            } while (current != head);

            return false;
        }

       
        public virtual void Clear()
        {
            head = null;
            Count = 0;
        }

       
        public virtual T[] ToArray()
        {
            T[] array = new T[Count];
            if (Count == 0) return array;

            DoublyNode<T> current = head;
            for (int i = 0; i < Count; i++)
            {
                array[i] = current.Data;
                current = current.Next;
            }
            return array;
        }
    }

}
