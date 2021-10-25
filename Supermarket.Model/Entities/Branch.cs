using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Supermarket.Model.Entities
{
    [Table("branch")]
    public partial class Branch
    {
        public Branch()
        {
            Cashboxes = new HashSet<Cashbox>();
            Orders = new HashSet<Order>();
            Shippings = new HashSet<Shipping>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("location_id")]
        public int? LocationId { get; set; }
        [Column("freezer_volume")]
        public int? FreezerVolume { get; set; }
        [Column("storage_volume")]
        public int? StorageVolume { get; set; }
        [Column("type")]
        [StringLength(30)]
        public string Type { get; set; }

        [ForeignKey(nameof(LocationId))]
        [InverseProperty(nameof(AddressLocation.Branches))]
        public virtual AddressLocation Location { get; set; }
        [InverseProperty(nameof(Cashbox.Branch))]
        public virtual ICollection<Cashbox> Cashboxes { get; set; }
        [InverseProperty(nameof(Order.Branch))]
        public virtual ICollection<Order> Orders { get; set; }
        [InverseProperty(nameof(Shipping.Branch))]
        public virtual ICollection<Shipping> Shippings { get; set; }
    }
}
