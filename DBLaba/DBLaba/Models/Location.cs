﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbWarehouse.Models
{
    [Table("Locations",Schema="public")]
    public class Location
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int? ProductId { get; set; }
 //       [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int? ProducerId { get; set; }
 //       [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
        public int? ShelfId { get; set; }
  //      [ForeignKey("ShelfId")]
        public Shelf Shelf { get; set; }
        public int Count { get; set; }
    }
}