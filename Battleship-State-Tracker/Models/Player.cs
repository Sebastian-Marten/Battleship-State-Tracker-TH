using Battleship_State_Tracker.Enums;
using Battleship_State_Tracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship_State_Tracker.Models
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public Board Board { get; set; }

        public void AddShip(Ship ship)
        {
            foreach(Ship existing in Ships)
            {
                foreach(Coordinates coord in existing.ShipCoordinates)
                {
                    if(ship.ShipCoordinates.Any(s => s.Equals(coord)))
                    {
                        throw new ApplicationException("Ship overlaps another Ship");
                    }
                }
            }
            foreach (Coordinates coordinate in ship.ShipCoordinates)
            {
                Square square = Board.Squares.FirstOrDefault(s => s.Coordinates.Equals(coordinate));
                if (square == null)
                {
                    throw new ApplicationException($"Ship square at {coordinate.X}, {coordinate.Y} not in game board");
                }
                square.Occupied = true;
            }
            Ships.Add(ship);

        }
        public List<Ship> Ships { get; } = new List<Ship>();
        public bool HasLost { get { return !Ships.Any(b => !b.Sunk); } }

        public ShotResult Shoot(IPlayer otherPlayer, Coordinates coordinates)
        {
            // See if the shot has been taken before
            Square shootingAt = otherPlayer.Board.Squares.FirstOrDefault(s => s.Coordinates.Equals(coordinates));
            if (shootingAt.Hit || shootingAt.Miss)
            {
                return ShotResult.AlreadyUsed;
            }
            if (shootingAt.Occupied)
            {
                shootingAt.Hit = true;
                foreach(Ship b in otherPlayer.Ships)
                {
                    Coordinates coord = b.ShipCoordinates.FirstOrDefault(s => s.Equals(coordinates));
                    if(coord != null)
                    {
                        b.Hits++;
                        break;
                    }
                }
                return ShotResult.Hit;
            }
            shootingAt.Miss = true;
            return ShotResult.Miss;
        }
    }
}
