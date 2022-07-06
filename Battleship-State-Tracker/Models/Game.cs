using Battleship_State_Tracker.Enums;
using Battleship_State_Tracker.Interfaces;
using System;
using System.Linq;

namespace Battleship_State_Tracker.Models
{
    public class Game
    {
        public Game(Rules rules, IPlayer playerOne, IPlayer playerTwo)
        {
            if (rules == null || playerOne == null || playerTwo == null)
            {
                throw new ArgumentNullException(nameof(rules));
            }

            Rules = rules;
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;

            if (rules == null || rules.ShipRules == null || !rules.ShipRules.Any())
            {
                throw new ApplicationException($"Please define some game rules");
            }
            if (playerOne == null || playerOne.Ships == null || !playerOne.Ships.Any())
            {
                throw new ApplicationException($"Player One setup incomplete");
            }
            if (playerTwo == null || playerTwo.Ships == null || !playerTwo.Ships.Any())
            {
                throw new ApplicationException($"Player Two setup incomplete");
            }
        }

        public Rules Rules { get; }
        public IPlayer PlayerOne { get; set; }
        public IPlayer PlayerTwo { get; set; }

        public void Move(IPlayer player, Coordinates move)
        {
            if(player == null || move == null)
            {
                throw new ArgumentNullException("A player and move are required");
            }
            IPlayer opponent = player.Equals(PlayerOne) ? PlayerTwo : PlayerOne;
            ShotResult shotResult = player.Shoot(opponent, move);
            if (shotResult == ShotResult.Hit)
            {
                Console.WriteLine($"{player.Name} has hit {opponent.Name}'s Battleship at ({move.X},{move.Y})");
                if (opponent.HasLost)
                {
                    Console.WriteLine($"{opponent.Name} lost!");
                }
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
