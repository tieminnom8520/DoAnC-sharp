using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using QuanLyCuaHangDienThoai.DTO;
using QuanLyCuaHangDienThoai.DAO;
using System.Collections.Specialized;
using System.ComponentModel;

namespace QuanLyCuaHangDienThoai.BUS
{ 
    public class SanPhamBUS
    {
        public DataTable DsSanPham; 
        public DataTable DsHienThi;
        public ArrayList DsHang = new ArrayList();
        Database db;
        Dictionary<string, string> dic;

        public int ascending = 0;
        public string sortingColumn = null;

        public SanPhamBUS()
        {
            db = new Database();
            layDanhSachSanPham();
            layDanhSachHang();
            // dictionary hỗ trợ sắp xếp datatable
            dic = new Dictionary<string, string>();
            dic.Add("Tên sản phẩm", "TENSP");
            dic.Add("Hệ điều hành", "OS");
            dic.Add("Camera", "CAMERA");
            dic.Add("Chip", "CPU");
            dic.Add("Ram", "RAM");
            dic.Add("Dung lượng", "BONHO");
            dic.Add("Pin", "PIN");
            dic.Add("Giá", "DONGIA");
            dic.Add("Số lượng", "SOLUONG");
        }

        public void layDanhSachHang()
        {
            DsHang.Clear();
            for(int i =0; i< DsHienThi.Rows.Count; i++)
            {
                if (!DsHang.Contains(DsHienThi.Rows[i][3].ToString())){
                    DsHang.Add(DsHienThi.Rows[i][3].ToString());
                } 
            }
        }

        public void layDanhSachSanPham()
        {
            String query = "Select * from sanpham";
            DsSanPham = db.Execute(query);
            DsHienThi = DsSanPham.Clone();

            foreach (DataRow originalRow in DsSanPham.Rows)
            {
                DataRow clonedRow = DsHienThi.NewRow();
                clonedRow.ItemArray = originalRow.ItemArray;
                DsHienThi.Rows.Add(clonedRow);
            }

        }
        public void ThemSanPham(SanPhamDTO sanpham)
        {
            db.ExecuteNonQuery(sanpham.insertString());
        }
        
        public void CapNhatSanPham(SanPhamDTO sanpham)
        {
            db.ExecuteNonQuery(sanpham.updateString());
        }
        public void timKiem(string timKiemStr)
        {
            DsHienThi.Clear();
            for(int i = 0; i< DsSanPham.Rows.Count; i++)
            {
                if (DsSanPham.Rows[i][1].ToString().Trim().ToLower().Contains(timKiemStr))
                {
                    DataRow clonedRow = DsHienThi.NewRow();
                    clonedRow.ItemArray = DsSanPham.Rows[i].ItemArray;
                    DsHienThi.Rows.Add(clonedRow);
                }
            }
        }

        public void sapXep(string sortColumn)
        {
            if (sortColumn.Equals(sortingColumn))
            {
                switch (ascending)
                {
                    case 0: ascending = 1; break;
                    case 1: ascending = 2; break;
                    case 2: ascending = 0; break;
                }
            }
            else
            {
                ascending = 1;
                sortingColumn = sortColumn;
            }

            DataView dataView = DsHienThi.DefaultView;
            switch (ascending)
            {
                case 0:
                    dataView.Sort = "MASP"; break;
                case 1:
                    dataView.Sort = $"{dic[sortColumn]} ASC"; break;
                    
                case 2:
                    dataView.Sort = $"{dic[sortColumn]} DESC"; break;
            }
            
            DsHienThi = dataView.ToTable();
        }
        public void filterByBrand(ArrayList HangArray, String timKiemStr)
        {
            timKiem(timKiemStr);
            for(int i =0; i<DsHienThi.Rows.Count; i++)
            {
                if (!HangArray.Contains(DsHienThi.Rows[i][3].ToString()))
                {
                    DsHienThi.Rows.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
