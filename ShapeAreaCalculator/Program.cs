namespace ShapeAreaCalculator;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>()
        {
            new Circle(5),
            new Circle(6),
            new Circle(4),
            new Rectangle(12, 5),
            new Rectangle(10, 33),
            new Rectangle(18, 14),
        };
        
        shapes.ForEach(x=>Console.WriteLine($"{x.GetArea()}"));
    }
}

/*
 * Shape Area Calculator
 * 
Covered Topics: Classes, Interfaces and Abstract Classes

Scenario: Compute total area for circles and rectangles stored in a polymorphic list.

Requirements:

Create abstract base Shape with abstract double GetArea().

Implement Circle and Rectangle overrides.

Iterate a List<Shape> and sum areas.

*/