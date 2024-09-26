using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelier.DTOLayer.DTOS.RoomDTO
{
    public class AddRoomDTO
    {
        [Required(ErrorMessage = "Lütfen Oda Numaranızı Giriniz.")]
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }
        [Required(ErrorMessage ="Lütfen Fiyat Giriniz.")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Lütfen Oda Başlığını Giriniz.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Lütfen Yatak Sayısını Giriniz.")]
        public string BedCount { get; set; }
        [Required(ErrorMessage = "Lütfen Banyo Sayısını Giriniz.")]
        public string BathCount { get; set; }
        
        public string Wifi { get; set; }
        public string Description { get; set; }

    }
}
