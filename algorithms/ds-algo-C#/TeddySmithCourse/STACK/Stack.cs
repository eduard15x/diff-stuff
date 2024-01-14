namespace TeddySmithCourse
{
    internal class Stack
    {
        public int MaxSize { get; set; } // array stacks you need a maxsize to init the array
        public string[] StackArray { get; set; }
        public int Top { get; set; }

        public Stack(int size)
        {
            this.MaxSize = size;
            // create an fixed size array
            this.StackArray = new string[MaxSize];
            this.Top = -1; // because array is empty, and for the first entry we need index 0
        }


        public void Push(string item) // you put item on top into stack
        {
            Top++;
            StackArray[Top] = item;
        }

        public string Pop() // you getting out the top element from the stack
        {
            int oldTop = Top; // placeholder
            Top--;

            return StackArray[oldTop];
        }

        public string Peek() // access the top in the stack
        {
            return StackArray[Top];
        }

        public bool isEmpty()
        {
            return Top == -1;
        }

        public bool isFull()
        {
            return MaxSize - 1 == Top;
        }
    }
}