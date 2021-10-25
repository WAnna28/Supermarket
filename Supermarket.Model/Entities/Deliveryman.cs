﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Supermarket.Model.Entities
{
    [Keyless]
    [Table("deliveryman")]
    public partial class Deliveryman
    {
        [Column("employee_id")]
        public int? EmployeeId { get; set; }
        [Column("car_type")]
        [StringLength(20)]
        public string CarType { get; set; }
        [Column("car_number")]
        [StringLength(7)]
        public string CarNumber { get; set; }
        [Column("car_model")]
        [StringLength(15)]
        public string CarModel { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public virtual User Employee { get; set; }
    }
}
