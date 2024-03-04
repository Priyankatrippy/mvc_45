using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAppfinalMvcMarch3.Models
{
    public class Logins
    {
        [Display(Name ="User Name")]
        public string UserName {  get; set; }
        [Display(Name = "Password")]
        public string UserPassword { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}