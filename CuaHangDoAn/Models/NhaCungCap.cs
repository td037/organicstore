using System.ComponentModel.DataAnnotations;

namespace CuaHangDoAn.Models
{
    public class NhaCungCap
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Khong duoc de trong Nha cung cap!")]
        [Display(Name = "Nha Cung Cap")]


        public string? Name { get; set; }
        public string? Address { get; set; }
        [Required(ErrorMessage = "Khong dung dinh dang địa chỉ!")]
        [Display(Name = "đia chỉ")]
        public string? SDT { get; set; }
    }
}
