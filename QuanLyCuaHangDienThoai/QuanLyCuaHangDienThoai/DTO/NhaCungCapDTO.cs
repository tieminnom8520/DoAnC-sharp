using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDienThoai.DTO
{
    internal class NhaCungCapDTO
    {
        private string maNCC;
        private string tenNCC;
        private string diaChi;
        private string sdt;

        public NhaCungCapDTO(string maNCC, string tenNCC, string diaChi, string sdt)
        {
            this.maNCC = maNCC;
            this.tenNCC = tenNCC;
            this.diaChi = diaChi;
            this.sdt = sdt;
        }

        public string MaNCC { get => maNCC; set => maNCC = value; }
        public string TenNCC { get => tenNCC; set => tenNCC = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
    }
}
