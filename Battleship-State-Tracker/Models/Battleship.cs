using System;

namespace Battleship_State_Tracker.Models
{
    public class Battleship : Ship
    {
        public Battleship(Coordinates bow, int length, bool horizontal)
        {
            ShipType = Enums.ShipTypes.Battleship;
            Name = "Battleship";

            if(bow == null)
            {
                throw new ArgumentException("The coordinates of the ships bow are required");
            }
            if(bow.X < 0 || bow.Y < 0)
            {
                throw new ArgumentException("The coordinates of the ships bow cannot be less than zero [0, 0]");
            }
            if(length < 1)
            {
                throw new ArgumentException("The length of the Battleship must be greater than 0");
            }
            Length = length;
            BowCoordinates = bow;
            Horizontal = horizontal;
            if (horizontal) {
                for (int i = bow.X; i < bow.X + length; i++)
                {
                    ShipCoordinates.Add(new Coordinates(i, bow.Y));
                }
            } else {
                for (int i = bow.Y; i < bow.Y + length; i++)
                {
                    ShipCoordinates.Add(new Coordinates(bow.X, i));
                }
            }
        }

    }
}
