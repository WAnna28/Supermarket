﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Supermarket.Model.Entities
{
    [Table("address_location")]
    public partial class AddressLocation
    {
        public AddressLocation()
        {
            Branches = new HashSet<Branch>();
            Suppliers = new HashSet<Supplier>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("city")]
        [StringLength(25)]
        public string City { get; set; }
        [Column("district")]
        [StringLength(25)]
        public string District { get; set; }
        [Column("street")]
        [StringLength(25)]
        public string Street { get; set; }
        [Column("apartment")]
        [StringLength(25)]
        public string Apartment { get; set; }
        [Column("building_number")]
        public int? BuildingNumber { get; set; }
        [Column("postal_code")]
        public int? PostalCode { get; set; }

        [InverseProperty(nameof(Branch.Location))]
        public virtual ICollection<Branch> Branches { get; set; }
        [InverseProperty(nameof(Supplier.Location))]
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
