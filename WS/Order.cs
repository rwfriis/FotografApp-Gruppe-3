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
            return string.Format("User: {0}, UserEmail: {5}, Address: {1}, DateTime: {4}, TypeOf: {2}, Portraits: {3}, Price: {6}", User, Address, TypeOf, Portraits, DateTime, UserEmail, Price);
        }
    }
}
