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
        [Required(ErrorMessage = "*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Subject { get; set; }

        [Required(ErrorMessage = "*")]
        [UIHint("Multilinetext")]
        public string Message { get; set; }
    }
}