namespace CuaHangDoAn.Models
{
    public class GioHangViewModel
    {
        // luu tru sp trong gio
        public IEnumerable<GioHang> DsGioHang { get; set; }
        // luu tru tong tien
        public HoaDon HoaDon { get; set; }
    }
}
