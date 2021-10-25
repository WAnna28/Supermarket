using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Supermarket.Model.Entities
{
    [Keyless]
    [Table("transaction_product")]
    public partial class TransactionProduct
    {
        [Column("transaction_id")]
        public int? TransactionId { get; set; }
        [Column("product_id")]
        public int? ProductId { get; set; }
        [Column("quantity")]
        public int? Quantity { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(TransactionId))]
        public virtual CashboxTransaction Transaction { get; set; }
    }
}
