using CuaHangDoAn.Data;
using CuaHangDoAn.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace CuaHangDoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SanPhamController : Controller
    {
        private readonly ApplicationDbContext _db;
        //private IEnumerable<object> files;

        public SanPhamController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Models.SanPham> sanpham = _db.SanPham.Include("TheLoai").ToList();
            return View(sanpham);
        }

        [HttpGet]   //lấy dữ liệu và hiển thị
        public IActionResult Upsert(int id)
        {
            Models.SanPham sanpham = new Models.SanPham();
            IEnumerable<SelectListItem> dstheloai = _db.TheLoai.Select(
                item => new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                });
            ViewBag.DSTheLoai = dstheloai;
            if (id == 0) // creat/insert
            {
                return View(sanpham);
            }
            else //edit/update
            {
                sanpham = _db.SanPham.Include("TheLoai").FirstOrDefault(sp => sp.Id == id);
                return View(sanpham);
            }
        }

        [HttpPost]
        public IActionResult Upsert(SanPham sanpham)
        {
            if(ModelState.IsValid)
            {
                if(sanpham.Id == 0)
                {
                    _db.SanPham.Add(sanpham);
                }
                else
                {
                    _db.SanPham.Update(sanpham);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();

            /* if (ModelState.IsValid)
             {
                 // Thêm sản phẩm vào cơ sở dữ liệu
                 if (sanpham.Id == 0)
                 {
                     _db.SanPham.Add(sanpham);
                 }
                 else
                 {
                     _db.SanPham.Update(sanpham);
                 }

                 // Lưu trữ danh sách hình ảnh
                 foreach (var file in files)
                 {
                     if (file != null)
                     {
                         var fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}";
                         var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                         using (var stream = new FileStream(path, FileMode.Create))
                         {
                             file.CopyTo(stream);
                         }

                         var image = new Image 
                         {
                             FileName = fileName,
                             SanPhamId = sanpham.Id
                         };

                         _db.Image.Add(image);
                     }
                 }

                 _db.SaveChanges();
                 return RedirectToAction("Index");
             }
           
            // Handle validation errors
            return View();
             */
        }
        [HttpPost]
public IActionResult Delete(int id)
{
 var sanpham = _db.SanPham.FirstOrDefault(sp => sp.Id == id);
 if (sanpham == null)
 {
     return NotFound();
 }
 _db.SanPham.Remove(sanpham);
 _db.SaveChanges();
 return Json(new { success = true });
}

[HttpGet]
public IActionResult Details(int id)
{
 if (id == 0)
 {
     return NotFound();
 }
 var sanpham = _db.SanPham.Find(id);
 return View(sanpham);
}

[HttpPost] //giử dl lên controll
public IActionResult Details(Models.SanPham sanpham)
{
 if (ModelState.IsValid)
 {
     _db.SanPham.Add(sanpham);
     _db.SaveChanges();
     return RedirectToAction("Index");
 }
 return View();
}

public IActionResult KiemTra()
{
 return View();
}


[HttpGet]
public IActionResult Upload()
{
 return View();
}

/*[HttpPost]
public IActionResult Upload(Image image, IFormFile file)
{
if (file != null)
 {
      //Lưu trữ hình ảnh trên máy chủ
     var fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}";
     var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", fileName);

     using (var stream = new FileStream(path, FileMode.Create))
     {
        file.CopyTo(stream);
   }

   //   Lưu thông tin hình ảnh vào cơ sở dữ liệu
     image.FileName = fileName;
     _db.Image.Add(image);
    _db.SaveChanges();
 }

 return RedirectToAction("Index");
}
*/
}
}
