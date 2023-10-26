using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BankEntities.General
{
    public class Client
    {
        public int IdClient { get; set; }
        public string Name { get; set; }
        public int IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }
        public int? IdLegalRepresentative { get; set; }
        public int? IdSavingsAccount { get; set; }
        public int? IdCurrentAccount { get; set; }
        public int? IdCDT { get; set; }
        public LegalRepresentative? LegalRepresentative { get; set; }
        public SavingsAccount? SavingsAccount { get; set; }
        public CurrentAccount? CurrentAccount { get; set; }
        public CDT? CDT { get; set; }
    }
}
