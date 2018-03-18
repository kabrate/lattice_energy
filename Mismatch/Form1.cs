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
            int t, type1, type2;
            double s, energy1, energy2, agl;
            if (textBox3.Text.ToString() != "" && textBox6.Text.ToString() != "" &&
               comboBox4.SelectedIndex != -1 && comboBox5.SelectedIndex != -1)
            {
                energy1 = double.Parse(textBox3.Text.ToString());
                energy2 = double.Parse(textBox6.Text.ToString());
                type1 = comboBox4.SelectedIndex + 1;
                type2 = comboBox5.SelectedIndex + 1;
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
            double energy1;
            if(textBox7.Text=="")//没有输入温度默认20度
            {
                name1 = comboBox1.SelectedItem.ToString();
                energy1 = Database.Energy(name1, 20);
                type1 = Database.Type(name1);
                textBox3.Text = energy1.ToString();
                comboBox4.SelectedIndex = type1 - 1;
            }
            else if(textBox7.Text != "" && int.Parse(textBox7.Text) >= 20 && int.Parse(textBox7.Text) <= 3000)//输入了20度到3000度之间的温度
            {
                name1 = comboBox1.SelectedItem.ToString();
                //temp = int.Parse(comboBox3.SelectedItem.ToString());
                temp = int.Parse(textBox7.Text);
                energy1 = Database.Energy(name1, temp);
                type1 = Database.Type(name1);
                textBox3.Text = energy1.ToString();
                comboBox4.SelectedIndex = type1 - 1;
            }
            else
            {
                MessageBox.Show("请先输入20-3000摄氏度之间的温度");
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)//选中物质2
        {
            int type2, temp;
            string name2;
            double energy2;

            if (textBox7.Text == "")//没有输入温度默认20度
            {
                name2 = comboBox2.SelectedItem.ToString();
                energy2 = Database.Energy(name2, 20);
                type2 = Database.Type(name2);
                textBox6.Text = energy2.ToString();
                comboBox5.SelectedIndex = type2 - 1;
            }
            else if (textBox7.Text != ""&&int.Parse(textBox7.Text)>=20&&int.Parse(textBox7.Text)<=3000)
            { 
                name2 = comboBox2.SelectedItem.ToString();
                temp = int.Parse(textBox7.Text);
                energy2 = Database.Energy(name2, temp);
                type2 = Database.Type(name2);
                textBox6.Text = energy2.ToString();
                comboBox5.SelectedIndex = type2 - 1;
            }
            else
            {
                MessageBox.Show("请先输入20-3000摄氏度之间的温度");
            }
        }
        private void Text_Changed(object sender,EventArgs e)
        {
            if(comboBox1.SelectedIndex!=-1) comboBox1_SelectedIndexChanged(sender, e);
            if(comboBox2.SelectedIndex!=-1) comboBox2_SelectedIndexChanged(sender, e);
        }
    }
}
