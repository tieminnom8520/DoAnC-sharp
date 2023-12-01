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
    public partial class Them_Sua_SanPhamForm : UserControl
    {

        SanPhamBUS sp_bus;
        QuanLySanPhamForm qlsp_form;
        private string sourceImage;
        private bool capnhat;
        public Them_Sua_SanPhamForm()
        {
            InitializeComponent();
        }
        public Them_Sua_SanPhamForm(QuanLySanPhamForm quanLySanPhamForm, SanPhamBUS sanPhamBUS, bool capnhat=false)
        {
            InitializeComponent();
            this.sp_bus = sanPhamBUS;
            this.qlsp_form = quanLySanPhamForm;
            this.hinhAnhLbl.Text = "";
            this.capnhat = capnhat;
            if(capnhat)
            {
                hienThiSua();
            }
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
                pictureBox1.BackgroundImage = Image.FromFile(sourceImage);
                hinhAnhLbl.Text = image;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {   // validate 
            if (txtTenSp.Text.Trim() == "" || hinhAnhLbl.Text.Trim() == "" || txtHang.Text.Trim() == "" || txtGia.Text == "" || txtCPU.Text.Trim() == "" ||
                 txtGPU.Text.Trim() == "" || txtRam.Text.Trim() == "" || txtBoNho.Text.Trim() == "" || txtHeDieuHanh.Text.Trim() == "" || txtNamSanXuat.Text == "" || txtThangBaoHanh.Text.Trim() == ""
                 || txtPin.Text.Trim() == "" || txtPhuKien.Text.Trim() == "" || txtCamera.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng điền đủ thông tin");
                return;
            }

            if (!checkDulicate())
            {
                MessageBox.Show("Sản phẩm bị trùng tên, vui lòng chọn tên khác");
                return;
            }
            // kiểm tra giá 
            try
            {
                long gia = Int64.Parse(txtGia.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng nhập giá hợp lệ");
                return;
            }
            // kiểm tra năm
            try
            {
                int namsx = Int32.Parse(txtNamSanXuat.Text);
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập năm sản xuất hợp lệ");
                return;
            }
            // kiểm tra tháng bảo hành
            try
            {
                int thangBh = Int32.Parse(txtThangBaoHanh.Text);
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập năm sản xuất hợp lệ");
                return;
            }

            // them hoặc cập nhật

            var confirmResult = DialogResult.Yes;
            if(capnhat == false)
            {
                confirmResult = MessageBox.Show("Xác nhận thêm sản phẩm ?",
                                     null,
                                     MessageBoxButtons.YesNo);
            }
            else
            {
                confirmResult = MessageBox.Show("Xác nhận cập nhật sản phẩm ?",
                                     null,
                                     MessageBoxButtons.YesNo);
            }
            
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    string ram = txtRam.Text;
                    while (ram.Length < 5)
                    {
                        ram = " " + ram;
                    }

                    SanPhamDTO sanpham = new SanPhamDTO(0, txtTenSp.Text, hinhAnhLbl.Text, txtHang.Text, long.Parse(txtGia.Text), 0,
                    txtCPU.Text, txtGPU.Text, ram, txtBoNho.Text, txtHeDieuHanh.Text, txtManHinh.Text, Int32.Parse(txtNamSanXuat.Text),
                    Int32.Parse(txtThangBaoHanh.Text),
                    txtPin.Text, txtPhuKien.Text, txtCamera.Text);
                    if (capnhat)
                    {
                        sanpham.MaSP = Int32.Parse(sp_bus.sanPhamDangChon[0].ToString());
                        sp_bus.CapNhatSanPham(sanpham);
                    }
                    else
                    {
                        sp_bus.ThemSanPham(sanpham);
                    }
                   
                   

                    string destinationImage = AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\img\\dienthoai\\" + hinhAnhLbl.Text + ".png";
                    // Copy hình ảnh khi cần
                    if (!File.Exists(destinationImage))
                    {
                        File.Copy(sourceImage, destinationImage);
                    }
                    // Kết quả 
                    if (capnhat)
                    {
                        MessageBox.Show("Cập nhật sản phẩm thành công");
                    }
                    else
                    {
                        MessageBox.Show("Thêm sản phẩm thành công");
                    }
                   
                    this.qlsp_form.ReLoad();
                    this.qlsp_form.parent_f.initQuanLySanPham();
                }
                catch (Exception ex)
                {
                    if (capnhat)
                    {
                        MessageBox.Show("Cập nhật sản phẩm không thành công lỗi :" + ex);
                    }
                    else
                        MessageBox.Show("Thêm sản phẩm không thành công lỗi :" + ex);
                }

            }
        }

        private void onlyReceiveNumber(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void refreshImageBtn_Click(object sender, EventArgs e)
        {
            this.pictureBox1.BackgroundImage = global::QuanLyCuaHangDienThoai.Properties.Resources.smartphone__2_;
            sourceImage = "";
            hinhAnhLbl.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.qlsp_form.ReLoad();
            this.qlsp_form.parent_f.initQuanLySanPham();
        }

        public void hienThiSua()
        {
            txtTenSp.Text = sp_bus.sanPhamDangChon[1].ToString();
            txtHang.Text = sp_bus.sanPhamDangChon[3].ToString(); 
            txtGia.Text = sp_bus.sanPhamDangChon[4].ToString().Split('.')[0];
            txtCPU.Text = sp_bus.sanPhamDangChon[6].ToString();
            txtGPU.Text = sp_bus.sanPhamDangChon[7].ToString();
            txtRam.Text = sp_bus.sanPhamDangChon[8].ToString();
            txtBoNho.Text = sp_bus.sanPhamDangChon[9].ToString();
            txtManHinh.Text = sp_bus.sanPhamDangChon[10].ToString();
            txtHeDieuHanh.Text = sp_bus.sanPhamDangChon[11].ToString();
            txtNamSanXuat.Text  = sp_bus.sanPhamDangChon[12].ToString();
            txtThangBaoHanh.Text = sp_bus.sanPhamDangChon[13].ToString();
            txtPin.Text = sp_bus.sanPhamDangChon[14].ToString();
            txtPhuKien.Text =  sp_bus.sanPhamDangChon[15].ToString();
            txtCamera.Text = sp_bus.sanPhamDangChon[16].ToString();

            hinhAnhLbl.Text = sp_bus.sanPhamDangChon[2].ToString();
            if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\img\\dienthoai\\" + hinhAnhLbl.Text + ".png"))
                pictureBox1.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\img\\dienthoai\\" + hinhAnhLbl.Text + ".png");
            else
                pictureBox1.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\img\\dienthoai\\notfound.png");
        }

        public bool checkDulicate()
        {
            for(int i =0; i < sp_bus.DsSanPham.Rows.Count;i++)
            {
                if (!capnhat)
                {
                    if (sp_bus.DsSanPham.Rows[i][1].ToString().Equals(txtTenSp.Text))
                    {
                        return false;
                    }
                }
                else
                {
                    if (sp_bus.DsSanPham.Rows[i][1].ToString().Equals(txtTenSp.Text) && !sp_bus.sanPhamDangChon[0].ToString().Equals(sp_bus.DsSanPham.Rows[i][0].ToString()))
                    {
                        return false;
                    }
                }
               
            }
            return true;
        }
    }
}
