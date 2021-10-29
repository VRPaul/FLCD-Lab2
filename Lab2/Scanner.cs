using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Lab2.DataStructure;

namespace Lab2
{
    public class Scanner
    {
        public HashTable St { get; } = new(128);
        public List<Tuple<string,Tuple<int, int>>> Pif { get; } = new();

        private List<string> operators;
        private List<string> separators;
        private List<string> reservedWords;

        private Regex regexTokens = new Regex(
            "-?[A-Za-z][A-Za-z0-9]*|\"[A-Za-z][A-Za-z0-9]*\"" +
            "|((\\+|\\-)?[0-9]+)|\\(|\\)|\\[|\\]|{|}|:|;|\\+<-|-<-|\\*<-|\\/<-|<=|>=|<-|=|\\+|-|\\*|\\/|,|\"");
        
        private Regex regexIdentifier = new Regex(@"[A-Za-z][A-Za-z0-9]*");

        private Regex regexConstant = new Regex("True|False|0|((\\+|\\-)?[1-9][0-9]*)|\"[A-Za-z][A-Za-z0-9]*\"");

        private int lineNo = 1;

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
                
                foreach (var match in regexTokens.Matches(line))
                {
                    if (reservedWords.Contains(match.ToString()) || operators.Contains(match.ToString()) || separators.Contains(match.ToString()))
                    {
                        //if (!IsInPif(match.ToString()))
                        {
                            Pif.Add(new Tuple<string, Tuple<int, int>>(match.ToString(), new Tuple<int, int>(-1,-1)));
                        }
                    }
                    else if (regexConstant.Match(match.ToString()).Success)
                    {
                        Pif.Add(new Tuple<string, Tuple<int, int>>("constant",St.Insert(match.ToString())));
                    }
                    else if (regexIdentifier.Match(match.ToString()).Success)
                    {
                        Pif.Add(new Tuple<string, Tuple<int, int>>("identifier",St.Insert(match.ToString())));
                    }

                    else
                    {
                        Console.WriteLine("Lexical Error on line: " + lineNo);
                        return;
                    }
                }
                lineNo++;
            }

            Console.WriteLine();
            foreach (var item in Pif)
            {
                Console.WriteLine(item.ToString());
            }
        }
        
        private bool IsInPif(string value)
        {
            return Pif.Any(item => item.Item1 == value);
        }
    }
}