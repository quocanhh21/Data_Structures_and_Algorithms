namespace Linked_List
{
    public class Node<T>
    {
        private T data;
        private Node<T> previous, next;

        public Node(T data, Node<T> previous, Node<T> next)
        {
            this.data = data;
            this.previous = previous;
            this.next = next;
        }

        public T Data { get => data; set => data = value; }
        public Node<T> Previous { get => previous; set => previous = value; }
        public Node<T> Next { get => next; set => next = value; }

        public string ToString()
        {
            return data.ToString();
        }
    }
}
