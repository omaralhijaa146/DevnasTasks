namespace ShapeAreaCalculator;

public abstract class Shape
{
    public virtual string Source=>string.Empty;
    public abstract double GetArea();
}