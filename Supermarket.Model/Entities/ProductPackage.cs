using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Supermarket.Model.Entities
{
    [Keyless]
    [Table("product_package")]
    public partial class ProductPackage
    {
        [Column("shipping_id")]
        public int? ShippingId { get; set; }
        [Column("branch_id")]
        public int? BranchId { get; set; }
        [Column("prod_id")]
        public int? ProdId { get; set; }
        [Column("warehouse_quantity")]
        public int? WarehouseQuantity { get; set; }
        [Column("dep_quantity")]
        public int? DepQuantity { get; set; }
        [Column("expiration_date", TypeName = "date")]
        public DateTime? ExpirationDate { get; set; }
        [Column("volume")]
        public int? Volume { get; set; }

        [ForeignKey(nameof(BranchId))]
        public virtual Branch Branch { get; set; }
        [ForeignKey(nameof(ProdId))]
        public virtual Product Prod { get; set; }
        [ForeignKey(nameof(ShippingId))]
        public virtual Shipping Shipping { get; set; }
    }
}
