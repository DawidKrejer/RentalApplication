using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalApplication.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
