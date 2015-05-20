namespace WS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        public Category()
        {
            Pictures = new HashSet<Picture>();
        }

        [Key]
        [Column("Category")]
        [StringLength(10)]
        public string Category1 { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
