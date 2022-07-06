using Battleship_State_Tracker.Enums;
using System.Collections.Generic;

namespace Battleship_State_Tracker.Models
{
    public abstract class Ship
    {
        public string Name { get; set; }
        public ShipTypes ShipType { get; set; }
        public List<Coordinates> ShipCoordinates { get; } = new List<Coordinates>();

        public int Length { get; set; } = 3;
        public int Hits { get; set; } = 0;
        public bool Sunk => Length == Hits;

        public Coordinates BowCoordinates { get; set; }
        public bool Horizontal { get; set; }
    }
}
