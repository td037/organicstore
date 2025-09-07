using CuaHangDoAn.Data;
using CuaHangDoAn.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace CuaHangDoAn.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            List<Models.SanPham> sanpham = _db.SanPham.Include("TheLoai").ToList();
            return View(sanpham);
        }

        public IActionResult shopingCart()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Detail(int sanphamId)
        {
            //tao gio hang o trang detail them gio hang
            GioHang giohang = new GioHang()
            {
                SanPhamId = sanphamId,
                SanPham = _db.SanPham.Include("TheLoai").FirstOrDefault(sp => sp.Id == sanphamId),
                Quantity = 1
            };
            return View(giohang);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Detail(GioHang giohang)
        {
           
                //Lấy thông tin tài khoản đang đăng nhập
                var identity = (ClaimsIdentity)User.Identity;
                var claim = identity.FindFirst(ClaimTypes.NameIdentifier);

                //Đưa thông tin tài khoản vào giỏ hàng
                giohang.ApplicationUserId = claim.Value;     
            
            //Kiem tra gio hang co trong san pham ch
                var giohangdb =_db.GioHang.FirstOrDefault(sp => sp.SanPhamId == giohang.SanPhamId && 
                sp.ApplicationUserId == giohang.ApplicationUserId );

            if ( giohangdb == null )
            {
                //them sp vao gio
                _db.GioHang.Add(giohang);
            }
            else// neu khong tim thay sp
            {
                giohangdb.Quantity += giohang.Quantity;
            }

                  
                //Thêm thông tin giỏ hàng vào CSDL
                _db.SaveChanges();

                return RedirectToAction("Index");           
        }




        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult Grid()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult BlogDetail()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}