using BankData.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankData
{
    public class BankDbContext: DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options)
            : base(options)
        {
        }
        public DbSet<Country> Country { get; set; }
        public DbSet<LegalRepresentative> LegalRepresentative { get; set; }
        public DbSet<CDT> CDT { get; set; }
        public DbSet<CurrentAccount> CurrentAccount { get; set; }
        public DbSet<SavingsAccount> SavingsAccount { get; set; }
        public DbSet<Client> Client { get; set; }
    }
}
