using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrjD1FW.Models
{
    public class company
    {


        [DataType(DataType.Text)]
        [Display(Name = "Company Name")]
        public string Username { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Street")]
        public string Street { get; set; }

        [DataType(DataType.PostalCode)]
        [Display(Name = "PostalCode")]
        public string zip { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "city")]
        public string city { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string tele { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Fax Number")]
        public string fax { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "FK_creator")]
        public int FK_creator { get; set; }

    }
}