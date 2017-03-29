namespace CarShop.Models.Entities
{
    using System;

    public class Currency
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Glyph { get; set; }
    }
}
