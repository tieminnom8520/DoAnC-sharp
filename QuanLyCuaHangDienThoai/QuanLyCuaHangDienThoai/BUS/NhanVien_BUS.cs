using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyCuaHangDienThoai.BUS
{
    internal class NhanVien_BUS
    {
        Database db;
        public NhanVien_BUS()
        {
            db = new Database();
        }
        public DataTable layDanhSachTenNhanVien()
        {
            string sql = "Select TENNV from NHANVIEN";
            return db.Execute(sql);
        }
        public DataTable layDanhSachNhanVien()
        {
            string sql = "Select * from NHANVIEN";
            return db.Execute(sql);
        }
        public DataRow layThongTinNhanVien(string tenNV)
        {
            // Lưu ý: Bạn cần thay đổi câu truy vấn và thực hiện kết nối cơ sở dữ liệu tương ứng
            string sql = $"SELECT * FROM NHANVIEN WHERE TENNV = N'{tenNV}'";

            DataTable dt = db.Execute(sql);

            // Kiểm tra nếu có dữ liệu trả về
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }

            // Trả về null nếu không tìm thấy nhân viên
            return null;
        }

        // Cập nhật thông tin của một nhân viên
        public void capNhatNhanVien(string tenNV, string sdt, string email, string diaChi, string chucVu)
        {
            // Lưu ý: Bạn cần thay đổi câu truy vấn và thực hiện kết nối cơ sở dữ liệu tương ứng
            string sql = String.Format("update TAIKHOAN set SDT = '{0}',  EMAIL = '{1}', DIACHI = N'{2}', CHUCVU = N'{3}' WHERE TENNV = N'{4}'", sdt, email, diaChi, chucVu, tenNV);
            db.ExecuteNonQuery(sql);
        }


        // Thêm một nhân viên mới
        public void themNhanVien(string tenNV, string sdt, string email, string diaChi, string chucVu)
        {
            string sql = String.Format("insert into NHANVIEN (TENNV, SDT, EMAIL, DIACHI, CHUCVU) values(N'{0}', '{1}','{2}',N'{3}',N'{4}')", tenNV, sdt, email, diaChi, chucVu );

            db.ExecuteNonQuery(sql);
        }
        public void xoaNhanVien(string ma)
        {
            string sql = String.Format("delete from NHANVIEN where MANV = {0}", Int32.Parse(ma));
            db.ExecuteNonQuery(sql);
        }
    }
}
