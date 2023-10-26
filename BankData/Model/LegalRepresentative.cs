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
    public class LegalRepresentative
    {
        [Key]
        public int IdLegalRepresentative { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(100)")]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required]
        public int IdentificationType { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(20)")]
        [StringLength(20)]
        public string IdentificationNumber { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        [StringLength(20)]
        public string MobileNumber { get; set; }

        [Required]
        public int IdCountry { get; set; }
        
        [Required]
        [ForeignKey("IdCountry")]
        public Country Country { get; set; }
    }
}
