namespace WS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [Key]
        [StringLength(50)]
        public string UserEmail { get; set; }

        public DateTime DateTime { get; set; }

        public int? Portraits { get; set; }

        public int Price { get; set; }

        [Required]
        [StringLength(10)]
        public string TypeOf { get; set; }

        [Required]
        public string Address { get; set; }

        public virtual TypesOfPhotograph TypesOfPhotograph { get; set; }

        public virtual User User { get; set; }

        public override string ToString()
        {
            return string.Format("UserEmail: {0}, Address: {1}, DateTime: {2}, TypeOf: {3}, Portraits: {4}, Price: {5}", UserEmail, Address, DateTime, TypeOf, Portraits, Price);
        }
    }
}
