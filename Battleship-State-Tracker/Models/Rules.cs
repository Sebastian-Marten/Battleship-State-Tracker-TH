using System.Collections.Generic;
namespace Battleship_State_Tracker.Models
{
    public class Rules
    {
        public int BoardSize { get; set; } = 10;
        public int MaximumTurns => BoardSize * BoardSize;
        public List<ShipRule> ShipRules { get; } = new List<ShipRule>();
    }
}
