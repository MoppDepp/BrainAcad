namespace CarShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    public class CarBrands
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarBrands()
        {
            this.CarModels = new HashSet<CarModels>();
        }

        [Required]
        [StringLength(60)]
        public string Brand { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarModels> CarModels { get; set; }

        public Guid Id { get; set; }
    }
}