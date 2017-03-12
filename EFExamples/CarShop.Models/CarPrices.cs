using System;

namespace CarShop.Models
{
    public class CarPrices
    {
        public int Id { get; set; }

        public Guid CarId { get; set; }

        public decimal Price { get; set; }

        public int CurrencyId { get; set; }

        public virtual Cars Cars { get; set; }

        public virtual Currencies Currencies { get; set; }
    }
}
