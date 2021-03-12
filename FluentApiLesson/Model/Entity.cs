using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FluentApiLesson.Model
{
    public abstract class Entity
    {
        //[Column("ID")]
        //[Key]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
