using System;
using System.Collections.Generic;

namespace SplitPay
{
    internal class Program
    {
        class Game
        {
            private List<string> players;
            private int ladderSize;

            public void StartGame()
            {
                Console.WriteLine("Please enter the number of players (2-6):");
                int numPlayers = 0;
                while (true)
                {
                    Console.Write("Number of players: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out numPlayers) && numPlayers >= 2 && numPlayers <= 6)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Please enter a number between 2 and 6.");
                    }
                }

                Console.WriteLine("Please enter the ladder size:");
                int ladderSize = 0;
                while (true)
                {
                    Console.Write("Ladder size: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out ladderSize) && ladderSize > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Please enter a positive integer.");
                    }
                }

                Console.WriteLine($"Starting a game with {numPlayers} players and a ladder size of {ladderSize}.");

                players = new List<string>();
                for (int i = 0; i < numPlayers; i++)
                {
                    Console.Write($"Player {i + 1}: ");
                    string playerName = Console.ReadLine();
                    players.Add(playerName);
                }

                Console.WriteLine("Game environment set up complete!");
                Console.WriteLine($"Total {players.Count} players are ready to play the game.");
            }
        }

        static void Main(string[] args)
        {
            Game game = new Game();
            game.StartGame();
        }
    }
}
