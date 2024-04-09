using System;
using TicTacToe;

namespace TicTacToe
{
    static class Game
    {
        public static void Start()
        {
            Board.Initialize();
            Board.Draw();

            while (!Board.GameOver())
            {
                if (Board.CurrentPlayer == Player.X)
                {
                    Console.WriteLine("Хiд гравця X.");
                    Board.MakeMove(Player.X);
                }
                else
                {
                    Console.WriteLine("Хiд комп'ютера.");
                    Board.MakeMove(Player.O);
                }

                Board.Draw();
            }

            if (Board.Winner != Player.None)
            {
                Console.WriteLine($"Гравець {Board.Winner} перемiг!");
            }
            else
            {
                Console.WriteLine("Нiчия!");
            }
        }
    }
}
