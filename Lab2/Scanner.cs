using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Lab2
{
    public class Scanner
    {
        public Hashtable St { get; } = new();
        public Dictionary<string, Tuple<int,int>> Pif { get; } = new();

        private List<string> operators;
        private List<string> separators;
        private List<string> reservedWords;

        /// <summary>
        /// Reads from a given input file the tokes of the language and puts them in 3 different collections:
        /// operators, separators, reservedWords
        /// </summary>
        /// <param name="tokensFilePath">Tokens file path</param>
        public Scanner(string tokensFilePath)
        {
            using var file = new StreamReader(tokensFilePath);
            var operatorsStrings = file.ReadLine()?.Split(" ");
            operators = new List<string>(operatorsStrings);
            
            var separatorsStrings = file.ReadLine()?.Split(" ");
            separators = new List<string>(separatorsStrings);
            separators.Add(" ");
            
            var reservedWordsStrings = file.ReadLine()?.Split(" ");
            reservedWords = new List<string>(reservedWordsStrings);

            file.Close();
        }

        /// <summary>
        /// Reads all lines from a file
        /// </summary>
        /// <param name="filePath">Program file path</param>
        /// <returns>A string collection with all line from the file</returns>
        private IEnumerable<string> ReadProgram(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        /// <summary>
        /// Scans the given program
        /// </summary>
        /// <param name="filePath">Program file path</param>
        public void Scan(string filePath)
        {
            var lines = ReadProgram(filePath);

            // get each line from the program
            foreach (var line in lines)
            {
            }
        }
    }
}