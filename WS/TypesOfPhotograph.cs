namespace WS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TypesOfPhotograph")]
    public partial class TypesOfPhotograph
    {
        public TypesOfPhotograph()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [StringLength(10)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
