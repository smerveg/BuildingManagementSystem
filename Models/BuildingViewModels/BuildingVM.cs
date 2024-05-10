using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingManagementSystem.ConsumeApi.Models.BuildingViewModels
{
    public class BuildingVM
    {
        [DisplayName("ID")]
        public int BuildingID { get; set; }
        [DisplayName("İsim")]
        [Required(ErrorMessage ="Lütfen bina ismini giriniz.")]
        public string Name { get; set; }
        [DisplayName("Özellikler")]
        public string Properties { get; set; }
    }
}
