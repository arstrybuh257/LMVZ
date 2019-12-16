using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class Form5 : MetroFramework.Forms.MetroForm
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            int res;
            bool ok = true;
            double x = 0;
            switch (metroComboBox2.SelectedIndex)
            {
                case 0:
                    x = 1.2;
                    break;
                case 1:
                    x = 1.375;
                    break;
                case 2:
                    x = 1.55;
                    break;
                case 3:
                    x = 1.725;
                    break;
                case 4:
                    x = 1.9;
                    break;
            }
            if (!Int32.TryParse(metroTextBox2.Text, out res))
            {
                MessageBox.Show("Введите корректный возраст (0-100 лет)!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            if (!Int32.TryParse(metroTextBox3.Text, out res))
            {
                MessageBox.Show("Введите корректный вес (0-200 кг)!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            if (!Int32.TryParse(metroTextBox4.Text, out res))
            {
                MessageBox.Show("Введите корректный рост!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            if (ok)
            {
                Form2 f = new Form2("examle", metroComboBox1.SelectedItem.ToString(),
                    Convert.ToInt32(metroTextBox2.Text), Convert.ToDouble(metroTextBox3.Text),
                    Convert.ToDouble(metroTextBox4.Text), x);
                f.Show();
                Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            ToolTip t2 = new ToolTip();
            t2.SetToolTip(metroTextBox2, "Сколько вам лет?");
            t2.SetToolTip(label5, "Сколько вам лет?");
            ToolTip t3 = new ToolTip();
            t3.SetToolTip(metroTextBox3, "Сколько вы сейчас весите(килограмм)?");
            t3.SetToolTip(label2, "Сколько вы сейчас весите(килограмм)?");
            ToolTip t4 = new ToolTip();
            t4.SetToolTip(metroTextBox4, "Ваш рост на данный момент(сантиметров)");
            t4.SetToolTip(label9, "Ваш рост на данный момент(сантиметров)");
            //ToolTip t5 = new ToolTip();
            //t5.SetToolTip(metroComboBox2, "Минимальный - не занимаетесь физ.активностью\nНизкий - физ.активность 1 раз в неделю\nСредний - физ.активность 2-5 раза в неделю\nВысокий - физ.активность 5-7 раз в неделю\nОчень высокий - физ.активность больше 1 раза каждый день");
            //t5.SetToolTip(metroLabel6, "Минимальный - не занимаетесь физ.активностью\nНизкий - физ.активность 1 раз в неделю\nСредний - физ.активность 2-5 раза в неделю\nВысокий - физ.активность 5-7 раз в неделю\nОчень высокий - физ.активность больше 1 раза каждый день");

        }
    }
}
