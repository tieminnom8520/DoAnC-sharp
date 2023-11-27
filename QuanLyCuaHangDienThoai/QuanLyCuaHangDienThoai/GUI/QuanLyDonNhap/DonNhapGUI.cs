using QuanLyCuaHangDienThoai.DTO;
using QuanLyCuaHangDienThoai.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangDienThoai.GUI.QuanLyDonNhap;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyCuaHangDienThoai.GUI
{
    public partial class DonNhapGUI : UserControl
    {
        DonNhapBUS busDN = new DonNhapBUS();
        public DonNhapGUI()
        {
            InitializeComponent();
        }
        private void DonNhap_GUI_Load(object sender, EventArgs e)
        {
            dgvDN.DataSource = busDN.LayDSDonNhap();
            lblTotal.Text = dgvDN.Rows.Count.ToString();
            cbNCC.DisplayMember = "mancc";
            cbNCC.DataSource = busDN.LayDataCB("mancc", "NhaCungCap");
            cbNV.DisplayMember = "manv";
            cbNV.DataSource = busDN.LayDataCB("manv", "NhanVien");
        }
        private void dgvDN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvDN.Rows[e.RowIndex];
            string[] parts = Convert.ToString(row.Cells[3].Value).Split('.');
            cbNCC.Text = Convert.ToString(row.Cells[1].Value);
            cbNV.Text = Convert.ToString(row.Cells[2].Value);
            lblTong.Text = parts[0];
            dtpNgaylap.Value = Convert.ToDateTime(row.Cells[4].Value);
            picDetail.Visible = true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DonNhapDTO tv = new DonNhapDTO(0, cbNCC.Text, cbNV.Text, long.Parse(lblTong.Text), dtpNgaylap.Value);
            busDN.themDonNhap(tv);
            MessageBox.Show("Thêm thành công");
            DonNhap_GUI_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lblTong.Text != "0")
            {
                int ID = Convert.ToInt16(dgvDN.SelectedRows[0].Cells[0].Value.ToString());
                DonNhapDTO cc = new DonNhapDTO(ID, cbNCC.Text, cbNV.Text, 0, dtpNgaylap.Value);
                busDN.suaDonNhap(cc);
                MessageBox.Show("Sửa thành công");
                DonNhap_GUI_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng để sửa.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lblTong.Text != "0")
            {
                int indexRow = dgvDN.CurrentCell.RowIndex;
                int ID = Convert.ToInt16(dgvDN.SelectedRows[0].Cells[0].Value.ToString());
                if (MessageBox.Show("Bạn có chắc là muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgvDN.Rows.RemoveAt(indexRow);
                    busDN.xoaDonNhap(ID);

                    MessageBox.Show("Xóa thành công");
                    DonNhap_GUI_Load(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa.");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            Timkiem tk = new Timkiem();
            tk.SendValue += ReceiveValue;
            tk.ShowDialog();
        }
        private void ReceiveValue(string label, string value)
        {
            dgvDN.DataSource = busDN.TimDonNhap(label,int.Parse(value));
            lblTotal.Text = dgvDN.Rows.Count.ToString();
        }
        private void ReceiveTotal(double total)
        {
            lblTong.Text = total.ToString();
            int ID = Convert.ToInt16(dgvDN.SelectedRows[0].Cells[0].Value.ToString());
            DonNhapDTO cc = new DonNhapDTO(ID, cbNCC.Text, cbNV.Text, long.Parse(lblTong.Text), dtpNgaylap.Value);
            busDN.suaDonNhap(cc);
            dgvDN.DataSource = busDN.LayDSDonNhap();
        }
        private void picDetail_Click(object sender, EventArgs e)
        {
            int indexRow = dgvDN.CurrentCell.RowIndex;
            int ID = Convert.ToInt16(dgvDN.SelectedRows[0].Cells[0].Value.ToString());
            CTDonNhapGUI ct = new CTDonNhapGUI(ID);
            ct.SendTotal += ReceiveTotal;
            ct.ShowDialog();
            picDetail.Visible = false;
        }
    }
}
