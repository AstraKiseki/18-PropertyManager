using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyManager.Api.Models
{
    public class RegistrationModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "The {0} password must be at least {2} characters long", MinimumLength =8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Comfirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmed password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}