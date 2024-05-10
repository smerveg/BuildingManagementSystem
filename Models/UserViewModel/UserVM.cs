using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingManagementSystem.ConsumeApi.Models.UserViewModel
{
    public class UserVM
    {
        //public int UserID { get; set; }
        [Required(ErrorMessage ="Lütfen kullanıcı adını giriniz.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen şifre giriniz.")]
        public string Password { get; set; }
    }
}
