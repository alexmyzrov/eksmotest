using System;
using System.Linq;
using System.Threading.Tasks;
using MatrixOperations.DAL;

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

            var storage = new MatrixTaskFileStorage(args[0]);

            Task result = null;

            try
            {
                var tasks = storage
                    .GetFiles()
                    .Select(filePath => Task.Run(() => ExecuteTaskFromFile(storage, filePath)))
                    .ToList();

                result = Task.WhenAll(tasks); 
                result.Wait();
            }
            catch
            {
                foreach (var exception in result.Exception.InnerExceptions)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        private static void ExecuteTaskFromFile(MatrixTaskFileStorage storage, string filePath)
        {
            var task = MatrixTaskFileStorage.GetTask(filePath);

            storage.Save(task.Execute(), task.Name);
        }
    }
}