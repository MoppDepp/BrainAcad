using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShop.Models
{
    public class Cars
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cars()
        {
            CarPrices = new HashSet<CarPrices>();
        }

        public Guid Id { get; set; }

        public Guid CarBrandModel { get; set; }

        [Column(TypeName = "date")]
        public DateTime Year { get; set; }

        public string NewField { get; set; }

        public virtual CarModels CarModels { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarPrices> CarPrices { get; set; }
    }
}
