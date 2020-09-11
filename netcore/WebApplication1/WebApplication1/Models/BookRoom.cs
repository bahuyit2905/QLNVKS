using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class BookRoom
    {
        [Key]
        public int BookRoomId { get; set; }
        [Required(ErrorMessage = "Bạn cần phải nhập")]
        [Column(TypeName = "varchar(150)")]
        [Display(Name = "FullName")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "FromDate")]
        public DateTime FromDate { get; set; }
        [Required]
        [Display(Name = "NumberPeople")]
        public int NumberPeople { get; set; }
        [Required]
        [Display(Name = "TelePhone")]
        public int TelePhone { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}
