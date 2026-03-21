using System;
using System.Collections.Generic;
using System.Linq;
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
        throw new ArgumentException("The sizes of the matrices must be equal");
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
  }
}
