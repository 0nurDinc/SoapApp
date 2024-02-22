using SoapApp.Service.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SoapApp.Service
{
    /// <summary>
    /// Summary description for AtmServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AtmServices : System.Web.Services.WebService
    {
        private AtmOperationBusiness atmOperation = new AtmOperationBusiness();

        [WebMethod]
        public bool WithDrawMoney(string IBAN, float amount)
        {
            return atmOperation.WithDrawMoney(IBAN, amount);
        }

        [WebMethod]
        public bool DepositMoney(string IBAN, float amount)
        {
            return atmOperation.DepositMoney(IBAN, amount);
        }

        [WebMethod]
        public bool EFT(string senderIBAN, string recipientIBAN, float amount)
        {
            return atmOperation.EFT(senderIBAN, recipientIBAN, amount);
        }

        [WebMethod]
        public bool SaveCustomer(string ID, string firstName, string lastName)
        {
            return atmOperation.SaveCustomer(ID, firstName, lastName);
        }


        [WebMethod]
        public bool OpenAnAccount(string id, string customerId, string IBAN, float balance)
        {
            return atmOperation.OpenAnAccount(id, customerId, IBAN, balance);
        }
    }
}

 

    
     

    
  