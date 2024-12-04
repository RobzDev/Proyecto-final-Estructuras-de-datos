using Proyecto_final_Estructuras_de_datos.Forms.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_Estructuras_de_datos.Stacks
{
    public class StaticStack<T>
    {
        private T[] _array;
        private int _top;
        private int _capacity;

        public StaticStack(int capacity)
        {
            _capacity = capacity;
            _array = new T[capacity];
            _top = -1;
        }

        public void Push(T item)
        {
            if (_top == _capacity - 1)
                throw new InvalidOperationException("Stack overflow: The stack is full.");

            _array[++_top] = item;
        }

        public T Pop()
        {
            if (_top == -1)
                throw new InvalidOperationException("Stack underflow: The stack is empty.");

            return _array[_top--];
        }

        public T Peek()
        {
            if (_top == -1)
                throw new InvalidOperationException("The stack is empty.");

            return _array[_top];
        }

        public bool IsEmpty()
        {
            return _top == -1;
        }

        public int Size => _top + 1;
    }
    public class DynamicStack<T>
    {
        private SimpleLinkedList<T> _list;

        public DynamicStack()
        {
            _list = new SimpleLinkedList<T>();
        }

        // Pushes an item onto the stack
        public void Push(T item)
        {
            _list.Add(item);
        }

        // Pops an item from the stack
        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack underflow: The stack is empty.");

            T value = _list.GetAt(_list.Count - 1); // Get the last item
            _list.RemoveAt(_list.Count - 1); // Remove it from the linked list
            return value;
        }

        // Peeks at the top item without removing it
        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("The stack is empty.");

            return _list.GetAt(_list.Count - 1); // Return the last item
        }

        // Checks if the stack is empty
        public bool IsEmpty()
        {
            return _list.Count == 0;
        }

        // Returns the number of elements in the stack
        public int Size()
        {
            return _list.Count;
        }
    }
}
