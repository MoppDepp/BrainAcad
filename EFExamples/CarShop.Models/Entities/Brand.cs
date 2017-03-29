namespace CarShop.Models.Entities
{
    using System;
    using System.Collections.Generic;

    public class Brand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Model> Models { get; set; } 
    }
}