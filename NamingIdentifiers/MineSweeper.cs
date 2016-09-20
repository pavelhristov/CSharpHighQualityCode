namespace MineSweeper
{
    using System;
    using System.Collections.Generic;

    public class MineSweeper
    {
        public static void Main(string[] args)
        {
            string command = string.Empty;
            char[,] gameField = CreateGameField();
            char[,] mines = PlaceBombs();
            int movesCount = 0;
            bool isOnBomb = false;
            List<HighScore> winners = new List<HighScore>(6);
            int row = 0;
            int col = 0;
            bool isGameStartedThisTurn = true;
            const int MaximumMoves = 35;
            bool areAllFreeBoxesOpen = false;

            do
            {
                if (isGameStartedThisTurn)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    DisplayGameField(gameField);
                    isGameStartedThisTurn = false;
                }

                Console.Write("Daj red i kolona : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                        row <= gameField.GetLength(0) && col <= gameField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Leaderboard(winners);
                        break;
                    case "restart":
                        gameField = CreateGameField();
                        mines = PlaceBombs();
                        DisplayGameField(gameField);
                        isOnBomb = false;
                        isGameStartedThisTurn = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (mines[row, col] != '*')
                        {
                            if (mines[row, col] == '-')
                            {
                                PlayerTurn(gameField, mines, row, col);
                                movesCount++;
                            }

                            if (MaximumMoves == movesCount)
                            {
                                areAllFreeBoxesOpen = true;
                            }
                            else
                            {
                                DisplayGameField(gameField);
                            }
                        }
                        else
                        {
                            isOnBomb = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (isOnBomb)
                {
                    DisplayGameField(mines);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " + "Daj si niknejm: ", movesCount);

                    string nickname = Console.ReadLine();
                    HighScore highScore = new HighScore(nickname, movesCount);
                    if (winners.Count < 5)
                    {
                        winners.Add(highScore);
                    }
                    else
                    {
                        for (int i = 0; i < winners.Count; i++)
                        {
                            if (winners[i].Points < highScore.Points)
                            {
                                winners.Insert(i, highScore);
                                winners.RemoveAt(winners.Count - 1);
                                break;
                            }
                        }
                    }

                    winners.Sort((HighScore highScore1, HighScore highScore2) => highScore2.Name.CompareTo(highScore1.Name));
                    winners.Sort((HighScore highScore1, HighScore highScore2) => highScore2.Points.CompareTo(highScore1.Points));
                    Leaderboard(winners);

                    gameField = CreateGameField();
                    mines = PlaceBombs();
                    movesCount = 0;
                    isOnBomb = false;
                    isGameStartedThisTurn = true;
                }

                if (areAllFreeBoxesOpen)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    DisplayGameField(mines);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string imeee = Console.ReadLine();
                    HighScore to4kii = new HighScore(imeee, movesCount);
                    winners.Add(to4kii);
                    Leaderboard(winners);
                    gameField = CreateGameField();
                    mines = PlaceBombs();
                    movesCount = 0;
                    areAllFreeBoxesOpen = false;
                    isGameStartedThisTurn = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void Leaderboard(List<HighScore> highScore)
        {
            Console.WriteLine("\nHigh score:");
            if (highScore.Count > 0)
            {
                for (int i = 0; i < highScore.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, highScore[i].Name, highScore[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void PlayerTurn(char[,] field, char[,] bombs, int row, int column)
        {
            char mines = MinesCount(bombs, row, column);
            bombs[row, column] = mines;
            field[row, column] = mines;
        }

        private static void DisplayGameField(char[,] field)
        {
            int rows = field.GetLength(0);
            int columns = field.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(string.Format("{0} ", field[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int rows = 5;
            int columns = 10;
            char[,] board = new char[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    board[row, col] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceBombs()
        {
            int rows = 5;
            int columns = 10;
            char[,] gameField = new char[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    gameField[row, col] = '-';
                }
            }

            List<int> mines = new List<int>();
            while (mines.Count < 15)
            {
                Random random = new Random();
                int asfd = random.Next(50);
                if (!mines.Contains(asfd))
                {
                    mines.Add(asfd);
                }
            }

            foreach (int mine in mines)
            {
                int row = mine / columns;
                int col = mine % columns;
                if (col == 0 && mine != 0)
                {
                    row--;
                    col = columns;
                }
                else
                {
                    col++;
                }

                gameField[row, col - 1] = '*';
            }

            return gameField;
        }

        private static void CalculateMines(char[,] field)
        {
            int rows = field.GetLength(0);
            int columns = field.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (field[row, col] != '*')
                    {
                        char minesCount = MinesCount(field, row, col);
                        field[row, col] = minesCount;
                    }
                }
            }
        }

        private static char MinesCount(char[,] field, int row, int col)
        {
            int minesCount = 0;
            int rows = field.GetLength(0);
            int columns = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, col] == '*')
                {
                    minesCount++;
                }
            }

            if (row + 1 < rows)
            {
                if (field[row + 1, col] == '*')
                {
                    minesCount++;
                }
            }

            if (col - 1 >= 0)
            {
                if (field[row, col - 1] == '*')
                {
                    minesCount++;
                }
            }

            if (col + 1 < columns)
            {
                if (field[row, col + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (field[row - 1, col - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < columns))
            {
                if (field[row - 1, col + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (field[row + 1, col - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < columns))
            {
                if (field[row + 1, col + 1] == '*')
                {
                    minesCount++;
                }
            }

            return char.Parse(minesCount.ToString());
        }

        public class HighScore
        {
            private string name;
            private int points;

            public HighScore()
            {
            }

            public HighScore(string name, int points)
            {
                this.name = name;
                this.points = points;
            }

            public string Name
            {
                get { return this.name; }
                set { this.name = value; }
            }

            public int Points
            {
                get { return this.points; }
                set { this.points = value; }
            }
        }
    }
}
