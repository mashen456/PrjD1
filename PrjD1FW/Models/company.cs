using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrjD1FW.Models
{
    public class company
    {


        [DataType(DataType.DateTime)]
        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "\"{0}\" muss mind. {2} Zeichen lang sein.", MinimumLength = 6)]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "\"{0}\" muss mind. {2} Zeichen lang sein.", MinimumLength = 6)]
        [Display(Name = "Street")]
        public string Street { get; set; }

        [DataType(DataType.PostalCode)]
        [StringLength(100, ErrorMessage = "\"{0}\" muss mind. {2} Zeichen lang sein.", MinimumLength = 4)]
        [Display(Name = "PostalCode")]
        public string zip { get; set; }

        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "\"{0}\" muss mind. {2} Zeichen lang sein.", MinimumLength = 2)]
        [Display(Name = "city")]
        public string city { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(100, ErrorMessage = "\"{0}\" muss mind. {2} Zeichen lang sein.", MinimumLength = 4)]
        [Display(Name = "Phone Number")]
        public string tele { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(100, ErrorMessage = "\"{0}\" muss mind. {2} Zeichen lang sein.", MinimumLength = 4)]
        [Display(Name = "Fax Number")]
        public string fax { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "FK_creator")]
        public int FK_creator { get; set; }

    }
}