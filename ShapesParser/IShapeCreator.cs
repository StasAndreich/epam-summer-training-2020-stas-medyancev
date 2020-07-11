using Shapes;

namespace ShapesUtilities
{
    /// <summary>
    /// Interface that defines a factory method
    /// for creating shapes instances.
    /// </summary>
    interface IShapeCreator
    {
        Shape CreateShape(string input);
    }
}
