using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace calculate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        [DllImport("findit.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static double energy(int Name1, int temperature);
        [DllImport("findit.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int type(int Name1, int temperature);
        [DllImport("findit.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static double cal(int type1, double energy1, int type2, double energy2);
        [DllImport("findit.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int plane(int type1, double energy1, int type2, double energy2);
        [DllImport("findit.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int plane1(int type);
        [DllImport("findit.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static double angle(int type1, double energy1, int type2, double energy2);
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int  t,type1,type2;
            double s,energy1,energy2,agl;
            if ( textBox3.Text.ToString() != "" && textBox6.Text.ToString() != "" &&
               comboBox4.SelectedIndex != -1 && comboBox5.SelectedIndex != -1)
            {
                energy1 = double.Parse(textBox3.Text.ToString());
                energy2 = double.Parse(textBox6.Text.ToString());
                type1 = comboBox4.SelectedIndex + 1;
                type2 = comboBox5.SelectedIndex + 1;
                s = cal(type1, energy1, type2, energy2);
                s = s * 100;
                s = Math.Round(s, 2, MidpointRounding.AwayFromZero);
                agl = angle(type1, energy1, type2, energy2);
                t = plane(type1, energy1, type2, energy2);
                textBox5.Text = s.ToString();
                textBox1.Text = t.ToString();
                textBox4.Text = agl.ToString();
                if (plane1(type1) == 100)
                    textBox2.Text = (plane1(type1)).ToString();
                else
                    textBox2.Text = "0334";
            }
            else
            {
                MessageBox.Show("请选择或输入所要求的参数");
            }
     
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int name1, type1, temp;
            double energy1;    
            if (comboBox3.SelectedItem!=null)
            {   
                 name1 = comboBox1.SelectedIndex + 1;    
                temp = int.Parse(comboBox3.SelectedItem.ToString());
                energy1 = energy(name1, temp);
                type1 = type(name1, temp);
                textBox3.Text = energy1.ToString();
                comboBox4.SelectedIndex = type1 - 1;

            }
            else
            {
                MessageBox.Show("请先选择温度");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int name2, type2, temp;
            double energy2;
            
            if (comboBox3.SelectedItem != null)
            {
                name2 = comboBox2.SelectedIndex + 1;
                temp = int.Parse(comboBox3.SelectedItem.ToString());
                energy2 = energy(name2, temp);
                type2 = type(name2, temp);
                textBox6.Text = energy2.ToString();
                comboBox5.SelectedIndex = type2 - 1;
            }
            else
            {
                MessageBox.Show("请先选择温度");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1) comboBox1_SelectedIndexChanged(sender, e);
            if (comboBox2.SelectedIndex != -1) comboBox2_SelectedIndexChanged(sender, e);
        }
    }
}
