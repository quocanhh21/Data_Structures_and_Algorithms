﻿using System.Collections;

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
                head = tail.Previous;
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
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public T RemoveAt(int index)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
