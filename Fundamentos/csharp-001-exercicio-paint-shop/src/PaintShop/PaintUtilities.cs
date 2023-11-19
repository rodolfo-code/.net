namespace PaintShop;

// 3 - Crie uma classe estática PaintUtilities
public static class PaintUtilities
{
    public static int BucketSizeLiters { get; set; }
    public static int SquareMetersPerLiter { get; set; }

    static PaintUtilities()
    {
        BucketSizeLiters = 20;
        SquareMetersPerLiter = 10;
    }

    public static int SquareMetersPerBucket
    {
        get { return SquareMetersPerLiter * BucketSizeLiters; }
    }

    public static int GetNeededPaintBuckets(double area)
    {
        return Convert.ToInt32(Math.Ceiling(area / SquareMetersPerBucket));
    }

    public static int GetNeededPaintBuckets(Wall wall)
    {
        double total = wall.PaintableArea / SquareMetersPerBucket;
        return Convert.ToInt32(Math.Ceiling(total));
    }

    public static int GetNeededPaintBuckets(Room room)
    {
        double total = room.TotalPaintableArea / SquareMetersPerBucket;
        return Convert.ToInt32(Math.Ceiling(total));
    }

    public static decimal CalculateCost(decimal price, double area)
    {
        return GetNeededPaintBuckets(area) * price;
    }

    public static decimal CalculateCost(decimal price, Wall wall)
    {
        return GetNeededPaintBuckets(wall) * price;
    }

    public static decimal CalculateCost(decimal price, Room room)
    {
        return GetNeededPaintBuckets(room) * price;
    }
}