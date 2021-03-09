
namespace TrainConsole
{
    public interface IRail : IRailwayItem
    {
        public int Id { get; set; }
        public IEndPoint EndPointA { get; set; }
        public IEndPoint EndPointB { get; set; }
    }
}
