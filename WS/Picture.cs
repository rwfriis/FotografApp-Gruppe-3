namespace WS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Picture
    {
        [Required]
        [StringLength(10)]
        public string Category { get; set; }

        [Key]
        [StringLength(255)]
        public string Source { get; set; }

        public virtual Category Category1 { get; set; }
    }
}
