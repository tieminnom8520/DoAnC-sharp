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

namespace QuanLyCuaHangDienThoai.GUI.QuanLyKhuyenMai
{
    public partial class Them_Sua_KM : UserControl
    {
        public KhuyenMaiBUS km_bus;
        QuanLyKhuyenMaiFrm qlkm_form;
        bool capnhat;
        public Them_Sua_KM()
        {
            InitializeComponent();
        }
        public Them_Sua_KM(QuanLyKhuyenMaiFrm qlkm_form,KhuyenMaiBUS km_bus, bool capnhat = false)
        {
            this.qlkm_form = qlkm_form;
            this.km_bus = km_bus;
            this.capnhat = capnhat;

            InitializeComponent();
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (this.capnhat)
            {
                this.km_bus.layDanhSachChiTietKhuyenMai();
                this.moTaTxt.Text = km_bus.khuyenMaiChon[1].ToString();
                this.dateTimePicker1.Value = DateTime.Parse(km_bus.khuyenMaiChon[2].ToString());
                this.dateTimePicker2.Value = DateTime.Parse(km_bus.khuyenMaiChon[3].ToString());
            }
            hienThi2Bang();
            hienThiNoiDung2Bang();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void hienThi2Bang()
        {
            sanpham_listview.Clear();

            sanpham_listview.Columns.Add("Tên sản phẩm");
            sanpham_listview.Columns.Add("Đơn giá");
            sanpham_listview.Columns.Add("Số lượng");

            for (int i = 0; i < sanpham_listview.Columns.Count; i++)
            {
                sanpham_listview.Columns[i].Width = sanpham_listview.Width / sanpham_listview.Columns.Count;
            }

            ctkm_listview.Clear();

            ctkm_listview.Columns.Add("Tên sản phẩm");
            ctkm_listview.Columns.Add("Đơn giá");
            ctkm_listview.Columns.Add("Phần trăm giảm");
            ctkm_listview.Columns.Add("Giá khuyến mãi");

            for (int i = 0; i < ctkm_listview.Columns.Count; i++)
            {
                ctkm_listview.Columns[i].Width = ctkm_listview.Width / ctkm_listview.Columns.Count;
            }
        }

        public void hienThiNoiDung2Bang()
        {
            for (int i = 0; i < km_bus.DsSanPham.Rows.Count; i++)
            {
                // kiểm tra có trong DsChiTietKhuyenMai
                if (km_bus.DsChiTietKhuyenMai.ContainsKey(Int32.Parse(km_bus.DsSanPham.Rows[i][0].ToString())))  // Có
                {
                    int phanTram = km_bus.DsChiTietKhuyenMai[Int32.Parse(km_bus.DsSanPham.Rows[i][0].ToString())];

                    ListViewItem lvi = ctkm_listview.Items.Add(km_bus.DsSanPham.Rows[i][1].ToString());
                    lvi.SubItems.Add(long.Parse(km_bus.DsSanPham.Rows[i][2].ToString().Split('.')[0]).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("vi-Vn")));
                    lvi.SubItems.Add(phanTram + "%");
                    double giaDaGiam = ((100 - phanTram) * 1.0 / 100) * Int64.Parse(km_bus.DsSanPham.Rows[i][2].ToString().Split('.')[0]);
                    /*MessageBox.Show(giaDaGiam+"");*/

                    lvi.SubItems.Add(giaDaGiam.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("vi-Vn")));

                    lvi.Tag = km_bus.DsSanPham.Rows[i][0].ToString(); // lưu lại masp
                }
                else // Không
                {
                    ListViewItem lvi = sanpham_listview.Items.Add(km_bus.DsSanPham.Rows[i][1].ToString());
                    lvi.SubItems.Add(long.Parse(km_bus.DsSanPham.Rows[i][2].ToString().Split('.')[0]).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("vi-Vn")));
                    lvi.SubItems.Add(km_bus.DsSanPham.Rows[i][3].ToString());
                    lvi.Tag = km_bus.DsSanPham.Rows[i][0].ToString();
                }
            }
        }

        private void themBtn_Click(object sender, EventArgs e)
        {
            if (sanpham_listview.SelectedIndices.Count > 0)
            {
                // Thêm vào danh sách ctkm   
                try
                {
                    int phanTram = Int32.Parse(PhanTramTxt.Text);
                    int masp = Int32.Parse(sanpham_listview.Items[sanpham_listview.SelectedIndices[0]].Tag.ToString());
                    km_bus.DsChiTietKhuyenMai.Add(masp, phanTram);


                    ListViewItem lvi = ctkm_listview.Items.Add(km_bus.DsSanPham.Rows[masp - 1][1].ToString());
                    lvi.SubItems.Add(long.Parse(km_bus.DsSanPham.Rows[masp - 1][2].ToString().Split('.')[0]).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("vi-Vn")));
                    lvi.SubItems.Add(phanTram + "%");
                    double giaDaGiam = ((100 - phanTram) * 1.0 / 100) * Int64.Parse(km_bus.DsSanPham.Rows[masp - 1][2].ToString().Split('.')[0]);
                    /*MessageBox.Show(giaDaGiam+"");*/
                    lvi.SubItems.Add(giaDaGiam.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("vi-Vn")));

                    lvi.Tag = masp; // lưu lại masp

                    sanpham_listview.Items.RemoveAt(sanpham_listview.SelectedIndices[0]);
                    PhanTramTxt.Text = "";
                    chonLbl.Text = "Sản phẩm đang chọn :";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bạn phải nhập phần trăm giảm");
                    PhanTramTxt.Focus();
                }
            }
            else
                MessageBox.Show("Bạn phải chọn sản phẩm");
        }

        private void sanpham_listview_Click(object sender, EventArgs e)
        {
            if (sanpham_listview.SelectedItems.Count > 0)
                chonLbl.Text = "Sản phẩm đang chọn :" + sanpham_listview.SelectedItems[0].SubItems[0].Text;

        }

        private void boBtn_Click(object sender, EventArgs e)
        {
            if (ctkm_listview.SelectedItems.Count > 0)
            {
                BoDiSanPhamTrongBangGiamGia(ctkm_listview.SelectedIndices[0]);
            }
            else
            {
                MessageBox.Show("Bạn phải chọn 1 sản phẩm khuyến mãi trong bảng");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ctkm_listview.Items.Count == 0)
            {
                MessageBox.Show("Không còn sản phẩm nào trong bảng giảm giá");
                return;
            }
            else
            {
                for (int i = 0; i < ctkm_listview.Items.Count; i++)
                {
                    BoDiSanPhamTrongBangGiamGia(i);
                    i--;
                }
            }
        }

        public void BoDiSanPhamTrongBangGiamGia(int viTriSanPhamTrongBangGiamGia)
        {
            int masp = Int32.Parse(ctkm_listview.Items[viTriSanPhamTrongBangGiamGia].Tag.ToString());

            // Thêm lại vào listview sản phẩm
            ListViewItem lvi = sanpham_listview.Items.Add(km_bus.DsSanPham.Rows[masp - 1][1].ToString());
            lvi.SubItems.Add(long.Parse(km_bus.DsSanPham.Rows[masp - 1][2].ToString().Split('.')[0]).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("vi-Vn")));
            lvi.SubItems.Add(km_bus.DsSanPham.Rows[masp - 1][3].ToString());
            lvi.Tag = masp;

            //Xóa khỏi danh sách chi tiết sản phẩm
            ctkm_listview.Items.RemoveAt(viTriSanPhamTrongBangGiamGia);
            bool kq = km_bus.DsChiTietKhuyenMai.Remove(masp);
            /*MessageBox.Show(kq + "");*/
        }

        private void button6_Click(object sender, EventArgs e)
        {
            km_bus.DsChiTietKhuyenMai.Clear();
            km_bus.khuyenMaiChon = null;
            qlkm_form.parent_f.initQuanLyKhuyenMai();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ((dateTimePicker1.Value.Date < DateTime.Now.Date || dateTimePicker1.Value.Date < DateTime.Now.Date) && this.capnhat) // Trường hợp ngày bắt đầu là ngày kết thúc trong quá khứ
            {
                MessageBox.Show("ngày bắt đầu và ngày kết thúc phải ở tương lai");
                return;
            }
            else if (dateTimePicker1.Value.Date == dateTimePicker2.Value.Date)// Trường hợp ngày bắt đầu và kết thúc trùng nhau 
            {
                MessageBox.Show("ngày bắt đầu và ngày kết thúc không được trùng nhau");
                return;
            }
            else if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date) // Ngày bắt đầu sau ngày kết thúc
            {
                MessageBox.Show("ngày bắt đầu phải trước ngày kết thúc");
                return;
            }

            if (moTaTxt.Text == "")
            {
                MessageBox.Show("mô tả khuyến mãi không được để trống");
                moTaTxt.Focus();
                return;
            }

            // Thêm 
            if (!this.capnhat)
            {
                km_bus.themKhuyenMai(moTaTxt.Text, dateTimePicker1.Value.Date.ToString(), dateTimePicker2.Value.Date.ToString());
                MessageBox.Show("Thêm mới 1 đợt khuyến mãi thành công");
            }
            else // Cập nhật
            {
                km_bus.CapNhatKhuyenMai(moTaTxt.Text, dateTimePicker1.Value.Date.ToString(), dateTimePicker2.Value.Date.ToString());
                MessageBox.Show("Cập nhật đợt khuyến mãi thành công");
            }
            this.qlkm_form.parent_f.initQuanLyKhuyenMai();
            this.qlkm_form.ReLoad();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
