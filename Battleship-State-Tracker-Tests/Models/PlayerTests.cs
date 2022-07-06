using System;
using Battleship_State_Tracker.Enums;
using Battleship_State_Tracker.Interfaces;
using Battleship_State_Tracker.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Battleship_State_Tracker_Tests.Models
{
    [TestClass]
    public  class PlayerTests
    {
        private Rules gameRules;
        private Board board;
        private ShipRule battleShipRule;
        private Player opponent;
        [TestInitialize]
        public void TestInitialize()
        {
            battleShipRule = new ShipRule(ShipTypes.Battleship, 4, 3);
            gameRules = new Rules { BoardSize = 10 };
            gameRules.ShipRules.Add(battleShipRule);
            board = new Board(gameRules.BoardSize);
            opponent = new Player { Board = new Board(gameRules.BoardSize), Name = "Opponent" };
            opponent.AddShip(new Battleship(new Coordinates(5, 5), 5, true));
        }


        [TestMethod]
        public void Player_Constructor_Creates_Valid_Player()
        {
            IPlayer player = new Player
            {
                Board = board,
                Name = "Player"
            };

            Assert.IsTrue(player.Name == "Player");
            Assert.IsTrue(player.Board.Equals(board));
            Assert.IsFalse(player.Ships.Any());
        }

        [TestMethod]
        public void Player_Add_Valid_BattlesShip_Properties_Set_Correctly()
        {
            IPlayer player = new Player
            {
                Board = board,
                Name = "Player"
            };
            Coordinates bowCoordiantes = new Coordinates(4, 4);
            player.AddShip(new Battleship(bowCoordiantes, battleShipRule.Length, true));
            Assert.IsTrue(player.Ships.Count == 1);
            Assert.AreEqual(player.Ships.First().BowCoordinates, bowCoordiantes);
            Assert.IsTrue(player.Ships.First().Name == "Battleship");
            Assert.IsTrue(player.Ships.First().Hits == 0);
            Assert.IsTrue(player.Ships.First().Horizontal == true);
            Assert.IsTrue(player.Ships.First().Length == battleShipRule.Length);
            Assert.IsTrue(player.Ships.First().ShipType == ShipTypes.Battleship);
        }

        [TestMethod]
        public void Player_Shot_At_Unoccupied_Coordinate()
        {
            IPlayer player = new Player
            {
                Board = board,
                Name = "Player"
            };
            ShotResult result = player.Shoot(opponent, new Coordinates(6, 6));
            Assert.IsTrue(result == ShotResult.Miss);
        }

        [TestMethod]
        public void Player_Shot_At_Occupied_Coordinate()
        {
            IPlayer player = new Player
            {
                Board = board,
                Name = "Player"
            };
            ShotResult result = player.Shoot(opponent, new Coordinates(7, 5));
            Assert.IsTrue(result == ShotResult.Hit);
        }

        [TestMethod]
        public void Player_Shot_At_Occupied_Coordinate_Has_Oponent_Lost()
        {
            IPlayer player = new Player
            {
                Board = board,
                Name = "Player"
            };
            ShotResult result = player.Shoot(opponent, new Coordinates(7, 5));
            Assert.IsTrue(result == ShotResult.Hit);
            Assert.IsFalse(opponent.HasLost);
        }

        [TestMethod]
        public void Added_Ship_Doesnt_Fit_On_Board()
        {
            IPlayer player = new Player
            {
                Board = board,
                Name = "Player"
            };
            
            Assert.ThrowsException<ApplicationException>(() => {
                player.AddShip(new Battleship(new Coordinates(7, 5), 5, true));
            });
        }

        [TestMethod]
        public void Added_Ship_Overlaps_Existing_Ship()
        {
            IPlayer player = new Player
            {
                Board = board,
                Name = "Player"
            };
            player.AddShip(new Battleship(new Coordinates(5, 5), 5, true));
            Assert.ThrowsException<ApplicationException>(() => {
                player.AddShip(new Battleship(new Coordinates(6, 5), 5, true));
            });
        }

        [TestMethod]
        public void Player_Loses_When_All_Ships_Sunk()
        {
            IPlayer player = new Player
            {
                Board = board,
                Name = "Player"
            };
            opponent.AddShip(new Battleship(new Coordinates(3, 4), 5, false));
            foreach(Ship ship in opponent.Ships)
            {
                foreach(Coordinates coord in ship.ShipCoordinates)
                {
                    ShotResult result = player.Shoot(opponent, coord);
                }
            }

            Assert.IsTrue(opponent.HasLost);
        }
    }
}
