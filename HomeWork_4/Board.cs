using System;

namespace TicTacToe
{
    enum Player
    {
        None,
        X,
        O
    }

    static class Board
    {
        public static Player[,] Cells { get; private set; }
        public static Player CurrentPlayer { get; private set; }
        public static Player Winner { get; private set; }

        public static void Initialize()
        {
            Cells = new Player[3, 3];
            CurrentPlayer = Player.X;
            Winner = Player.None;
        }

        public static void Draw()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    char cellValue = '.';
                    if (Cells[row, col] == Player.X)
                        cellValue = 'X';
                    else if (Cells[row, col] == Player.O)
                        cellValue = 'O';
                    Console.Write($" {cellValue} ");
                }
                Console.WriteLine();
            }
        }

        public static void MakeMove(Player player)
        {
            Random random = new Random();
            int row, col;
            do
            {
                row = random.Next(3);
                col = random.Next(3);
            } while (Cells[row, col] != Player.None);

            Cells[row, col] = player;

            if (CheckWinner(player))
            {
                Winner = player;
            }
            else if (CheckDraw())
            {
                Winner = Player.None;
            }
            else
            {
                CurrentPlayer = CurrentPlayer == Player.X ? Player.O : Player.X;
            }
        }

        private static bool CheckWinner(Player player)
        {
            // Перевірка стовбиків та діагоналей
            for (int i = 0; i < 3; i++)
            {
                if (Cells[i, 0] == player && Cells[i, 1] == player && Cells[i, 2] == player)
                    return true;
                if (Cells[0, i] == player && Cells[1, i] == player && Cells[2, i] == player)
                    return true;
            }
            if (Cells[0, 0] == player && Cells[1, 1] == player && Cells[2, 2] == player)
                return true;
            if (Cells[0, 2] == player && Cells[1, 1] == player && Cells[2, 0] == player)
                return true;

            return false;
        }

        private static bool CheckDraw()
        {
            // Перевірка заповнена до кінця дошка?
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (Cells[row, col] == Player.None)
                        return false;
                }
            }
            return true;
        }

        public static bool GameOver()
        {
            return Winner != Player.None || CheckDraw();
        }
    }
}
