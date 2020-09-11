using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.ViewModels
{
    public class HomeCreateViewModel
    {
        [Required(ErrorMessage = "Bạn cần phải nhập")]
        [MaxLength(20, ErrorMessage = "Can not excced 20 characters")]
        public string Fullname { get; set; }
        [Required]
        [Display(Name = "Office Email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [Required]
        public Dept? Department { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
