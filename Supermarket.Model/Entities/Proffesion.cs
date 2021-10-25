using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Supermarket.Model.Entities
{
    [Table("proffesion")]
    public partial class Proffesion
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("prof_name")]
        [StringLength(50)]
        public string ProfName { get; set; }
    }
}
