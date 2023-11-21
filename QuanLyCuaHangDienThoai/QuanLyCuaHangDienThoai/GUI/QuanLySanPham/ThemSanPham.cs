using QuanLyCuaHangDienThoai.BUS;
using QuanLyCuaHangDienThoai.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai.GUI.QuanLySanPham
{
    public partial class ThemSanPham : Form
    {
        SanPhamBUS sp_bus;
        QuanLySanPhamForm qlsp_form;
        private string sourceImage;

        public ThemSanPham()
        {
            InitializeComponent();
        }

        public ThemSanPham(QuanLySanPhamForm quanLySanPhamForm,SanPhamBUS sanPhamBUS)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.sp_bus = sanPhamBUS;
            this.qlsp_form = quanLySanPhamForm;
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

        private void button1_Click(object sender, EventArgs e)
        {   // validate 
            if(txtTenSp.Text.Trim()=="" || hinhAnhLbl.Text.Trim() == "" || txtHang.Text.Trim() == "" || txtGia.Text == "" || txtCPU.Text.Trim() == "" ||
                 txtGPU.Text.Trim() == "" || txtRam.Text.Trim() == "" || txtBoNho.Text.Trim() == "" || txtHeDieuHanh.Text.Trim() == "" || txtNamSanXuat.Text =="" || txtThangBaoHanh.Text.Trim()==""
                 || txtPin.Text.Trim() == "" || txtPhuKien.Text.Trim() == "" ||  txtCamera.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng điền đủ thông tin");
            }

            try
            {
                long gia = Int64.Parse(txtGia.Text);
            }
            catch (Exception ex){
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

            // them san pham

            var confirmResult = MessageBox.Show("Xác nhận thêm sản phẩm ?",
                                     null,
                                     MessageBoxButtons.YesNo);
            if(confirmResult == DialogResult.Yes)
            {
                try
                {
                    string ram = txtRam.Text;
                    while (ram.Length < 5)
                    {
                        ram = " "+ram;
                    }
                    SanPhamDTO sanpham = new SanPhamDTO(0, txtTenSp.Text, hinhAnhLbl.Text, txtHang.Text, long.Parse(txtGia.Text), 0,
                    txtCPU.Text, txtGPU.Text, ram, txtBoNho.Text, txtHeDieuHanh.Text, txtManHinh.Text, Int32.Parse(txtNamSanXuat.Text) , 
                    Int32.Parse(txtThangBaoHanh.Text),
                    txtPin.Text, txtPhuKien.Text, txtCamera.Text);
                    sp_bus.ThemSanPham(sanpham);

                    string destinationImage = AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\img\\dienthoai\\" + hinhAnhLbl.Text + ".png";

                    if (!File.Exists(destinationImage))
                    {
                        File.Copy(sourceImage, destinationImage);
                    }
                    MessageBox.Show("Thêm sản phẩm thành công");
                    this.qlsp_form.ReLoad();
                    Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm sản phẩm không thành công lỗi :" + ex);
                }

            }
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsLetter(e.KeyChar))
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
    }
}
