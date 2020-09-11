using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class HotelRoom
    {
        [Key]
        public int HotelRoomId { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(250)")]
        [Display(Name = "Name Room")]
        public string FullName { get; set; }
        public string Images { get; set; }
        public int Amount { get; set; }
        public string Acreage { get; set; }

    }
}
