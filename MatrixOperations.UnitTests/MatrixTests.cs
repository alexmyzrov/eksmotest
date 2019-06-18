using System;
using MatrixOperations.Domain;
using Xunit;

namespace MatrixOperations.UnitTests
{
    public class MatrixTests
    {
        [Fact]
        public void Add()
        {
            // Arrange
            var first = new Matrix(new int[,]
            {
                { 1, 3, 0, 2 },
                { 4, 1, 3, 1 }
            });
            
            var second = new Matrix(new int[,]
            {
                { 4, -3, 2, -2 },
                { -3, 0, 4, 0 }
            });
            
            var expected = new Matrix(new int[,]
            {
                { 5, 0, 2, 0 },
                { 1, 1, 7, 1 }
            });

            // Act
            var result = first + second;

            // Assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Add_SizesNotMatches_ThrowsException()
        {
            // Arrange
            var first = new Matrix(new int[,]
            {
                { 1, 3, 0, 2 },
                { 4, 1, 3, 1 }
            });
            
            var second = new Matrix(new int[,]
            {
                { 4, -3, 2 },
                { -3, 0, 4 }
            });

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => first + second);
        }
        
        [Fact]
        public void Subtract()
        {
            // Arrange
            var first = new Matrix(new int[,]
            {
                { 1, 3, 0, 2 },
                { 4, 1, 3, 1 }
            });
            
            var second = new Matrix(new int[,]
            {
                { 4, -3, 2, -2 },
                { -3, 0, 4, 0 }
            });
            
            var expected = new Matrix(new int[,]
            {
                { -3, 6, -2, 4 },
                { 7, 1, -1, 1 }
            });

            // Act
            var result = first - second;

            // Assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Subtract_SizesNotMatches_ThrowsException()
        {
            // Arrange
            var first = new Matrix(new int[,]
            {
                { 1, 3, 0, 2 },
                { 4, 1, 3, 1 }
            });
            
            var second = new Matrix(new int[,]
            {
                { 4, -3, 2 },
                { -3, 0, 4 }
            });

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => first - second);
        }
        
        [Fact]
        public void Multiply()
        {
            // Arrange
            var first = new Matrix(new int[,]
            {
                { 1, 4, -3, 2 },
                { 5, 10, 0, 3 },
                { 4, 1, 2, 6 }
            });
            
            var second = new Matrix(new int[,]
            {
                { -2, 1, 2 },
                { 3, 4, -5 },
                { 5, 10, 1 },
                { 2, 0, 1 }
            });
            
            var expected = new Matrix(new int[,]
            {
                { -1, -13, -19 },
                { 26, 45, -37 },
                { 17, 28, 11 }
            });

            // Act
            var result = first * second;

            // Assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Multiply_SizesNotMatches_ThrowsException()
        {
            // Arrange
            var first = new Matrix(new int[,]
            {
                { 1, 3 },
                { 4, 1 }
            });
            
            var second = new Matrix(new int[,]
            {
                { 4, -3, 2 },
                { -3, 0, 4 }
            });

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => first + second);
        }
        
        [Fact]
        public void Transpose()
        {
            // Arrange
            var matrix = new Matrix(new int[,]
            {
                { 1, 4, -3, 2 },
                { 5, 10, 0, 3 },
                { 4, 1, 2, 6 }
            });
            
            var expected = new Matrix(new int[,]
            {
                { 1, 5, 4 },
                { 4, 10, 1 },
                { -3, 0, 2 },
                { 2, 3, 6 },
            });

            // Act
            var result = matrix.Transpose();

            // Assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Equality_MatrixAreEqual_True()
        {
            // Arrange
            var first = new Matrix(new int[,]
            {
                { 1, 4, -3, 2 },
                { 5, 10, 0, 3 },
                { 4, 1, 2, 6 }
            });
            
            var second = new Matrix(new int[,]
            {
                { 1, 4, -3, 2 },
                { 5, 10, 0, 3 },
                { 4, 1, 2, 6 }
            });

            // Act
            var result = Equals(first, second);

            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void Equality_MatrixAreNotEqual_False()
        {
            // Arrange
            var first = new Matrix(new int[,]
            {
                { 1, 4, -3, 2 },
                { 5, 10, 0, 3 },
                { 4, 1, 2, 6 }
            });
            
            var second = new Matrix(new int[,]
            {
                { 0, 4, -3, 2 },
                { 5, 10, 0, 3 },
                { 4, 1, 2, 6 }
            });

            // Act
            var result = Equals(first, second);

            // Assert
            Assert.False(result);
        }
        
        [Fact]
        public void Equality_DifferentTypes_False()
        {
            // Arrange
            var first = new Matrix(new int[,]
            {
                { 1, 4, -3 },
                { 5, 10, 0 },
                { 4, 1, 2 }
            });
            
            var second = new object();

            // Act
            var result = Equals(first, second);

            // Assert
            Assert.False(result);
        }
        
        [Fact]
        public void Equality_MatrixHasDifferentShape_False()
        {
            // Arrange
            var first = new Matrix(new int[,]
            {
                { 1, 4, -3 },
                { 5, 10, 0 },
                { 4, 1, 2 }
            });
            
            var second = new Matrix(new int[,]
            {
                { 0, 4, -3, 2 },
                { 5, 10, 0, 3 },
                { 4, 1, 2, 6 }
            });

            // Act
            var result = Equals(first, second);

            // Assert
            Assert.False(result);
        }
    }
}