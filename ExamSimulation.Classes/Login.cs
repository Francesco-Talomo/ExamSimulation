using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSimulation.Classes
{
    public class Login
    {
        [Required(ErrorMessage = "Email is required.")]
        [Display(Name = "Email : ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [Display(Name = "Password : ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}