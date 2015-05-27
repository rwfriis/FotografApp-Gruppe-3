namespace Webservice
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
            Orders = new HashSet<Orders>();
        }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public int Id { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
