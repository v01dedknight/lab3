using System;

namespace lab3 {
  // Исключение для размеров матриц
  internal class MatrixSizeException : Exception {
    public MatrixSizeException(string message) : base(message) { }
  }
}