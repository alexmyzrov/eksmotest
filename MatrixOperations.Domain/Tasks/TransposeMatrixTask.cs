using System.Collections.Generic;

namespace MatrixOperations.Domain.Tasks
{
    public class TransposeMatrixTask: MatrixTask
    {
        public TransposeMatrixTask(string name) : base(name)
        {
        }
        
        public override IEnumerable<Matrix> Execute()
        {
            var result = new List<Matrix>();
            
            foreach (var matrix in Matrices)
            {
                result.Add(matrix.Transpose());
            }

            return result;
        }
    }
}