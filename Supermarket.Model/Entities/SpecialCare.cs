using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Supermarket.Model.Entities
{
    [Keyless]
    [Table("special_care")]
    public partial class SpecialCare
    {
        [Column("prod_id")]
        public int? ProdId { get; set; }
        [Column("max_temp")]
        public int? MaxTemp { get; set; }
        [Column("min_temp")]
        public int? MinTemp { get; set; }
        [Column("expiration_date", TypeName = "datetime")]
        public DateTime? ExpirationDate { get; set; }

        [ForeignKey(nameof(ProdId))]
        public virtual Product Prod { get; set; }
    }
}
