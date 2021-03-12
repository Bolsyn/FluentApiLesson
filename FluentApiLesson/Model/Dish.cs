using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FluentApiLesson.Model
{
    //[Table("dishes")]
    public class Dish : Entity
    {
        //[Column("name")]
        //[Required]
        //[StringLength(50)]
        public string Name { get; set; }
        public ICollection<DishProducts> DishProducts { get; set; }
    }
}
