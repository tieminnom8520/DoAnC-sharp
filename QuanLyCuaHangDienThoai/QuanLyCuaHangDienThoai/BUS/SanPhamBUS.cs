using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using QuanLyCuaHangDienThoai.DTO;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using OfficeOpenXml;

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

        public DataRow sanPhamDangChon;

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
        public void ThemSanPhamBangExcel(string filepath)
        {
            using (var package = new ExcelPackage(new FileInfo(filepath)))
            {
                var worksheet = package.Workbook.Worksheets[0];

                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                for (int row = 2; row <= rowCount; row++)
                {
                    for(int col = 1; col <= colCount; col++)
                    {
                        if(worksheet.Cells[row, col].Text == "")
                        {
                            DialogResult dialogResult = MessageBox.Show("Có khoản trắng trong file, bạn vẫn muốn nhập bằng Excel chứ?", "Cảnh báo", MessageBoxButtons.YesNo);
                            if(dialogResult == DialogResult.Yes)
                            {
                                break;
                            }else if(dialogResult == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }
                    string tensp = worksheet.Cells[row, 1].Text;
                    string image = worksheet.Cells[row, 2].Text; ;
                    string hang = worksheet.Cells[row, 3].Text;
                    int gia = Int32.Parse(worksheet.Cells[row, 4].Text);
                    int soluong = 0;
                    string cpu = worksheet.Cells[row, 5].Text;
                    string gpu = worksheet.Cells[row, 6].Text;
                    string ram = worksheet.Cells[row, 7].Text;
                    string bonho = worksheet.Cells[row, 8].Text;
                    string manhinh = worksheet.Cells[row, 9].Text;
                    string hedieuhanh = worksheet.Cells[row, 10].Text;
                    int namsx = Int32.Parse(worksheet.Cells[row, 11].Text);
                    int baohanh = Int32.Parse(worksheet.Cells[row, 12].Text);
                    string pin = worksheet.Cells[row, 13].Text;
                    string phukien = worksheet.Cells[row, 14].Text;
                    string camera = worksheet.Cells[row, 15].Text;
                    SanPhamDTO sp = new SanPhamDTO(0, tensp, image, hang, gia,soluong, cpu, gpu, ram, bonho, manhinh, hedieuhanh, namsx, baohanh, pin,phukien,camera);
                    ThemSanPham(sp);
                }
            }
        }

        public void CapNhatSanPham(SanPhamDTO sanpham)
        {
            db.ExecuteNonQuery(sanpham.updateString());
        }

        public bool xoaDuocKhong(int masp)
        {
            DataTable dataTable = db.Execute("Select Sanpham.MaSP" +
                "\r\nfrom Sanpham" +
                "\r\nwhere Sanpham.MASP" +
                "\r\nin " +
                "\r\n(select sp.masp" +
                "\r\nfrom CT_DONNHAP as ctdn join  Sanpham as sp on ctdn.MASP = sp.MASP)" +
                "\r\nor" +
                "\r\nSanpham.MASP" +
                " \r\nin" +
                "\r\n(select sp.masp" +
                "\r\nfrom CT_HOADON as cthd join  Sanpham as sp on cthd.MASP = sp.MASP)");
            for(int i =0; i< dataTable.Rows.Count; i++)
            {
                if(masp == Int32.Parse(dataTable.Rows[i][0].ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        public void XoaSanPham(int masp)
        {
                db.ExecuteNonQuery("Delete sanpham where masp = "+masp);        
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
