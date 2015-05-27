namespace Webservice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Categories
    {
        public Categories()
        {
            Pictures = new HashSet<Pictures>();
        }

        [Required]
        [StringLength(10)]
        public string Category { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public int Id { get; set; }

        public virtual ICollection<Pictures> Pictures { get; set; }
    }
}
