using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangDienThoai.DAO;

namespace QuanLyCuaHangDienThoai.BUS
{
    public  class KhuyenMaiBUS 
    {
        Database db;
        public DataTable dsKhuyenMai;
        public DataTable DsHienThi;
        public Dictionary<string, string> dic;

        // hỗ trợ thêm, cập nhật khuyến mãi
        public DataRow khuyenMaiChon;
        public DataTable DsSanPham;
        public Dictionary<int , int> DsChiTietKhuyenMai;

        public KhuyenMaiBUS()
        {
            db = new Database();

            layDanhSachKhuyenMai();

            dic = new Dictionary<string, string>();
            dic.Add("Mô tả khuyến mãi", "MOTA");
            dic.Add("Ngày bắt đầu", "NGAYBD");
            dic.Add("Ngày kết thúc", "NGAYKT");
            dic.Add("Tình trạng", "");

            layDanhSachSanPham();

            DsChiTietKhuyenMai = new Dictionary<int, int>();
        }
        public void layDanhSachKhuyenMai()
        {
            String query = "Select * from KhuyenMai Order By NgayBD DESC";
            dsKhuyenMai = db.Execute(query);

            DsHienThi = dsKhuyenMai.Clone();
            for (int i = 0; i < dsKhuyenMai.Rows.Count; i++)
            {
                DataRow dataRow = DsHienThi.NewRow();
                dataRow.ItemArray = dsKhuyenMai.Rows[i].ItemArray;
                DsHienThi.Rows.Add(dataRow);
            }
        }

        public void layDanhSachSanPham()
        {
            DsSanPham = db.Execute("Select masp, tensp, dongia, soluong from Sanpham");
        }

        public void timKiem(String timKiemStr)
        {
            DsHienThi.Clear();
            for (int i = 0; i< dsKhuyenMai.Rows.Count; i++)
            {
                if (dsKhuyenMai.Rows[i][1].ToString().ToLower().Contains(timKiemStr.ToLower().Trim())){
                    DataRow dataRow = DsHienThi.NewRow();
                    dataRow.ItemArray = dsKhuyenMai.Rows[i].ItemArray;
                    DsHienThi.Rows.Add(dataRow);
                }
            }
        }

        public void sapXep(String sortColumn, int ascending)
        {
            DataView dataView = DsHienThi.DefaultView;
            switch (ascending)
            {
                case 0:
                    dataView.Sort = "MAKM"; break;
                case 1:
                    dataView.Sort = $"{dic[sortColumn]} ASC"; break;

                case 2:
                    dataView.Sort = $"{dic[sortColumn]} DESC"; break;
            }

            DsHienThi = dataView.ToTable();
        }
        // TODO : THêm khuyến mãi mới 
        public void themKhuyenMai(string mota, string ngaybd,string ngaykt)
        {
            string query = String.Format("insert into KhuyenMai values(N'{0}', N'{1}', N'{2}')", mota, ngaybd, ngaykt);
            db.ExecuteNonQuery(query);

            DataTable data = db.Execute("Select MAKM from KhuyenMai");
            layDanhSachKhuyenMai();
            int makm = Convert.ToInt32(data.Rows[dsKhuyenMai.Rows.Count-1][0].ToString());
            MessageBox.Show(makm + "");

            for (int i = 0; i < DsChiTietKhuyenMai.Count; i++)
            {
                string query2 = String.Format("insert into CT_KhuyenMai values(N'{0}', N'{1}', N'{2}')", makm, DsChiTietKhuyenMai.Keys.ToArray()[i], DsChiTietKhuyenMai.Values.ToArray()[i]);
                db.ExecuteNonQuery(query2);
            }

            DsChiTietKhuyenMai.Clear();
        }

        // lay chi tiet khuyen mai cua 1 khuyen mai
        public void layDanhSachChiTietKhuyenMai()
        {
            DsChiTietKhuyenMai.Clear();
            int makm = Int32.Parse(khuyenMaiChon[0].ToString());
            /*MessageBox.Show(makm + "");*/
            DataTable ctkm_makm = db.Execute(string.Format("Select * From CT_KhuyenMai where makm = {0}", makm));

            for(int i = 0; i < ctkm_makm.Rows.Count; i++)
            {
                DsChiTietKhuyenMai.Add(Int32.Parse(ctkm_makm.Rows[i][1].ToString()), Int32.Parse(ctkm_makm.Rows[i][2].ToString()));
            }
        }

        // TODO : Cập nhật khuyến mãi
        public void CapNhatKhuyenMai(string mota, string ngaybd, string ngaykt)
        {
            int makm = Int32.Parse(khuyenMaiChon[0].ToString());

            string query = String.Format("Update KhuyenMai set mota = N'{0}', ngaybd = N'{1}', ngaykt =  N'{2}' where makm= {3} ", mota, ngaybd, ngaykt, makm);
            db.ExecuteNonQuery(query);

            db.ExecuteNonQuery(string.Format("Delete from CT_KhuyenMai where makm = {0}",makm));

            for (int i = 0; i < DsChiTietKhuyenMai.Count; i++)
            {
                string query2 = String.Format("insert into CT_KhuyenMai values(N'{0}', N'{1}', N'{2}')", makm, DsChiTietKhuyenMai.Keys.ToArray()[i], DsChiTietKhuyenMai.Values.ToArray()[i]);
                db.ExecuteNonQuery(query2);
            }

            DsChiTietKhuyenMai.Clear();
        }

        // TODO : Xóa đợt khuyến mãi
        public void xoaDotKhuyenMai(int makm)
        {
            string query = String.Format("Delete from KhuyenMai where makm = {0}", makm);
            db.ExecuteNonQuery(query);
        }
    }
}
