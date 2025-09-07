using CuaHangDoAn.Data;
using CuaHangDoAn.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CuaHangDoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class DonHangController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DonHangController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<HoaDon> hoadon = _db.HoaDon.Include("ApplicationUser").ToList();
            return View(hoadon);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var hd = _db.HoaDon.Find(id);
            return View(hd);
        }

        [HttpPost] //giử dl lên controll
        public IActionResult Details(Models.HoaDon hd)
        {
            if (ModelState.IsValid)
            {
                _db.Add(hd);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult ChiTietHoaDon(int hoadonid)
        {
            //IEnumerable<ChiTietHoaDon> cthd = _db.ChiTietHoaDon.Include("ApplicationUser").ToList();
            IEnumerable<ChiTietHoaDon> cthd = _db.ChiTietHoaDon.Include("SanPham").Where(x => x.HoaDonId == hoadonid).ToList();
            return View(cthd);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var hoadon = _db.SanPham.FirstOrDefault(hd => hd.Id == id);
            if (hoadon == null)
            {
                return NotFound();
            }
            _db.SanPham.Remove(hoadon);
            _db.SaveChanges();
            return Json(new { success = true });
        }
    }
}
