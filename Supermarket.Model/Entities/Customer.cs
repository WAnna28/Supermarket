using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Supermarket.Model.Entities
{
    [Keyless]
    [Table("customer")]
    public partial class Customer
    {
        [Column("id")]
        public int? Id { get; set; }
        [Column("first_name")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Column("last_name")]
        [StringLength(30)]
        public string LastName { get; set; }
        [Column("birth_date", TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        [Column("gender")]
        [StringLength(50)]
        public string Gender { get; set; }
        [Column("email")]
        [StringLength(64)]
        public string Email { get; set; }
        [Column("phone_number")]
        [StringLength(12)]
        public string PhoneNumber { get; set; }
        [Column("address_id")]
        public int? AddressId { get; set; }
        [Column("created_date", TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [ForeignKey(nameof(AddressId))]
        public virtual AddressLocation Address { get; set; }
        [ForeignKey(nameof(Id))]
        public virtual User IdNavigation { get; set; }
    }
}
