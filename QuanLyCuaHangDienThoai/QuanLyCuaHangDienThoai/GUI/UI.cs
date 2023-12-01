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
using QuanLyCuaHangDienThoai.GUI.ThongKe;

namespace QuanLyCuaHangDienThoai.GUI
{
    public partial class UI : Form
    {
        private QuanLySanPhamForm qlsp_form = null;
        private QuanLyKhuyenMaiFrm qlkm_form = null;
        private ThongKeForm thongKe_form = null;
        public string name = "?";
        public UI()
        {
            InitializeComponent();
            splitContainer2.Panel2.AutoSize = true;
        }

        private void UI_Load(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Today.ToString();
        }

        private void tabSanPham_Click(object sender, EventArgs e)
        {
           initQuanLySanPham();
        }

        private void tabKhuyenMai_Click(object sender, EventArgs e)
        {
            initQuanLyKhuyenMai();
        }

        public void initQuanLySanPham()
        {
            if (qlsp_form == null)
            {
                splitContainer2.Panel2.Controls.Clear();
                qlsp_form = new QuanLySanPhamForm();
                qlsp_form.Dock = DockStyle.Fill;
                splitContainer2.Panel2.Controls.Add(qlsp_form);
                qlsp_form.parent_f = this;
            }
            else
            {
                splitContainer2.Panel2.Controls.Clear();
                splitContainer2.Panel2.Controls.Add(qlsp_form);
            }
        }

        public void initQuanLyKhuyenMai()
        {
            if (qlkm_form == null)
            {
                splitContainer2.Panel2.Controls.Clear();
                qlkm_form = new QuanLyKhuyenMaiFrm();
                qlkm_form.Dock = DockStyle.Fill;
                splitContainer2.Panel2.Controls.Add(qlkm_form);
                qlkm_form.parent_f = this;
            }
            else
            {
                splitContainer2.Panel2.Controls.Clear();
                splitContainer2.Panel2.Controls.Add(qlkm_form);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(thongKe_form == null)
            {
                splitContainer2.Panel2.Controls.Clear();
                thongKe_form = new ThongKeForm();
                thongKe_form.Dock = DockStyle.Fill;
                thongKe_form.parent_f = this;
                splitContainer2.Panel2.Controls.Add(thongKe_form);
            }
            else
            {
                splitContainer2.Panel2.Controls.Clear();
                splitContainer2.Panel2.Controls.Add(thongKe_form);
            }
        }
    }
}
