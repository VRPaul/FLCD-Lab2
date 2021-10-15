using System;

namespace Lab2
{
    public class HashTable
    {
        private Node[] universe;
        private readonly int tableSize;

        public HashTable(int maxTableSize)
        {
            tableSize = maxTableSize;
            universe = new Node[tableSize];
        }

        /// <summary>
        /// Hash function
        /// Here we used division method which divides and gives reminder, here we can see we used 7(a prime)
        /// to start with and 31(again prime), primes are good make random hash, as well I multiplied ASCII value with
        /// character position in string so "aSp" and "AsP" won't be same as well "asp" and "psa".
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>returns index from the space based on some calculation</returns>
        private int HashFunction(string key)
        {
            var index = 7;
            var asciiVal = 0;
            for (var i = 0; i < key.Length; i++)
            {
                asciiVal = key[i] * i;
                index = index * 31 + asciiVal;
            }
            return index % tableSize;
        }

        /// <summary>
        /// Inserts a value with key to table
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value associated to key</param>
        public void Insert(string key, object value)
        {
            var genIndex = HashFunction(key);
            Node node = universe[genIndex];

            if (node == null)
            {
                universe[genIndex] = new Node() { Key = key, Value = value };
                return;
            }

            if (node.Key == key)
                throw new Exception("Can't use same key!");

            //resolve collision
            while (node.Next != null)
            {
                node = node.Next;
                if (node.Key == key)
                    throw new Exception("Can't use same key!");
            }

            var newNode = new Node() { Key = key, Value = value, Previous = node, Next = null };
            node.Next = newNode;
        }

        /// <summary>
        /// fetch value of a key
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>value</returns>
        public object GetValue(string key)
        {
            var genIndex = HashFunction(key);
            Node node = universe[genIndex];
            while (node != null)
            {
                if (node.Key == key)
                {
                    return node.Value;
                }
                node = node.Next;
            }

            throw new Exception("Don't have the key in hash!");
        }
    }
}