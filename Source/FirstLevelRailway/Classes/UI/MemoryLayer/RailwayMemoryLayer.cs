﻿using System.Collections.Generic;
using System.Text.Json;

namespace TrainConsole
{
    public class RailwayMemoryLayer : IMemoryLayer
    {
        public List<IDrawable> Drawables { get; set; } = new List<IDrawable>();
        public void AppendRailwayDrawables()
        {
            var railwayParts = Railway.GetRailwayParts();
            foreach (var part in railwayParts)
            {
                var tryUnit = DrawableRailwayPart.ConvertPart(part);
                TryAppend(tryUnit);
            }
        }
        public bool IsInDrawables(IDrawable drawable)
        {
            foreach (var item in Drawables)
                if (drawable.IsSame(item))
                    return true;
            return false;
        }
        public void TryAppend(IDrawable tryUnit)
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
