using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NpgsqlDocStore.Model
{
    public abstract class DocumentBacked<T>
        where T : class, new()
    {
        [Column(TypeName = "jsonb")]
        public T Document { get; set; }
    }
}
