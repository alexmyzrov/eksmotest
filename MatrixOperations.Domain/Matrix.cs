﻿using System;

namespace MatrixOperations.Domain
{
    public class Matrix
    {
        private readonly int[,] _data;

        public Matrix(int[,] data)
        {
            _data = data ?? throw new ArgumentNullException();
        }

        public static Matrix operator +(Matrix first, Matrix second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException();
            }

            if (!first.IsSameShapeAs(second))
            {
                throw new ArgumentException("Matrix sizes must match");
            }

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
            if (first == null || second == null)
            {
                throw new ArgumentNullException();
            }
            
            if (!first.IsSameShapeAs(second))
            {
                throw new ArgumentException("Matrix sizes must match");
            }
            
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
            if (first == null || second == null)
            {
                throw new ArgumentNullException();
            }
            
            if (first.Columns != second.Rows)
            {
                throw new ArgumentException("First matrix columns count must match second matrix rows count");
            }

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

        public override string ToString()
        {
            var result = string.Empty;

            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns - 1; j++)
                {
                    result += _data[i, j].ToString() + ' ';
                }

                result += _data[i, Columns - 1] + Environment.NewLine;
            }

            return result;
        }
        
#pragma warning disable 659
        public override bool Equals(object obj)
#pragma warning restore 659
        {
            if (obj == null || GetType() != obj.GetType()) 
            {
                return false;
            }

            var another = (Matrix)obj;

            if (!IsSameShapeAs(another))
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

        private bool IsSameShapeAs(Matrix another)
        {
            return Rows == another.Rows && Columns == another.Columns;
        }
    }
}