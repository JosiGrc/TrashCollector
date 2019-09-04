using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        //Variables
        [Key]
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public int zipcode { get; set; }
        public string state { get; set; }
        public int phoneNumber { get; set; }
        //Ctor

        //Methods
    }
}