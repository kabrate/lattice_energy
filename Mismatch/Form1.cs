using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mismatch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)//计算
        {
            int t, type1=0, type2=0;
            double s, energy1, energy2, agl;
            if (textBox3.Text.ToString() != "" && textBox6.Text.ToString() != "" &&
              textBox10.Text!="" && textBox11.Text!="")
            {
                energy1 = double.Parse(textBox3.Text.ToString());
                energy2 = double.Parse(textBox6.Text.ToString());
                //type1 = comboBox4.SelectedIndex + 1;
                switch (textBox10.Text)
                {
                    case "FCC": type1 = 1; break;
                    case "BCC": type1 = 2; break;
                    case "刚玉": type1 = 3; break;
                    case "金红石": type1 = 4; break;
                    case "β-方石英": type1 = 5; break;
                }
                switch (textBox11.Text)
                {
                    case "FCC": type2 = 1; break;
                    case "BCC": type2 = 2; break;
                    case "刚玉": type2 = 3; break;
                    case "金红石": type2 = 4; break;
                    case "β-方石英": type2 = 5; break;
                }
                Calculate cal = new Calculate(type1,energy1,type2,energy2);
                s = cal.lattice_energy(type1, energy1, type2, energy2);
                s = s * 100;
                s = Math.Round(s, 2, MidpointRounding.AwayFromZero);
                agl = cal.angle;
                t = cal.plane1;
                textBox5.Text = s.ToString();
                textBox1.Text = t.ToString();
                textBox4.Text = agl.ToString();
                textBox2.Text = cal.plane2.ToString();
            }
            else
            {
                MessageBox.Show("请选择或输入所要求的参数");
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)//选中物质1
        {
            int type1, temp;
            string name1;
            string type="";
            double energy1,k;
            if(textBox7.Text=="")//没有输入温度默认20度
            {
                name1 = comboBox1.SelectedItem.ToString();
                Database.Energy(name1, 20,out k,out energy1);
                energy1=Math.Round(energy1,6,MidpointRounding.AwayFromZero);
                k=Math.Round(k,8,MidpointRounding.AwayFromZero);
                type1 = Database.Type(name1);
                textBox3.Text = energy1.ToString();
                //comboBox4.SelectedIndex = type1 - 1;
                switch(type1)
                {
                    case (1): type = "FCC"; break;
                    case 2: type = "BCC"; break;
                    case 3: type = "刚玉"; break;
                    case 4: type = "金红石"; break;
                    case 5: type = "β-方石英"; break;
                }
                textBox10.Text = type;
                textBox8.Text = k.ToString();
            }
            else if(textBox7.Text != "" && int.Parse(textBox7.Text) >= 20 && int.Parse(textBox7.Text) <= 3000)//输入了20度到3000度之间的温度
            {
                temp = int.Parse(textBox7.Text);
                name1 = comboBox1.SelectedItem.ToString();
                Database.Energy(name1, temp, out k, out energy1);
                energy1=Math.Round(energy1, 6, MidpointRounding.AwayFromZero);
                k=Math.Round(k, 8, MidpointRounding.AwayFromZero);
                type1 = Database.Type(name1);
                textBox3.Text = energy1.ToString();
                //comboBox4.SelectedIndex = type1 - 1;
                switch (type1)
                {
                    case (1): type = "FCC"; break;
                    case 2: type = "BCC"; break;
                    case 3: type = "刚玉"; break;
                    case 4: type = "金红石"; break;
                    case 5: type = "β-方石英"; break;
                }
                textBox10.Text = type;
                textBox8.Text = k.ToString();
            }
            else
            {
                MessageBox.Show("请先输入20-3000摄氏度之间的温度");
                comboBox1.SelectedIndex = -1;
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)//选中物质2
        {
            int type2, temp;
            string name2;
            double energy2,k;
            string type="";

            if (textBox7.Text == "")//没有输入温度默认20度
            {
                name2 = comboBox2.SelectedItem.ToString();
                Database.Energy(name2, 20,out k,out energy2);
                type2 = Database.Type(name2);
                energy2=Math.Round(energy2, 6, MidpointRounding.AwayFromZero);
                k=Math.Round(k, 8, MidpointRounding.AwayFromZero);
                textBox6.Text = energy2.ToString();
                // comboBox5.SelectedIndex = type2 - 1;
                switch (type2)
                {
                    case (1): type = "FCC"; break;
                    case 2: type = "BCC"; break;
                    case 3: type = "刚玉"; break;
                    case 4: type = "金红石"; break;
                    case 5: type = "β-方石英"; break;
                }
                textBox11.Text = type;
                textBox9.Text = k.ToString();
            }
            else if (textBox7.Text != ""&&int.Parse(textBox7.Text)>=20&&int.Parse(textBox7.Text)<=3000)
            { 
                name2 = comboBox2.SelectedItem.ToString();
                temp = int.Parse(textBox7.Text);
                Database.Energy(name2, temp,out k,out energy2);
                type2 = Database.Type(name2);
                energy2=Math.Round(energy2, 6, MidpointRounding.AwayFromZero);
                textBox6.Text = energy2.ToString();
                k=Math.Round(k, 8, MidpointRounding.AwayFromZero);
                //comboBox5.SelectedIndex = type2 - 1;
                switch (type2)
                {
                    case (1): type = "FCC"; break;
                    case 2: type = "BCC"; break;
                    case 3: type = "刚玉"; break;
                    case 4: type = "金红石"; break;
                    case 5: type = "β-方石英"; break;
                }
                textBox11.Text = type;
                textBox9.Text = k.ToString();
            }
            else
            {
                MessageBox.Show("请先输入20-3000摄氏度之间的温度");
                comboBox2.SelectedIndex = -1;
            }
        }
        private void Finished(object sender, EventArgs e)
        {
            if (int.Parse(textBox7.Text) < 20 || int.Parse(textBox7.Text) > 3000)
            {
                MessageBox.Show("请先输入20 - 3000摄氏度之间的温度");
                textBox7.Focus();
            }
            else
            {
                if (comboBox1.SelectedIndex != -1) comboBox1_SelectedIndexChanged(sender,e);
                if (comboBox2.SelectedIndex != -1) comboBox2_SelectedIndexChanged(sender, e);
            }
        }
        private void Complete(object sender,KeyEventArgs e)
        {
            if(e.KeyCode ==Keys.Enter)
            {
                Finished(sender,e);
                Form1 form1 = new Form1();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox7.Text) < 20 || int.Parse(textBox7.Text) > 3000)
            {
                MessageBox.Show("请先输入20 - 3000摄氏度之间的温度");
                textBox7.Focus();
            }
        }
    }
}
