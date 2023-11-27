using QuanLyCuaHangDienThoai.BUS;
using QuanLyCuaHangDienThoai.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyCuaHangDienThoai.GUI.QuanLySanPham
{
    public partial class NhaCungCapGUI : UserControl
    {
        public NhaCungCapGUI()
        {
            InitializeComponent();
        }
            NhaCungCap_BUS busNCC = new NhaCungCap_BUS();
            ErrorProvider errSonguyen = new ErrorProvider();
        
            private void NhaCungCap_GUI_Load(object sender, EventArgs e)
            {
                dgvNCC.DataSource = busNCC.LayDSNhaCungCap();
                lblTotal.Text = dgvNCC.Rows.Count.ToString();
                txtTen.Clear();
                txtDiachi.Clear();
                txtSdt.Clear();
            }
            private void btnAdd_Click(object sender, EventArgs e)
            {
                if (txtTen.Text == "" || txtDiachi.Text == "" || txtSdt.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin.");
                }
                else
                {
                    Regex regex = new Regex(@"^0\d{9}$");
                    if (busNCC.KiemTraTonTai(txtTen.Text))
                    {
                        if (MessageBox.Show("Nhà cung cấp đã tồn tại trong trạng thái ẩn. Bạn có muốn khôi phục không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            busNCC.KhoiPhucNhaCungCap(txtTen.Text);
                            MessageBox.Show("Khôi phục thành công");
                            NhaCungCap_GUI_Load(sender, e);
                        }
                    }
                    else
                    {
                        if (!regex.IsMatch(txtSdt.Text))
                        {
                            MessageBox.Show("Số điện thoại không hợp lệ. Số điện thoại hợp lệ phải bắt đầu từ 0 và đủ 10 số.");
                            txtSdt.Clear();
                        }
                        else
                        {
                            NhaCungCapDTO tv = new NhaCungCapDTO(0, txtTen.Text, txtDiachi.Text, txtSdt.Text);
                            busNCC.themNhaCungCap(tv);
                            MessageBox.Show("Thêm thành công");
                            NhaCungCap_GUI_Load(sender, e);
                        }
                }
                }

            }

            private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvNCC.Rows[e.RowIndex];
                txtTen.Text = Convert.ToString(row.Cells[1].Value);
                txtDiachi.Text = Convert.ToString(row.Cells[2].Value);
                txtSdt.Text = Convert.ToString(row.Cells[3].Value);
            }

            private void btnXoa_Click(object sender, EventArgs e)
            {
                if (txtTen.Text == "" || txtDiachi.Text == "" || txtSdt.Text == "")
                {
                    MessageBox.Show("Vui lòng chọn dòng để xóa.");
                }
                else
                {
                    int ID = Convert.ToInt16(dgvNCC.SelectedRows[0].Cells[0].Value.ToString());
                    if (busNCC.KiemTraThamChieu(ID.ToString()))
                    {
                        MessageBox.Show("Nhà cung cấp đang được tham chiếu đến bảng khác. Không thể xóa.");
                    }
                    else
                    {
                        int indexRow = dgvNCC.CurrentCell.RowIndex;

                        if (MessageBox.Show("Bạn có chắc là muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //   dgvNCC.Rows.RemoveAt(indexRow);
                            busNCC.xoaNhaCungCap(ID);
                            MessageBox.Show("Xóa thành công");
                            NhaCungCap_GUI_Load(sender, e);
                        }
                    }
                }
            }

            private void btnSua_Click(object sender, EventArgs e)
            {
                if (txtTen.Text == "" || txtDiachi.Text == "" || txtSdt.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin.");
                }
                else
                {
                    int ID = Convert.ToInt16(dgvNCC.SelectedRows[0].Cells[0].Value.ToString());
                    NhaCungCapDTO cc = new NhaCungCapDTO(ID, txtTen.Text, txtDiachi.Text, txtSdt.Text);
                    busNCC.suaNhaCungCap(cc);
                    MessageBox.Show("Sửa thành công");
                    NhaCungCap_GUI_Load(sender, e);
                }
            }

            private void btnTim_Click(object sender, EventArgs e)
            {
                if (txtTen.Text == "")
                {
                    MessageBox.Show("Nhập tên để tìm kiếm.");
                }
                else
                {
                    var result = busNCC.TimChiTietDonNhap(txtTen.Text);
                    if (result == null || result.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả nào");
                    }
                    else
                    {
                        dgvNCC.DataSource = result;
                        lblTotal.Text = dgvNCC.Rows.Count.ToString();
                    }
            }
        }
            Control ctrNum;
            private void txtSdt_TextChanged(object sender, EventArgs e)
            {
                ctrNum = (Control)sender;
                if (ctrNum.Text.Length > 0)
                    try
                    {
                        int.Parse(txtSdt.Text);
                        this.errSonguyen.Clear();
                    }
                    catch (FormatException)
                    {
                        this.errSonguyen.SetError(ctrNum, "Chỉ nhập số.");
                        txtSdt.Clear();
                    }
            }
    }  

}


