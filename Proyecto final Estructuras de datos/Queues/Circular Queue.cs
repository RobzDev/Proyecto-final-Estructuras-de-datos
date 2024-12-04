using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_final_Estructuras_de_datos.Forms.Lists;

namespace Proyecto_final_Estructuras_de_datos.Queues
{
    public class Static_CircularQueue<T>
    {
        private T[] _array;
        private int _front;
        private int _rear;
        private int _size;
        private int _capacity;

        public Static_CircularQueue(int capacity)
        {
            _capacity = capacity;
            _array = new T[capacity];
            _front = 0;
            _rear = -1;
            _size = 0;
        }

        public void Circular_Double_Enqueue(T item)
        {
            if (_size == _capacity)
                throw new InvalidOperationException("Queue is full.");

            _rear = (_rear + 1) % _capacity;
            _array[_rear] = item;
            _size++;
        }

        public T CircularDoubleDequeue()
        {
            if (_size == 0)
                throw new InvalidOperationException("Queue is empty.");

            T value = _array[_front];
            _front = (_front + 1) % _capacity;
            _size--;
            return value;
        }

        public T Circular_Double_Peek()
        {
            if (_size == 0)
                throw new InvalidOperationException("Queue is empty.");

            return _array[_front];
        }

        public int Count => _size;

        public bool IsEmpty => _size == 0;
    }

    public class DynamicCircularQueue<T>
    {
        // Internal linked list to manage queue elements
        private SimpleLinkedList<T> _list;

        // Reference to the last node to maintain O(1) enqueue
        private Node<T> _lastNode;

     
        public DynamicCircularQueue()
        {
            _list = new SimpleLinkedList<T>();
            _lastNode = null;
        }

    
        public void Enqueue(T item)
        {
            // If the list is empty
            if (_list.Count == 0)
            {
                _list.Add(item);
                _lastNode = _list.head;
                _lastNode.Next = _lastNode; // Point to itself to create circular structure
            }
            else
            {
                // Add new node
                _list.Add(item);

                // Update the last node to point to the first (head)
                Node<T> newLastNode = _lastNode.Next;
                newLastNode.Next = _list.head; // Maintain circular link
                _lastNode = newLastNode;
            }
        }

        public T Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty.");

            // Get the first item
            T item = _list.head.Data;

            // Remove the first item
            _list.RemoveAt(0);

            // If queue becomes empty after removal
            if (_list.Count == 0)
            {
                _lastNode = null;
            }
            else
            {
                // Maintain circular link
                _lastNode.Next = _list.head;
            }

            return item;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty.");

            return _list.head.Data;
        }

      
        public int Count => _list.Count;

      
        public bool IsEmpty => _list.Count == 0;

     
        public void Clear()
        {
            _list.Clear();
            _lastNode = null;
        }

       
        public T[] ToArray()
        {
            return _list.ToArray();
        }
    }
}
