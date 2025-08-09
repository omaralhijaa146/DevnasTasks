namespace ShapeAreaCalculator;

public class Rectangle : Shape
{
    
    public double Width { get; }
    public double Height { get;}
    public virtual string Source => typeof(Rectangle).Name;
    
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }
    
    public override double GetArea()
    {
        Console.WriteLine($"{Source} Area");
        return Width * Height;
    }
}