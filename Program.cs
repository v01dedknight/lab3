using System;
namespace lab3 {
  internal class Program {
    static void Main(string[] args) {
      try {
        // Инициализация двух матриц размером 3x3
        SquareMatrix A = new SquareMatrix(3, 0, 5);
        SquareMatrix B = new SquareMatrix(3, 0, 5);

        Console.WriteLine($"Matrix A:\n{A}");

        Console.WriteLine($"Matrix B:\n{B}");

        // Сложение
        SquareMatrix sum = A + B;
        Console.WriteLine($"A + B:\n{sum}");

        // Умножение
        SquareMatrix product = A * B;
        Console.WriteLine($"A * B:\n{product}");

        // Проверка на равенство
        Console.WriteLine("A == B?");
        Console.WriteLine(A == B);

        // Клонирование
        SquareMatrix cloneA = A.Clone();
        Console.WriteLine($"Clone A:\n{cloneA}");

        // Проверка исключения
        SquareMatrix C = new SquareMatrix(2);
        Console.WriteLine("try A + C: ");
        // Вызов исключения
        SquareMatrix fail = A + C;
      } catch (MatrixSizeException sizeException) {
        Console.WriteLine("Exception cought: " + sizeException.Message);
      }
    }
  }
}