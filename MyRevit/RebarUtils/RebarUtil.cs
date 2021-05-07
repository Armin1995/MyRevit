using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRevit.RebarUtils
{
    class RebarUtil
    {
        public static Rebar CreateRebar(Autodesk.Revit.DB.Document document, FamilyInstance column, RebarBarType barType, RebarHookType hookType)
        {
            // Define the rebar geometry information - Line rebar
            LocationPoint location = column.Location as LocationPoint;
            XYZ origin = location.Point;
            XYZ normal = new XYZ(1, 0, 0);
            // create rebar 9' long
            XYZ rebarLineEnd = new XYZ(origin.X, origin.Y, origin.Z + 9);
            Line rebarLine = Line.CreateBound(origin, rebarLineEnd);

            // Create the line rebar
            IList<Curve> curves = new List<Curve>();
            curves.Add(rebarLine);

            Rebar rebar = Rebar.CreateFromCurves(document, Autodesk.Revit.DB.Structure.RebarStyle.Standard, barType, hookType, hookType, column, origin, curves, RebarHookOrientation.Right, RebarHookOrientation.Left, true, true);

            if (null != rebar)
            {
                // set specific layout for new rebar as fixed number, with 10 bars, distribution path length of 1.5'
                // with bars of the bar set on the same side of the rebar plane as indicated by normal
                // and both first and last bar in the set are shown
                rebar.GetShapeDrivenAccessor().SetLayoutAsFixedNumber(10, 1.5, true, true, true);
            }

            return rebar;
        }

    }
}
