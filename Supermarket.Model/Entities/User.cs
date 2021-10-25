using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Supermarket.Model.Entities
{
    [Table("users")]
    public partial class User
    {
        public User()
        {
            CashboxTransactions = new HashSet<CashboxTransaction>();
            OrderCustomers = new HashSet<Order>();
            OrderDeliveryMen = new HashSet<Order>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("username")]
        [StringLength(20)]
        public string Username { get; set; }
        [Column("passwd")]
        [StringLength(64)]
        public string Passwd { get; set; }

        [InverseProperty(nameof(CashboxTransaction.CashierNavigation))]
        public virtual ICollection<CashboxTransaction> CashboxTransactions { get; set; }
        [InverseProperty(nameof(Order.Customer))]
        public virtual ICollection<Order> OrderCustomers { get; set; }
        [InverseProperty(nameof(Order.DeliveryMan))]
        public virtual ICollection<Order> OrderDeliveryMen { get; set; }
    }
}
