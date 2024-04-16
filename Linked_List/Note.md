# Note

###

### Why linked list data structure needed?
 - Dynamic Data structure: The size of memory can be allocated or de-allocated at run time based on the operation insertion or deletion.
 - Ease of Insertion/Deletion: The insertion and deletion of elements are simpler than arrays since no elements need to be shifted after insertion and deletion, Just the address needed to be updated.
 - Efficient Memory Utilization: As we know Linked List is a dynamic data structure the size increases or decreases as per the requirement so this avoids the wastage of memory. 
 - Implementation: Various advanced data structures can be implemented using a linked list like a stack, queue, graph, hash maps, etc.
	
### Types of linked lists: 
 ##### 1. Singly linked list:
 ##### 2. Doubly linked list:
 ##### 3. Circular linked list:

 ### Comparison Singly vs Doubly
|				| Singly | Doubly |
|---------------| ------ | ------ |
|Memory			| better( 1 pointer) | (2 pointer) |
|Implementation | Better |	-	|
|Action			| Cannot | Reverse tracing|
|---------------| ------ | ------ |
| (Insert)Head	| O(1)   | O(1) |
| (Insert)Tail	| O(1)   | O(1) |
| (Insert)Middle| O(n)   | O(n) |
| (Remove)Head  | O(1)   | O(1) |
| (Remove)Tail  | O(n)   | O(1) |
| (Remove)Middle| O(n)   | O(n) |