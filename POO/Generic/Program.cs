namespace Generic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            var subscription = new Subscription();
            var context = new DataContext<Person>();
            context.Save(person);
        }
    }

    public class DataContext<T>
        where T : Person
    {
        public void Save(T entity)
        {

        }

    }

    public class Person { }

    public class Payment { }

    public class Subscription { }
}