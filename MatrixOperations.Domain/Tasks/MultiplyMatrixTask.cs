using System.Collections.Generic;
using System.Linq;

namespace MatrixOperations.Domain.Tasks
{
    public class MultiplyMatrixTask: MatrixTask
    {
        public MultiplyMatrixTask(string name) : base(name)
        {
        }
        
        public override IEnumerable<Matrix> Execute()
        {
            var result = Matrices.Aggregate((f, s) => f * s);
            
            return new List<Matrix> { result };
        }
    }
}