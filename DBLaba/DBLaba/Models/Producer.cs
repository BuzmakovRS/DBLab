using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbWarehouse.Models
{
    [Table("Pruducers", Schema = "public")]
    public class Producer
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Column("ProducerName")]
        public string Name { get; set; }
        public string City { get; set; }
        public ICollection<Location> Locations { get; set; }

        public Producer()
        {
            Locations = new List<Location>();
        }
    }
}