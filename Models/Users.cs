using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Combine.Models
{
    public class Users{
        public int id {get;set;}
        public string first_name {get;set;}

        public string last_name {get;set;}
        public string email {get;set;}
        public string password {get;set;}
    }
}