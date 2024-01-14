namespace TeddySmithCourse
{
    internal class LinkedList
    {
        // IMPORTANT - Insert
        // 1. Create a new node
        // 2. Assign data to the next field
        // 3. Assign the head
        // 4. O(1)

        // We have [Node1, Node2, Node3, null]. How to insert new Node at the beggining?
        public Node? First { get; set; }

        public void InsertFirst(int data)
        {
            // create the node
            Node newNode = new Node();

            // put the data in the node
            newNode.Data = data;

            // put the old node in the next
            newNode.Next = First;

            // make the head the new node
            First = newNode;
        }


        // IMPORTANT - delete
        // 1. Assign a temporary variable
        // 2. Assign new head
        // 3. Return temporary variable
        // 4. O(1)
        public Node DeleteFirst()
        {
            // assign temporary var
            Node temporary = First;
            // assign the new head
            First = First.Next;

            return temporary;
        }


        // IMPORTANT - iterate
        // 1. Assign a current node
        // 2. Make a while loop
        // 3. Check current node is null
        public void DisplayList()
        {
            Console.WriteLine("Iterating thru list...");
            Node currentNode = First;

            while (currentNode != null)
            {
                currentNode.DisplayNode();
                currentNode = currentNode.Next;
            }
        }


        public void InsertLast(int data)
        {
            Node currentNode = First;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            Node newNode = new Node();
            newNode.Data = data;

            currentNode.Next = newNode;
        }
    }
}