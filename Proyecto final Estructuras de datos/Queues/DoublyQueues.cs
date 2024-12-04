using Proyecto_final_Estructuras_de_datos.Forms.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_Estructuras_de_datos.Queues
{
    public class DynamicDeque<T>
    {
        private SimpleLinkedList<T> _list;

        public DynamicDeque()
        {
            _list = new SimpleLinkedList<T>();
        }

        // Enqueue at the front
        public void EnqueueFirst(T item)
        {
            _list.InsertAt(0, item); // Insert at index 0 (front)
        }

        // Enqueue at the back
        public void EnqueueLast(T item)
        {
            _list.Add(item); // Add at the end (back)
        }

        // Dequeue from the front
        public T DequeueFirst()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Deque underflow: The deque is empty.");

            return _list.RemoveAt(0); // Remove from index 0 (front)
        }

        // Dequeue from the back
        public T DequeueLast()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Deque underflow: The deque is empty.");

            return _list.RemoveAt(_list.Count - 1); // Remove from the end (back)
        }

        // Peek at the front item
        public T PeekFirst()
        {
            if (IsEmpty())
                throw new InvalidOperationException("The deque is empty.");

            return _list.GetAt(0); // Get item at the front (index 0)
        }

        // Peek at the back item
        public T PeekLast()
        {
            if (IsEmpty())
                throw new InvalidOperationException("The deque is empty.");

            return _list.GetAt(_list.Count - 1); // Get item at the back (last index)
        }

        // Check if the deque is empty
        public bool IsEmpty()
        {
            return _list.Count == 0;
        }

        // Return the number of items in the deque
        public int Size()
        {
            return _list.Count;
        }
    }
}
