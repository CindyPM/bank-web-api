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
    public class CurrentAccount
    {
        [Key]
        public int IdCurrentAccount { get; set; }
        
        [Required]
        public long Balance { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool State { get; set; }

    }
}
