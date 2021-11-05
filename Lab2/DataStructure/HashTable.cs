using System;
using System.Collections.Generic;
using System.IO;

namespace Lab2.DataStructure
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
        /// <param name="value">key</param>
        /// <returns>returns index from the space based on some calculation</returns>
        private int HashFunction(string value)
        {
            var index = 1;
            var asciiVal = 0;
            for (var i = 0; i < value.Length; i++)
            {
                asciiVal = value[i] * i;
                index = index * 2 + asciiVal;
            }

            return index % tableSize;
        }

        /// <summary>
        /// Inserts a value to table
        /// </summary>
        /// <param name="value">value to insert</param>
        /// <returns>Position in table with node index of the inserted element</returns>
        public Tuple<int, int> Insert(string value)
        {
            var hashValue = HashFunction(value);
            Node node = universe[hashValue];

            if (!Equals(Search(value), new Tuple<int, int>(-1, -1)))
            {
                return Search(value);
            }

            if (node == null)
            {
                universe[hashValue] = new Node() {Value = value};
                return new Tuple<int, int>(hashValue, 0);
            }

            //resolve collision
            var index = 1;
            while (node.Next != null)
            {
                node = node.Next;
                index++;
            }

            var newNode = new Node() {Value = value, Previous = node, Next = null};
            node.Next = newNode;

            return new Tuple<int, int>(hashValue, index);
        }

        /// <summary>
        /// Searches for a value in the table
        /// </summary>
        /// <param name="value">Value to search</param>
        /// <returns>Position in table with node index or (-1,-1) if the value is not found</returns>
        public Tuple<int, int> Search(string value)
        {
            var hashValue = HashFunction(value);
            Node node = universe[hashValue];
            var index = 0;
            while (node != null)
            {
                if (node.Value == value)
                {
                    return new Tuple<int, int>(hashValue, index);
                }

                node = node.Next;
                index++;
            }

            return new Tuple<int, int>(-1, -1);
        }

        public void Print()
        {
            List<string> lines = new List<string>();

            for (var index = 0; index < universe.Length; index++)
            {
                Node node = universe[index];
                var nodeCrt = 0;
                while (node != null)
                {

                    lines.Add(index + " " + nodeCrt + " : " + node.Value);
                    
                    node = node.Next;
                    nodeCrt++;
                }
                index++;
            }
            
            File.WriteAllLines("ST.out", lines);
        }
    }
}