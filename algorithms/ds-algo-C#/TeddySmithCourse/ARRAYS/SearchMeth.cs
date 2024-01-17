namespace TeddySmithCourse
{
    internal class SearchMeth
    {
        // Linear Search - easiest one (looping until a condition is true)
        public void LinearSearch()
        {
            int[] intArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8};


            // key means what value we looking for
            bool LinearSearch(int[] array, int key)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == key)
                    {
                        return true;
                    }
                }
                return false;
            }

            Console.WriteLine(LinearSearch(intArray, 12));
            Console.WriteLine(LinearSearch(intArray, 9));
            Console.WriteLine(LinearSearch(intArray, 6));
            Console.WriteLine(LinearSearch(intArray, 1));
        }


        public void BinarySearch()
        {
            // [-20, -15, 2, 7, 20, 30, 54]
            // Search value = 2
            // Start = 0
            // End = 7
            // Mid = (start + end) / 2 = 3.5 -> 3   ===>>> middle is element 7 from array
            // newArray[] = [-20, -15, 2, 7]
            
            // Search value = 2
            // NewStart = 0
            // NewEnd = 3
            // Mid = (start + end) / 2 = 1  ===>>> middle is element -15 from array
            // newArray[] = [2, 7]
            
            // Search value = 2
            // Start = mid point + 1 = 2 ->>>>>>>>>>>the new mid
            // End = 3
            // Mid = (start + end) / 2 = 2.5 -> 2   ===>>> middle is element 2 from array
            // newArray[] = [-15, 2, 7]

            int[] intArrayOne = [-22, -15, 2, 7, 20, 30, 54];
            int[] intArrayTwo = [-2224, -4115, 412, 474, 1220, 3440, 5144];
            int[] intArrayThree = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            int[] intArrayFour = [-20, -15, -10, -5, 20, 30, 54];
            Console.WriteLine(SearchMethod(intArrayOne, 2));
            Console.WriteLine(SearchMethod(intArrayTwo, 474));
            Console.WriteLine(SearchMethod(intArrayThree, 7));
            Console.WriteLine(SearchMethod(intArrayFour, 30));

            int SearchMethod(int[] intArray, int searchValue)
            {
                int start = 0;
                int end = intArray.Length;

                // start end + while less than is going criss crossing
                while (start < end)
                {
                    int midpoint = (start + end) / 2;

                    // search the middle of the book
                    if (intArray[midpoint] == searchValue)
                    {
                        return midpoint;
                    }
                    else if (intArray[midpoint] < searchValue)
                    {
                        start = midpoint + 1;
                    }
                    else
                    {
                        end = midpoint;
                    }
                }

                return -1;
            }

        }


        // BUBBLE SORT
        // easy but BAD - quadratic - n2
        // learning swaps / nested forloops
        // turn this [5,6,1,7,2,4] ---->>>>> into this [1,2,4,5,6,7]
        // comparing 2 by 2: example comparing 5,6 --->> 6,1 (swap) ---->> 6,7  ---->>> 7,2 (swap) ---> 7,4 (swap)
        // do again same
        public void BubbleSort()
        {
            int[] intArray = new int[] {5, 6, 1, 7, 2, 4};

            Console.WriteLine("-----------");
            Console.WriteLine("BUBBLE SORT");
            Console.WriteLine("-----------");

            // hold the temporary swap variable. Think of this as a state.
            int temp = 0;

            // iterates over entire loop many times
            for (int pointer = 0; pointer < intArray.Length; pointer++)
            {
                // forms the 'box that does the comparison'
                for (int sort = 0; sort < intArray.Length - 1; sort++)
                {
                    // this checks to see if
                    if (intArray[sort] > intArray[sort +1])
                    {
                        // we store variable as temp so we dont overwrite it when we swap
                        temp = intArray[sort + 1];
                        // put left to the right
                        intArray[sort + 1] = intArray[sort];
                        // put the right to the left
                        intArray[sort] = temp;
                    }
                }
            }

            foreach (var nr in intArray)
            {
                Console.WriteLine(nr);
            }
        }
    }
}