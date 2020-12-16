using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;//allows for MetaData to be used

namespace StoreFront.UI.MVC.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "* Please enter a Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "* Please enter an Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Subject { get; set; }

        [Required(ErrorMessage = "* Please enter a Message")]
        [UIHint("Multilinetext")]
        public string Message { get; set; }
    }
}