using Battleship_State_Tracker.Enums;

namespace Battleship_State_Tracker.Models
{
    public class ShipRule
    {
        public ShipRule(ShipTypes shipType, int length, int number)
        {
            ShipType = shipType;
            Length = length;
            Number = number;
        }
        public ShipTypes ShipType { get; }
        public int Length { get; }
        public int Number { get; }
    }
}
