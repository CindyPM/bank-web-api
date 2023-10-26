
namespace BankEntities.General
{
    public class SavingsAccount
    {
        public int IdSavingsAccount { get; set; }
        
        public long Balance { get; set; }

        public decimal InterestRate { get; set; }

        public bool State { get; set; } = true;
    }
}
