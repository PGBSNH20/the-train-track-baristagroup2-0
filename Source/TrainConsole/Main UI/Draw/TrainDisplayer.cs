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
        private IDrawable LastDrawn { get; set; }
        public void Display(List<IRailwayPart> route, int index)
        {
            if (index != 0)
            {
                LastDrawn.Color = System.ConsoleColor.White;
                LastDrawn.IsDrawn = false;
            }
            var railwayPart = route[index];
            var trainPart = DrawableRailwayPart.ConvertPart(railwayPart);

            trainPart.Color = System.ConsoleColor.Green;
            if (railwayPart.GetType() == typeof(Station))
                trainPart.Color = System.ConsoleColor.Red;

            LastDrawn = trainPart;
            RailwayLayer.TryAppend(trainPart);
        }
    }
}