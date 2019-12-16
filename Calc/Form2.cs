using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Calc
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        
        string name, sex;
        int age,temp;
        double w, h, k;
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Учеба\ЛМВз\Calc\Calc\Database1.mdf;Integrated Security=True";

        private void metroButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connStr;

            int cal = 0;
            switch (listBox1.SelectedItem.ToString())
            {
                case "Хлеб":
                    cal = 1 * Convert.ToInt32(metroTextBox1.Text);
                    break;
                case "Овсянная каша":
                    cal = 2 * Convert.ToInt32(metroTextBox1.Text);
                    break;
                case "Рисовая каша":
                    cal = Convert.ToInt32(1.5 * Convert.ToInt32(metroTextBox1.Text));
                    break;
                case "Картошка пюре":
                    cal = Convert.ToInt32(1.3 * Convert.ToInt32(metroTextBox1.Text));
                    break;
            }
            SqlCommand cmd = new SqlCommand($"insert into [Table] (food,number) values (N'{listBox1.SelectedItem.ToString()}',{cal})", con);
            con.Open();

            cmd.ExecuteNonQuery();
            this.tableTableAdapter.Fill(this.database1DataSet.Table);
            metroGrid1.Refresh();
            MessageBox.Show("аа");
            con.Close();
            int sum = 0;
            foreach (DataGridViewRow Row in metroGrid1.Rows)
            {
                sum += Convert.ToInt32(Row.Cells[1].Value);
            }
            metroLabel9.Text = sum.ToString() + " калл.";
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connStr;

            int cal = 0;
            switch (listBox2.SelectedItem.ToString())
            {
                case "Приседания":
                    cal = Convert.ToInt32(0.4 * Convert.ToInt32(metroTextBox2.Text));
                    break;
                case "Отжимания":
                    cal = Convert.ToInt32(0.3 * Convert.ToInt32(metroTextBox2.Text));
                    break;
                case "Скручивания":
                    cal = Convert.ToInt32(0.2 * Convert.ToInt32(metroTextBox2.Text));
                    break;

            }
            SqlCommand cmd = new SqlCommand($"insert into [Table2] (exercise,number) values (N'{listBox2.SelectedItem.ToString()}',{cal})", con);
            con.Open();

            cmd.ExecuteNonQuery();
            this.table2TableAdapter.Fill(this.database1DataSet.Table2);
            metroGrid1.Refresh();
            con.Close();
            int sum = 0;
            foreach (DataGridViewRow Row in metroGrid2.Rows)
            {
                sum += Convert.ToInt32(Row.Cells[1].Value);
            }
            metroLabel11.Text = sum.ToString() + " калл.";
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = @"with t1 (sum1) as (
select sum(number) from[table]
),
t2(sum2) as (
select sum(number)from[table2]
)
select sum1-sum2 from t1, t2";
            SqlCommand comand = new SqlCommand(sql, conn);
            string name = comand.ExecuteScalar().ToString();

            if (temp > Convert.ToDouble(name))
            {
                DialogResult res = MetroFramework.MetroMessageBox.Show(this, $"Ваши калории за день - {name}. Нужные каллории - {temp}\n Вы потребили на {temp - Convert.ToDouble(name)} меньше каллорий чем нужно. Хороший результат!\nЗакончить день и стереть данные?", "УРА!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, 150);
                if (res == DialogResult.OK)
                {
                    sql = "delete from [table];delete from [table2]";
                    comand = new SqlCommand(sql, conn);
                    comand.ExecuteNonQuery();
                    try
                    {
                        sql = $"insert into [table3] values (GETDATE(),{Convert.ToInt32(name)})";
                        comand = new SqlCommand(sql, conn);
                        comand.ExecuteNonQuery();
                    }
                    catch (Exception ex) {
                        MessageBox.Show("Вы уже добавили данные сегодня!","Ошибка!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        
                    }
                    this.tableTableAdapter.Fill(this.database1DataSet.Table);
                    this.table2TableAdapter.Fill(this.database1DataSet.Table2);
                }
            }
            else
            {
                DialogResult res = MetroFramework.MetroMessageBox.Show(this, $"Ваши калории за день - {name}. Нужные каллории - {temp}\n Вы потребили на { Convert.ToDouble(name) - temp} больше каллорий чем нужно. День прошел зря.\nЗакончить день и стереть данные?", "УРА!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, 150);
                if (res == DialogResult.OK)
                {
                    sql = "delete from [table];delete from [table2]";
                    comand = new SqlCommand(sql, conn);
                    comand.ExecuteNonQuery();
                    MessageBox.Show((Convert.ToInt32(name) - Convert.ToInt32(temp)).ToString());
                    sql = $"insert into [table3] values (GETDATE(),{Convert.ToInt32(name)})";
                    comand = new SqlCommand(sql, conn);
                    comand.ExecuteNonQuery();
                    this.tableTableAdapter.Fill(this.database1DataSet.Table);
                    this.table2TableAdapter.Fill(this.database1DataSet.Table2);
                }
            }
            conn.Close();
        }

        private void metroTextBox3_Click(object sender, EventArgs e)
        {

        }


        private void metroTextBox3_TextChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < listBox1.Items.Count; i++)
            {



                if (listBox1.Items[i].ToString().ToUpper().Contains(metroTextBox3.Text.ToUpper()))
                {
                    listBox1.SelectedIndex = i;


                    break;
                }

            }
        }

        private void metroTextBox4_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox2.Items.Count; i++)
            {



                if (listBox2.Items[i].ToString().ToUpper().Contains(metroTextBox4.Text.ToUpper()))
                {
                    listBox2.SelectedIndex = i;


                    break;
                }

            }
        }

        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4(1);
            f.ShowDialog();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            Form4 f2 = new Form4(2);
            f2.ShowDialog();
        }

        private void metroLabel18_Click(object sender, EventArgs e)
        {

        }

        private void metroPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroLabel22_Click(object sender, EventArgs e)
        {

        }

        private void metroPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3(temp);
            f.ShowDialog();
        }

        public Form2(string name, string sex, int age, double w, double h, double k)
        {
            InitializeComponent();
            this.name = name;
            this.sex = sex;
            this.age = age;
            this.w = w;
            this.h = h;
            this.k = k;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Table2". При необходимости она может быть перемещена или удалена.
            this.table2TableAdapter.Fill(this.database1DataSet.Table2);
            //дите TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Table". При необходимости она может быть перемещена или удалена.
            this.tableTableAdapter.Fill(this.database1DataSet.Table);
            temp = sex == "М" ? Convert.ToInt32((66.47 + (13.75 * w) + (5 * h) - (6.76 * age)) * k) : Convert.ToInt32((655.1 + (9.56 * w) + (1.85 * h) - (4.68 * age)) * k);
            metroLabel1.Text = $"Для поддержания веса {temp} каллорий ";
            metroLabel18.Text = $"Для сброса веса {temp*0.8} каллорий";
            int sum = 0;
            foreach (DataGridViewRow Row in metroGrid1.Rows)
            {
                sum += Convert.ToInt32(Row.Cells[1].Value);
            }
            metroLabel9.Text = sum.ToString() + " калл.";
            sum = 0;
            foreach (DataGridViewRow Row in metroGrid2.Rows)
            {
                sum += Convert.ToInt32(Row.Cells[1].Value);
            }
            metroLabel11.Text = sum.ToString() + " калл.";
            metroLabel26.Text = name;
            metroLabel27.Text = age.ToString();
            metroLabel28.Text = w.ToString();
        }
    }
}

/* for (int i = 0; i < listBox1.Items.Count; i++)
            {
                
                
                             
                    if (listBox1.Items[i].ToString().ToUpper().Contains(metroTextBox3.Text.ToUpper()))
                    {
                        listBox1.SelectedIndex = i;
                        
                        curSearch = i + 1;
                        break;
                    }
                if (i + 1 == listBox1.Items.Count)
                {
                    curSearch = 0;
                    MessageBox.Show("Поиск окончен");
                }
            }*/
