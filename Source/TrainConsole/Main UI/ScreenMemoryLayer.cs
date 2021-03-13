﻿using System.Collections.Generic;
using System.Text.Json;

namespace TrainConsole
{
    public static class ScreenMemoryLayer
    {
        public static List<IDrawable> Drawables = new List<IDrawable>();
        public static void AppendRailway()
        {
            var railwayParts = Railway.GetRailwayParts();
            foreach (var part in railwayParts)
            {
                var tryUnit = DrawableRailwayPart.ConvertPart(part);
                TryAppendUnit(tryUnit);
            }
        }
        public static bool IsInDrawables(IDrawable drawable)
        {
            foreach (var item in Drawables)
                if (drawable.IsSame(item))
                    return true;
            return false;
        }
        public static void TryAppendUnit(IDrawable tryUnit)
        {
            if (IsInDrawables(tryUnit)) return;

            var oldUnit = Drawables.Find(x =>
            x.CoordinateY == tryUnit.CoordinateY && x.CoordinateX == tryUnit.CoordinateX);

            if(oldUnit != null)
                Drawables.Remove(oldUnit);

            Drawables.Add(tryUnit);
        }
        //public static bool UnitExists(IDrawable tryUnit)
        //=>
        //    Drawables.Exists(m => m.CoordinateX == tryUnit.CoordinateX && m.CoordinateY == tryUnit.CoordinateY);
        //public static bool UnitChanged(IDrawable tryUnit)
        //{
        //    var unit = Drawables.Find(m => m.CoordinateX == tryUnit.CoordinateX && m.CoordinateY == tryUnit.CoordinateY);

        //    string jUnit = JsonSerializer.Serialize(unit);
        //    string jTryUnit = JsonSerializer.Serialize(tryUnit);

        //    return !jUnit.Equals(jTryUnit);
        //}
        //public static bool TryReplace(IDrawable tryUnit)
        //{
        //    if (!UnitExists(tryUnit)) return false;
        //    if (!UnitChanged(tryUnit)) return false;
        //    else
        //    {
        //        int index = Drawables.FindIndex(m => m.CoordinateX == tryUnit.CoordinateX && m.CoordinateY == tryUnit.CoordinateY);
        //        Drawables.RemoveAt(index);
        //        Drawables.Insert(index, tryUnit);
        //        return true;
        //    }
        //}
    }
}
