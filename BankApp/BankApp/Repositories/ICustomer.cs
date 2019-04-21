using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;

namespace BankApp.Repositories
{
    public interface ICustomer
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(long id);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        void CreateCustomer(Customer customer);
    }
}
