using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Массивы_16._06__1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] mas = new int[50];
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Эл. массива", "Эл. массива");
            dataGridView1.Rows.Add(50);
            Random r = new Random();
            for(int i = 0; i < mas.Length; i++)
            {
                mas[i] = r.Next(-20, 20);
                dataGridView1.Rows[i].Cells[0].Value = mas[i];
            }
        }
    }
}
