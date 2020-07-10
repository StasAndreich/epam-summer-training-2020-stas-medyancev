using System;

namespace GeometricalFigures
{
    /// <summary>
    /// Abstract class that defines a basic
    /// geometrical figure and its basic methods.
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Keeps the figure name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Returns the area of the figure.
        /// </summary>
        /// <returns>Double area value.</returns>
        public abstract double GetArea();

        /// <summary>
        /// Returns the area of the figure.
        /// </summary>
        /// <returns>Double perimeter value.</returns>
        public abstract double GetPerimeter();
    }
}
