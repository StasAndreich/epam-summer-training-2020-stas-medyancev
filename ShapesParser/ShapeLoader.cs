using Shapes;
using System.Collections.Generic;
using System.IO;

namespace ShapesUtilities
{
    public static class ShapeLoader
    {
        public static Shape[] LoadShapesArrayFromFile(string filePath)
        {
            var inputShapesList = new List<Shape>();

            foreach (var line in File.ReadAllLines(filePath))
            {
                inputShapesList.Add();
            }
        }
    }
}
