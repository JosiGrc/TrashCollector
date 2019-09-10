using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        //Variables

        //Ctor
        [Key]
       
        public int Id { get; set; }//add balance that would be a double

        [Display( Name = "First Name")]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Display(Name = "Address")]
        public string address { get; set; }

        [Display(Name = "Zipcode")]
        public int zipcode { get; set; }

        [Display(Name = "State")]
        public string state { get; set; }

        [Display(Name = "E-Mail")]
        public string email { get; set; }

        [Display(Name = "Balance")]
        public double balance { get; set; }

        [Display(Name = "Pickup Date")]
        public string pickUpdate { get; set; }

        [Display(Name = "Suspend Pickup Date")]
        public string suspendPickup { get; set; }

        [Display(Name = "Additional Pickups")]
        public string additionalPickup { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public enum DayOfWeek { };



        //Methods
    }
}