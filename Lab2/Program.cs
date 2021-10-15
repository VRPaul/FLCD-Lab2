using System;
using System.Diagnostics;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            TestAddElement();
            TestAddElementFirstKey();
            TestAddElementsThirdKey();
            TestGetNonexistentKey();
        }

        private static void TestAddElement()
        {
            var st = new SymbolTable();

            var key = st.Insert("test");

            Debug.Assert(st.Get(key) == "test");
        }

        private static void TestAddElementFirstKey()
        {
            var st = new SymbolTable();

            var key = st.Insert("test");

            Debug.Assert(key == 'a');
        }

        private static void TestAddElementsThirdKey()
        {
            var st = new SymbolTable();

            st.Insert("test1");
            st.Insert("test2");
            var key = st.Insert("test3");

            Debug.Assert(key == 'c');
        }
        
        private static void TestGetNonexistentKey()
        {
            var st = new SymbolTable();
            Console.WriteLine(st.Get('a'));
        }
    }
}