namespace TeddySmithCourse
{
    internal class Node
    {
        public int Data { get; set; }
        public Node? Next { get; set; }

        public void DisplayNode()
        {
            Console.WriteLine(Data);
        }
    }
}