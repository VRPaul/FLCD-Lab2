using System;
using System.Diagnostics;
using System.IO;
using Lab2.Tests;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Scanner scanner = new Scanner("token.in");
            scanner.Scan(Path.Combine(Environment.CurrentDirectory, @"p1.x"));
        }
        
    }
}