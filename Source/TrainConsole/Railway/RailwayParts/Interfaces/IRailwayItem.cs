
namespace TrainConsole
{
    public interface IRailwayItem
    {
        public int Id { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public char Char { get; set; }
    }
}
