using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangDienThoai.GUI.QuanLyKhuyenMai;
using QuanLyCuaHangDienThoai.GUI.QuanLySanPham;

namespace QuanLyCuaHangDienThoai.GUI
{
    public partial class UI : Form
    {
        private QuanLySanPhamForm qlsp_form = null;
        private QuanLyKhuyenMaiFrm qlkm_form = null;

        public UI()
        {
            InitializeComponent();
            splitContainer2.Panel2.AutoSize = true;
        }

        private void UI_Load(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString();
            menu.Controls.Add(tabSanPham);
            menu.Controls.Add(tabKhuyenMai);
            menu.Controls.Add(tabNhanVien);
            menu.Controls.Add(tabTaiKhoan);
            menu.Controls.Add(tabDonNhap);
            menu.Controls.Add(tabNhaCungCap);
            menu.Controls.Add(tabHoaDon);
            menu.Controls.Add(tabKhachHang);
        }
        private void activeTab(Control sender)
        {
            foreach (Control button in menu.Controls)
            {
                if(button.Equals(sender))
                {
                    button.BackColor = SystemColors.GradientActiveCaption;
                }    
                else
                {
                    button.BackColor = SystemColors.GradientInactiveCaption;
                }    
            }    
        }
        private void tabSanPham_Click(object sender, EventArgs e)
        {
            if (qlsp_form == null) {
                splitContainer2.Panel2.Controls.Clear();
                qlsp_form = new QuanLySanPhamForm();
                qlsp_form.Dock = DockStyle.Fill;
                splitContainer2.Panel2.Controls.Add(qlsp_form);
            }
            else
            {
                splitContainer2.Panel2.Controls.Clear();
                splitContainer2.Panel2.Controls.Add(qlsp_form);
            }
            activeTab((Control)sender);
        }

        private void tabKhuyenMai_Click(object sender, EventArgs e)
        {
            if(qlkm_form == null)
            {
                splitContainer2.Panel2.Controls.Clear();
                qlkm_form = new QuanLyKhuyenMaiFrm();
                qlkm_form.Dock = DockStyle.Fill;
                splitContainer2.Panel2.Controls.Add(qlkm_form);
            }
            else
            {
                splitContainer2.Panel2.Controls.Clear();
                splitContainer2.Panel2.Controls.Add(qlkm_form);
            }
            activeTab((Control)sender);
        }

        private void tabKhachHang_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            KhachHang_GUI kh = new KhachHang_GUI();
            kh.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Add(kh);
            activeTab((Control)sender);
        }

        private void tabHoaDon_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            HoaDon_GUI hd = new HoaDon_GUI();
            hd.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Add(hd);
            activeTab((Control)sender);
        }

    }
}
