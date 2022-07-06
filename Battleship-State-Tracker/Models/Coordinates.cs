using System;
using System.Collections.Generic;

namespace Battleship_State_Tracker.Models
{
    public class Coordinates : IEquatable<Coordinates>
    {
        public Coordinates() { }
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj) => Equals(obj as Coordinates);

        public bool Equals(Coordinates coordinates)
        {
            if (coordinates is null)
            {
                return false;
            }

            if (ReferenceEquals(this, coordinates))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (GetType() != coordinates.GetType())
            {
                return false;
            }

            return (X == coordinates.X) && (Y == coordinates.Y);
        }

        public override int GetHashCode() => (X, Y).GetHashCode();

        public static bool operator ==(Coordinates a, Coordinates b)
        {
            if (a is null)
            {
                if (b is null)
                {
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            return a.Equals(b);
        }

        public static bool operator !=(Coordinates a, Coordinates b) => !(a == b);
    }
}