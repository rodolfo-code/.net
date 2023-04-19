using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace FluentBlog
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new BlogDataContext();
            // var user = new User
            // {
            //     Name = "Rodolfo Oliveira",
            //     Slug = "rodolfooliveira",
            //     Email = "rod.vgo@gmail.com",
            //     Bio = "2x Microsoft MVP",
            //     Image = "https://balta.io",
            //     PasswordHash = "123456"
            // };

            // var category = new Category
            // {
            //     Name = "Backend",
            //     Slug = "backend"
            // };

            // var post = new Post
            // {
            //     Author = user,
            //     Category = category,
            //     Body = "<p>Hello world</p>",
            //     Slug = "comecando-com-ef-core",
            //     Summary = "Neste artigo vamos aprender EF Core",
            //     Title = "Começando com EF Core",
            //     CreateDate = DateTime.Now,
            //     LastUpdateDate = DateTime.Now,
            // };

            // context.Posts.Add(post);
            // context.SaveChanges();

            // var posts = context
            //     .Posts
            //     .AsNoTracking()
            //     .Include(x => x.Author)
            //     .Include(x => x.Category)
            //     .OrderByDescending(x => x.LastUpdateDate)
            //     .ToList();

            // foreach (var post in posts)
            // {
            //     Console.WriteLine($"{post.Title} escrito por {post.Author?.Name} em {post.Category?.Name}");
            // }

            // var posts = context
            //     .Posts
            //     // .AsNoTracking()
            //     .Include(x => x.Author)
            //     .Include(x => x.Category)
            //     .OrderByDescending(x => x.LastUpdateDate)
            //     .FirstOrDefault();

            // posts.Author.Name = "Gumercindo";
            // context.Posts.Update(posts);
            // context.SaveChanges();

            // context.Users.Add(new User
            // {
            //     Name = "Rodolfo Oliveira",
            //     Slug = "rodolfooliveira",
            //     Email = "rod.vgo@gmail.com",
            //     Bio = "2x Microsoft MVP",
            //     Image = "https://balta.io",
            //     PasswordHash = "123456"
            // });

            // context.SaveChanges();

            var user = context.Users.FirstOrDefault();

            var post = new Post
            {
                Author = user,
                Body = "<p>Hello world</p>",
                Category = new Category
                {
                    Name = "Backend",
                    Slug = "backend"
                },
                CreateDate = DateTime.Now,
                // LastUpdateDate = DateTime.Now,
                Slug = "meu-artigo",
                Summary = "Neste artigo vamos aprender EF Core",
                Title = "Meu artigo",
            };

            context.Posts.Add(post);
            context.SaveChanges();
        }
    }
}