using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankEntities.Enums
{
    public class Enums
    {
        public enum TypeProduct
        {
            SavingsAccount = 1,
            CurrentAccount = 2,
            CDT = 3
        }

        public enum Action
        {
            Deposit = 1,
            Withdrawal = 2
        }
    }
}
