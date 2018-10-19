using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Combine.Models
{
    public class UserViewModel{
        public int id {get;set;}

        [Required(ErrorMessage = "Please type your first name")]
        [MinLength(2)]
        [RegularExpression("^[a-zA-Z]+$",ErrorMessage = "Letter only")]
        public string first_name {get;set;}

        [Required(ErrorMessage = "Please type your last name")]
        [MinLength(2)]
        [RegularExpression("^[a-zA-Z]+$",ErrorMessage = "Letter only")]
        public string last_name {get;set;}

        [Required(ErrorMessage = "Please type your email")]
        [EmailAddress]
        public string email {get;set;}
        
        [Required (ErrorMessage = "Please type your password")]
        [MinLength(8)]
        public string password {get;set;}
        public string confirm_password {get;set;}

    }
}