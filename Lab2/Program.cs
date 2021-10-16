using System;
using System.Diagnostics;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            TestAddElement();
            TestAddElementKey();
            TestAddElementReturnedKey();
        }

        private static void TestAddElement()
        {
            var st = new HashTable(50);

            st.Insert("test");

            Debug.Assert(!Equals(st.Search("test"), new Tuple<int, int>(-1, -1)));
        }

        private static void TestAddElementKey()
        {
            var st = new HashTable(50);

            st.Insert("test");
            Console.WriteLine(st.Search("test"));
            Debug.Assert(Equals(st.Search("test"), new Tuple<int, int>(36, 0)));
        }

        private static void TestAddElementReturnedKey()
        {
            var st = new HashTable(50);

            var key = st.Insert("test");

            Debug.Assert(Equals(st.Search("test"), key));
        }
        
    }
}