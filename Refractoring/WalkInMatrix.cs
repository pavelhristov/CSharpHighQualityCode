namespace Matrix
{
    using System;

    class WalkInMatrix
    {
        // last minute job, still too much while, not proper naming and wild magic

        static void Main(string[] args)
        {
            //Console.WriteLine( "Enter a positive number " );
            //string input = Console.ReadLine(  );
            //int n = 0;
            //while ( !int.TryParse( input, out n ) || n < 0 || n > 100 )
            //{
            //    Console.WriteLine( "You haven't entered a correct positive number" );
            //    input = Console.ReadLine(  );
            //}
            int n = 6;
            int[,] matrix = new int[n, n];
            int step = n;
            int k = 1;
            int i = 0;
            int j = 0;
            int dx = 1;
            int dy = 1;
            matrix[i, j] = k;

            while (proverka(matrix, i, j))
            {
                if (i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0)
                {
                    while ((i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0))
                    {
                        change(ref dx, ref dy);
                    }
                }

                i += dx;
                j += dy;
                k++;
                matrix[i, j] = k;
            }

            var notFilled = IsMatrixComplete(matrix);
            i = notFilled[0];
            j = notFilled[1];

            if (i != 0 && j != 0)
            {
                dx = 1;
                dy = 1;
                matrix[i, j] = ++k;

                while (proverka(matrix, i, j))
                {
                    if (i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0)
                    {
                        while ((i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0))
                        {
                            change(ref dx, ref dy);
                        }
                    }

                    i += dx;
                    j += dy;
                    k++;
                    matrix[i, j] = k;
                }
            }

            PrintMatrix(matrix);
        }

        static void PrintMatrix(int[,] matrix)
        {
            int length = matrix.GetLength(0);

            for (int row = 0; row < length; row++)
            {
                for (int col = 0; col < length; col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        static void change(ref int dx, ref int dy)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int cd = 0;

            for (int count = 0; count < 8; count++)
            {
                if (dirX[count] == dx && dirY[count] == dy)
                {
                    cd = count; break;
                }
            }

            if (cd == 7)
            {
                dx = dirX[0];
                dy = dirY[0];
                return;
            }

            dx = dirX[cd + 1];
            dy = dirY[cd + 1];
        }
        static bool proverka(int[,] arr, int x, int y)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int length = arr.GetLength(0);

            for (int i = 0; i < 8; i++)
            {
                if (x + dirX[i] >= length || x + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }
                if (y + dirY[i] >= length || y + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (arr[x + dirX[i], y + dirY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        static int[] IsMatrixComplete(int[,] matrix)
        {
            int length = matrix.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[]{ 0,0};
        }
    }
}
