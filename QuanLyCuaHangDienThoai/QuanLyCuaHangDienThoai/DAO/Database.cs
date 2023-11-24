using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai
{
    public class Database
    {
        SqlConnection sqlConn;
        SqlDataAdapter da;//Bo dieu phoi du lieu
        DataSet ds; //Doi tuong chhua CSDL khi giao tiep 
        static string strCnn = "Data Source=DESKTOP-b92hk9o\\SQLEXPRESS; Database=CuaHangDienThoai; Integrated Security = True";

        public  Database()
        {
            sqlConn =  new SqlConnection(strCnn);
        }

        public DataTable Execute(String sqlStr)
        {

            da = new SqlDataAdapter(sqlStr, sqlConn);
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public void ExecuteNonQuery(String sqlStr)
        {
            SqlCommand sqlcmd = new SqlCommand(sqlStr, sqlConn);
            sqlConn.Open(); //Mo ket noi
            sqlcmd.ExecuteNonQuery();//Lenh hien lenh Them/Xoa/Sua
            sqlConn.Close();//Dong ket noi
        }
    }
}
