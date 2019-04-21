using System;
using BankApp.Models;
using BankApp.Repositories;

namespace BankApp
{
    class Program
    {
        static private BankRepositories bankRepositories = new BankRepositories();
        static private CustomerRepositories customerRepositories = new CustomerRepositories();
        static private AccountRepositories accountRepositories = new AccountRepositories();
        static private TransactionRepositories transactionRepositories = new TransactionRepositories();

        static void Main(string[] args)
        {
            PrintBanks();
            CreateBank();
            DeleteBank();
            UpdateBank();
            PrintBank();
            PrintCustomers();
            CreateCustomerAndAccount();
            UpdateOrDeleteCustomer();
            PrintAccountsByBankId();
            PrintAccountsByCustomerId();
            PrintTransactionsByCustomerId();
            CreateTransactionForCustomer();
            Console.ReadKey();
        }


        static void PrintBanks()
        {
            var banks = bankRepositories.GetBanks();
            foreach (var bank in banks)
            {
                Console.WriteLine($"{bank.Id} {bank.Name} {bank.BIC}");
            }
        }

        static void PrintBank()
        {
            Console.Write("Syötä etsittävän pankin Id:");
            int id = int.Parse(Console.ReadLine());
            var banks = bankRepositories.GetBanks();
            foreach (var bank in banks)
            {
                if (bank.Id == id)
                {
                    Console.WriteLine($"{bank.Id} {bank.Name} {bank.BIC}");
                }

            }
        }

        static void CreateBank()
        {
            Bank newBank = new Bank();
            Console.Write("Syötä uuden pankin nimi: ");
            newBank.Name = Console.ReadLine();
            Console.Write("Syötä uuden pankin BIC: ");
            newBank.BIC = Console.ReadLine();

            bankRepositories.CreateBank(newBank);
        }

        static void DeleteBank()
        {
            Console.Write("Syötä poistettavan pankin id: ");
            long id = long.Parse(Console.ReadLine());
            var bank = bankRepositories.GetBankById(id);

            if (bank == null)
            {
                Console.WriteLine($"Pankkia id:llä {id} ei löytynyt.");
            }

            else
            {
                Console.WriteLine($"Pankki: {bank.Id}, {bank.Name}, {bank.BIC}");
                bankRepositories.DeleteBank(bank);
                Console.WriteLine("Data poistettu onnistuneesti.");
            }
        }
        static void UpdateBank()
        {
            Console.Write("Syötä päivitettävän pankin id: ");
            long id = long.Parse(Console.ReadLine());
            var bank = bankRepositories.GetBankById(id);
            Console.Write("Syötä pankin uusi nimi: ");
            bank.Name = Console.ReadLine();
            Console.Write("Syötä pankin uusi BIC: ");
            bank.BIC = Console.ReadLine();

            bankRepositories.UpdateBank(bank);
        }

        static void PrintCustomers()
        {
            var customers = customerRepositories.GetCustomers();
            Console.Write("Syötä pankin id, jonka asiakkaat haluat listata: ");
            long bankId = long.Parse(Console.ReadLine());

            foreach (var customer in customers)
            {
                if (customer.BankId == bankId)
                {
                    Console.WriteLine($"{customer.Id} {customer.Firstname} {customer.Lastname}");
                }
            }
        }

