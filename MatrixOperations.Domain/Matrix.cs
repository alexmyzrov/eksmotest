using System;

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
            throw new NotImplementedException();
        }
        
        public static Matrix operator -(Matrix first, Matrix second)
        {
            throw new NotImplementedException();
        }
        
        public static Matrix operator *(Matrix first, Matrix second)
        {
            throw new NotImplementedException();
        }

        public Matrix Transpose()
        {
            throw new NotImplementedException();
        }
    }
}