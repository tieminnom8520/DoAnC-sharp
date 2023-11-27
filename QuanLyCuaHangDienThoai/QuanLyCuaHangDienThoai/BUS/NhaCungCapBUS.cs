using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangDienThoai.DAO;
using QuanLyCuaHangDienThoai.DTO;

namespace QuanLyCuaHangDienThoai.BUS
{
    internal class NhaCungCap_BUS
    {
        NhaCungCap_DAO ncc = new NhaCungCap_DAO();
        public DataTable LayDSNhaCungCap()
        {
            return ncc.LayDSNhaCungCap();
        }
        public void themNhaCungCap(NhaCungCapDTO cc)
        {
            ncc.ThemNhaCungCap(cc);
        }
        public void suaNhaCungCap(NhaCungCapDTO cc)
        {
            ncc.CapNhatNhaCungCap(cc);
        }
        public void xoaNhaCungCap(int cc)
        {
            ncc.XoaNhaCungCap(cc);
        }
        public void KhoiPhucNhaCungCap(string tencc)
        {
            ncc.KhoiPhucNhaCungCap(tencc);
        }
        public DataTable TimChiTietDonNhap(string tencc)
        {
            return ncc.TimKiemNhaCungCap(tencc);
        }
        public bool KiemTraThamChieu(string mancc)
        {
            return ncc.KiemTraThamChieu(mancc);
        }
        public bool KiemTraTonTai(string tencc)
        {
            return ncc.KiemTraTonTai(tencc);
        }
    }
}
