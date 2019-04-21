using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;

namespace BankApp.Repositories
{
    public interface IAccount
    {
        List<Account> GetAccounts();
        Account GetAccountById(long id);
        void DeleteAccount(Account account);
        void CreateAccount(Account account);
    }
}
