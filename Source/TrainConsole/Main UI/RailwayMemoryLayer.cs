using System.Collections.Generic;
using System.Text.Json;

namespace TrainConsole
{
    public static class RailwayMemoryLayer
    {
        public static List<IDrawable> Drawables = new List<IDrawable>();
        public static void AppendRailwayDrawables()
        {
            var railwayParts = Railway.GetRailwayParts();
            foreach (var part in railwayParts)
            {
                var tryUnit = DrawableRailwayPart.ConvertPart(part);
                TryAppend(tryUnit);
            }
        }
        public static bool IsInDrawables(IDrawable drawable)
        {
            foreach (var item in Drawables)
                if (drawable.IsSame(item))
                    return true;
            return false;
        }
        public static void TryAppend(IDrawable tryUnit)
        {
            if (IsInDrawables(tryUnit)) return;

            var oldUnit = Drawables.Find(x =>
            x.CoordinateY == tryUnit.CoordinateY && x.CoordinateX == tryUnit.CoordinateX);

            if(oldUnit != null)
                Drawables.Remove(oldUnit);

            Drawables.Add(tryUnit);
        }
    }
}
