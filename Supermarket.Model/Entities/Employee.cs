using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Supermarket.Model.Entities
{
    [Keyless]
    [Table("employee")]
    public partial class Employee
    {
        [Column("id")]
        public int? Id { get; set; }
        [Column("first_name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Column("last_name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Column("birth_date", TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        [Column("gender")]
        [StringLength(50)]
        public string Gender { get; set; }
        [Column("phone_number")]
        [StringLength(12)]
        public string PhoneNumber { get; set; }
        [Column("email")]
        [StringLength(64)]
        public string Email { get; set; }
        [Column("address_id")]
        public int? AddressId { get; set; }
        [Column("profession_id")]
        public int? ProfessionId { get; set; }
        [Column("starting_salary", TypeName = "money")]
        public decimal? StartingSalary { get; set; }
        [Column("salary", TypeName = "money")]
        public decimal? Salary { get; set; }
        [Column("firstday_date", TypeName = "date")]
        public DateTime? FirstdayDate { get; set; }
        [Column("created_date", TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [Column("department_id")]
        public int? DepartmentId { get; set; }
        [Column("branch_id")]
        public int? BranchId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public virtual AddressLocation Address { get; set; }
        [ForeignKey(nameof(BranchId))]
        public virtual Branch Branch { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(Id))]
        public virtual User IdNavigation { get; set; }
        [ForeignKey(nameof(ProfessionId))]
        public virtual Proffesion Profession { get; set; }
    }
}
