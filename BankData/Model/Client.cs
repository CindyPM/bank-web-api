using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankData.Model
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int IdentificationType { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        [StringLength(20)]
        public string IdentificationNumber { get; set; }
        public int? IdLegalRepresentative { get; set; }
        public int? IdSavingsAccount { get; set; }
        public int? IdCurrentAccount { get; set; }
        public int? IdCDT { get; set; }

        [ForeignKey("IdLegalRepresentative")]
        public LegalRepresentative? LegalRepresentative { get; set; }

        [ForeignKey("IdSavingsAccount")]
        public SavingsAccount? SavingsAccount { get; set; }

        [ForeignKey("IdCurrentAccount")]
        public CurrentAccount? CurrentAccount { get; set; }

        [ForeignKey("IdCDT")]
        public CDT? CDT { get; set; }
    }
}
