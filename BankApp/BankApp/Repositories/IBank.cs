using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Repositories
{
    public interface IBank
    {
        List<Bank> GetBanks();
        void CreateBank(Bank bank);
        void DeleteBank(Bank bank);
        Bank GetBankById(long id);
    }
}
