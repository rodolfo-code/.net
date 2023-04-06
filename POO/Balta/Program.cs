using Balta.ContentContext;
namespace Balta
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var articles = new List<Article>();
            articles.Add(new Article("Artigo sobnre OOP", "www.orientacao.com"));
            articles.Add(new Article("Artigo sobnre funcional", "www.programacao.com"));
            articles.Add(new Article("Artigo sobnre Rodolfo", "www.desenvolvimento.com"));

            foreach (var article in articles)
            {
                Console.WriteLine(article.Id);
                Console.WriteLine(article.Title);
                Console.WriteLine(article.Url);
            }
        }
    }
}