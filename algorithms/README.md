# This folder will contain different algorithms written in different programming languages for self learning

## Data structures and Algorithms for Begginers
`https://www.youtube.com/watch?v=BBpAmxU_NQo&list=LL&index=2&t=16s&ab_channel=ProgrammingwithMosh`
`Pro`

`Programming with Mosh`


## TOPICS COVERED
    - Big O Notation
    - Arrays
    - Linked Lists

### Big O Notation ( `O(n)` )
-O notation is used to describe the performance of an algorithm (scalable or not)
-operations we use can be more or less costly depending on what data structures we use





## Data Structures and Algorithms In C#:
`https://www.youtube.com/watch?v=n7nLxRaZfac&list=PL82C6-O4XrHf49SjEZWSa5DHN--ZRrcN_&ab_channel=TeddySmith`
`Teddy Smith`

## TOPICS COVERED
    - Abstract Data Types
    - Big-O Notations
    - Array / Array Insertions


### `Abstract Data Types`
    -this is just a class (object)
    -CRUD
    -"representation & operation"
    -List, Linked-List, Queue, etc (are basically classes that store and operate on data at the end of the day)

### `Big-O Notations`
    * How efficient/fast/well/optimized is your code ?
    * How we measure this stuffs ?
    * O(1).........O(n).........O(n^2)        -> 99% of the algorithms

`O(1)` - Constant time complexity

    -Assigment:         var test = 0;
    -Declarations:      var test;
    -Arithmetic:        2 + 2;
    -Comparison:        2 > 1;
    -Access Element:    array[1];
    -Call Function:     someFunction();


`O(n)` - Linear time complexity

    -Think "for loop"
    -Number of inputs increase time
    -Take the bigger number
    -EX: the bigger the array is, the complexity is increased

    -int total = 0      -> O(1)
    -while (i < 10)     -> O(n)


`O(n^2)` - Quadratic

    -A nested forloop/iteration

var n = int.Parse(Console.ReadLine());
for (var r = 1; r <=n; r++)
{
    for (var c = 1; c <= n; c++)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}


`*** log N`

    -Binary search & Trees



`*** n log(n)`

    -Quick Sort, Merge Sort, Shell Sort, Cube Sort






### `ARRAYS`

    -Array contains anything
    -Random Access
    -Killer Feature? GET / SET
    -AKA "Random Access"
    -Think "Hard Drive vs RAM"
    -! Lists<> are actually arrays in C#

   `Array INSERTIONS & DELETIONS`
    -insert at the end of array
    -insert at the start of array
    -insert anywhere in array
    -delete from end of array
    -delete from start of array
    -delete from anywhere from array


### `LINEAR SEARCH ARRAYS`
    -easiest searching algoritm for a search
    -looping an array until a specific statements is returning true (match requirements)



### `LINKED LIST`
    -the most important C# Data Structure
    -ancestor of the List<>
    -its like an "array objectified"s

    -BAD THINGS ABOUT ARRAYS: size is fixed / can't insert into middle
    -GOOD THINGS ABOUT LINKED LIST: size dynamic / can insert anywhere


### `STACK`
    -LAST IN - FIRST OUT
    -FIRST IN - LAST OUT
    -LAST IN is the top in the stack
    -think "a tube of tennis balls"
    -METHODS:
        -push
        -pop
        -peek

### `QUEUE`
    -FIRST IN - FIRST OUT
    -Think of a Drive-Thru FastFood (first who come, he orders first, he leaves first)
    -METHODS:
        -add (add item to the end) `enqueue`
        -remove (remove item at the front) `dequeue`
        -peek


### `BINARY SEARCH`
    -the phone book algorithm
    -you can only search SORTED DATA !!!!!!!!!!!!!!!!!!!!!!!!

    PSEUDO CODE:
        -find middle element
        -is the middle element? Yes? Done
        -is element bigger? search the left half
        -is element smaller? search the right half
        -keep "Halfing" till you find the number
        -(START + END) / 2  = 3.5 -> middle element is index 3


