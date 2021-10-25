using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Supermarket.Model.Entities
{
    [Table("cashbox_transaction")]
    public partial class CashboxTransaction
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("cashier")]
        public int? Cashier { get; set; }
        [Column("cashbox_id")]
        public int? CashboxId { get; set; }
        [Required]
        [Column("date")]
        public byte[] Date { get; set; }

        [ForeignKey(nameof(CashboxId))]
        [InverseProperty("CashboxTransactions")]
        public virtual Cashbox Cashbox { get; set; }
        [ForeignKey(nameof(Cashier))]
        [InverseProperty(nameof(User.CashboxTransactions))]
        public virtual User CashierNavigation { get; set; }
    }
}
