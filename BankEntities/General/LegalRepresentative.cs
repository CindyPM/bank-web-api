using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankEntities.General
{
    public class LegalRepresentative
    {
        public int IdLegalRepresentative { get; set; }
        public string Name { get; set; }
        public int IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }
        public string MobileNumber { get; set; }
        public int IdCountry { get; set; }
    }
}
