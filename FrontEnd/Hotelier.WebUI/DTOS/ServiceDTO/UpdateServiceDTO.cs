﻿using System.ComponentModel.DataAnnotations;

namespace Hotelier.WebUI.DTOS.ServiceDTO
{
    public class UpdateServiceDTO
    {
        public int ServiceID { get; set; }
        [Required(ErrorMessage = "Hizmet ikon linki giriniz...")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Hizmet başlığı giriniz...")]
        [StringLength(100, ErrorMessage = "Hizmet başlığı maks 100 karakter olmalıdır...")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Hizmet açıklaması giriniz...")]
        [StringLength(500, ErrorMessage = "Hizmet başlığı maks 500 karakter olmalıdır...")]
        public string Description { get; set; }
    }
}
