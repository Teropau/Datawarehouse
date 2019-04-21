using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;

namespace BankApp.Repositories
{
    public interface ITransaction
    {
        List<Transaction> GetTransactions();
        void CreateTransaction(Transaction transaction);
    }
}
