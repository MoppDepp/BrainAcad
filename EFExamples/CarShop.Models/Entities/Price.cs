namespace CarShop.Models.Entities
{
    using System;

    public class Price
    {
        public Guid Id { get; set; }

        public decimal Value { get; set; }

        public Guid CurrencyId { get; set; }

        public Guid CarId { get; set; }

        public virtual Currency Currency { get; set; }

        public virtual Car Car { get; set; }
    }
}
