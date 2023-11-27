using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangDienThoai.BUS;
using QuanLyCuaHangDienThoai.DTO;

namespace QuanLyCuaHangDienThoai.GUI
{
    public partial class CTDonNhapGUI : Form
    {
        CTDonNhapBUS busDN = new CTDonNhapBUS();
        ErrorProvider errSonguyen = new ErrorProvider();
        private int id;
        private double total = 0;
        public delegate void SendTotalDelegate(double total);
        public event SendTotalDelegate SendTotal;
        public CTDonNhapGUI(int index)
        {
            InitializeComponent();
            id = index;
        }
        private void CTDonNhap_GUI_Load(object sender, EventArgs e)
        {
            dgvCT.DataSource = busDN.LayDSChiTietDonNhap(id);
            lblMadn.Text = Convert.ToString(id);
            lblTotal.Text = dgvCT.Rows.Count.ToString();
            cbSP.DisplayMember = "masp";
            cbSP.DataSource = busDN.LayDataCB("masp", "SanPham");
            txtDongia.Clear();
            total = 0;
            for (int i = 0; i < dgvCT.Rows.Count; ++i)
            {
                total += (Convert.ToDouble(dgvCT.Rows[i].Cells[1].Value) * Convert.ToDouble(dgvCT.Rows[i].Cells[2].Value));
            }
            lblTong.Text = Convert.ToString(total);
        }
        private void dgvCT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvCT.Rows[e.RowIndex];
            string[] parts = Convert.ToString(row.Cells[2].Value).Split('.');
            cbSP.Text = Convert.ToString(row.Cells[0].Value);
            numSoluong.Text = Convert.ToString(row.Cells[1].Value);
            txtDongia.Text = parts[0];
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDongia.Text == "" || numSoluong.Value == 0)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin.");
            }
            else
            {
                if (busDN.KiemTraSanPham(cbSP.Text))
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại.");
                }
                else
                {
                    ChiTietDonNhapDTO tv = new ChiTietDonNhapDTO(id, cbSP.Text, long.Parse(txtDongia.Text), Convert.ToInt16(numSoluong.Value));
                    busDN.themCTDonNhap(tv);
                    MessageBox.Show("Thêm thành công");
                    CTDonNhap_GUI_Load(sender, e);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtDongia.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin.");
            }
            else
            {
                int ID = Convert.ToInt16(dgvCT.SelectedRows[0].Cells[0].Value.ToString());
                ChiTietDonNhapDTO cc = new ChiTietDonNhapDTO(id, Convert.ToString(ID), long.Parse(txtDongia.Text), Convert.ToInt16(numSoluong.Value));
                busDN.suaCTDonNhap(cc);
                MessageBox.Show("Sửa thành công");
                CTDonNhap_GUI_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int indexRow = dgvCT.CurrentCell.RowIndex;
            int ID = Convert.ToInt16(dgvCT.SelectedRows[0].Cells[0].Value.ToString());
            if (MessageBox.Show("Bạn có chắc là muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dgvCT.Rows.RemoveAt(indexRow);
                busDN.xoaCTDonNhap(ID);

                MessageBox.Show("Xóa thành công");
                CTDonNhap_GUI_Load(sender, e);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            dgvCT.DataSource = busDN.TimChiTietDonNhap(id, int.Parse(cbSP.Text));
            lblMadn.Text = Convert.ToString(id);
            lblTotal.Text = dgvCT.Rows.Count.ToString();
            cbSP.DisplayMember = "masp";
            cbSP.DataSource = busDN.LayDataCB("masp", "SanPham");
            txtDongia.Clear();
            double tong = 0;
            for (int i = 0; i < dgvCT.Rows.Count; ++i)
            {
                tong += Convert.ToDouble(dgvCT.Rows[i].Cells[1].Value) * Convert.ToDouble(dgvCT.Rows[i].Cells[2].Value);
            }
            lblTong.Text = Convert.ToString(tong);
        }
        Control ctrNum;
        private void txtDongia_TextChanged(object sender, EventArgs e)
        {
            ctrNum = (Control)sender;
            if (ctrNum.Text.Length > 0)
                try
                {
                    float.Parse(txtDongia.Text);
                    this.errSonguyen.Clear();
                }
                catch (FormatException)
                {
                    this.errSonguyen.SetError(ctrNum, "Chỉ nhập số.");
                    txtDongia.Clear();
                }
        }

        private void CTDonNhap_GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            SendTotal?.Invoke(total);
        }
    }
}
