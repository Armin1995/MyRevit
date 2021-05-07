using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using MyRevit.RebarUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRevit
{
    [Transaction(TransactionMode.Manual), Regeneration(RegenerationOption.Manual)]
    class QuickTest : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiapp = commandData.Application;
            var doc = commandData.Application.ActiveUIDocument.Document;

            var columns = new FilteredElementCollector(doc).OfClass(typeof(FamilyInstance)).OfCategory(BuiltInCategory.OST_StructuralColumns).ToElements();
            var rebarBarType = new FilteredElementCollector(doc).OfClass(typeof(RebarBarType)).WhereElementIsElementType().ToElements().First() as RebarBarType;
            var rebarHookType = new FilteredElementCollector(doc).OfClass(typeof(RebarHookType)).WhereElementIsElementType().ToElements().First() as RebarHookType;

            if (rebarBarType != null && rebarHookType != null)
            {
                using (Transaction trans = new Transaction(doc, "Create Rebar"))
                {
                    try
                    {
                        trans.Start();

                        foreach (FamilyInstance column in columns)
                        {
                            RebarUtil.CreateRebar(doc, column, rebarBarType, rebarHookType);
                        }

                        trans.Commit();
                    }
                    catch (System.Exception e)
                    {
                        trans.RollBack();
                    }
                }
            }

            return Result.Succeeded;
        }
    }
}
