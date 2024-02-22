using SoapApp.Service.Context;
using SoapApp.Service.Entities;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace SoapApp.Service.Business
{
    public class AtmOperationBusiness
    {
        public bool WithDrawMoney(string IBAN, float amount)
        {
            if (string.IsNullOrEmpty(IBAN) || amount < 1)
                return false;

            using (var atm = new AtmContext())
            {
                var account = atm.Accounts.FirstOrDefault(x => x.IBAN == IBAN);
                if (account.Balance < amount)
                    return false;

                account.Balance-=amount;
                atm.Entry(account).State = System.Data.Entity.EntityState.Modified;
                atm.SaveChanges();
                return true;
            }

        }


        public bool DepositMoney(string IBAN , float amount)
        {
            if (string.IsNullOrEmpty(IBAN) || amount < 1)
                return false;

            using (var atm = new AtmContext())
            {
                var account = atm.Accounts.FirstOrDefault(x => x.IBAN == IBAN);
                if (account is null)
                    return false;

                account.Balance += amount;
                atm.Entry(account).State = System.Data.Entity.EntityState.Modified;
                atm.SaveChanges();
                return true;
            }
        }


        public bool EFT(string senderIBAN, string recipientIBAN, float amount)
        {
            if (string.IsNullOrEmpty(senderIBAN) || string.IsNullOrEmpty(recipientIBAN) || amount < 1)
                return false;

            using (var atm = new AtmContext())
            {
                using (var transaction = atm.Database.BeginTransaction())
                {
                    try
                    {
                        var senderAccount = atm.Accounts.FirstOrDefault(x => x.IBAN == senderIBAN);
                        var recipientAccount = atm.Accounts.FirstOrDefault(x=>x.IBAN == recipientIBAN);

                        if (senderAccount is null || recipientAccount is null)
                            return false;

                        if (senderAccount.Balance < amount)
                            return false;

                        senderAccount.Balance -= amount;
                        recipientAccount.Balance += amount;

                        atm.Entry(senderAccount).State = System.Data.Entity.EntityState.Modified;
                        atm.Entry(recipientAccount).State = System.Data.Entity.EntityState.Modified;

                        atm.SaveChanges();

                        return true;
                    }
                    catch 
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }


        public bool SaveCustomer(string ID,string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                return false;

            using (var atm = new AtmContext())
            {
                var customer = new Customer()
                {
                    ID = Guid.Parse(ID),
                    FirstName = firstName,
                    LastName = lastName
                };

                atm.Customers.Add(customer);
                atm.SaveChanges();
                return true;
            }
        }


        public bool OpenAnAccount(string id ,string customerId, string IBAN, float balance)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(customerId) || string.IsNullOrEmpty(IBAN) || balance < 0)
                return false;

            using (var atm = new AtmContext())
            {
                var user = atm.Customers.FirstOrDefault(x => x.ID.ToString() == customerId);
                if (user is null)
                    return false;

                var account = new Account()
                {
                    ID = Guid.Parse(id),
                    CustomerID = Guid.Parse(customerId),
                    IBAN = IBAN,
                    Balance = balance
                };

                atm.Accounts.Add(account);
                atm.SaveChanges();

                return true;
            }
        }

    }
}