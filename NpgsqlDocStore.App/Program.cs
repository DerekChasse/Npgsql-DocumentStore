using NpgsqlDocStore.App.Fakers;
using NpgsqlDocStore.Model;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;

namespace NpgsqlDocStore.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var blogPostFaker = new BlogPostFaker();

            NpgsqlContext context = new NpgsqlContext();

            IEnumerable<BlogPostDocument> blogPosts = new List<BlogPostDocument>();

            int blogsToGenerate = 100;

            TimeThis($"Generating {blogsToGenerate} Blogs", () =>
            {
                blogPosts = blogPostFaker.Generate(blogsToGenerate).Select(bp => new BlogPostDocument { Document = bp });
            });

            TimeThis("Adding Blogs To Context", () =>
            {
                context.BlogPosts.AddRange(blogPosts);
            });

            TimeThis("Saving Changes", () =>
            {
                context.SaveChanges();
            });

            var count = context.BlogPosts.Count();
            Console.WriteLine($"There are now {count} blogs.");

            IEnumerable<BlogPostDocument> blogPostDocuments = new List<BlogPostDocument>();

            TimeThis($"Fetching {blogsToGenerate} blogs", () =>
            {
                blogPostDocuments = context.BlogPosts.Take(blogsToGenerate);
            });

            Console.WriteLine($"Here are {blogsToGenerate} blog authors and the number of comments");
            Console.WriteLine(JsonSerializer.Serialize(blogPostDocuments.Select(bp => new { Author = bp.Document.Author.Name, Comments = bp.Document.Comments.Count }), new JsonSerializerOptions { WriteIndented = true }));

            List<string> authors = new List<string>();
            TimeThis($"Querying for authors of posts who's name starts with 'A'", () =>
            {
                authors = context.BlogPosts
                                    .Where(bp => bp.Document.Author.Name.StartsWith("A"))
                                    .Select(bp => bp.Document.Author.Name)
                                    .ToList();

                context.BlogPosts.Where(bp => bp.Document.Comments.Any(c => c.Content.Contains("great"))).ToList();
            });

            Console.WriteLine(JsonSerializer.Serialize(authors, new JsonSerializerOptions { WriteIndented = true }));

        }

        static void TimeThis(string message, Action action)
        {
            Stopwatch sw = Stopwatch.StartNew();
            action.Invoke();
            Console.WriteLine($"{message} : {sw.Elapsed}");
        }
    }
}
