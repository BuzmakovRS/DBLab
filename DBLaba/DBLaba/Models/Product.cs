using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbWarehouse.Models
{
    [Table("Products", Schema = "public")]
    public class Product
    {

        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        [Column("ProductName")]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Material { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public ICollection<Location> Locations { get; set; }

        public Product()
        {
            Locations = new List<Location>();
        }
    }
}