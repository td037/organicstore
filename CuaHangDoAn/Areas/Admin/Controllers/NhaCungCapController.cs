using CuaHangDoAn.Data;
using CuaHangDoAn.Models;
using Microsoft.AspNetCore.Mvc;

namespace CuaHangDoAn.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class NhaCungCapController : Controller
    {
        private readonly ApplicationDbContext _db;
        public NhaCungCapController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var nhacungcap = _db.NhaCungCap.ToList();
            ViewBag.NhaCungCap = nhacungcap;
            return View();
        }

        [HttpPost] //giử dl lên controll
        public IActionResult Creat(NhaCungCap nhacungcap)
        {
            /* _db.NhaCungCap.Add(nhacungcap);
             _db.SaveChanges();
             return RedirectToAction("Index");*/
            if (ModelState.IsValid)
            {
                _db.NhaCungCap.Add(nhacungcap);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]//lấy dl và hiển thị lên trang tạo đi
        public IActionResult Creat()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var nhacungcap = _db.NhaCungCap.Find(id);
            return View(nhacungcap);
        }

        [HttpPost]
        public IActionResult Edit(NhaCungCap nhacungcap)
        {
            if (ModelState.IsValid)
            {
                _db.NhaCungCap.Update(nhacungcap);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var nhacungcap = _db.NhaCungCap.Find(id);
            return View(nhacungcap);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var nhacungcap = _db.NhaCungCap.Find(id);
            if (nhacungcap == null)
            {
                return NotFound();
            }
            _db.NhaCungCap.Remove(nhacungcap);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var nhacungcap = _db.NhaCungCap.Find(id);
            return View(nhacungcap);
        }

        [HttpPost]
        public IActionResult Details(NhaCungCap nhacungcap)
        {
            if (ModelState.IsValid)
            {
                _db.NhaCungCap.Update(nhacungcap);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
