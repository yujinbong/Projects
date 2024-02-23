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
                Console.WriteLine("Please enter the names of the players: ");

                players = new List<string>();
            }


        }

        

        static void Main(string[] args)
        {
        }
    }
}

