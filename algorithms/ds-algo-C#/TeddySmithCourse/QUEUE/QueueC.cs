namespace TeddySmithCourse
{
    internal class QueueC
    {
        private int MaxSize { get; set; } // sets the number of elements because this is an array
        private int[] QueueArray { get; set; } // actual array
        private int Front { get; set; } // keep track of front
        private int Rear { get; set; } // index to keep track of adds
        private int NItems { get; set; } // keep track of length

        public QueueC(int size)
        {
            this.MaxSize = size;
            this.QueueArray = new int[MaxSize];
            Front = 0;
            Rear = -1;
        }


        // Insert
        public void Enqueue(int item)
        {
            Rear++;
            QueueArray[Rear] = item;
            NItems++;
        }

        public int Dequeue()
        {
            int temp = QueueArray[Front];
            Front++;

            if (Front == MaxSize)
            {
                Front = 0;
            }

            NItems --;
            return temp;
        }

        public int Peek()
        {
            return QueueArray[Front];
        }
    }
}