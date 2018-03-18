using System;
using System.Data;
using System.Data.SQLite;
namespace Mismatch
{
    class Database
    {
        public static double Energy(string name, int temperature)
        {
            double x,y,k=0;//纵坐标 横坐标 斜率    
            DataTable dt = new DataTable();//存储该复习的结果
            SQLiteDataAdapter da;
            SQLiteConnection conn;
            conn = new SQLiteConnection("Data Source=lattice_energy.db;");//导出7天的倍数以前记录的单词
            conn.Open();
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * from lattice_energy WHERE Name= @Name";
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@Name"),
            };
            parameters[0].Value = name;
            cmd.Parameters.Add(parameters[0]);
            cmd.ExecuteNonQuery();
            da = new SQLiteDataAdapter(cmd);//直接把数据结果放到datatable中，           
            da.Fill(dt);
            SQLiteCommandBuilder thisbuilder = new SQLiteCommandBuilder(da);
            cmd.ExecuteNonQuery();
            conn.Close();
            for (int i=1;i<7;i++)
            {
                y = Double.Parse(dt.Rows[i]["Energy"].ToString())- Double.Parse(dt.Rows[0]["Energy"].ToString());
                x = Double.Parse(dt.Rows[i]["Temperature"].ToString())- Double.Parse(dt.Rows[0]["Temperature"].ToString());
                k = k + y/x;
            }
            k = k / 6;
            x = temperature - Double.Parse(dt.Rows[0]["Temperature"].ToString());
            y = Double.Parse(dt.Rows[0]["Energy"].ToString())+k*x;
            return y;
        }
        public static int Type(string name)
        {
            int type=0;
            DataTable dt = new DataTable();//存储该复习的结果
            SQLiteDataAdapter da;
            SQLiteConnection conn;
            conn = new SQLiteConnection("Data Source=lattice_energy.db;");//导出7天的倍数以前记录的单词
            conn.Open();
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * from lattice_energy WHERE Name= @Name ";
            SQLiteParameter[] parameters = {
            new SQLiteParameter("@Name"), };
            parameters[0].Value = name;
            cmd.Parameters.Add(parameters[0]);
            cmd.ExecuteNonQuery();
            da = new SQLiteDataAdapter(cmd);//直接把数据结果放到datatable中，           
            da.Fill(dt);
            SQLiteCommandBuilder thisbuilder = new SQLiteCommandBuilder(da);
            cmd.ExecuteNonQuery();
            conn.Close();
            switch (dt.Rows[0]["Type"].ToString())
            {
                case "FCC": type = 1; break;
                case "BCC": type = 2; break;
                case "刚玉": type = 3; break;
                case "金红石": type = 4; break;
                case "β-方石英": type = 5; break;
            }
            return type;
        }
    }
}
