using System;
using System.Data;
using System.Data.SQLite;
namespace Mismatch
{
    class Database
    {
        public static double Energy(string name, int temperature)
        {
            DataTable dt = new DataTable();//存储该复习的结果
            SQLiteDataAdapter da;
            SQLiteConnection conn;
            conn = new SQLiteConnection("Data Source=lattice_energy.db;");//导出7天的倍数以前记录的单词
            conn.Open();
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * from lattice_energy WHERE Name= @Name AND Temperature=@Temp";
            SQLiteParameter[] parameters = {
            new SQLiteParameter("@Name"),
            new SQLiteParameter("@Temp"), };
            parameters[0].Value = name;
            parameters[1].Value = temperature;
            cmd.Parameters.Add(parameters[0]);
            cmd.Parameters.Add(parameters[1]);
            cmd.ExecuteNonQuery();
            da = new SQLiteDataAdapter(cmd);//直接把数据结果放到datatable中，           
            da.Fill(dt);
            SQLiteCommandBuilder thisbuilder = new SQLiteCommandBuilder(da);
            cmd.ExecuteNonQuery();
            conn.Close();
            return double.Parse(dt.Rows[0]["Energy"].ToString());
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
