using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ATM.Models;
using ATM.Data.Migrations;

namespace ATM.Data
{
    public class ATMContext : DbContext
    {
        public ATMContext() :base("ATM")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ATMContext, Configuration>());
        }

        public DbSet<CardAccount> CardAccounts { get; set; }

        public DbSet<TransactionHistory> TransactionsHistory { get; set; }
    }
}
