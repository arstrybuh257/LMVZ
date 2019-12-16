using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Calc
{
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Учеба\ЛМВз\Calc\Calc\Database1.mdf;Integrated Security=True";
        public Form3(int temp)
        {
            
            InitializeComponent();
           
            chart1.Series[0].BorderWidth = 5;
            chart1.Series[1].BorderWidth = 2;
            chart1.Series[1].ChartType = SeriesChartType.Line;

            Axis ax = new Axis();
            ax.Title = "Дни";
            chart1.ChartAreas[0].AxisX = ax;
            Axis ay = new Axis();
            ay.Title = "Калории от нормы";
           
            chart1.ChartAreas[0].AxisY = ay;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = @"select * from [table3]";
            SqlCommand comand = new SqlCommand(sql, conn);
            var reader = comand.ExecuteReader();
            chart1.ChartAreas[0].AxisY.Maximum = 3600;
            chart1.ChartAreas[0].AxisY.Minimum = 1000;
            while (reader.Read())
            {
                
                string x = reader.GetDateTime(0).ToString().Substring(0,6);
                int y = reader.GetInt32(1);
                
                chart1.Series[0].Points.AddXY(x, y);
                chart1.Series[1].Points.AddXY(x, temp);
                

            }

        }
    }
}
