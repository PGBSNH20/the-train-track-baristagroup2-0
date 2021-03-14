using System.Collections.Generic;

namespace TrainConsole
{
    public class TrainDisplayer
    {
        private RailwayMemoryLayer RailwayLayer;
        public TrainDisplayer(RailwayMemoryLayer railwayLayer)
        {
            RailwayLayer = railwayLayer;
        }
        public void Display(List<IRailwayPart> route, int index)
        {
            if (index != 0)
            {
                var drawPart = DrawableRailwayPart.ConvertPart(route[index - 1]);
                RailwayLayer.TryAppend(drawPart);
            }
            var trainPart = DrawableRailwayPart.ConvertPart(route[index]);
            trainPart.Color = System.ConsoleColor.Green;
            RailwayLayer.TryAppend(trainPart);
        }
    }
}