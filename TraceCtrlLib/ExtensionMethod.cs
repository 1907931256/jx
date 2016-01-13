using System.Collections.Generic;
using System.Drawing;

namespace TraceCtrlLib.PanelExtend
{
    public static class ExtensionMethod
    {
        public static bool IsBetween(this int value, int lowerBound, int upperBound, bool includeLowBound = false, bool includeUpperBound = false)
        {
            return(includeLowBound && value == lowerBound) || (includeUpperBound && value == upperBound) || (value > lowerBound && value < upperBound);
        }

        public static bool IsNullOrEmpty(this List<TracePanel> value)
        {
            return (value == null || value.Count == 0);
        }

        public static bool IsNullOrEmpty(this List<TraceChain> value)
        {
            return (value == null || value.Count == 0);
        }

        public static bool IsNullOrEmpty(this List<TraceMonitorPoint> value)
        {
            return (value == null || value.Count == 0);
        }

        public static Point CenterPoint(this Rectangle rect)
        {
            return new Point(rect.X+rect.Width/2,rect.Y+rect.Height/2);
        }

        //public static List<TraceChain> Find(this List<TraceChain> traceChains, String entity)
        //{
        //    if (traceChains.IsNullOrEmpty() || string.IsNullOrEmpty(entity))
        //        return null;

        //    return traceChains.Where(tc => tc.Entity == entity).ToList();
        //}
    }
}
