
namespace TrainConsole
{
    public interface IRail : IRailwayPart
    {
        public int Id { get; set; }
        public IEndPoint EndPointA { get; set; }
        public IEndPoint EndPointB { get; set; }
    }
}
