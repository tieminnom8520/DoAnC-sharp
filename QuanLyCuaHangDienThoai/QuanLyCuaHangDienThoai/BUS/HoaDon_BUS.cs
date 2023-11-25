using System;
using System.Data;
using System.Drawing;

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
        public DataTable layDanhSachHoaDon(bool sort)
        {
            string sql;
            if (sort)
            {
                sql = "select H.MAHD, K.TENKH, N.TENNV, H.NGAYLAP, H.DIACHIGIAO, H.TONGTIEN, H.TRANGTHAI, H.MAKH, H.MANV from HoaDon H, KhachHang K, NhanVien N where H.MANV = N.MANV and H.MAKH = K.MAKH order by TRANGTHAI";
            }
            else
            {
                sql = "select H.MAHD, K.TENKH, N.TENNV, H.NGAYLAP, H.DIACHIGIAO, H.TONGTIEN, H.TRANGTHAI, H.MAKH, H.MANV from HoaDon H, KhachHang K, NhanVien N where H.MANV = N.MANV and H.MAKH = K.MAKH";
            }
            return db.Execute(sql);
        }
        public DataTable timHoaDon(string ten, bool sort)
        {
            string sql;
            if (sort)
            {
                sql = String.Format("select H.MAHD, K.TENKH, N.TENNV, H.NGAYLAP, H.DIACHIGIAO, H.TONGTIEN, H.TRANGTHAI, H.MAKH, H.MANV from HoaDon H, KhachHang K, NhanVien N where H.MANV = N.MANV and H.MAKH = K.MAKH and TENKH like N'%{0}%' order by TRANGTHAI", ten);
            }
            else
            {
                sql = String.Format("select H.MAHD, K.TENKH, N.TENNV, H.NGAYLAP, H.DIACHIGIAO, H.TONGTIEN, H.TRANGTHAI, H.MAKH, H.MANV from HoaDon H, KhachHang K, NhanVien N where H.MANV = N.MANV and H.MAKH = K.MAKH and TENKH like N'%{0}%'", ten);
            }    
            return db.Execute(sql);
        }
        public void suaHoaDon(string ma)
        {
            string sql = String.Format("update HOADON set TRANGTHAI = 1 where MAHD = {0}", Int32.Parse(ma));
            db.ExecuteNonQuery(sql);
        }
    }
}
