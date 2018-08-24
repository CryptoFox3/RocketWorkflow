using System;
using System.Collections.Generic;
using System.Linq;
    using System.ComponentModel.DataAnnotations;
using System.Web;

namespace RocketWorkflow.Models
{
    
        public class EmailFormModel
        {
            [Required, Display(Name = "Your name")]
            public string FromName { get; set; }
            [Required, Display(Name = "Your email"), EmailAddress]
            public string FromEmail { get; set; }
            [Required]
            public string Message { get; set; }
            public string RecipientEmail { get; set; }
    }
    
}