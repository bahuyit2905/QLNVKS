using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class HotelRoomsCreateViewModel
    {
        [Required]
        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Name Room")]
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Amount { get; set; }
        public string Acreage { get; set; }
        public IFormFile Images { get; set; } 
        public string urlImages { get; set; }
    }
}
