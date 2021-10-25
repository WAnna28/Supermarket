using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Supermarket.Model.Entities
{
    [Keyless]
    [Table("dispose_package")]
    public partial class DisposePackage
    {
        [Column("prod_id")]
        public int? ProdId { get; set; }
        [Column("branch_id")]
        public int? BranchId { get; set; }
        [Column("quantity")]
        public int? Quantity { get; set; }
        [Column("volume")]
        public int? Volume { get; set; }

        [ForeignKey(nameof(BranchId))]
        public virtual Branch Branch { get; set; }
        [ForeignKey(nameof(ProdId))]
        public virtual Product Prod { get; set; }
    }
}
