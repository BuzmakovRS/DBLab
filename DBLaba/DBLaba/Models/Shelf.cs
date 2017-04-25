using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbWarehouse.Models
{
    [Table("Shelves", Schema = "public")]
    public class Shelf
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column("ShelfName")]
        public string Name { get; set; }
        public string Position { get; set; }
        public ICollection<Location> Locations { get; set; }

        public Shelf()
        {
            Locations = new List<Location>();
        }
    }
}