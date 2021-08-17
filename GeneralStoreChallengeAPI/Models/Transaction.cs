﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeneralStoreChallengeAPI.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]//ForeginKey
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]//ForeginKey
        public string ProductSKU { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        public int ItemCount { get; set; }

        [Required]
        public DateTime DateOfTransaction { get; set; }

        //public List<Product> Products { get; set; }
        //public List<Customer> Customers { get; set; }

    }
}