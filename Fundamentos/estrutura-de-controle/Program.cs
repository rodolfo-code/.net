public class Program
{
    public static void Main()
    {
        Console.WriteLine("Informe o numero de lados");
        string? numberSideString = Console.ReadLine();
        int numberSides = Convert.ToInt32(numberSideString);

        string name = string.Empty;

        switch (numberSides)
        {
            case < 3:
                name = "Nao é um poligono";
                break;
            case 3:
                name = "Triangulo";
                break;
            case 4:
                name = "Quadrilatero";
                break;
            default:
                name = "Poligono nao identificado";
                break;
        }

        Console.WriteLine($"Ó Pligono é um {name}");
    }
}