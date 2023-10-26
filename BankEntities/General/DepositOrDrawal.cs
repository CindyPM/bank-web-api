using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankEntities.General
{
    public class DepositOrDrawal
    {
        public int Action { get; set;}
        public int TypeProduct { get; set;}
        public string NumIdentification { get; set;}
        public long Amount { get; set;}
    }
}
