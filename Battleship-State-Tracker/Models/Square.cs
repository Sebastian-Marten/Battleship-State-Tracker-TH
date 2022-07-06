namespace Battleship_State_Tracker.Models
{
    public class Square
    {
        public Square (Coordinates coordinates)
        {
            Coordinates = coordinates;
        }
        public bool Occupied { get; set; }
        public bool Hit { get; set; }
        public bool Miss { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}
