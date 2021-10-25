using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Supermarket.Model.Entities
{
    [Keyless]
    [Table("cell_products")]
    public partial class CellProduct
    {
        [Column("branch_id")]
        public int? BranchId { get; set; }
        [Column("product_id")]
        public int? ProductId { get; set; }
        [Column("dep_quantity")]
        public int? DepQuantity { get; set; }
        [Column("optimal_quantity")]
        public int? OptimalQuantity { get; set; }
        [Column("max_quantity")]
        public int? MaxQuantity { get; set; }

        [ForeignKey(nameof(BranchId))]
        public virtual Branch Branch { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
    }
}
