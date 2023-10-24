using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDienThoai.DTO
{
    internal class ChiTietKhuyenMaiDTO
    {
        private string maKM;
        private string maSP;
        private int phanTram;

        public ChiTietKhuyenMaiDTO(string maKM, string maSP, int phanTram)
        {
            this.maKM = maKM;
            this.maSP = maSP;
            this.phanTram = phanTram;
        }

        public string MaKM { get => maKM; set => maKM = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        public int PhanTram { get => phanTram; set => phanTram = value; }
    }
}
