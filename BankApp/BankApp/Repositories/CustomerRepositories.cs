using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using System.Linq;

namespace BankApp.Repositories
{
    class CustomerRepositories : ICustomer
    {
        private readonly BankdbContext _bankdbContext = new BankdbContext();

        public void CreateCustomer(Customer customer)
        {
            _bankdbContext.Add(customer);
            _bankdbContext.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            _bankdbContext.Customer.Remove(customer);
            _bankdbContext.SaveChanges();
        }

        public Customer GetCustomerById(long id)
        {
            var customer = _bankdbContext.Customer.Find(id);
            return customer;
        }

        public List<Customer> GetCustomers()
        {
            var customers = _bankdbContext.Customer.ToList();
            return customers;
        }

        public void UpdateCustomer(Customer customer)
        {
            _bankdbContext.Customer.Update(customer);
            _bankdbContext.SaveChanges();
        }
    }
}
