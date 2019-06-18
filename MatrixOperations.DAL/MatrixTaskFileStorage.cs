using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MatrixOperations.Domain;
using MatrixOperations.Domain.Tasks;

namespace MatrixOperations.DAL
{
    public class MatrixTaskFileStorage
    {
        private readonly string _folderPath;
        
        private const string MultiplyTaskTypeName = "multiply";
        private const string AddTaskTypeName = "add";
        private const string SubtractTaskTypeName = "subtract";
        private const string TransposeTaskTypeName = "transpose";
        
        private const string TaskFilePattern = "*.txt";
        private const string TaskResultPostfix = "_result.txt";
        
        public MatrixTaskFileStorage(string folderPath)
        {
            _folderPath = folderPath;
        }
        
        public IEnumerable<string> GetFiles()
        {
            return Directory.EnumerateFiles(_folderPath, TaskFilePattern)
                .Where(f => !f.EndsWith(TaskResultPostfix));
        }
        
        public static MatrixTask GetTask(string filePath)
        {
            MatrixTask matrixTask;

            var taskName = Path.GetFileNameWithoutExtension(filePath);
            
            using (var reader = File.OpenText(filePath))
            {
                var taskTypeName = reader.ReadLine();
                
                // Space after task type name
                reader.ReadLine();

                matrixTask = CreateFromTypeName(taskTypeName, taskName);

                while (!reader.EndOfStream)
                {
                    matrixTask.AddMatrix(ReadMatrix(reader));
                }
            }

            return matrixTask;
        }
        
        public void Save(IEnumerable<Matrix> matrices, string taskName)
        {
            var result = string.Empty;
            
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var matrix in matrices)
            {
                result += matrix + Environment.NewLine;
            }
            
            File.WriteAllText($"{_folderPath}/{taskName}{TaskResultPostfix}", result);
        }

        private static Matrix ReadMatrix(TextReader reader)
        {
            var numbers = new List<List<int>>();

            var nextLine = reader.ReadLine();

            while (!string.IsNullOrEmpty(nextLine))
            {
                numbers.Add(nextLine.Split(' ')
                    .Select(int.Parse)
                    .ToList());

                nextLine = reader.ReadLine();
            }

            var rowsCount = numbers.Count;

            var columnsCount = numbers[0].Count;

            var data = new int[rowsCount, columnsCount];

            for (var i = 0; i < numbers.Count; i++)
            {
                if (numbers[i].Count != columnsCount)
                {
                    throw new ArgumentException("Wrong matrix shape");
                }

                for (var j = 0; j < numbers[i].Count; j++)
                {
                    data[i, j] = numbers[i][j];
                }
            }
            
            return new Matrix(data);
        }

        private static MatrixTask CreateFromTypeName(string taskTypeName, string taskName)
        {
            switch (taskTypeName)
            {
                case MultiplyTaskTypeName:
                    return new MultiplyMatrixTask(taskName);
                case AddTaskTypeName:
                    return new AddMatrixTask(taskName);
                case SubtractTaskTypeName:
                    return new SubtractMatrixTask(taskName);
                case TransposeTaskTypeName:
                    return new TransposeMatrixTask(taskName);
                default:
                    throw new ArgumentException("Unexpected task type");
            }
        }
    }
}