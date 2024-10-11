namespace Linked_List
{
    public interface IDoublyLinkedList<T> 
    {
        // O(n)
        void Clear();

        // Constant
        int Size { get; }

        // Constant
        bool IsEmpty { get; }

        // O(1)
        void Add(T element);

        // O(1)
        void AddFirst(T element);

        // O(1)
        void AddLast(T element);

        // O(1)
        T PeekFirst();

        // O(1)
        T PeekLast();

        // O(1)
        T RemoveFirst();

        // O(1)
        T RemoveLast();

        // O(1)
        T Remove(Node<T> node);

        // O(n)
        bool Remove(T item);

        // O(n)
        T RemoveAt(int index);

        // O(n)
        int IndexOf(T item);

        // O(n)
        bool Contains(T item);
    }

}
