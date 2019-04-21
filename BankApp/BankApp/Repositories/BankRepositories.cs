using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using System.Linq;

namespace BankApp.Repositories
{
    class BankRepositories : IBank
    {
        private readonly BankdbContext _bankdbContext = new BankdbContext();

        public void CreateBank(Bank bank)
        {
            _bankdbContext.Add(bank);
            _bankdbContext.SaveChanges();
        }
        public void DeleteBank(Bank bank)
        {
            _bankdbContext.Bank.Remove(bank);
            _bankdbContext.SaveChanges();
        }
        public Bank GetBankById(long id)
        {
            var bank = _bankdbContext.Bank.Find(id);
            return bank;
        }

        public List<Bank> GetBanks()
        {
            var banks = _bankdbContext.Bank.ToList();

            return banks;
        }

        public void UpdateBank(Bank bank)
        {
            _bankdbContext.Bank.Update(bank);
            _bankdbContext.SaveChanges();
        }
    }
}
