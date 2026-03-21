using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace lab3 {
  // Class for generating a square matrixes
  public class SquareMatrix {
    // Declaring a two-dimensional array for storing the matrix data and a variable for storing the size of the matrix
    private int[,] data;
    private int size;
    private static Random randomObjectForFilling = new Random();

    // Constructor for filling the matrix with random numbers in the range from 0 to 9
    public SquareMatrix(int sizeOfMatrix) {
      this.size = sizeOfMatrix;

      // Random data
      data = new int[sizeOfMatrix, sizeOfMatrix];

      // Filling
      for (int indexOfRow = 0; indexOfRow < sizeOfMatrix; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < sizeOfMatrix; ++indexOfColumn) {
          data[indexOfRow, indexOfColumn] = randomObjectForFilling.Next(0, 10);
        }
      }
    }

    // Constructor with parameters for filling the matrix with random numbers in a specified range
    public SquareMatrix(int sizeOfMatrix, int min, int max) {
      this.size = sizeOfMatrix;

      // Random data
      data = new int[sizeOfMatrix, sizeOfMatrix];

      // Filling
      for (int indexOfRow = 0; indexOfRow < sizeOfMatrix; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < sizeOfMatrix; ++indexOfColumn) {
          data[indexOfRow, indexOfColumn] = randomObjectForFilling.Next(min, max);
        }
      }
    }

    // Overloading the addition operator for adding two matrices
    public static SquareMatrix operator +(SquareMatrix firstMatrix, SquareMatrix secondMatrix) {
      // Checking the sizes of the matrices
      if (firstMatrix.size != secondMatrix.size) {
        throw new MatrixSizeException("The sizes of the matrices must be equal");
      }

      // Result of the addition
      SquareMatrix resultMatrix = new SquareMatrix(firstMatrix.size);

      // Adding the matrices
      for (int indexOfRow = 0; indexOfRow < firstMatrix.size; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < firstMatrix.size; ++indexOfColumn) {
          resultMatrix.data[indexOfRow, indexOfColumn] = firstMatrix.data[indexOfRow, indexOfColumn] + secondMatrix.data[indexOfRow, indexOfColumn];
        }
      }

      return resultMatrix;
    }

    // Overloading the multiplication operator for multiplying two matrices
    public static SquareMatrix operator *(SquareMatrix firstMatrix, SquareMatrix secondMatrix) {
      // Checking the sizes of the matrices
      if (firstMatrix.size != secondMatrix.size) {
        throw new MatrixSizeException("The sizes of the matrices must be equal");
      }

      // Result of the multiplication
      SquareMatrix resultMatrix = new SquareMatrix(firstMatrix.size);

      // Multiplying the matrices
      for (int indexOfRow = 0; indexOfRow < firstMatrix.size; ++indexOfRow) {

        // Iterating through the columns of the second matrix
        for (int indexOfColumn = 0; indexOfColumn < firstMatrix.size; ++indexOfColumn) {
          int sumOfTheProducts = 0;
          for (int indexOfElement = 0; indexOfElement < firstMatrix.size; ++indexOfElement) {
            sumOfTheProducts += firstMatrix.data[indexOfRow, indexOfElement] * secondMatrix.data[indexOfElement, indexOfColumn];
          }

          // Storing the result
          resultMatrix.data[indexOfRow, indexOfColumn] = sumOfTheProducts;
        }
      }

      return resultMatrix;
    }

    // Overload for operator <
    public static SquareMatrix operator <(SquareMatrix firstMatrix, SquareMatrix secondMatrix) {
      // Checking the sizes of the matrices
      if (firstMatrix.size != secondMatrix.size) {
        throw new MatrixSizeException("The sizes of the matrices must be equal");
      }

      // Result of the comparison
      SquareMatrix resultMatrix = new SquareMatrix(firstMatrix.size);

      // Comparing the matrices
      for (int indexOfRow = 0; indexOfRow < firstMatrix.size; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < firstMatrix.size; ++indexOfColumn) {
          resultMatrix.data[indexOfRow, indexOfColumn] = firstMatrix.data[indexOfRow, indexOfColumn] < secondMatrix.data[indexOfRow, indexOfColumn] ? 1 : 0;
        }
      }

      return resultMatrix;
    }

    // Overload for operator >
    public static SquareMatrix operator >(SquareMatrix firstMatrix, SquareMatrix secondMatrix) {
      // Checking the sizes of the matrices
      if (firstMatrix.size != secondMatrix.size) {
        throw new MatrixSizeException("The sizes of the matrices must be equal");
      }

      // Result of the comparison
      SquareMatrix resultMatrix = new SquareMatrix(firstMatrix.size);

      // Comparing the matrices
      for (int indexOfRow = 0; indexOfRow < firstMatrix.size; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < firstMatrix.size; ++indexOfColumn) {
          resultMatrix.data[indexOfRow, indexOfColumn] = firstMatrix.data[indexOfRow, indexOfColumn] > secondMatrix.data[indexOfRow, indexOfColumn] ? 1 : 0;
        }
      }

      return resultMatrix;
    }

    // >=
    public static SquareMatrix operator >=(SquareMatrix firstMatrix, SquareMatrix secondMatrix) {
      // Checking the sizes of the matrices
      if (firstMatrix.size != secondMatrix.size) {
        throw new MatrixSizeException("The sizes of the matrices must be equal");
      }

      // Result of the comparison
      SquareMatrix resultMatrix = new SquareMatrix(firstMatrix.size);

      // Comparing the matrices
      for (int indexOfRow = 0; indexOfRow < firstMatrix.size; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < firstMatrix.size; ++indexOfColumn) {
          resultMatrix.data[indexOfRow, indexOfColumn] = firstMatrix.data[indexOfRow, indexOfColumn] >= secondMatrix.data[indexOfRow, indexOfColumn] ? 1 : 0;
        }
      }

      return resultMatrix;
    }

    // <=
    public static SquareMatrix operator <=(SquareMatrix firstMatrix, SquareMatrix secondMatrix) {
      // Check
      if (firstMatrix.size != secondMatrix.size) {
        throw new MatrixSizeException("The sizes of the matrices must be equal");
      }

      // Result of the comparison
      SquareMatrix resultMatrix = new SquareMatrix(firstMatrix.size);

      // Comparing the matrices
      for (int indexOfRow = 0; indexOfRow < firstMatrix.size; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < firstMatrix.size; ++indexOfColumn) {
          resultMatrix.data[indexOfRow, indexOfColumn] = firstMatrix.data[indexOfRow, indexOfColumn] <= secondMatrix.data[indexOfRow, indexOfColumn] ? 1 : 0;
        }
      }

      return resultMatrix;
    }

    // ==
    public static SquareMatrix operator ==(SquareMatrix firstMatrix, SquareMatrix secondMatrix) {
      // Checking the sizes of the matrices
      if (firstMatrix.size != secondMatrix.size) {
        throw new MatrixSizeException("The sizes of the matrices must be equal");
      }

      // Result of the comparison
      SquareMatrix resultMatrix = new SquareMatrix(firstMatrix.size);

      // Comparing the matrices
      for (int indexOfRow = 0; indexOfRow < firstMatrix.size; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < firstMatrix.size; ++indexOfColumn) {
          resultMatrix.data[indexOfRow, indexOfColumn] = firstMatrix.data[indexOfRow, indexOfColumn] == secondMatrix.data[indexOfRow, indexOfColumn] ? 1 : 0;
        }
      }

      return resultMatrix;
    }

    // !=
    public static SquareMatrix operator !=(SquareMatrix firstMatrix, SquareMatrix secondMatrix) {
      // Checking the sizes of the matrices
      if (firstMatrix.size != secondMatrix.size) {
        throw new MatrixSizeException("The sizes of the matrices must be equal");
      }

      // Result of the comparison
      SquareMatrix resultMatrix = new SquareMatrix(firstMatrix.size);

      // Comparing the matrices
      for (int indexOfRow = 0; indexOfRow < firstMatrix.size; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < firstMatrix.size; ++indexOfColumn) {
          resultMatrix.data[indexOfRow, indexOfColumn] = firstMatrix.data[indexOfRow, indexOfColumn] != secondMatrix.data[indexOfRow, indexOfColumn] ? 1 : 0;
        }
      }

      return resultMatrix;
    }

    // Overriding the ToString method for displaying the matrix
    public override string ToString() {
      // Using StringBuilder for efficient string concatenation
      StringBuilder stringBuilder = new StringBuilder();

      // Iterating through the matrix and appending its elements to the StringBuilder
      for (int indexOfRow = 0; indexOfRow < size; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < size; ++indexOfColumn) {
          stringBuilder.Append(data[indexOfRow, indexOfColumn] + " ");
        }

        stringBuilder.Append(Environment.NewLine);
      }

      // Returning the string representation of the matrix
      return stringBuilder.ToString();
    }

    public override bool Equals(object obj) {
      // Checking if the object is null or if it is of a different type
      if (obj == null || GetType() != obj.GetType()) {
        return false;
      }

      // Casting the object to SquareMatrix
      SquareMatrix otherMatrix = (SquareMatrix)obj;

      // Checking the sizes of the matrices
      if (size != otherMatrix.size) {
        return false;
      }

      // Comparing the matrices element by element
      for (int indexOfRow = 0; indexOfRow < size; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < size; ++indexOfColumn) {
          // If any element is different, the matrices are not equal
          if (data[indexOfRow, indexOfColumn] != otherMatrix.data[indexOfRow, indexOfColumn]) {
            return false;
          }
        }
      }

      return true;
    }

    // Overriding the GetHashCode method for generating a hash code for the matrix
    public override int GetHashCode() {
      // Starting with a non-zero prime number
      int hash = 17;

      // Combining the hash codes of the size and the elements of the matrix
      for (int indexOfRow = 0; indexOfRow < size; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < size; ++indexOfColumn) {
          hash = hash * 31 + data[indexOfRow, indexOfColumn].GetHashCode();
        }
      }

      return hash;
    }

    // Clone
    public SquareMatrix Clone() {
      // new object
      SquareMatrix copy = new SquareMatrix(size);

      // Copy every element
      for (int indexOfRow = 0; indexOfRow < size; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < size; ++indexOfColumn) {
          copy.data[indexOfRow, indexOfColumn] = data[indexOfRow, indexOfColumn];
        }
      }

      return copy;
    }

    // My custom exception ( for sizes )
    public class MatrixSizeException : Exception {
      public MatrixSizeException(string message) : base(message) { }
    }
  }
}
