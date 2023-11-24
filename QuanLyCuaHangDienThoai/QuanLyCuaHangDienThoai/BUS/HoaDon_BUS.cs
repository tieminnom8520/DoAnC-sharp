using System;
using System.Data;

namespace QuanLyCuaHangDienThoai.BUS
{
    internal class HoaDon_BUS
    {
        Database db;
        public HoaDon_BUS()
        {
            db = new Database();
        }
        public DataTable layDanhSachSanPham()
        {
            string sql = "select MASP, TENSP, HANG, DONGIA, SOLUONG  from SanPham";
            return db.Execute(sql);
        }
        public DataTable layDanhSachKhachHang()
        {
            string sql = "select MAKH, TENKH from KhachHang";
            return db.Execute(sql);
        }
        public DataTable timKiemSanPham(string ten)
        {
            string sql = String.Format("select MASP, TENSP, HANG, DONGIA, SOLUONG  from SanPham where TENSP like N'%{0}%'", ten);
            return db.Execute(sql);
        }

    }
}
