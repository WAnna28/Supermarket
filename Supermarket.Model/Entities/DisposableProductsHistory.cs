using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Supermarket.Model.Entities
{
    [Keyless]
    [Table("disposable_products_history")]
    public partial class DisposableProductsHistory
    {
        [Column("id")]
        public int? Id { get; set; }
        [Column("refound_status")]
        public bool? RefoundStatus { get; set; }
        [Column("refunder_id")]
        public int? RefunderId { get; set; }
        [Column("refund_price")]
        public int? RefundPrice { get; set; }
        [Column("create_date", TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [ForeignKey(nameof(Id))]
        public virtual Product IdNavigation { get; set; }
        [ForeignKey(nameof(RefunderId))]
        public virtual Supplier Refunder { get; set; }
    }
}
