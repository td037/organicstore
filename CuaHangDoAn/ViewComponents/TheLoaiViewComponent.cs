using CuaHangDoAn.Data;
using CuaHangDoAn.Models;
using Microsoft.AspNetCore.Mvc;

namespace CuaHangDoAn.ViewComponents
{
    public class TheLoaiViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;

        public TheLoaiViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }


        public IViewComponentResult Invoke()
        {
            // lấy danh sách các thể loại
            //var theloai = _db.TheLoai.ToList();
            IEnumerable<TheLoai> theloai = _db.TheLoai.ToList();
            return View(theloai);
        }


    }
}
