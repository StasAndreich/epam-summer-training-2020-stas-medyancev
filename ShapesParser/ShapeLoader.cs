using Shapes;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ShapesUtilities
{
    /// <summary>
    /// Class that loads shapes from different sources.
    /// </summary>
    public static class ShapeLoader
    {
        /// <summary>
        /// Loads a shapes array from a properly formatted text file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static Shape[] LoadShapesArrayFromTextFile(string filePath)
        {
            IShapeCreator shapeCreator = null;
            var shapesList = new List<Shape>();

            // Read all lines in a file.
            foreach (var line in File.ReadAllLines(filePath))
            {
                var lineParts = line.Split(' ');
                
                // Search for the specific figure.
                switch(lineParts[0])
                {
                    case "Circle":
                        shapeCreator = new CircleCreator();
                        break;
                    case "Triangle":
                        shapeCreator = new TriangleCreator();
                        break;
                    case "Rectangle":
                        shapeCreator = new RectangleCreator();
                        break;
                    case "Square":
                        shapeCreator = new SquareCreator();
                        break;
                    default:
                        break;
                }

                // Creating a figure from the current string line.
                var shape = LoadShapeFromString(shapeCreator, line);
                shapesList.Add(shape);
            }

            return shapesList.ToArray();
        }

        /// <summary>
        /// Creates a shape from an input string.
        /// </summary>
        /// <param name="shapeCreator"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Shape LoadShapeFromString(IShapeCreator shapeCreator, string input)
        {
            // Create regular expressions.
            // Sipmle variant: "Shape 4 5.6".
            var regexSides = new Regex(@"[+-]?([0-9]*[.])?[0-9]+");

            // Coords variant: "Shape (4.5; 7.8) (3.2; 8.83)".
            var regexPoints = new Regex(@"\(([+-]?([0-9]*[.])?[0-9]+)\;\s*([+-]?([0-9]*[.])?[0-9]+)\)");

            var matchesSides = regexSides.Matches(input);
            var matchesPoints = regexPoints.Matches(input);

            // Create a shape from coords.
            if (matchesPoints.Count != 0)
            {
                // Accumulate all vertices in Point[] array.
                var points = new Point[matchesPoints.Count];
                int i = 0;

                foreach (Match match in matchesPoints)
                {
                    // Parse coord values.
                    GroupCollection groups = match.Groups;
                    double.TryParse(groups[1].Value, result: out double x);
                    double.TryParse(groups[3].Value, result: out double y);

                    // Create a new Point object.
                    points[i] = new Point(x, y);
                    i++;
                }

                return shapeCreator.CreateShape(points);
            }

            // Create a shape from sides.
            else if (matchesSides.Count != 0)
            {
                var sides = new double[matchesSides.Count];
                int i = 0;

                foreach (Match match in matchesSides)
                {
                    // Parse sides values.
                    double.TryParse(match.Value, result: out double side);

                    // Assign a side value to an array.
                    sides[i] = side;
                    i++;
                }

                return shapeCreator.CreateShape(sides);
            }

            // If there is nothing to create.
            return null;
        }
    }
}
