using NpgsqlDocStore.Model.Entity;

using System;
using System.Collections.Generic;
using System.Text;

namespace NpgsqlDocStore.Model
{
    public class BlogPostDocument : DocumentBacked<BlogPost>, IEntity
    {
        public int Id { get; set; }
    }
}
