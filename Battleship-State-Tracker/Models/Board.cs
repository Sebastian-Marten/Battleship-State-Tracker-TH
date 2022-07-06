using System;
using System.Collections.Generic;

namespace Battleship_State_Tracker.Models
{
    public class Board
    {
        public Board(int boardSize)
        {
            if (boardSize < 1) {
                throw new ArgumentException("Board size must be greate than zero");
            }
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Squares.Add(new Square(new Coordinates(i, j)));
                }
            }
            Size = boardSize;

        }
        public int Size { get; }
        public List<Square> Squares { get; } = new List<Square>();
    }
}
