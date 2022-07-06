using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Battleship_State_Tracker.Models;
namespace Battleship_State_Tracker.Models.Tests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void Board_Constructor_With_Valid_Size_Creates_Valid_Board_Squares()
        {
            int boardSize = 6;
            Board board = new Board(boardSize);
            Assert.IsTrue(board.Squares.Count == boardSize * boardSize);
        }

        [TestMethod]
        public void Board_Constructor_Sets_Size_Property()
        {
            int boardSize = 8;
            Board board = new Board(boardSize);
            Assert.IsTrue(board.Size == boardSize);
        }

        [TestMethod]
        public void Board_Constructor_Size_Must_Be_Greater_Than_Zero()
        {
            int boardSize = -3;
            Assert.ThrowsException<ArgumentException>(() => { Board board = new Board(boardSize); });
        }
    }
}
