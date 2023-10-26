
namespace BankEntities.General
{
    public class CDT
    {
        public int IdCDT { get; set; } 
        public long Balance { get; set; }
        public decimal InterestRate { get; set; }
        public bool State { get; set; } = true;
    }
}
