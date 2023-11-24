﻿using System;
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
            lblDateTime.Text = DateTime.Today.ToString();
        }

        private void tabSanPham_Click(object sender, EventArgs e)
        {
           initQuanLySanPham();
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
    }
}
