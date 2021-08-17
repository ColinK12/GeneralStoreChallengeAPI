﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeneralStoreChallengeAPI.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey (nameof(Transaction))]
        [Required]
        public String FirstName { get; set; }
        
        [Required]
        public String LastName { get; set; }
        
        [Required]
        public String FullName { get; set; }
        public virtual Transaction Transaction { get; set; }
        public List<Transaction> transactions { get; set; }
    }
}