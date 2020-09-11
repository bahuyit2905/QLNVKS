using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.ViewModels
{
    public class HomeEditViewModel : HomeCreateViewModel
    {
        public int Id { get; set; }
        public string AvatarPath { get; set; }

    }
}
