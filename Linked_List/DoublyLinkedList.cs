using System.Collections;
using System.Runtime.Serialization;

namespace Linked_List
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private int size;
        private Node<T> head = null;
        private Node<T> tail = null;

        public int Size => size;

        public bool IsEmpty => size == 0;

        public void Add(T element)
        {
            AddLast(element);
        }

        public void AddFirst(T element)
        {
            if (IsEmpty)
            {
                head = tail = new Node<T>(element, null, null);
            }
            else
            {
                head.Previous = new Node<T>(element, null, head);
                head = head.Previous;
            }
        }

        public void AddLast(T element)
        {
            if (IsEmpty)
            {
                head = tail = new Node<T>(element, null, null);
            }
            else
            {
                tail.Next = new Node<T>(element, tail, null);
                tail = tail.Next;
            }

            size++;
        }

        public void Clear()
        {
            // Clear
            Node<T> currentNode = head;
            while (currentNode != null)
            {
                Node<T> nextNode = currentNode.Next;
                currentNode.Next = null;
                currentNode.Previous = null;
                currentNode.Data = default;
                currentNode = nextNode;
            }

            // Reset
            head = tail = null;
            size = 0;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            int index = 0;

            Node<T> currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Data.Equals(item))
                {
                    return index;
                }
                currentNode = currentNode.Next;
                if (currentNode == null)
                {
                    return -1;
                }
                index++;
            }

            return index;
        }

        public T PeekFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Empty linked list!");
            }
            return head.Data;
        }

        public T PeekLast()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Empty linked list!");
            }
            return tail.Data;
        }

        public T Remove(Node<T> node)
        {
            if (node.Previous == null) return RemoveFirst();
            if (node.Next == null) return RemoveLast();

            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;

            T data = node.Data;
            size--;

            // Reset
            node.Data = default;
            node.Previous = null;
            node.Next = null;
            node = null;

            return data;
        }

        public bool Remove(T item)
        {
            Node<T> currentNode = head;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(item))
                {
                    Remove(currentNode);
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }

        public T RemoveAt(int index)
        {
            if (index <0 || index >= size) throw new ArgumentOutOfRangeException("Index out of range!");

            Node<T> currentNode;
            int i;
            if (index < size / 2)
            {
                for (i = 0, currentNode = head; i != index; i++)
                {
                    currentNode = currentNode.Next;
                }
            }
            else
            {
                for (i = size - 1, currentNode = tail; i != index; i--)
                {
                    currentNode = currentNode.Previous;
                }
            }

            return Remove(currentNode);
        }

        public T RemoveFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Empty linked list!");
            }
            
            T data = head.Data;
            head = head.Next;
            size--;
            if (IsEmpty) tail = null;
            else head.Previous = null;

            return data;
        }

        public T RemoveLast()
        {
            if(IsEmpty)
            {
                throw new InvalidOperationException("Empty linked list!");
            }

            T data = tail.Data;
            tail = tail.Previous;
            size--;
            if (IsEmpty) head = null;
            else tail.Next = null;

            return data;
        }

        public void Traverse()
        {
            Console.WriteLine("Traverse through doubly linked list");
            Node<T> currentNode = head;
            while (currentNode != null)
            {
                
                Console.Write(currentNode.Data + " <-> ");
                currentNode = currentNode.Next;
            }
            Console.Write("null");
        }

        public void ReverseTraverse()
        {
            Console.Write("\n");
            Console.WriteLine("Reverse traverse through doubly linked list");
            Node<T> currentNode = tail;
            while (currentNode != null)
            {
                Console.Write(currentNode.Data + " <-> ");
                currentNode = currentNode.Previous;
            }
            Console.Write("null");
        }

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
