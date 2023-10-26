using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankData.Model
{
    public class CDT
    {
        [Key]
        public int IdCDT { get; set; }
        
        [Required]
        public long Balance { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal InterestRate { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool State { get; set; }
    }
}
