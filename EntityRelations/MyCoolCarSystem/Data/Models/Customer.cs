using System.Collections;
using System.Collections.Generic;

namespace MyCoolCarSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataValidations.Custumer;
    
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(MaxNameLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public ICollection<CarPurchase> Purchases { get; set; } = new HashSet<CarPurchase>();
    }
}