using QuanLyCuaHangDienThoai.BUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDienThoai.BUS
{
    internal class TaiKhoan_BUS
    {
        Database db;
        public TaiKhoan_BUS() 
        {
            db = new Database();
        }
        public DataTable CheckUser(string username, string password)
        {
            string sql = $"SELECT * FROM TAIKHOAN WHERE USERNAME = '{username}' AND PASSWORD = '{password}'";
            return db.Execute(sql);
        }
        public DataTable layDanhSachTaiKhoan()
        {
            string sql = "Select * from TAIKHOAN";
            return db.Execute(sql);
        }
        public void themTaiKhoan(int manv,string username, string password,int tinhtrang)
        {
            string sql = String.Format("insert into TAIKHOAN(MANV, USERNAME,PASSWORD,TINHTRANG) values('{0}', '{1}','{2}','{3}')", manv, username, password, tinhtrang);
            db.ExecuteNonQuery(sql);
        }
        public void suaTaiKhoan(string ma, int manv, string username, string password, int tinhtrang)
        {
            string sql = String.Format("update TAIKHOAN set MANV = N'{0}', USERNAME = {1}, PASSWORD = {2}, TINHTRANG = {3} where MATK = {4}", manv, username, password,tinhtrang, Int32.Parse(ma));
            db.ExecuteNonQuery(sql);
        }
        public void xoaTaiKhoan(string ma)
        {
            string sql = String.Format("delete from TAIKHOAN where MATK = {0}", Int32.Parse(ma));
            db.ExecuteNonQuery(sql);
        }
        public DataTable timKiemTaiKhoan(string username)
        {
            string sql = String.Format("select * from TAIKHOAN where USERNAME like N'%{0}%'", username);
            return db.Execute(sql);
        }
    }
}
