using System;

namespace lab3 {
  internal class Program {
    static void Main(string[] args) {
      try {
        // Init two matrices with size 3x3
        SquareMatrix A = new SquareMatrix(3, 0, 5);
        SquareMatrix B = new SquareMatrix(3, 0, 5);

        Console.WriteLine($"Matrix A:\n{A}");

        Console.WriteLine($"Matrix B:\n{B}");

        // Addition
        SquareMatrix sum = A + B;
        Console.WriteLine($"A + B:\n{sum}");

        // Multiplication
        SquareMatrix product = A * B;
        Console.WriteLine($"A * B:\n{product}");

        // Equality check
        Console.WriteLine("A == B?");
        Console.WriteLine(A == B);

        // Cloning
        SquareMatrix cloneA = A.Clone();
        Console.WriteLine($"Clone A:\n{cloneA}");

        // Exception check
        SquareMatrix C = new SquareMatrix(2);
        Console.WriteLine("try A + C: ");
        // Trigger
        SquareMatrix fail = A + C;
      } catch (MatrixSizeException sizeException) {
        Console.WriteLine("Exception cought: " + sizeException.Message);
      }
    }
  }
}