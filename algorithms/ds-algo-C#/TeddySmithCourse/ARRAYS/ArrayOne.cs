namespace TeddySmithCourse
{
    internal class ArrayOne
    {
        // Insertion at the end of array
        public void InsertionAtTheEnd()
        {
            Console.WriteLine("InsertionAtTheEnd - ended");

            int[] intArray = new int[6];
            int length = 0; // we need to keep track of the index
            // .Length method is based of capacity

            // Adding data in our array
            for (int i = 0; i < 3; i++)
            {
                intArray[length] = i;
                length++;
            }

            intArray[length] = 8;
            length++;

            Console.WriteLine("InsertionAtTheEnd - ended");
        }


        // Insertion at the start of array
        public void InsertionAtTheStart()
        {
            Console.WriteLine("InsertionAtTheStart - ended");

            int[] intArray = new int[6];
            int length = 0; // we need to keep track of the index
            // .Length method is based of capacity

            // Adding data in our array
            for (int i = 0; i < 3; i++)
            {
                intArray[length] = i + 1;
                length++;
            }

            // now we want to insert at start end of our array
            for (int i = 3; i >= 0; i--)
            {
                // this is moving over all the values
                intArray[i + 1] = intArray[i];
            }

            intArray[0] = 20;


            Console.WriteLine("InsertionAtTheStart - ended");
        }



        // Insert anywhere in array -> insert in the middle
        public void InsertionAnywhereArray()
        {
            //d

            Console.WriteLine("InsertionAnywhereArray - ended");

            int[] intArray = new int[10];
            int length = 0; // we need to keep track of the index
            // .Length method is based of capacity

            // Adding data in our array
            for (int i = 0; i < 8; i++)
            {
                intArray[length] = i + 1;
                length++;
            }

            // shift element one position to the right
            for (int i = 4; i >= 2; i--)
            {
                intArray[i + 1] = intArray[i];
            }

            intArray[2] = 50;


            Console.WriteLine("InsertionAnywhereArray - ended");
        }



        // Deleting from the end of array
        public void DeleteFromTheEnd()
        {
            int[] intArray = new int[10];
            int length = 0;

            for (int i = 0; i < 6; i++)
            {
                intArray[length] = i;
                length++;
            }

            int[] newIntArray = new int[length-1];

            for (int i = 0; i < length - 1; i++)
            {
                newIntArray[i] = intArray[i];
            }

            length--;
        }


        // Deleting from the start of array
        public void DeleteFromTheStart()
        {
            int[] intArray = new int[10];
            int length = 0;

            for (int i = 0; i < 6; i++)
            {
                intArray[length] = i;
                length++;
            }

            for (int i = 1; i < length; i++)
            {
                intArray[i - 1] = intArray[i];
            }
            
            length--;
        }



        // Delete from anywhere from array
        public void DeleteFromAnywhere()
        {
            int[] intArray = new int[10];
            int length = 0;

            for (int i = 0; i < 6; i++)
            {
                intArray[length] = i;
                length++;
            }

            for (int i = 2; i < length; i++)
            {
                intArray[i - 1] = intArray[i];
            }

            length--;

            for (int i = 0; i < length; i++) {
                Console.WriteLine(intArray[i]);
            }
        }
    }
}