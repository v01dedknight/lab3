using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3 {
  public class SquareMatrix {
    // Declaring matrixes and size of matrix
    public int[,] firstMatrix;
    public int[,] secondMatrix;
    public int sizeOfMatrix;

    // Constructor of class SquareMatrix, which initializes the size of matrix and fills the first and second matrix with random numbers from 0 to 9
    public SquareMatrix(int sizeOfMatrix) {
      // Init the size of matrix and two matrixes
      this.sizeOfMatrix = sizeOfMatrix;
      firstMatrix = new int[sizeOfMatrix, sizeOfMatrix];
      Random randomForMatrix = new Random();

      // Fill the first matrix with random numbers from 0 to 9
      for (int indexOfRow = 0; indexOfRow < sizeOfMatrix; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < sizeOfMatrix; ++indexOfColumn) {
          firstMatrix[indexOfRow, indexOfColumn] = randomForMatrix.Next(0, 10);
        }
      }

      // Fill the second matrix with random numbers from 0 to 9
      for (int indexOfRow = 0; indexOfRow < sizeOfMatrix; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < sizeOfMatrix; ++indexOfColumn) {
          secondMatrix[indexOfRow, indexOfColumn] = randomForMatrix.Next(0, 10);
        }
      }

    }
    internal class Program {
      static void Main(string[] args) {
      }
    }
  }
}
