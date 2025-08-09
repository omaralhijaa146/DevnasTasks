namespace ShapeAreaCalculator;

public class Circle : Shape
{
    public double Radius { get;}
    public override string Source => typeof(Circle).Name;
    
    public Circle(double radius)
    {
        Radius = radius;
    }
    
    public override double GetArea()
    {
        Console.WriteLine($"{Source} Area");
        return Math.PI * Math.Pow(Radius, 2);
    }
}