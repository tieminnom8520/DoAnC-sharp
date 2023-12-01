using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDienThoai.DTO
{
    internal class TaiKhoanDTO
    {
        private string maTK;
        private string maNV;
        private string username;
        private string password;
        private string tinhTrang;
        public TaiKhoanDTO(string maTK, string maNV, string username, string password, string tinhTrang)
        {
            this.maTK = maTK;
            this.maNV = maNV;
            this.username = username;
            this.password = password;
            this.tinhTrang = tinhTrang;
        }

        public string MaTK { get => maTK; set => maTK = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
    } 
}
