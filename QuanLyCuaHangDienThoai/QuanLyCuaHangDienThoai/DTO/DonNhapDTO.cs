using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDienThoai.DTO
{
    internal class DonNhapDTO
    {
        private string maDN;
        private string maNCC;
        private string maNV;
        private long tongTien;
        private DateTime ngayNhap;

        public DonNhapDTO(string maDN, string maNCC, string maNV, long tongTien, DateTime ngayNhap)
        {
            this.maDN = maDN;
            this.maNCC = maNCC;
            this.maNV = maNV;
            this.tongTien = tongTien;
            this.ngayNhap = ngayNhap;
        }

        public string MaDN { get => maDN; set => maDN = value; }
        public string MaNCC { get => maNCC; set => maNCC = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public long TongTien { get => tongTien; set => tongTien = value; }
        public DateTime NgayNhap { get => ngayNhap; set => ngayNhap = value; }
    }
}
