using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Bạn cần phải nhập")]
        [MaxLength(20, ErrorMessage ="Can not excced 20 characters")]
        public string Fullname { get; set; } 
        [Required]
        [Display(Name ="Office Email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage ="Invalid email format")] 
        public string Email { get; set; }
        [Required]
        public Dept? Department { get; set; }
        public string AvatarPath { get; set; }
      

        public override string ToString()
        {
            return $"Id : {Id}, Fullname:{Fullname}, Email: {Email} " + $"Department: {Department}, AvatarPath: {AvatarPath}";
        }
    }
    
}

