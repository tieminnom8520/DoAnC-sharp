using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDienThoai.DTO
{
    internal class SanPhamDTO
    {
        private string maSP;
        private string tenSP;
        private string imageURL;
        private long donGia;
        private int soLuong;
        private string cpu;
        private string gpu;
        private int ram;
        private int boNho;
        private string heDieuHanh;
        private int namSX;
        private int thoiGianBaoHanh;
        private int pin;
        private string phuKien;
        private string camera;

        public SanPhamDTO(string maSP, string tenSP, string imageURL, long donGia, int soLuong, string cpu, string gpu, int ram, int boNho, string heDieuHanh, int namSX, int thoiGianBaoHanh, int pin, string phuKien, string camera)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.imageURL = imageURL;
            this.donGia = donGia;
            this.soLuong = soLuong;
            this.cpu = cpu;
            this.gpu = gpu;
            this.ram = ram;
            this.boNho = boNho;
            this.heDieuHanh = heDieuHanh;
            this.namSX = namSX;
            this.thoiGianBaoHanh = thoiGianBaoHanh;
            this.pin = pin;
            this.phuKien = phuKien;
            this.camera = camera;
        }

        public string MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public string ImageURL { get => imageURL; set => imageURL = value; }
        public long DonGia { get => donGia; set => donGia = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string CPU { get => cpu; set => cpu = value; }
        public string GPU { get => gpu; set => gpu = value; }
        public int RAM { get => ram; set => ram = value; }
        public int BoNho { get => boNho; set => boNho = value; }
        public string HeDieuHanh { get => heDieuHanh; set => heDieuHanh = value; }
        public int NamSX { get => namSX; set => namSX = value; }
        public int ThoiGianBaoHanh { get => thoiGianBaoHanh; set => thoiGianBaoHanh = value; }
        public int Pin { get => pin; set => pin = value; }
        public string PhuKien { get => phuKien; set => phuKien = value; }
        public string Camera { get => camera; set => camera = value; }
    }
}
