using System.Collections.Generic;

namespace MatrixOperations.Domain.Tasks
{
    public abstract class MatrixTask
    {
        public string Name { get; }

        protected readonly List<Matrix> Matrices;
        
        protected MatrixTask(string name)
        {
            Name = name;
            Matrices = new List<Matrix>();
        }

        public void AddMatrix(Matrix matrix)
        {
            Matrices.Add(matrix);
        }

        public abstract IEnumerable<Matrix> Execute();
    }
}