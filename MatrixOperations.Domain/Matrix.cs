namespace MatrixOperations.Domain
{
    public class Matrix
    {
        private readonly int[,] _data;

        public Matrix(int[,] data)
        {
            _data = data;
        }

        public static Matrix operator +(Matrix first, Matrix second)
        {
            var result = new int[first.Rows, first.Columns];
            
            for (var i = 0; i < first.Rows; i++)
            {
                for (var j = 0; j < first.Columns; j++)
                {
                    result[i, j] = first._data[i, j] + second._data[i, j];
                }
            }
            
            return new Matrix(result);
        }
        
        public static Matrix operator -(Matrix first, Matrix second)
        {
            var result = new int[first.Rows, first.Columns];
            
            for (var i = 0; i < first.Rows; i++)
            {
                for (var j = 0; j < first.Columns; j++)
                {
                    result[i, j] = first._data[i, j] - second._data[i, j];
                }
            }
            
            return new Matrix(result);
        }
        
        public static Matrix operator *(Matrix first, Matrix second)
        {
            var result = new int[first.Rows, second.Columns];
            
            for (var i = 0; i < first.Rows; i++)
            {
                for (var j = 0; j < second.Columns; j++)
                {
                    for (var k = 0; k < second.Rows; k++)
                    {
                        result[i, j] += first._data[i, k] * second._data[k, j];
                    }
                }
            }
            
            return new Matrix(result);
        }

        public Matrix Transpose()
        {
            var result = new int[Columns, Rows];
            
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    result[j, i] = _data[i, j];
                }
            }
            
            return new Matrix(result);
        }
        
#pragma warning disable 659
        public override bool Equals(object obj)
#pragma warning restore 659
        {
            if ((obj == null) || GetType() != obj.GetType()) 
            {
                return false;
            }

            var another = (Matrix)obj;

            if (Rows != another.Rows || Columns != another.Columns)
            {
                return false;
            }

            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    if (_data[i, j] != another._data[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        
        private int Rows => _data.GetLength(0);

        private int Columns => _data.GetLength(1);
    }
}