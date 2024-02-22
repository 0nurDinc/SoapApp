using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoapApp.Service.Entities
{
    public class Customer
    {
        [Key]
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}