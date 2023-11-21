using QuanLyCuaHangDienThoai.BUS;
using QuanLyCuaHangDienThoai.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai.GUI.QuanLySanPham
{
    public partial class CapNhatSanPham : Form
    {
        public SanPhamBUS sp_bus;
        private int masp;
        private string sourceImage;
        private QuanLySanPhamForm qlsp_form;
        public CapNhatSanPham()
        {
            InitializeComponent();
        }

        public CapNhatSanPham(QuanLySanPhamForm quanLySanPhamForm,SanPhamDTO sanpham, SanPhamBUS sanPhamBUS)
        {
            qlsp_form = quanLySanPhamForm;
            this.masp = sanpham.MaSP;
            sp_bus = sanPhamBUS;
            
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            
            txtTenSp.Text = sanpham.TenSP;
            txtHang.Text = sanpham.Hang;
            txtGia.Text = sanpham.DonGia+"";
            txtCPU.Text = sanpham.CPU;
            txtGPU.Text = sanpham.GPU;
            txtRam.Text = sanpham.RAM;
            txtBoNho.Text = sanpham.BoNho;
            txtManHinh.Text = sanpham.ManHinh;
            txtHeDieuHanh.Text = sanpham.HeDieuHanh;
            txtNamSanXuat.Text = sanpham.NamSX+"";
            txtThangBaoHanh.Text = sanpham.ThoiGianBaoHanh+"";
            txtPin.Text = sanpham.Pin;
            txtPhuKien.Text = sanpham.PhuKien;
            txtCamera.Text = sanpham.Camera;
            hinhAnhLbl.Text = sanpham.ImageURL;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\img\\dienthoai";

            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Get the selected file's path
                sourceImage = openFileDialog.FileName;

                // Do something with the file path, e.g., display it in a TextBox
                string[] image_file_split = sourceImage.Split('\\');
                string image_file = image_file_split[image_file_split.Length - 1];
                string image = image_file.Split('.')[0];
                hinhAnhLbl.Text = image;
            }
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNamSanXuat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtThangBaoHanh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // validate 
            if (txtTenSp.Text.Trim() == "" || hinhAnhLbl.Text.Trim() == "" || txtHang.Text.Trim() == "" || txtGia.Text == "" || txtCPU.Text.Trim() == "" ||
                 txtGPU.Text.Trim() == "" || txtRam.Text.Trim() == "" || txtBoNho.Text.Trim() == "" || txtHeDieuHanh.Text.Trim() == "" || txtNamSanXuat.Text == "" || txtThangBaoHanh.Text.Trim() == ""
                 || txtPin.Text.Trim() == "" || txtPhuKien.Text.Trim() == "" || txtCamera.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng điền đủ thông tin");
            }

            try
            {
                long gia = Int64.Parse(txtGia.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng nhập giá hợp lệ");
            }

            try
            {
                int namsx = Int32.Parse(txtNamSanXuat.Text);
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập năm sản xuất hợp lệ");
            }

            try
            {
                int thangBh = Int32.Parse(txtThangBaoHanh.Text);
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập năm sản xuất hợp lệ");
            }

            var confirmResult = MessageBox.Show("Xác nhận cập nhật sản phẩm ?",
                                     null,
                                     MessageBoxButtons.YesNo);

            string ram = txtRam.Text;
            while (ram.Length < 5)
            {
                ram = " " + ram;
            }

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    SanPhamDTO sanpham = new SanPhamDTO(this.masp, txtTenSp.Text, hinhAnhLbl.Text, txtHang.Text, long.Parse(txtGia.Text), 0,
                    txtCPU.Text, txtGPU.Text, ram, txtBoNho.Text, txtHeDieuHanh.Text, txtManHinh.Text, Int32.Parse(txtNamSanXuat.Text),
                    Int32.Parse(txtThangBaoHanh.Text),
                    txtPin.Text, txtPhuKien.Text, txtCamera.Text);
                    sp_bus.CapNhatSanPham(sanpham);

                    string destinationImage = AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\img\\dienthoai\\" + hinhAnhLbl.Text + ".png";
                    if (!File.Exists(destinationImage))
                    {
                        File.Copy(sourceImage, destinationImage);
                    }  
                    MessageBox.Show("Cập nhật sản phẩm thành công");
                    this.qlsp_form.ReLoad();
                    Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cập nhật sản phẩm không thành công lỗi :" + ex);
                }
            }
        }
    }
}
