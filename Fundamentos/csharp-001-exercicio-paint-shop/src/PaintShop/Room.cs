namespace PaintShop;
using System.Linq;


// 2 - Crie uma classe Room
public class Room
{
    public double TotalPaintableArea
    {
        get { return walls.Sum(wall => wall.PaintableArea); }
    }
    public Wall[] walls { get; }
    public Room(params Wall[] walls)
    {
        this.walls = walls;
    }
}