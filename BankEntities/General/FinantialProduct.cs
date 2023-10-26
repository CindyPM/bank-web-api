using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankEntities.General
{
    public class FinantialProduct
    {
        public long Balance { get; set; }
        public decimal InterestRate { get; set; }
        public bool State { get; set; } = true;
    }

    public class FinantialProductCancel
    {
        public int IdClient { get; set; }
        public int IdFinantialProduct { get; set; }
        public int FinantialProductType { get; set; }
    }

    public class FinantialProductProjection
    {
        public long Balance { get; set; }
        public decimal InterestRate { get; set; }
    }

    public class FinantialProductProjectionResponse
    {
        public string Month { get; set; }
        public double Balance { get; set; }
    }
}
