using System.Collections.Generic;
using Battleship_State_Tracker.Interfaces;
using Battleship_State_Tracker.Models;
namespace Battleship_State_Tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Setup here
            Rules gameRules = new Rules();
            gameRules.BoardSize = 10;
            gameRules.ShipRules.Add(new ShipRule(Enums.ShipTypes.Battleship, 4, 3));
            // Set up the boards here to show a board can be created
            Board boardOne = new Board(gameRules.BoardSize);
            Board boardTwo = new Board(gameRules.BoardSize);

            // Add some battleships
            IPlayer playerOne = new Player
            {
                Board = boardOne,
                Name = "Player One"
            };

            foreach (ShipRule shipRule in gameRules.ShipRules)
            {
                if(shipRule.ShipType == Enums.ShipTypes.Battleship)
                {
                    playerOne.AddShip(new Battleship(new Coordinates(1, 6), shipRule.Length, false));
                    playerOne.AddShip(new Battleship(new Coordinates(3, 5), shipRule.Length, true));
                    playerOne.AddShip(new Battleship(new Coordinates(5, 2), shipRule.Length, true));
                }

            }

            IPlayer playerTwo = new Player
            {
                Board = boardTwo,
                Name = "Player Two"
            };
            foreach (ShipRule shipRule in gameRules.ShipRules)
            {
                if (shipRule.ShipType == Enums.ShipTypes.Battleship)
                {
                    playerTwo.AddShip(new Battleship(new Coordinates(3, 4), shipRule.Length, false));
                    playerTwo.AddShip(new Battleship(new Coordinates(5, 5), shipRule.Length, true));
                    playerTwo.AddShip(new Battleship(new Coordinates(1, 2), shipRule.Length, true));
                }

            }

            // Start
            Game Game = new Game(gameRules, playerOne, playerTwo);
            Game.Move(playerTwo, new Coordinates(5, 5));
        }
    }
}
