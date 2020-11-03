using Bogus;
using Bogus.Extensions;

using NpgsqlDocStore.Model.Entity;

using System;
using System.Collections.Generic;
using System.Text;

namespace NpgsqlDocStore.App.Fakers
{
    public class CommentFaker : Faker<Comment>
    {
        public CommentFaker()
        {
            RuleFor(c => c.Content, f => f.Rant.Review());
            RuleFor(c => c.Email, f => f.Internet.Email());
            RuleFor(c => c.UserName, f => f.Internet.UserName());
        }
    }
}
