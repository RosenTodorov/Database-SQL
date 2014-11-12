namespace ATM.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ATM.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ATMContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(ATMContext context)
        {
            context.CardAccounts.AddOrUpdate(ca => ca.CardNumber,
                new CardAccount { CardCash = 300m, CardNumber = "0001", CardPin = "1111"},
                new CardAccount { CardCash = 400m, CardNumber = "0002", CardPin = "2222"},
                new CardAccount { CardCash = 500m, CardNumber = "0003", CardPin = "3333"},
                new CardAccount { CardCash = 600m, CardNumber = "0004", CardPin = "4444"}
                );
        }
    }
}
