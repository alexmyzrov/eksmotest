using System;

namespace MatrixOperations.App
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a path to tasks folder.");
                return;
            }
            
            Console.WriteLine(args[0]);
        }
    }
}