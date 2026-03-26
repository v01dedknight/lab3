using System;
using System.Text;

namespace lab3 {
  // Класс для генерации квадратных матриц
  public class SquareMatrix {
    // Объявление двумерного массива для хранения данных матрицы и переменной для хранения размера матрицы
    private int[,] data;
    private int size;
    private static Random randomObjectForFilling = new Random();

    // Конструктор для заполнения матрицы случайными числами в диапазоне от 0 до 9
    public SquareMatrix(int sizeOfMatrix) {
      this.size = sizeOfMatrix;

      // Случайные данные
      data = new int[sizeOfMatrix, sizeOfMatrix];

      // Заполнение
      for (int indexOfRow = 0; indexOfRow < sizeOfMatrix; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < sizeOfMatrix; ++indexOfColumn) {
          data[indexOfRow, indexOfColumn] = randomObjectForFilling.Next(0, 10);
        }
      }
    }

    // Конструктор с параметрами для заполнения матрицы случайными числами в заданном диапазоне
    public SquareMatrix(int sizeOfMatrix, int min, int max) {
      this.size = sizeOfMatrix;

      // Случайные данные
      data = new int[sizeOfMatrix, sizeOfMatrix];

      // Заполнение
      for (int indexOfRow = 0; indexOfRow < sizeOfMatrix; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < sizeOfMatrix; ++indexOfColumn) {
          data[indexOfRow, indexOfColumn] = randomObjectForFilling.Next(min, max);
        }
      }
    }

    // Перегрузка оператора сложения для сложения двух матриц
    public static SquareMatrix operator +(SquareMatrix firstMatrix, SquareMatrix secondMatrix) {
      // Проверка размеров матриц
      if (firstMatrix.size != secondMatrix.size) {
        throw new MatrixSizeException("Размеры матриц должны быть равны");
      }

      // Результат сложения
      SquareMatrix resultMatrix = new SquareMatrix(firstMatrix.size);

      // Сложение матриц
      for (int indexOfRow = 0; indexOfRow < firstMatrix.size; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < firstMatrix.size; ++indexOfColumn) {
          resultMatrix.data[indexOfRow, indexOfColumn] = firstMatrix.data[indexOfRow, indexOfColumn] + secondMatrix.data[indexOfRow, indexOfColumn];
        }
      }

      return resultMatrix;
    }

    // Перегрузка оператора умножения для умножения двух матриц
    public static SquareMatrix operator *(SquareMatrix firstMatrix, SquareMatrix secondMatrix) {
      // Проверка размеров матриц
      if (firstMatrix.size != secondMatrix.size) {
        throw new MatrixSizeException("Размеры матриц должны быть равны");
      }

      // Результат умножения
      SquareMatrix resultMatrix = new SquareMatrix(firstMatrix.size);

      // Умножение матриц
      for (int indexOfRow = 0; indexOfRow < firstMatrix.size; ++indexOfRow) {

        // Итерация по столбцам второй матрицы
        for (int indexOfColumn = 0; indexOfColumn < firstMatrix.size; ++indexOfColumn) {
          int sumOfTheProducts = 0;
          for (int indexOfElement = 0; indexOfElement < firstMatrix.size; ++indexOfElement) {
            sumOfTheProducts += firstMatrix.data[indexOfRow, indexOfElement] * secondMatrix.data[indexOfElement, indexOfColumn];
          }

          // Сохранение результата
          resultMatrix.data[indexOfRow, indexOfColumn] = sumOfTheProducts;
        }
      }

      return resultMatrix;
    }

    // Перегрузка оператора <
    public static SquareMatrix operator <(SquareMatrix firstMatrix, SquareMatrix secondMatrix) {
      // Проверка размеров матриц
      if (firstMatrix.size != secondMatrix.size) {
        throw new MatrixSizeException("Размеры матриц должны быть равны");
      }

      // Результат сравнения
      SquareMatrix resultMatrix = new SquareMatrix(firstMatrix.size);

      // Сравнение матриц
      for (int indexOfRow = 0; indexOfRow < firstMatrix.size; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < firstMatrix.size; ++indexOfColumn) {
          resultMatrix.data[indexOfRow, indexOfColumn] = firstMatrix.data[indexOfRow, indexOfColumn] < secondMatrix.data[indexOfRow, indexOfColumn] ? 1 : 0;
        }
      }

      return resultMatrix;
    }

    // Перегрузка оператора >
    public static SquareMatrix operator >(SquareMatrix firstMatrix, SquareMatrix secondMatrix) {
      // Проверка размеров матриц
      if (firstMatrix.size != secondMatrix.size) {
        throw new MatrixSizeException("Размеры матриц должны быть равны");
      }

      // Результат сравнения
      SquareMatrix resultMatrix = new SquareMatrix(firstMatrix.size);

      // Сравнение матриц
      for (int indexOfRow = 0; indexOfRow < firstMatrix.size; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < firstMatrix.size; ++indexOfColumn) {
          resultMatrix.data[indexOfRow, indexOfColumn] = firstMatrix.data[indexOfRow, indexOfColumn] > secondMatrix.data[indexOfRow, indexOfColumn] ? 1 : 0;
        }
      }

      return resultMatrix;
    }

    // Оператор >=
    public static SquareMatrix operator >=(SquareMatrix firstMatrix, SquareMatrix secondMatrix) {
      // Проверка размеров матриц
      if (firstMatrix.size != secondMatrix.size) {
        throw new MatrixSizeException("Размеры матриц должны быть равны");
      }

      // Результат сравнения
      SquareMatrix resultMatrix = new SquareMatrix(firstMatrix.size);

      // Сравнение матриц
      for (int indexOfRow = 0; indexOfRow < firstMatrix.size; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < firstMatrix.size; ++indexOfColumn) {
          resultMatrix.data[indexOfRow, indexOfColumn] = firstMatrix.data[indexOfRow, indexOfColumn] >= secondMatrix.data[indexOfRow, indexOfColumn] ? 1 : 0;
        }
      }

      return resultMatrix;
    }

    // Оператор <=
    public static SquareMatrix operator <=(SquareMatrix firstMatrix, SquareMatrix secondMatrix) {
      // Проверка
      if (firstMatrix.size != secondMatrix.size) {
        throw new MatrixSizeException("Размеры матриц должны быть равны");
      }

      // Результат сравнения
      SquareMatrix resultMatrix = new SquareMatrix(firstMatrix.size);

      // Сравнение матриц
      for (int indexOfRow = 0; indexOfRow < firstMatrix.size; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < firstMatrix.size; ++indexOfColumn) {
          resultMatrix.data[indexOfRow, indexOfColumn] = firstMatrix.data[indexOfRow, indexOfColumn] <= secondMatrix.data[indexOfRow, indexOfColumn] ? 1 : 0;
        }
      }

      return resultMatrix;
    }

    // Оператор ==
    public static SquareMatrix operator ==(SquareMatrix firstMatrix, SquareMatrix secondMatrix) {
      // Проверка размеров матриц
      if (firstMatrix.size != secondMatrix.size) {
        throw new MatrixSizeException("Размеры матриц должны быть равны");
      }

      // Результат сравнения
      SquareMatrix resultMatrix = new SquareMatrix(firstMatrix.size);

      // Сравнение матриц
      for (int indexOfRow = 0; indexOfRow < firstMatrix.size; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < firstMatrix.size; ++indexOfColumn) {
          resultMatrix.data[indexOfRow, indexOfColumn] = firstMatrix.data[indexOfRow, indexOfColumn] == secondMatrix.data[indexOfRow, indexOfColumn] ? 1 : 0;
        }
      }

      return resultMatrix;
    }

    // Оператор !=
    public static SquareMatrix operator !=(SquareMatrix firstMatrix, SquareMatrix secondMatrix) {
      // Проверка размеров матриц
      if (firstMatrix.size != secondMatrix.size) {
        throw new MatrixSizeException("Размеры матриц должны быть равны");
      }

      // Результат сравнения
      SquareMatrix resultMatrix = new SquareMatrix(firstMatrix.size);

      // Сравнение матриц
      for (int indexOfRow = 0; indexOfRow < firstMatrix.size; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < firstMatrix.size; ++indexOfColumn) {
          resultMatrix.data[indexOfRow, indexOfColumn] = firstMatrix.data[indexOfRow, indexOfColumn] != secondMatrix.data[indexOfRow, indexOfColumn] ? 1 : 0;
        }
      }

      return resultMatrix;
    }

    // Переопределение метода ToString для отображения матрицы
    public override string ToString() {
      // Использование StringBuilder для эффективной конкатенации строк
      StringBuilder stringBuilder = new StringBuilder();

      // Обход матрицы и добавление её элементов в StringBuilder
      for (int indexOfRow = 0; indexOfRow < size; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < size; ++indexOfColumn) {
          stringBuilder.Append(data[indexOfRow, indexOfColumn] + " ");
        }

        stringBuilder.Append(Environment.NewLine);
      }

      // Возврат строкового представления матрицы
      return stringBuilder.ToString();
    }

    public override bool Equals(object obj) {
      // Проверка, является ли объект null или имеет другой тип
      if (obj == null || GetType() != obj.GetType()) {
        return false;
      }

      // Приведение объекта к типу SquareMatrix
      SquareMatrix otherMatrix = (SquareMatrix)obj;

      // Проверка размеров матриц
      if (size != otherMatrix.size) {
        return false;
      }

      // Поэлементное сравнение матриц
      for (int indexOfRow = 0; indexOfRow < size; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < size; ++indexOfColumn) {
          // Если какой-либо элемент отличается, матрицы не равны
          if (data[indexOfRow, indexOfColumn] != otherMatrix.data[indexOfRow, indexOfColumn]) {
            return false;
          }
        }
      }

      return true;
    }

    // Переопределение метода GetHashCode для генерации хэш-кода матрицы
    public override int GetHashCode() {
      // Начало с ненулевого простого числа
      int hash = 17;

      // Комбинирование хэш-кодов размера и элементов матрицы
      for (int indexOfRow = 0; indexOfRow < size; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < size; ++indexOfColumn) {
          hash = hash * 31 + data[indexOfRow, indexOfColumn].GetHashCode();
        }
      }

      return hash;
    }

    // Клонирование
    public SquareMatrix Clone() {
      // Новый объект
      SquareMatrix copy = new SquareMatrix(size);

      // Копирование каждого элемента
      for (int indexOfRow = 0; indexOfRow < size; ++indexOfRow) {
        for (int indexOfColumn = 0; indexOfColumn < size; ++indexOfColumn) {
          copy.data[indexOfRow, indexOfColumn] = data[indexOfRow, indexOfColumn];
        }
      }

      return copy;
    }
  }
}