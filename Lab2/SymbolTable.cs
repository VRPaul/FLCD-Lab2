namespace Lab2
{
    public class SymbolTable
    {
        private HashTable hashTable = new HashTable(50);

        private char currentKey = 'a';

        public char Insert(string value)
        {
            hashTable.Insert(currentKey.ToString(), value);

            var insertedKey = currentKey;

            currentKey = (char)(currentKey + 1);
            
            return insertedKey;
        }

        public string Get(char key)
        {
            return hashTable.GetValue(key.ToString()).ToString();
        }
        
    }
}