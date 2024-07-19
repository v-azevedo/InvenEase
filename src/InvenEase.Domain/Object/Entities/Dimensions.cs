using InvenEase.Domain.Common.Models;

namespace InvenEase.Domain.Object.Entities;

public sealed class Dimensions : ValueObject
{
    public double Length { get; private set; }
    public double Width { get; private set; }
    public double Height { get; private set; }
    public double Weight { get; private set; }

    private Dimensions(double length, double width, double height, double weight)
    {
        Length = length;
        Width = width;
        Height = height;
        Weight = weight;
    }

    public static Dimensions CreateNew(double length, double width, double height, double weight)
    {
        return new Dimensions(length, width, height, weight);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Length;
        yield return Width;
        yield return Height;
        yield return Weight;
    }
}