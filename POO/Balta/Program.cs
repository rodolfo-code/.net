using Balta.ContentContext;
namespace Balta
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var course = new Course();
            course.Level = ContentContext.Enums.EContentLevel.Beginner;

        }
    }
}