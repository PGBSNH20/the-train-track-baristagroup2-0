using System;

namespace FirstLevelRailway
{
    public static class RailwayLocator
    {
        //public static IRailwayPart LocateWithId(int id)
        //{
        //    try
        //    {
        //        return Railway.RailwayParts.Find(x => x.Id == id);
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}
        public static IRailwayPart LocateWithPosXY((int X, int Y) coord, bool railwayParts = true)
        {
            if (railwayParts == true)
            {
                var searchParts = Railway.GetRailwayParts();
            }
            else
            {
                var searchParts = Railway.RailwayParts;
            }
            try
            {
                return Railway.RailwayParts.Find(item => item.CoordinateX == coord.X && item.CoordinateY == coord.Y);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static IRailwayPart LocateUp(IRailwayPart part)
        {
            var up = LocateWithPosXY((part.CoordinateX, part.CoordinateY - 1));
            return (IRailwayPart)up;
        }
        public static IRailwayPart LocateUpRight(IRailwayPart part)
        {
            var upRight = LocateWithPosXY((part.CoordinateX + 1, part.CoordinateY - 1));
            return (IRailwayPart)upRight;
        }
        public static IRailwayPart LocateRight(IRailwayPart part)
        {
            var right = LocateWithPosXY((part.CoordinateX + 1, part.CoordinateY));
            return (IRailwayPart)right;
        }
        public static IRailwayPart LocateDownRight(IRailwayPart part)
        {
            var downRight = LocateWithPosXY((part.CoordinateX + 1, part.CoordinateY + 1));
            return (IRailwayPart)downRight;
        }
        public static IRailwayPart LocateDown(IRailwayPart part)
        {
            var down = LocateWithPosXY((part.CoordinateX, part.CoordinateY + 1));
            return (IRailwayPart)down;
        }
        public static IRailwayPart LocateDownLeft(IRailwayPart part)
        {
            var downLeft = LocateWithPosXY((part.CoordinateX - 1, part.CoordinateY + 1));
            return (IRailwayPart)downLeft;
        }

        public static IRailwayPart LocateLeft(IRailwayPart part)
        {
            var left = LocateWithPosXY((part.CoordinateX - 1, part.CoordinateY));
            return (IRailwayPart)left;
        }
        public static IRailwayPart LocateUpLeft(IRailwayPart part)
        {
            var upLeft = LocateWithPosXY((part.CoordinateX - 1, part.CoordinateY - 1));
            return (IRailwayPart)upLeft;
        }
    }
}
