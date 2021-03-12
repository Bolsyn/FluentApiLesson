using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApiLesson.Model
{
    public class DishProducts : Entity
    {
        public Guid DishId { get; set; }

        public virtual Dish Dish { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
