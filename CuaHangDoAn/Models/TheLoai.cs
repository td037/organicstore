using System.ComponentModel.DataAnnotations;

namespace CuaHangDoAn.Models
{
    public class TheLoai
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Khong duoc de trong the loai!")]
        [Display(Name = "the loai")]

        public string? Name { get; set; }
        [Required(ErrorMessage = "Khong dung dinh dang ngay!")]
        [Display(Name = "Ngay tao")]
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
