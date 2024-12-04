using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_final_Estructuras_de_datos.Forms.Lists;

namespace Proyecto_final_Estructuras_de_datos.Queues
{
    public class StaticQueue<T>
    {
        private T[] _array;
        private int _front;
        private int _rear;
        private int _size;
        private int _capacity;

        public StaticQueue(int capacity)
        {
            _capacity = capacity;
            _array = new T[capacity];
            _front = 0;
            _rear = -1;
            _size = 0;
        }

        public void Enqueue(T item)
        {
            if (_size == _capacity)
                throw new InvalidOperationException("Queue is full.");

            _rear = (_rear + 1) % _capacity;
            _array[_rear] = item;
            _size++;
        }

        public T Dequeue()
        {
            if (_size == 0)
                throw new InvalidOperationException("Queue is empty.");

            T value = _array[_front];
            _front = (_front + 1) % _capacity;
            _size--;
            return value;
        }

        public T Peek()
        {
            if (_size == 0)
                throw new InvalidOperationException("Queue is empty.");

            return _array[_front];
        }

        public int Count => _size;

        public bool IsEmpty => _size == 0;
    }
    public class DynamicQueue<T>
    {
        // Internal linked list to manage queue elements
        private SimpleLinkedList<T> _list;

       
        public DynamicQueue()
        {
            _list = new SimpleLinkedList<T>();
        }

        
        public void Enqueue(T item)
        {
            _list.Add(item);
        }

        
        public T Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty.");

            return _list.RemoveAt(0);
        }

   
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty.");

            return _list.GetAt(0);
        }

      
        public int Count => _list.Count;

       
        public bool IsEmpty => _list.Count == 0;

       
        public void Clear()
        {
            _list.Clear();
        }

        public T[] ToArray()
        {
            return _list.ToArray();
        }
    }

}
