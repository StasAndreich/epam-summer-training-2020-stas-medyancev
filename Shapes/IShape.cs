namespace Shapes
{
    /// <summary>
    /// Contains definitions for a shape elements.
    /// </summary>
    interface IShape
    {


        string Name { get; }

        double GetPerimeter();

        double GetArea();
    }
}
