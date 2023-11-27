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
    internal class DonNhapBUS
    {
        DonNhapDAO dn = new DonNhapDAO();
        public DataTable LayDSDonNhap()
        {
            return dn.LayDSDonNhap();
        }
        public DataTable LayDataCB(string ma, string table)
        {
            return dn.LayDataCB(ma, table);
        }
        public bool KiemTraNhaCungCap(string mancc)
        {
            return dn.KiemTraNhaCungCap(mancc);
        }
        public void themDonNhap(DonNhapDTO cc)
        {
            dn.ThemDonNhap(cc);
        }
        public void suaDonNhap(DonNhapDTO cc)
        {
            dn.CapNhatDonNhap(cc);
        }
        public void xoaDonNhap(int cc)
        {
            dn.XoaDonNhap(cc);
        }
        public DataTable TimDonNhap(string lable, int value)
        {
            return dn.TimDonNhap(lable, value);
        }
    }
}
