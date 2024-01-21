namespace TeddySmithCourse
{
    internal class HashTable
    {
        // mose useful algorithm in data structure
            // used to store key - value pairs
            // similar to arrays and unordered
            // *Hash tables are fast for everything: Find, Add, Remove
            // Disadvantage? (Collision! and Load Factor)

        // KEYS -> Hash Functions -> VALUE

        // * Why use HASH TABLES over Array?    // More flexibility
        // array[3] = "Eduard"
        // array["name"] = "Eduard"

        // * What are they called in C# ?
        // Dictionary<TKey, TValue>
         

        // ! * What is a hash?? ------>>>>>. "ADDRESS LOCATER"

        public string[] _hashTable { get; set; }

        public HashTable()
        {
            _hashTable = new string[10];
        }

        // very weak algorithm hashing
        private int _hash(string key)
        {
            return key.Length % _hashTable.Length;
        }

        public string Get(string key)
        {
            int hashedKey = _hash(key);
            return _hashTable[hashedKey];
        }

        public void Set(string key, string value)
        {
            // key is going to be hashed
            int hashedKey = _hash(key);

            if (_hashTable[hashedKey] != null)
            {
                Console.WriteLine("Sorry, hash collision has occured.");
            }
            else
            {
                _hashTable[hashedKey] = value;
            }

        }
    }
}