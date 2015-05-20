namespace WS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [Key]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Tlf { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public byte TypeOfUser { get; set; }

        public virtual Order Order { get; set; }
    }
}
