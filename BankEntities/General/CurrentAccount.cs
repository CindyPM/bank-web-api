
namespace BankEntities.General
{
    public class CurrentAccount
    {
        public int IdCurrentAccount { get; set; }
        
        public long Balance { get; set; }

        public bool State { get; set; } = true;

    }
}
