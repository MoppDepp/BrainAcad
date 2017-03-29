namespace CarShop.Models.Entities
{
    using System.Collections.Generic;

    public class ModelType
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public virtual ICollection<Model> Models { get; set; } 
    }
}
