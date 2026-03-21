using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3 {
  // My custom exception for sizes
  internal class MatrixSizeException : Exception {
    public MatrixSizeException(string message) : base(message) { }
  }
}