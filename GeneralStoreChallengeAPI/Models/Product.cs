using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeneralStoreChallengeAPI.Models
{
    public class Product
    {
        [Key]
        public string SKU { get; set; }
        [ForeignKey (nameof(Transaction))]

        [Required]
        public string Name { get; set; }

        [Required]
        public short Cost { get; set; }

        [Required]
        public int NumberInInventory { get; set; }

        [Required]
        public bool IsInStock { get; set; }
    }
}