using System;

namespace lab3 {
  // My custom exception for sizes
  internal class MatrixSizeException : Exception {
    public MatrixSizeException(string message) : base(message) { }
  }
}