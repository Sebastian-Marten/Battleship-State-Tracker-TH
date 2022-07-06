using Battleship_State_Tracker.Enums;
using Battleship_State_Tracker.Models;
using System.Collections.Generic;

namespace Battleship_State_Tracker.Interfaces
{
    public interface IPlayer
    {
        string Name { get; }
        Board Board { get; set; }
        List<Ship> Ships { get; }
        bool HasLost { get; }
        ShotResult Shoot(IPlayer otherPlayer, Coordinates coordinates);
        void AddShip(Ship ship);
    }
}
