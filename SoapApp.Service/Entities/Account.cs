using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SoapApp.Service.Entities
{
    public class Account
    {
        [Key]
        public Guid ID { get; set; }

        [ForeignKey("Customer")]
        public Guid CustomerID { get; set; }
        public string IBAN { get; set; }
        public float Balance { get; set; }


        public Customer Customer { get; set; }
    }
}