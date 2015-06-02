namespace Webservice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public int Portraits { get; set; }

        public int Price { get; set; }

        public int TypeOfId { get; set; }

        [Required]
        public string Address { get; set; }

        public int Id { get; set; }
    }
}
