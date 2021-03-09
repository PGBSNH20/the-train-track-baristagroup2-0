
namespace TrainConsole
{
    public interface IRail : IRailwayPart
    {
        public IEndPoint EndPointA { get; set; }
        public IEndPoint EndPointB { get; set; }
    }
}
