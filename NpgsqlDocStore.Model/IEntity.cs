using System;
using System.Collections.Generic;
using System.Text;

namespace NpgsqlDocStore.Model
{
    interface IEntity
    {
        public int Id { get; set; }
    }
}
