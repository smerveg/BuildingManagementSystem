

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingManagementSystem.ConsumeApi.Models.RoomViewModels
{
    public class RoomVM
    {
        [DisplayName("ID")]
        public int RoomID { get; set; }
        [DisplayName("İsim")]
        [Required(ErrorMessage = "Lütfen oda adını giriniz.")]
        public string Name { get; set; }
        [DisplayName("Kat No")]
        [Range(0, int.MaxValue, ErrorMessage = "Lütfen geçerli bir sayı giriniz.")]
        public int Floor { get; set; }
        [DisplayName("Özellikler")]
        public string Properties { get; set; }
        [DisplayName("BuildingID")]
        [Required(ErrorMessage = "Lütfen bir bina seçiniz.")]
        public int BuildingID { get; set; }
        [DisplayName("Bina")]
        public string BuildingName { get; set; }

    }
}
