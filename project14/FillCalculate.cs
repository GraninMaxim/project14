using LibMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace project14
{
    internal static class FillCalculate
    {
        public static void Fill(this Matrix<int> matrix, int rowCount, int columnCount, int minValue, int maxValue)
        {
            int[,] matr = new int[rowCount, columnCount];
            Random rnd = new();
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    matr[i, j] = rnd.Next(minValue, maxValue);
                }
            }
            matrix.Add(matr);
        }

        public static int Calculate(this Matrix<int> matrix, int rowCount, int columnCount)
        {
            int res = 0;
            for (int j = 0; j < columnCount; j++)
            {
                int neg = 0;
                int pos = 0;
                for (int i = 0; i < rowCount; i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        neg++;
                    }
                    else if (matrix[i, j] > 0)
                    {
                        pos++;
                    }
                }
                if (neg == pos)
                {
                    res = j + 1;
                }
            }
            return res;
        }
    }
}