        static void UpdateOrDeleteCustomer()
        {
            Console.Write("1: Muokkaa asiakkaan tietoja.\n" +
                "2: Poista asiakkaan tiedot.\n" +
                "Tee valinta ja paina enter: ");
            int caseSwitch = int.Parse(Console.ReadLine());
            switch (caseSwitch)
            {
                case 1:
                    Console.Write("Syötä päivitettävän asiakkaan id: ");
                    long id = long.Parse(Console.ReadLine());
                    var customer = customerRepositories.GetCustomerById(id);
                    Console.Write("Syötä asiakkaan uusi etunimi: ");
                    customer.Firstname = Console.ReadLine();
                    Console.Write("Syötä asiakkaan uusi sukunimi: ");
                    customer.Lastname = Console.ReadLine();

                    customerRepositories.UpdateCustomer(customer);
                    break;

                case 2:
                    Console.Write("Syötä poistettavan asiakkaan id: ");
                    id = long.Parse(Console.ReadLine());
                    customer = customerRepositories.GetCustomerById(id);

                    if (customer == null)
                    {
                        Console.WriteLine($"Asiakasta id:llä {id} ei löytynyt.");
                    }

                    else
                    {
                        Console.WriteLine($"{customer.Id} {customer.Firstname} {customer.Lastname}");
                        customerRepositories.DeleteCustomer(customer);
                        Console.WriteLine("Data poistettu onnistuneesti.");
                    }
                    break;
                default:
                    Console.WriteLine("rikki");
                    break;
            }
        }

        static void CreateCustomerAndAccount()
        {
            Customer newCustomer = new Customer();
            Console.Write("\nSyötä pankin id, johon uusi asiakas tulee:");
            newCustomer.BankId = long.Parse(Console.ReadLine());
            Console.Write("Uuden asiakkaan etunimi: ");
            newCustomer.Firstname = Console.ReadLine();
            Console.Write("Uuden asiakkaan sukunimi: ");
            newCustomer.Lastname = Console.ReadLine();

            customerRepositories.CreateCustomer(newCustomer);

            Account newAccount = new Account();
            newAccount.BankId = newCustomer.BankId;
            newAccount.CustomerId = newCustomer.Id;
            Console.Write("Syötä uuden tilin IBAN: ");
            newAccount.IBAN = Console.ReadLine();
            Console.Write("Syötä uuden tilin nimi: ");
            newAccount.Name = Console.ReadLine();

            accountRepositories.CreateAccount(newAccount);
        }

        static void PrintAccountsByBankId()
        {
            Console.Write("Stötä pankin Id, jonka tilit tahdot tulostaa: ");
            long bankId = long.Parse(Console.ReadLine());
            var accountList = accountRepositories.GetAccounts();
            foreach (var account in accountList)
            {
                if (account.BankId == bankId)
                {
                    Console.WriteLine(account.IBAN);
                }
            }
        }

        static void PrintAccountsByCustomerId()
        {
            var accountList = accountRepositories.GetAccounts();
            Console.Write("Syötä asiakkaan Id, jonka tilit tahdot listata: ");
            long id = long.Parse(Console.ReadLine());

            foreach (var account in accountList)
            {
                if (account.CustomerId == id)
                {
                    Console.WriteLine($"{account.IBAN} {account.Name} {account.Balance}");
                }
            }
        }

        static void PrintTransactionsByCustomerId()
        {
            var transactionList = transactionRepositories.GetTransactions();
            var accountList = accountRepositories.GetAccounts();
            Console.Write("Syötä asiakkaan Id, jonka tilitapahtumat haluat listata: ");
            long id = long.Parse(Console.ReadLine());

            foreach (var transaction in transactionList)
            {
                foreach (var account in accountList)
                {
                    if (transaction.IBAN == account.IBAN)
                    {
                        Console.WriteLine($"{transaction.Amount} {transaction.TimeStamp}");
                    }
                }
            }
        }

        static void CreateTransactionForCustomer()
        {
            Transaction newTransaction = new Transaction();
            Console.Write($"Syötä asiakkaan Id, jolle haluat luoda uuden tilitapahtuman: ");
            long id = long.Parse(Console.ReadLine());
            var account = accountRepositories.GetAccountById(id);
            newTransaction.IBAN = account.IBAN;
            Console.Write("Syötä tilitapahtuman summa tai erotus: ");
            newTransaction.Amount = decimal.Parse(Console.ReadLine());

            account.Balance += newTransaction.Amount;

            transactionRepositories.CreateTransaction(newTransaction);
        }
    }
}
