using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Supermarket.Model.Entities
{
    [Table("product")]
    public partial class Product
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("description")]
        [StringLength(500)]
        public string Description { get; set; }
        [Column("price", TypeName = "money")]
        public decimal? Price { get; set; }
        [Column("cost", TypeName = "money")]
        public decimal? Cost { get; set; }
        [Column("code")]
        public int? Code { get; set; }
        [Column("refunded")]
        public bool? Refunded { get; set; }
        [Column("supplier_id")]
        public int? SupplierId { get; set; }
        [Column("category_id")]
        public int? CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Products")]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(SupplierId))]
        [InverseProperty("Products")]
        public virtual Supplier Supplier { get; set; }
    }
}
