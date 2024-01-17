namespace TeddySmithCourse
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.WriteLine("hello dan");

            Test myClass = new Test();

            var sum = myClass.Calc(5);

            Console.WriteLine(sum);

            // ADT
            // Declare the Data Structure

            // Stack ts = new Stack();
            Pokemon squirtle = new Pokemon();


            // array
            ArrayOne arrayOne = new ArrayOne();
            arrayOne.InsertionAtTheEnd();
            arrayOne.InsertionAtTheStart();
            arrayOne.InsertionAnywhereArray();
            arrayOne.DeleteFromTheEnd();
            arrayOne.DeleteFromTheStart();
            arrayOne.DeleteFromAnywhere();

            // array search
            Console.WriteLine("---------------------");
            Console.WriteLine("Array - Linear search");
            Console.WriteLine("---------------------");
            SearchMeth searchMeth = new SearchMeth();
            searchMeth.LinearSearch();

            // linked list
            // Also explication of Node inside of the linked list
            Node nodeA = new Node();
            nodeA.Data = 415;

            Node nodeB = new Node();
            nodeB.Data = 653;

            Node nodeC = new Node();
            nodeC.Data = 357;

            Node nodeD = new Node();
            nodeD.Data = 622;

            nodeA.Next = nodeB;
            nodeB.Next = nodeC;
            nodeC.Next = nodeD;




            // linked list
            Console.WriteLine("---------------------");
            Console.WriteLine("Linked List");
            Console.WriteLine("---------------------");
            LinkedList linkedList = new LinkedList();
            // insert
            linkedList.InsertFirst(1);
            linkedList.InsertFirst(2);
            linkedList.InsertFirst(3);
            linkedList.InsertFirst(4);
            linkedList.InsertFirst(5);
            // delete
            linkedList.DeleteFirst();
            linkedList.DeleteFirst();
            linkedList.DeleteFirst();
            // insert last
            linkedList.InsertLast(343434);
            // iterate
            linkedList.DisplayList();




            // stack
            Console.WriteLine("---------------------");
            Console.WriteLine("Stack");
            Console.WriteLine("---------------------");
            Stack myStack = new Stack(10);

            Console.WriteLine(myStack.isEmpty());

            for (int i = 0; i < 3; i++)
            {
                myStack.Push("squirtle");
                myStack.Push("pickachu");
                myStack.Push("charmander");
            }

            Console.WriteLine(myStack.isEmpty());
            myStack.Pop();
            myStack.Peek();

            while (!myStack.isEmpty())
            {
                var myVal = myStack.Pop();
                Console.WriteLine(myVal);
            }
            Console.WriteLine(myStack.isEmpty());




            // Queue
            Console.WriteLine("---------------------");
            Console.WriteLine("Queue");
            Console.WriteLine("---------------------");
            QueueC myQueue = new QueueC(10);

            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.Enqueue(4);
            myQueue.Dequeue();
            myQueue.Dequeue();
            myQueue.Peek();



            // Binary search
            Console.WriteLine("---------------------");
            Console.WriteLine("Binary search");
            Console.WriteLine("---------------------");
            SearchMeth searchMethTwo = new SearchMeth();
            searchMethTwo.BinarySearch();
        }
    }
}