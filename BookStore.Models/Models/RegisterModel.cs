using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Models
{
    public class RegisterModel
    {
       
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "E-mail is not valid")]
        //[EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public int Roleid { get; set; }

    }
}
