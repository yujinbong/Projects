using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPay
{
    internal class Program
    {
        class Game 
        {
            private List<string> players;
            public string Player { get; set; }
            public int Ladder { get; set; }
            public string LadderStatement { get; set; }

            public void StartGame()
            {
                Console.WriteLine("Please enter the names of the players: (Start='q')");

                players = new List<string>();
                for(int i=0; i< 6; i++)  //maximum 6 players
                {
                    Console.Write($"Player {i + 1}: ");
                  //Console.Write("Player " + (i + 1) + ": ");

                    string playerName = Console.ReadLine(); //receive player list from user
                    if (string.IsNullOrEmpty(playerName))
                    {
                        Console.WriteLine("Please type player name:");
                        i--;  
                        continue; 
                    }
                    else if (playerName.ToLower() == "q")
                    {
                        break; 
                    }

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

