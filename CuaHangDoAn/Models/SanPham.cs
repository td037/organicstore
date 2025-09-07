using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace CuaHangDoAn.Models
{
    public class SanPham
    {
        [Key]
        public int Id { get; set; } //ma sp
        [Required]
        public string? Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string? Description { get; set; }
        //public string? ImageUrl { get; set; } // hinh anh sp
        public string? ImageUrl { get; set; }
      //  [ValidateNever]
       // public List<Image> Images { get; set; } // Danh sách hình ảnh liên kết với sản phẩm
       [Required]
        public int TheLoaiId { get; set; }
        [ForeignKey("TheLoaiId")]
        [ValidateNever]
        public TheLoai TheLoai { get; set; }

        //[Required]
        //public int NCCId { get; set; }
        //[ForeignKey("NCCId")]
        //[ValidateNever]
        //public NhaCungCap NhaCungCap { get; set; }
    }
}
