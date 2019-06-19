using System;
using System.Linq;
using System.Threading.Tasks;
using MatrixOperations.DAL;

namespace MatrixOperations.App
{
    internal static class Program
    {
        private static int _tasksCount;
        
        private static int _completedTasksCount;
        
        private static readonly object Locker = new object();
        
        private static MatrixTaskFileStorage _storage;
        
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a path to tasks folder.");
                return;
            }

            _storage = new MatrixTaskFileStorage(args[0]);

            Task result = null;

            try
            {
                var files = _storage
                    .GetFiles()
                    .ToList();

                _tasksCount = files.Count;
                
                var tasks = files
                    .Select(filePath => Task.Run(() => ExecuteTaskFromFile(filePath)))
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

        private static void ExecuteTaskFromFile(string filePath)
        {
            var task = MatrixTaskFileStorage.GetTask(filePath);

            _storage.Save(task.Execute(), task.Name);

            lock (Locker)
            {
                _completedTasksCount++;
                Console.Write($"\rCompleted {_completedTasksCount} of {_tasksCount} tasks    ");
            }
        }
    }
}