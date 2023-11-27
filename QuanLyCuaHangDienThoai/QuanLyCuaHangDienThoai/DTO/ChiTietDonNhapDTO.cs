using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDienThoai.DTO
{
    internal class ChiTietDonNhapDTO
    {
        private int maDN;
        private string maSP;
        private long donGia;
        private int soLuong;

        public ChiTietDonNhapDTO(int maDN, string maSP, long donGia, int soLuong)
        {
            this.maDN = maDN;
            this.maSP = maSP;
            this.donGia = donGia;
            this.soLuong = soLuong;
        }

        public int MaDN { get => maDN; set => maDN = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        public long DonGia { get => donGia; set => donGia = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
    }
}
