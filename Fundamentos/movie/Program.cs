namespace Movie;

using MovieSpace.Models;
using System.Linq;
using MovieSpace.DTO;

public class MovieAPI
{
    public static void Main(string[] args)
    {
        string[] eletivas = new string[3];
        eletivas[0] = "C#";
        eletivas[1] = "Java";

        //lista generica
        List<string> listaEletivas = new List<string>();

        //dicionario - tupla indice valor
        Dictionary<string, int> numeroPE = new Dictionary<string, int>();
        numeroPE["C#"] = 10;
        numeroPE["Java"] = 15;

        //hashset - lista de valor unico
        HashSet<string> hashEletivas = new HashSet<string>();

        //fila
        Queue<string> filaEletivas = new Queue<string>();

        //stack
        Stack<string> pilhaEletivas = new Stack<string>();

        List<Movie> movieList = new()
        {
            new Movie {Name = "A origem", ReleaseYear = 2008, Genre = "Sci-fi", Rating = (float)4.98},
            new Movie {Name = "O iluminado", ReleaseYear = 1989, Genre = "Horror", Rating = (float)4.5},
            new Movie {Name = "A rede social", ReleaseYear = 2010, Genre = "Drama", Rating = (float)3.5},
            new Movie {Name = "Assassin's Creed", ReleaseYear = 2016, Genre = "Adventure", Rating = (float)3.0}
        };

        Movie novoFilme = new()
        {
            Name = "Piratas do caribe",
            ReleaseYear = 2003,
            Genre = "Adventure",
            Rating = (float)4.99
        };

        movieList.Add(novoFilme);

        List<ActressPerson> actressPeople = new List<ActressPerson>()
        {
            new ActressPerson {Name = "Leonardo DiCaprio", Movie = "A origem"},
            new ActressPerson {Name = "Jesse Eisenberg", Movie = "A rede social"},
            new ActressPerson {Name = "Marion Cotillard", Movie = "A origem"},
            new ActressPerson {Name = "Tom Hardy", Movie = "A origem"},
            new ActressPerson {Name = "Marion Cotillard", Movie = "Assassin's Creed"}
        };

        var movieQuery = from movie in movieList
                         where movie.ReleaseYear > 2005
                         orderby movie.Rating descending
                         select movie;

        var movieQueryInfo = from movie in movieList
                             where movie.ReleaseYear > 2005
                             orderby movie.Rating descending
                             select new MovieInfo
                             {
                                 Info = movie.Name + " foi lançado em " + movie.ReleaseYear,
                                 Rating = movie.Rating,
                             };

        var actressPeopleMovie = from actressPerson in actressPeople
                                 join movie in movieList
                                 on actressPerson.Movie equals movie.Name
                                 //where movie.ReleaseYear > 2012
                                 select new AcrtessInfo
                                 {
                                     Name = actressPerson.Name,
                                     Movie = actressPerson.Movie,
                                     ReleaseYear = movie.ReleaseYear,
                                     Rating = movie.Rating,
                                 };

        var actressPeopleGroup = from actressPerson in actressPeople
                                 join movie in movieList
                                 on actressPerson.Movie equals movie.Name
                                 group actressPerson by actressPerson.Movie into movieGroup
                                 select movieGroup;

        foreach (var movie in actressPeopleGroup)
        {
            Console.WriteLine(movie.Key);
            foreach(var item in movie)
            {
                Console.WriteLine(item.Name);
            };
            Console.WriteLine("");
        }


        foreach (var actressInfo in actressPeopleMovie)
        {
            //Console.WriteLine(actressInfo.Name + " - " + actressInfo.Movie + " - " + actressInfo.ReleaseYear);
        }

        foreach (var movie in movieQueryInfo)
        {
            //Console.WriteLine(movie.Info);
        }
    }
}