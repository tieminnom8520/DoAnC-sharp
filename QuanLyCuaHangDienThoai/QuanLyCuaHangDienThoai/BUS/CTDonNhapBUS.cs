using QuanLyCuaHangDienThoai.DTO;
using QuanLyCuaHangDienThoai.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDienThoai.BUS
{
    internal class CTDonNhapBUS
    {
        CTDonNhapDAO dn = new CTDonNhapDAO();
        public DataTable LayDSChiTietDonNhap(int madn)
        {
            return dn.LayDSChiTietDonNhap(madn);
        }
        public DataTable LayDataCB(string ma, string table)
        {
            return dn.LayDataCB(ma, table);
        }
        public bool KiemTraSanPham(string maSP)
        {
            return dn.KiemTraSanPham(maSP);
        }
        public void themCTDonNhap(ChiTietDonNhapDTO cc)
        {
            dn.ThemCTDonNhap(cc);
        }
        public void suaCTDonNhap(ChiTietDonNhapDTO cc)
        {
            dn.CapNhatCTDonNhap(cc);
        }
        public void xoaCTDonNhap(int cc)
        {
            dn.XoaCTDonNhap(cc);
        }
        public DataTable TimChiTietDonNhap(int madn, int masp)
        {
            return dn.TimKiemChiTietDonNhap(madn, masp);
        }
    }
}
