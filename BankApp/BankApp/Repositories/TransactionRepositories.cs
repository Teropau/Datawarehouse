using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using System.Linq;

namespace BankApp.Repositories
{
    class TransactionRepositories : ITransaction
    {
        private readonly BankdbContext _bankdbContext = new BankdbContext();

        public void CreateTransaction(Transaction transaction)
        {
            _bankdbContext.Add(transaction);
            _bankdbContext.SaveChanges();
        }

        public List<Transaction> GetTransactions()
        {
            var transactions = _bankdbContext.Transaction.ToList();
            return transactions;
        }
    }
}
