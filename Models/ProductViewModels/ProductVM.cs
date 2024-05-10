using BuildingManagementSystem.ConsumeApi.Models.StorageViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingManagementSystem.ConsumeApi.Models.ProductViewModels
{
    public class ProductVM
    {
        [DisplayName("ID")]
        public int ProductID { get; set; }
        [DisplayName("İsim")]
        [Required(ErrorMessage ="Lütfen ürün adını giriniz.")]
        public string Name { get; set; }

        [DisplayName("Özellikler")]
        public string Description { get; set; }
        [DisplayName("StorageID")]
        [Required(ErrorMessage = "Lütfen bir depo seçiniz.")]
        public int StorageID { get; set; }
        [DisplayName("Depo")]       
        public string StorageName { get; set; }
        public List<StorageVM> Storages { get; set; }
        [DisplayName("Miktar")]
        [Range(0, int.MaxValue, ErrorMessage = "Lütfen geçerli bir sayı giriniz.")]
        public int Quantity { get; set; }
    }
}
