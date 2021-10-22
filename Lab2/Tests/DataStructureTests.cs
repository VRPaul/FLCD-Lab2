using System;
using System.Diagnostics;
using Lab2.DataStructure;

namespace Lab2.Tests
{
    public static class DataStructureTests
    {
        /// <summary>
        /// Adds an element, then searches to if it's there
        /// </summary>
        public static void TestAddElement()
        {
            var st = new HashTable(50);

            st.Insert("test");

            Debug.Assert(!Equals(st.Search("test"), new Tuple<int, int>(-1, -1)));
        }

        /// <summary>
        /// Adds an element, then compares the expected position with the one resulted after a search
        /// </summary>
        public static void TestAddElementKey()
        {
            var st = new HashTable(50);

            st.Insert("test");
            Console.WriteLine(st.Search("test"));
            Debug.Assert(Equals(st.Search("test"), new Tuple<int, int>(36, 0)));
        }

        /// <summary>
        /// Adds an element, then compares the returned key with the one resulted after a search
        /// </summary>
        public static void TestAddElementReturnedKey()
        {
            var st = new HashTable(50);

            var key = st.Insert("test");

            Debug.Assert(Equals(st.Search("test"), key));
        }
    }
}