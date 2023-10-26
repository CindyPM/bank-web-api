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
    public class Country
    {
        [Key]
        public int IdCountry { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(3)")]
        [StringLength(3)]
        public string  Code { get; set; }
    }
}
