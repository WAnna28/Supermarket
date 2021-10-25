using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Supermarket.Model.Entities
{
    [Table("shipping")]
    public partial class Shipping
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("branch_id")]
        public int? BranchId { get; set; }
        [Column("supplier_id")]
        public int? SupplierId { get; set; }
        [Column("quantity")]
        public int? Quantity { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("sent_at", TypeName = "datetime")]
        public DateTime? SentAt { get; set; }
        [Column("arrived_at", TypeName = "datetime")]
        public DateTime? ArrivedAt { get; set; }

        [ForeignKey(nameof(BranchId))]
        [InverseProperty("Shippings")]
        public virtual Branch Branch { get; set; }
        [ForeignKey(nameof(SupplierId))]
        [InverseProperty("Shippings")]
        public virtual Supplier Supplier { get; set; }
    }
}
