namespace Webservice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pictures
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(255)]
        public string Source { get; set; }

        public int Id { get; set; }

        public virtual Categories Categories { get; set; }
    }
}
