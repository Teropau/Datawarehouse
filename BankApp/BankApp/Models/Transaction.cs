using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApp.Models
{
    public partial class Transaction
    {
        public long Id { get; set; }
        [Required]
        [StringLength(20)]
        public string IBAN { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime TimeStamp { get; set; }

        [ForeignKey("IBAN")]
        [InverseProperty("Transaction")]
        public virtual Account IBANNavigation { get; set; }
    }
}