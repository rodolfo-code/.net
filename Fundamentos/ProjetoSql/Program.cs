using ProjetoSql.Models;
using System.Globalization;

public class Program
{
    public static void Main(string[] args)
    {
        var context = new StudentContext();

        context.Database.EnsureCreated();
        var newStudent = new Student
        {
            Name = "Rodolfo",
            Birthday = DateTime.ParseExact("20/11/1992", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            Address = "Rua dos Alfeneiros"
        };

        context.Students.Add(newStudent);
        context.SaveChanges();
    }


}
