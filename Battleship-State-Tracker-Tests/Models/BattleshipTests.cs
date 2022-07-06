using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Battleship_State_Tracker.Models.Tests
{
    [TestClass()]
    public class BattleshipTests
    {
        [TestMethod()]
        public void Create_Battleship_Not_Null()
        {
            Coordinates bowCoordinates = new Coordinates { X = 3, Y = 6 };
            int length = 4;
            bool horizontal = true;
            Battleship ship = new Battleship(bowCoordinates, length, horizontal);
            Assert.IsNotNull(ship);
            Assert.IsInstanceOfType(ship, typeof(Battleship));
        }

        [TestMethod()]
        public void Create_Battleship_Is_Battleship()
        {
            Coordinates bowCoordinates = new Coordinates { X = 3, Y = 6 };
            int length = 4;
            bool horizontal = true;
            Battleship ship = new Battleship(bowCoordinates, length, horizontal);
            Assert.IsInstanceOfType(ship, typeof(Battleship));
        }

        [TestMethod()]
        public void Battleship_Length_Same_As_Parameter_Lenght_Input()
        {
            Coordinates bowCoordinates = new Coordinates { X = 3, Y = 6 };
            int length = 4;
            bool horizontal = true;
            Battleship ship = new Battleship(bowCoordinates, length, horizontal);
            Assert.IsTrue(ship.Length == length);
        }

        [TestMethod()]
        public void Battleship_Coordinates_Created_Correctly_Horizontal()
        {
            Coordinates bowCoordinates = new Coordinates { X = 3, Y = 6 };
            int length = 5;
            bool horizontal = true;
            Battleship ship = new Battleship(bowCoordinates, length, horizontal);

            Assert.IsTrue(ship.ShipCoordinates.Count == length);
            Assert.AreEqual(ship.ShipCoordinates.First(), bowCoordinates);
            Assert.AreEqual(ship.ShipCoordinates.Last(), new Coordinates(bowCoordinates.X + length - 1, bowCoordinates.Y));

            for (int i = 0; i < length; i++)
            {
                Coordinates check = new Coordinates(i + bowCoordinates.X, bowCoordinates.Y);
                Assert.AreEqual(check, ship.ShipCoordinates[i]);
            }

        }

        [TestMethod()]
        public void Battleship_Coordinates_Created_Correctly_Vertical()
        {
            Coordinates bowCoordinates = new Coordinates { X = 3, Y = 3 };
            int length = 5;
            bool horizontal = false;
            Battleship ship = new Battleship(bowCoordinates, length, horizontal);

            Assert.IsTrue(ship.ShipCoordinates.Count == length);
            Assert.AreEqual(ship.ShipCoordinates.First(), bowCoordinates);
            Assert.AreEqual(ship.ShipCoordinates.Last(), new Coordinates(bowCoordinates.X, bowCoordinates.Y + length - 1));

            for (int i = 0; i < length; i++)
            {
                Coordinates check = new Coordinates(bowCoordinates.X, bowCoordinates.Y + i);
                Assert.AreEqual(check, ship.ShipCoordinates[i]);
            }

        }
    }
}