using System;
using System.Collections.Generic;

// Node class for Doubly Linked List
public class DLinkedNode
{
    public int Key { get; set; }
    public int Value { get; set; }
    public DLinkedNode Prev { get; set; }
    public DLinkedNode Next { get; set; }

    public DLinkedNode(int key = 0, int value = 0)
    {
        Key = key;
        Value = value;
    }
}

// LRU Cache class
public class LRUCache
{
    private Dictionary<int, DLinkedNode> cache = new Dictionary<int, DLinkedNode>();
    private int size;
    private int capacity;
    private DLinkedNode head, tail;

    public LRUCache(int capacity)
    {
        this.size = 0;
        this.capacity = capacity;

        // Dummy head and tail nodes to simplify boundary operations
        head = new DLinkedNode();
        tail = new DLinkedNode();
        head.Next = tail;
        tail.Prev = head;
    }

    // Get value from cache
    public int Get(int key)
    {
        if (!cache.ContainsKey(key))
            return -1;

        // Move the accessed node to the front (most recently used)
        DLinkedNode node = cache[key];
        MoveToHead(node);

        return node.Value;
    }

    // Put key-value into the cache
    public void Put(int key, int value)
    {
        if (cache.ContainsKey(key))
        {
            // Update the existing node and move it to the front
            DLinkedNode node = cache[key];
            node.Value = value;
            MoveToHead(node);
        }
        else
        {
            // If the cache is full, remove the least recently used node (tail)
            if (size == capacity)
            {
                DLinkedNode tail = RemoveTail();
                cache.Remove(tail.Key);
                size--;
            }

            // Create a new node and add it to the front
            DLinkedNode newNode = new DLinkedNode(key, value);
            cache[key] = newNode;
            AddToHead(newNode);
            size++;
        }
    }

    // Move a node to the front (mark it as most recently used)
    private void MoveToHead(DLinkedNode node)
    {
        RemoveNode(node);
        AddToHead(node);
    }

    // Add a new node right after the head (most recently used position)
    private void AddToHead(DLinkedNode node)
    {
        node.Prev = head;
        node.Next = head.Next;
        head.Next.Prev = node;
        head.Next = node;
    }

    // Remove a node from the linked list
    private void RemoveNode(DLinkedNode node)
    {
        DLinkedNode prevNode = node.Prev;
        DLinkedNode nextNode = node.Next;

        prevNode.Next = nextNode;
        nextNode.Prev = prevNode;
    }

    // Remove the tail node (least recently used)
    private DLinkedNode RemoveTail()
    {
        DLinkedNode node = tail.Prev;
        RemoveNode(node);
        return node;
    }
}

public class Program
{
    public static void Main()
    {
        LRUCache cache = new LRUCache(2); // Cache capacity is 2

        cache.Put(2, 1);
        cache.Put(2, 2);
        Console.WriteLine(cache.Get(2));   // returns 1

        cache.Put(1, 1);   // evicts key 2
        //Console.WriteLine(cache.Get(2));   // returns -1 (not found)

        cache.Put(4, 1);   // evicts key 1
        Console.WriteLine(cache.Get(2));   // returns -1 (not found)
        //Console.WriteLine(cache.Get(3));   // returns 3
        //Console.WriteLine(cache.Get(4));   // returns 4
    }
}
