using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDienThoai.DAO
{
    internal class Database
    {
        SqlConnection sqlConn; //Doi tuong ket noi CSDL
        SqlDataAdapter da;//Bo dieu phoi du lieu
        DataSet ds; //Doi tuong chhua CSDL khi giao tiep
        public string srvName = @"HARRYHERE\SQLEXPRESS";
        public string dbName = "CUAHANGDIENTHOAI";
        public Database()
        {
            string connStr = "Data source=" + srvName + ";database=" + dbName + ";Integrated Security = True";
            sqlConn = new SqlConnection(connStr);
            try
            {
                sqlConn.Open();
                Console.WriteLine("Connected");
                sqlConn.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("Unconnected");
            }
        }
        //Phuong thuc de thuc hien cau lenh strSQL truy vân du lieu
        public DataTable Execute(string sqlStr)
        {
            da = new SqlDataAdapter(sqlStr, sqlConn);
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        //Phuong thuc de thuc hien cac lenh Them, Xoa, Sua
        public void ExecuteNonQuery(string strSQL)
        {
            using (SqlCommand sqlcmd = new SqlCommand(strSQL, sqlConn))
            {
                sqlConn.Open(); //Mo ket noi
                sqlcmd.ExecuteNonQuery();//Lenh hien lenh Them/Xoa/Sua
            }
            sqlConn.Close();//Dong ket noi
        }
        public int ExecuteScalar(string strSQL)
        {
            int count = 0;
            try
            {
                using (SqlCommand sqlcmd = new SqlCommand(strSQL, sqlConn))
                {
                    sqlConn.Open(); // Mở kết nối
                    count = (int)sqlcmd.ExecuteScalar(); // Thực hiện truy vấn và lấy kết quả
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ tại đây
                Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close(); // Đóng kết nối
                }
            }
            return count;
        }

    }
}
