namespace MetricImperialConverter;

public class MetricImperialConverter
{
    private readonly Dictionary<string, double> _conversionFactors;

    public MetricImperialConverter()
    {
        _conversionFactors=new()
        {
            {ConversionDirectionConstants.KmToMi,MetricConversionFactors.Km / MetricConversionFactors.Mi},
            {ConversionDirectionConstants.MiToKm,MetricConversionFactors.Mi / MetricConversionFactors.Km},
            {ConversionDirectionConstants.KmToYd,MetricConversionFactors.Km/MetricConversionFactors.Yd},
            {ConversionDirectionConstants.YdToKm,MetricConversionFactors.Yd/MetricConversionFactors.Km},
            {ConversionDirectionConstants.MToYd,MetricConversionFactors.M / MetricConversionFactors.Yd},
            {ConversionDirectionConstants.YdToM,MetricConversionFactors.Yd/MetricConversionFactors.M},
        };
        //KmToMi
        //MiToKm
        //MToYd
        //YdToM
        //KmToYd
        //YdToKm
    }


    public double Convert(double value, string fromUnit, string toUnit)
    {
        string combinedUnit=string.Concat(fromUnit,"to",toUnit);

        if (!_conversionFactors.TryGetValue(combinedUnit,out var conversionFactor))
            throw new ArgumentException("Invalid Unit");
        
        return Math.Round(value * conversionFactor,4);
    }
}