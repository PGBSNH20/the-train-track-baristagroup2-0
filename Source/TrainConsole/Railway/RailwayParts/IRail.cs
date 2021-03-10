
namespace TrainConsole
{
    public interface IRail : IRailwayItem, IRailwayPart
    {
        public IRailwayPart EndPointA { get; set; }
        public IRailwayPart EndPointB { get; set; }
    }
}
