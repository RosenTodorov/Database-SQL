using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

using ATM.Data;
using ATM.Models;

namespace ATM.ConsoleClient
{
    public class ConsoleClient
    {
        static void Main()
        {
            //Try with invalid pin code
            string cardNumber = "0001";
            string cardPIN = "3333";
            decimal sum = 10;

            try
            {
                WithdrawMoney(cardNumber, cardPIN, sum);
            }
            catch (Exception exception)
            {
                
                Console.WriteLine("Error!" + exception.Message);
            }

            //Try with too much money
            cardPIN = "1111";
            sum = 1000;

            try
            {
                WithdrawMoney(cardNumber, cardPIN, sum);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error!" + exception.Message);
            }

            //Try with valid data
            sum = 200;
            try
            {
                WithdrawMoney(cardNumber, cardPIN, sum);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error!" + exception.Message);
            }

        }

        private static void WithdrawMoney(string cardNumber, string PINCode, decimal sum) 
        {
            TransactionOptions tranOptions = new TransactionOptions();
            tranOptions.IsolationLevel = IsolationLevel.RepeatableRead;

            using (TransactionScope tran = new TransactionScope(TransactionScopeOption.Required, tranOptions))
            {
                using (var db = new ATMContext())
                {
                    var account = db.CardAccounts.Where(ca => ca.CardNumber == cardNumber && ca.CardPin == PINCode).FirstOrDefault();
                    if (account == null)
                    {
                        throw new ArgumentException("No card with these parameters.");
                    }
                    if (sum <= 0)
                    {
                        throw new ArgumentException("Sum must be positive.");
                    }
                    if (account.CardCash < sum)
                    {
                        throw new ArgumentException("Not enough money in the card.");
                    }

                    LogTransaction(sum, cardNumber);
                    account.CardCash -= sum;
                    Console.WriteLine("You took {0}$ ", sum);

                    db.SaveChanges();
                }
            }
        }

        private static void LogTransaction(decimal sum, string cardNumber)
        {
            using (var db = new ATMContext())
            {
                TransactionHistory log = new TransactionHistory 
                {
                    CardNumber = cardNumber,
                    Amount = sum,
                    TransactionDate = DateTime.Now
                };

                db.TransactionsHistory.Add(log);
                db.SaveChanges();
            }
        }
    }
}
