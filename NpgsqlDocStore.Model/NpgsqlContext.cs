using Microsoft.EntityFrameworkCore;

using Npgsql;

using System;
using System.Collections.Generic;
using System.Text;

namespace NpgsqlDocStore.Model
{
    public class NpgsqlContext : DbContext
    {
        public DbSet<BlogPostDocument> BlogPosts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var builder = new NpgsqlConnectionStringBuilder();
            builder.Host = "192.168.1.21";
            builder.Username = "postgres";
            builder.Password = "password";
            builder.Database = "DocStore";


            optionsBuilder.UseNpgsql(builder.ToString());

        }
    }
}
