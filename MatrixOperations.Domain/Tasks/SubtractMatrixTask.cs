using System.Collections.Generic;
using System.Linq;

namespace MatrixOperations.Domain.Tasks
{
    public class SubtractMatrixTask: MatrixTask
    {
        public SubtractMatrixTask(string name) : base(name)
        {
        }
        
        public override IEnumerable<Matrix> Execute()
        {
            var result = Matrices.Aggregate((f, s) => f - s);
            
            return new List<Matrix> { result };
        }
    }
}