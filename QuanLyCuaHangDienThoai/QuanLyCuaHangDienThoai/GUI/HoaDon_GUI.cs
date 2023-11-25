﻿using QuanLyCuaHangDienThoai.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai.GUI
{
    public partial class HoaDon_GUI : UserControl
    {
        HoaDon_BUS hd = new HoaDon_BUS();
        public HoaDon_GUI()
        {
            InitializeComponent();
        }
        private void HoaDon_GUI_Load(object sender, EventArgs e)
        {
            //tab 1
            lsvSanPham.FullRowSelect = true;
            lsvSanPham.View = View.Details;
            lsvSanPham.Columns.Add("Mã sản phẩm");
            lsvSanPham.Columns.Add("Tên sản phẩm");
            lsvSanPham.Columns.Add("Hãng");
            lsvSanPham.Columns.Add("Đơn giá");
            lsvSanPham.Columns.Add("Số lượng");


            lsvCTHoaDon.FullRowSelect = true;
            lsvCTHoaDon.View = View.Details;
            lsvCTHoaDon.Columns.Add("Mã sản phẩm");
            lsvCTHoaDon.Columns.Add("Tên sản phẩm");
            lsvCTHoaDon.Columns.Add("Đơn giá");
            lsvCTHoaDon.Columns.Add("Số lượng mua");
            lsvCTHoaDon.Columns.Add("Thành tiền");
            lsvCTHoaDon.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lsvCTHoaDon.Columns[0].Width = 0;

            txtNgayLap.Text = DateTime.Now.ToString();
            loadSanPham();
            btnXoa.Enabled = btnThanhToan.Enabled = txtTienTra.Enabled = txtDiaChi.Enabled = false;
            cboTrangThai.SelectedIndex = 1;

            //tab 2
            lsvHoaDon.FullRowSelect = true;
            lsvHoaDon.View = View.Details;
            lsvHoaDon.Columns.Add("Mã hóa đơn");
            lsvHoaDon.Columns.Add("Khách hàng");
            lsvHoaDon.Columns.Add("Nhân viên");
            lsvHoaDon.Columns.Add("Ngày lập");
            lsvHoaDon.Columns.Add("Địa chỉ giao");
            lsvHoaDon.Columns.Add("Tổng tiền");
            lsvHoaDon.Columns.Add("Trạng thái");
            lsvHoaDon.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lsvHoaDon.Columns[0].Width = 0;
            cboTrangThai.Enabled = false;
        }
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            loadSanPham();
            loadHoaDon();
        }
        //tab lập
        private void loadSanPham()
        {
            lsvSanPham.Items.Clear();
            DataTable dt = hd.layDanhSachSanPham();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvSanPham.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
            }
            lsvSanPham.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lsvSanPham.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
            lsvSanPham.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
            lsvSanPham.Columns[0].Width = 0;
            btnThem.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lsvSanPham.Items.Clear();
            DataTable dt = hd.timKiemSanPham(txtTimKiem.Text);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvSanPham.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
            }
            lsvSanPham.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lsvSanPham.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
            lsvSanPham.Columns[0].Width = 0;
            btnThem.Enabled = false;

            for (int i = 0; i < lsvCTHoaDon.Items.Count; i++)
            {
                string ma = lsvCTHoaDon.Items[i].SubItems[0].Text;
                for (int j = 0; j < lsvSanPham.Items.Count; j++)
                {
                    if (ma.Equals(lsvSanPham.Items[j].SubItems[0].Text))
                    {
                        int soLuongHienTai = Int32.Parse(lsvSanPham.Items[j].SubItems[4].Text) - Int32.Parse(lsvCTHoaDon.Items[i].SubItems[3].Text);
                        lsvSanPham.Items[j].SubItems[4].Text = soLuongHienTai.ToString();
                        break;
                    }
                }
            }
        }
        private void lsvSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvSanPham.SelectedIndices.Count > 0)
            {
                btnThem.Enabled = true;
                txtSoLuong.Text = "1";
            }
            else
            {
                btnThem.Enabled = false;
            }
        }
        private void tinhTongTien()
        {
            double tongtien = 0;
            for (int i = 0; i < lsvCTHoaDon.Items.Count; i++)
            {
                tongtien += double.Parse(lsvCTHoaDon.Items[i].SubItems[4].Text);
            }

            if (tongtien == 0)
            {
                txtTienTra.Enabled = false;
                btnThanhToan.Enabled = false;
            }
            else
            {
                txtTienTra.Enabled = true;
                btnThanhToan.Enabled = true;
            }
            txtTongTien.Text = tongtien.ToString();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            int soluong;
            if (lsvSanPham.SelectedIndices.Count > 0 && Int32.TryParse(txtSoLuong.Text, out soluong) && Int32.Parse(txtSoLuong.Text) > 0)
            {
                if (soluong <= Int32.Parse(lsvSanPham.SelectedItems[0].SubItems[4].Text))
                {
                    for(int i = 0; i < lsvCTHoaDon.Items.Count; i++)
                    {
                        if (lsvCTHoaDon.Items[0].SubItems[0].Text.Equals(lsvSanPham.SelectedItems[0].SubItems[0].Text))
                        {
                            lsvCTHoaDon.Items[i].SubItems[3].Text = (Int32.Parse(lsvCTHoaDon.Items[i].SubItems[3].Text) + soluong).ToString();
                            double thanhtienmoi = double.Parse(lsvCTHoaDon.Items[i].SubItems[2].Text) * Int32.Parse(lsvCTHoaDon.Items[i].SubItems[3].Text);
                            lsvCTHoaDon.Items[i].SubItems[4].Text = thanhtienmoi.ToString();

                            lsvSanPham.SelectedItems[0].SubItems[4].Text = (Int32.Parse(lsvSanPham.SelectedItems[0].SubItems[4].Text) - soluong).ToString();
                            txtSoLuong.Text = "";
                            btnThem.Enabled = false;
                            btnThanhToan.Enabled = true;

                            tinhTongTien();
                            return;
                        }    
                    }    

                    ListViewItem lvi = lsvCTHoaDon.Items.Add(lsvSanPham.SelectedItems[0].SubItems[0].Text);
                    lvi.SubItems.Add(lsvSanPham.SelectedItems[0].SubItems[1].Text);
                    lvi.SubItems.Add(lsvSanPham.SelectedItems[0].SubItems[3].Text);
                    lvi.SubItems.Add(txtSoLuong.Text);
                    double thanhtien = double.Parse(lsvSanPham.SelectedItems[0].SubItems[3].Text) * soluong;
                    lvi.SubItems.Add(thanhtien.ToString());
                    lsvCTHoaDon.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    lsvCTHoaDon.Columns[0].Width = 0;
                    lsvCTHoaDon.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);

                    lsvSanPham.SelectedItems[0].SubItems[4].Text = (Int32.Parse(lsvSanPham.SelectedItems[0].SubItems[4].Text) - soluong).ToString();
                    txtSoLuong.Text = "";
                    btnThem.Enabled = false;
                    btnThanhToan.Enabled = true;

                    tinhTongTien();
                }
                else
                {
                    MessageBox.Show("Số lượng mua không được lớn hơn số lượng tồn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoLuong.Focus();
                }
            }
            else
            {
                MessageBox.Show("Số lượng mua chỉ được nhập số nguyên dương", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoLuong.Focus();
            }
        }

        private void lsvCTHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvCTHoaDon.SelectedIndices.Count > 0)
            {
                btnXoa.Enabled = true;
            }
            else
            {
                btnXoa.Enabled = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lsvCTHoaDon.SelectedIndices.Count > 0)
            {
                string ma = lsvCTHoaDon.SelectedItems[0].SubItems[0].Text;
                for (int i = 0; i < lsvSanPham.Items.Count; i++)
                {
                    if (ma.Equals(lsvSanPham.Items[i].SubItems[0].Text))
                    {
                        int soLuongBanDau = Int32.Parse(lsvSanPham.Items[i].SubItems[4].Text) + Int32.Parse(lsvCTHoaDon.SelectedItems[0].SubItems[3].Text);
                        lsvSanPham.Items[i].SubItems[4].Text = soLuongBanDau.ToString();
                        break;
                    }
                }
                lsvCTHoaDon.Items.Remove(lsvCTHoaDon.SelectedItems[0]);
                btnXoa.Enabled = false;
                tinhTongTien();
            }
        }

        private void txtTienTra_TextChanged(object sender, EventArgs e)
        {
            if (!txtTienTra.Text.Trim().Equals(""))
            {
                if (txtTienTra.Text.All(Char.IsDigit))
                {
                    txtTienThoi.Text = (double.Parse(txtTongTien.Text) - double.Parse(txtTienTra.Text)).ToString();
                }
                else
                {
                    MessageBox.Show("Số tiền trả chỉ được phép nhập số dương", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTienTra.Text = txtTienTra.Text.Remove(txtTienTra.Text.Length - 1);
                }
            }
            else
            {
                txtTienThoi.Text = "";
            }
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( cboTrangThai.SelectedIndex == 1 )
            {
                txtDiaChi.Enabled = false;
                txtDiaChi.Text = "";
            }    
            else
            {
                txtDiaChi.Enabled = true;
            }    
        }

        //tab quản lý
        private void loadHoaDon()
        {
            lsvHoaDon.Items.Clear();
            DataTable dt = hd.layDanhSachHoaDon(checkBox1.Checked);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvHoaDon.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
                if (dt.Rows[i][6].ToString() == "1")
                {
                    lvi.SubItems.Add("Đã thanh toán");
                }
                else
                {
                    lvi.SubItems.Add("Chưa thanh toán");
                }
            }
            lsvHoaDon.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lsvHoaDon.Columns[0].Width = 0;
            btnSuaTrangThai.Enabled = false;
        }

        private void btnTimTheoTen_Click(object sender, EventArgs e)
        {
            lsvHoaDon.Items.Clear();
            DataTable dt = hd.timHoaDon(txtTenKhachHang.Text, checkBox1.Checked);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvHoaDon.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
                if(dt.Rows[i][6].ToString() == "1")
                {
                    lvi.SubItems.Add("Đã thanh toán");
                }
                else
                {
                    lvi.SubItems.Add("Chưa thanh toán");
                }    
            }
            lsvHoaDon.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lsvHoaDon.Columns[0].Width = 0;
            btnSuaTrangThai.Enabled = false;
        }

        private void lsvHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( lsvHoaDon.SelectedIndices.Count > 0 )
            {
                if (lsvHoaDon.SelectedItems[0].SubItems[6].Text.Equals("Đã thanh toán"))
                {
                    cboTrangThai2.Enabled = false;
                    cboTrangThai2.SelectedIndex = cboTrangThai2.FindString(lsvHoaDon.SelectedItems[0].SubItems[6].Text);
                    btnSuaTrangThai.Enabled = false;
                }    
                else
                {
                    cboTrangThai2.Enabled = true;
                    cboTrangThai2.SelectedIndex = cboTrangThai2.FindString(lsvHoaDon.SelectedItems[0].SubItems[6].Text);
                    btnSuaTrangThai.Enabled = true;
                }    
            }
            else
            {
                btnSuaTrangThai.Enabled = false;
            }    
        }
        private void btnSuaTrangThai_Click(object sender, EventArgs e)
        {
            hd.suaHoaDon(lsvHoaDon.SelectedItems[0].SubItems[0].Text);
            MessageBox.Show("Sửa hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadHoaDon();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            loadHoaDon();
        }
        
    }
}