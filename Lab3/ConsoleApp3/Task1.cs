namespace Lab3
{
    public class Matrix
    {
        private int[,] _matrix;

        public int[,] MyMatrix
        {
            get { return _matrix; }
            set { _matrix = value; }
        }
        public Matrix(int n)
        {
            _matrix = new int[n, n];
            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j < i)
                    {
                        _matrix[i, j] = rand.Next(-17, 37);
                    }
                    else
                    {
                        _matrix[i, j] = rand.Next(100, 10001);
                    }
                }
            }
        }
        public Matrix(int n, int m)
        {
            _matrix = new int[n, m];
            Console.WriteLine($"Введите {n * m} элементов массива:");

            for (int i = 0; i < n; i++)
            {
                for (int j = m - 1; j >= 0; j--)
                {
                    
                    while (4 == 4)
                    {
                        Console.Write($"Элемент [{i},{j}]: ");
                        try
                        {
                            int check = int.Parse(Console.ReadLine());
                            _matrix[i, j] = check;
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid input");
                        }
                    }
                    
                }
            }
        }
        public Matrix(int n, bool flag)
        {
            _matrix = new int[n, n];
            int i = n - 1;
            int j = n - 1;
            int counter = 1;
            int maxi = (n * (n - 1)) / 2 + n;

            while (maxi > 0)
            {
                _matrix[i, j] = maxi;
                maxi--;
                i--;
                j--;
                if (i < 0 || j < 0)
                {
                    counter++;
                    i = n - 1;
                    j = n - counter;
                    if (j < 0) break;
                }
            }
        }
        private Matrix(int n, int m, bool createEmpty)
        {
            _matrix = new int[n, m];
        }
        public int FindMaxOne()
        {
            if (_matrix == null)
            {
                Console.WriteLine("Элементы в массиве не найдены");
                return 0;
            }

            int rows = _matrix.GetLength(0);
            int cols = _matrix.GetLength(1);
            int totalElements = rows * cols;
            int[] elems = new int[totalElements];
            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    elems[index] = _matrix[i, j];
                    index++;
                }
            }

            int[] counter = new int[totalElements];
            for (int i = 0; i < totalElements; i++)
            {
                for (int j = 0; j < totalElements; j++)
                {
                    if (elems[i] == elems[j])
                    {
                        counter[i]++;
                    }
                }
            }

            int maxNum = int.MinValue;
            bool foundUnique = false;
            for (int i = 0; i < totalElements; i++)
            {
                if (counter[i] == 1 && elems[i] > maxNum)
                {
                    maxNum = elems[i];
                    foundUnique = true;
                }
            }

            if (foundUnique)
            {
                return maxNum;
            }
            else
            {
                Console.WriteLine("В массиве не нашлось уникальных элементов");
                return 0;
            }
        }
        public static Matrix operator *(int scalar, Matrix matrix)
        {
            if (matrix.MyMatrix == null)
            {
                return null;
            }

            int rows = matrix.MyMatrix.GetLength(0);
            int cols = matrix.MyMatrix.GetLength(1);
            Matrix result = new Matrix(rows, cols, true);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result.MyMatrix[i, j] = scalar * matrix.MyMatrix[i, j];
                }
            }
            return result;
        }

        public static Matrix operator -(Matrix left, Matrix right)
        {
            if (left.MyMatrix == null || right.MyMatrix == null)
            {
                return null;
            }

            int rows = left.MyMatrix.GetLength(0);
            int cols = left.MyMatrix.GetLength(1);

            if (rows != right.MyMatrix.GetLength(0) || cols != right.MyMatrix.GetLength(1))
            {
                return null;
            }


            Matrix result = new Matrix(rows, cols, true);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result.MyMatrix[i, j] = left.MyMatrix[i, j] - right.MyMatrix[i, j];
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix left, Matrix right)
        {
            if (left.MyMatrix == null || right.MyMatrix == null)
            {
                return null;
            }

            int leftRows = left.MyMatrix.GetLength(0);
            int leftCols = left.MyMatrix.GetLength(1);
            int rightRows = right.MyMatrix.GetLength(0);
            int rightCols = right.MyMatrix.GetLength(1);

            if (leftCols != rightRows)
            {
                return null;
            }

            Matrix result = new Matrix(leftRows, rightCols, true);

            for (int i = 0; i < leftRows; i++)
            {
                for (int j = 0; j < rightCols; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < leftCols; k++)
                    {
                        sum += left.MyMatrix[i, k] * right.MyMatrix[k, j];
                    }
                    result.MyMatrix[i, j] = sum;
                }
            }
            return result;
        }
        public override string ToString()
        {
            if (_matrix == null)
            {
                return "Матрица не инициализирована";
            }

            int rows = _matrix.GetLength(0);
            int cols = _matrix.GetLength(1);
            string result = "";

            for (int i = 0; i < rows; i++)
            {
                result += "[ ";
                for (int j = 0; j < cols; j++)
                {
                    result += _matrix[i, j].ToString() + " ";
                }
                result += "]\n";
            }
            return result;
        }

        public void PrintMatrix()
        {
            if (_matrix == null)
            {
                return;
            }
            int rows = _matrix.GetLength(0);
            int cols = _matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                Console.Write("[ ");
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(_matrix[i, j] + "\t");
                }
                Console.Write(" ]");
                Console.WriteLine();
            }
        }
    }
}