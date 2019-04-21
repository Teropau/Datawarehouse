using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BankApp.Models;

namespace BankApp.Repositories
{
    class AccountRepositories : IAccount
    {
        private readonly BankdbContext _bankdbContext = new BankdbContext();

        public void CreateAccount(Account account)
        {
            _bankdbContext.Add(account);
            _bankdbContext.SaveChanges();
        }

        public void DeleteAccount(Account account)
        {
            _bankdbContext.Remove(account);
            _bankdbContext.SaveChanges();
        }

        public Account GetAccountById(long id)
        {
            var account = _bankdbContext.Account.Find(id);
            return account;

        }

        public List<Account> GetAccounts()
        {
            var accounts = _bankdbContext.Account.ToList();
            return accounts;
        }
    }
}
