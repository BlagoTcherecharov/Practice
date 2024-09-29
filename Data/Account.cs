using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Bank_account.Data
{
    internal class Account
    {
        [Key]
        [EmailAddress]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public float Balance { get; set; }
        public float Loan { get; set; }
    }
}
