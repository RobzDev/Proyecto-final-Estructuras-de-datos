using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_Estructuras_de_datos.Queues
{

    public class VectorOfVectors_PQ<T>
    {
        private T[][] _queue;
        private int _maxPriority;

        // Constructor, initialize with max priority level
        public VectorOfVectors_PQ(int maxPriority)
        {
            _maxPriority = maxPriority;
            _queue = new T[maxPriority + 1][];  // Array of arrays
            for (int i = 0; i <= maxPriority; i++)
            {
                _queue[i] = new T[0];  // Initialize each inner array as an empty array
            }
        }

        // Enqueue an item with a specified priority
        public void Enqueue(T item, int priority)
        {
            if (priority < 0 || priority > _maxPriority)
                throw new ArgumentException("Priority out of range.");

            // Resize the array at the given priority index to accommodate the new item
            Array.Resize(ref _queue[priority], _queue[priority].Length + 1);
            _queue[priority][_queue[priority].Length - 1] = item;
        }

        // Dequeue the item with the highest priority (largest priority value)
        public T Dequeue()
        {
            // Find the highest non-empty priority array
            for (int i = _maxPriority; i >= 0; i--)
            {
                if (_queue[i].Length > 0)
                {
                    T item = _queue[i][0];
                    // Shift all items down in the array (like removing the first element)
                    for (int j = 0; j < _queue[i].Length - 1; j++)
                    {
                        _queue[i][j] = _queue[i][j + 1];
                    }
                    Array.Resize(ref _queue[i], _queue[i].Length - 1);  // Remove last item (after shift)
                    return item;
                }
            }

            throw new InvalidOperationException("Queue is empty.");
        }

        // Peek the item with the highest priority (without removing it)
        public T Peek()
        {
            for (int i = _maxPriority; i >= 0; i--)
            {
                if (_queue[i].Length > 0)
                {
                    return _queue[i][0];
                }
            }

            throw new InvalidOperationException("Queue is empty.");
        }

        // Check if the priority queue is empty
        public bool IsEmpty()
        {
            for (int i = 0; i <= _maxPriority; i++)
            {
                if (_queue[i].Length > 0)
                {
                    return false;
                }
            }
            return true;
        }

        // Return the number of elements in the priority queue
        public int Size()
        {
            int size = 0;
            for (int i = 0; i <= _maxPriority; i++)
            {
                size += _queue[i].Length;
            }
            return size;
        }
    }
    public class VectorOfLists_PQ<T>
    {
        // Array of lists to store elements at different priority levels
        private List<T>[] _priorityLists;

        // Maximum priority level supported
        private int _maxPriority;

        // Constructor
        public VectorOfLists_PQ(int maxPriority)
        {
            // Validate max priority
            if (maxPriority < 0)
                throw new ArgumentException("Max priority must be non-negative.");

            // Initialize the array of lists
            _maxPriority = maxPriority;
            _priorityLists = new List<T>[maxPriority + 1];

            // Initialize each list
            for (int i = 0; i <= maxPriority; i++)
            {
                _priorityLists[i] = new List<T>();
            }
        }

        // Add an item with specified priority
        public void Enqueue(T item, int priority)
        {
            // Validate priority range
            if (priority < 0 || priority > _maxPriority)
                throw new ArgumentException("Priority out of range.");

            // Add item to the appropriate priority list
            _priorityLists[priority].Add(item);
        }

        // Remove and return the highest priority item
        public T Dequeue()
        {
            // Find the highest non-empty priority list
            for (int i = _maxPriority; i >= 0; i--)
            {
                if (_priorityLists[i].Count > 0)
                {
                    // Get the first item in the list
                    T item = _priorityLists[i][0];

                    // Remove the first item
                    _priorityLists[i].RemoveAt(0);

                    return item;
                }
            }

            // If no items found, throw an exception
            throw new InvalidOperationException("Queue is empty.");
        }

        // View the highest priority item without removing it
        public T Peek()
        {
            // Find the highest non-empty priority list
            for (int i = _maxPriority; i >= 0; i--)
            {
                if (_priorityLists[i].Count > 0)
                {
                    return _priorityLists[i][0];
                }
            }

            // If no items found, throw an exception
            throw new InvalidOperationException("Queue is empty.");
        }

        // Check if the queue is empty
        public bool IsEmpty()
        {
            // Check if all priority lists are empty
            for (int i = 0; i <= _maxPriority; i++)
            {
                if (_priorityLists[i].Count > 0)
                {
                    return false;
                }
            }
            return true;
        }

        // Get the total number of items in the queue
        public int Size()
        {
            int totalSize = 0;

            // Sum the sizes of all priority lists
            for (int i = 0; i <= _maxPriority; i++)
            {
                totalSize += _priorityLists[i].Count;
            }

            return totalSize;
        }

        // Optional: Clear the entire queue
        public void Clear()
        {
            // Clear each list in the array
            for (int i = 0; i <= _maxPriority; i++)
            {
                _priorityLists[i].Clear();
            }
        }
    }
    public class ListOfLists_PQ<T>
    {
        // Vector of Vectors, where each index represents a priority level.
        private List<List<T>> _queue;
        private int _maxPriority;

        // Constructor, initialize with max priority level.
        public ListOfLists_PQ(int maxPriority)
        {
            _maxPriority = maxPriority;
            _queue = new List<List<T>>(new List<T>[maxPriority + 1]); // +1 because index starts at 0
            for (int i = 0; i <= maxPriority; i++)
            {
                _queue[i] = new List<T>();
            }
        }

        // Enqueue an item with a specified priority
        public void Enqueue(T item, int priority)
        {
            if (priority < 0 || priority > _maxPriority)
                throw new ArgumentException("Priority out of range.");

            _queue[priority].Add(item);
        }

        // Dequeue the item with the highest priority (largest priority value)
        public T Dequeue()
        {
            // Find the highest non-empty priority list
            for (int i = _maxPriority; i >= 0; i--)
            {
                if (_queue[i].Count > 0)
                {
                    T item = _queue[i][0];
                    _queue[i].RemoveAt(0); // Remove the item
                    return item;
                }
            }

            throw new InvalidOperationException("Queue is empty.");
        }

        // Peek the item with the highest priority (without removing it)
        public T Peek()
        {
            for (int i = _maxPriority; i >= 0; i--)
            {
                if (_queue[i].Count > 0)
                {
                    return _queue[i][0];
                }
            }

            throw new InvalidOperationException("Queue is empty.");
        }

        // Check if the priority queue is empty
        public bool IsEmpty()
        {
            for (int i = 0; i <= _maxPriority; i++)
            {
                if (_queue[i].Count > 0)
                {
                    return false;
                }
            }
            return true;
        }

        // Return the number of elements in the priority queue
        public int Size()
        {
            int size = 0;
            for (int i = 0; i <= _maxPriority; i++)
            {
                size += _queue[i].Count;
            }
            return size;
        }
    }
    public class ListOfVectors_PQ<T>
    {
        private List<T[]> _queue;
        private int _maxPriority;

        public ListOfVectors_PQ(int maxPriority)
        {
            _maxPriority = maxPriority;
            _queue = new List<T[]>(maxPriority + 1);
            for (int i = 0; i <= maxPriority; i++)
            {
                _queue.Add(new T[0]);
            }
        }

        public void Enqueue(T item, int priority)
        {
            if (priority < 0 || priority > _maxPriority)
                throw new ArgumentException("Priority out of range.");

            // Create a new array with increased size and copy existing elements
            T[] currentArray = _queue[priority];
            Array.Resize(ref currentArray, currentArray.Length + 1);
            currentArray[currentArray.Length - 1] = item;
            _queue[priority] = currentArray;
        }

        public T Dequeue()
        {
            for (int i = _maxPriority; i >= 0; i--)
            {
                if (_queue[i].Length > 0)
                {
                    T item = _queue[i][0];

                    // Create a new smaller array to remove the first element
                    T[] currentArray = _queue[i];
                    T[] newArray = new T[currentArray.Length - 1];

                    // Copy elements after the first one
                    Array.Copy(currentArray, 1, newArray, 0, newArray.Length);

                    _queue[i] = newArray;
                    return item;
                }
            }
            throw new InvalidOperationException("Queue is empty.");
        }

        // Rest of the methods remain the same as in your original implementation
        public T Peek()
        {
            for (int i = _maxPriority; i >= 0; i--)
            {
                if (_queue[i].Length > 0)
                {
                    return _queue[i][0];
                }
            }
            throw new InvalidOperationException("Queue is empty.");
        }

        public bool IsEmpty()
        {
            for (int i = 0; i <= _maxPriority; i++)
            {
                if (_queue[i].Length > 0)
                {
                    return false;
                }
            }
            return true;
        }

        public int Size()
        {
            int size = 0;
            for (int i = 0; i <= _maxPriority; i++)
            {
                size += _queue[i].Length;
            }
            return size;
        }
    }
}
