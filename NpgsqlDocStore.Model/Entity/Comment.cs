using System;
using System.Collections.Generic;
using System.Text;

namespace NpgsqlDocStore.Model.Entity
{
    public class Comment
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Content { get; set; }
    }
}
