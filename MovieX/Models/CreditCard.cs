using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieX.Models
{
    public class CreditCard
    {
        [Key]
        [Required]
        [MaxLength(15)]
        public string CardNumber { get; set; }

        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(1)]
        public string Month { get; set; }

        [Required]
        [MaxLength(1)]
        public string Year { get; set; }

        [Required]
        [MaxLength(2)]
        public string CCV { get; set; }
    }
}