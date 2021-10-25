using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Supermarket.Model.Entities
{
    [Keyless]
    [Table("log_sessions")]
    public partial class LogSession
    {
        [Column("id")]
        public int? Id { get; set; }
        [Column("log_in", TypeName = "datetime")]
        public DateTime? LogIn { get; set; }
        [Column("log_out", TypeName = "datetime")]
        public DateTime? LogOut { get; set; }

        [ForeignKey(nameof(Id))]
        public virtual User IdNavigation { get; set; }
    }
}
