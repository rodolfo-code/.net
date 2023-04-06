﻿using Blog.Data;
using Blog.Models;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BlogDataContext())
            {
                // var tag = new Tag { Name = "CREATE", Slug = "create" };
                // context.Tags.Add(tag);
                // context.SaveChanges();

                var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
                tag.Name = ".NET";
                tag.Slug = "dotnet";

                context.Update(tag);
                context.SaveChanges();
            }
        }
    }
}