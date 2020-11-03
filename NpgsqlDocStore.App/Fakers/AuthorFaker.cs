using Bogus;
using Bogus.Extensions;

using NpgsqlDocStore.Model.Entity;

using System;
using System.Collections.Generic;
using System.Text;

namespace NpgsqlDocStore.App.Fakers
{
    public class AuthorFaker : Faker<Author>
    {
        public AuthorFaker()
        {
            RuleFor(a => a.Name, f => f.Name.FullName());
            RuleFor(a => a.Email, f => f.Internet.Email());
        }
    }
}
