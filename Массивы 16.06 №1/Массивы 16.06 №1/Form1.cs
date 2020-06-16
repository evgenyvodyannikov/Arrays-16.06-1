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
        int[] mas;
        int start;
        int end;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("Эл. массива", "Эл. массива");
                dataGridView1.Rows.Add(int.Parse(tB3.Text));
                Random r = new Random();
                mas = new int[int.Parse(tB3.Text)];
                start = int.Parse(tB1.Text);
                end = int.Parse(tB2.Text);
                for (int i = 0; i < mas.Length; i++)
                {
                    mas[i] = r.Next(start, end);
                    dataGridView1.Rows[i].Cells[0].Value = mas[i];
                }
                button2.Enabled = true;
            }
            catch { 
                if (start > end)
                    MessageBox.Show("Начало диапазона должно быть меньше конца", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                MessageBox.Show("Введите данные для создания массива!!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int k = 1;
            int max = 0;
            for (int i = 1; i < mas.Length; i++)
            {
                if(mas[i-1] == mas[i])
                { k++; }
                else
                { k = 1; }
                if(k > max)
                { max = k;}    
            }
            MessageBox.Show("Длина цепочки повторяющихся элементов равна " + max.ToString(), "Ответ:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                if (tb.Text.Length == 3 && tb.Text.Length <= 3)
                {
                    e.Handled = true;
                }
                return;
            }
            if (e.KeyChar == '-')
            {
                if ((tB1.Text.IndexOf('-') != -1) || (tB1.Text.Length == 1))
                {
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }
            }
            e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            try
            {
                switch (tb.Name)
                {
                    case "tB1":
                        { 
                            if (int.Parse(tB1.Text) < -50) tB1.Text = "-50";
                            if (int.Parse(tB1.Text) >  50) tB1.Text = "50";
                            if (int.Parse(tB1.Text) > int.Parse(tB2.Text)) tB1.Text = (int.Parse(tB2.Text) - 1).ToString();
                        }
                        break;
                    case "tB2":
                        {
                            if (int.Parse(tB2.Text) > 50) tB2.Text = "50";
                            if (int.Parse(tB1.Text) < -50) tB1.Text = "-50";
                        }
                        break;
                    case "tB3":
                        { if (int.Parse(tB3.Text) > 250) tB3.Text = "250"; }
                        break;
                }
            }
            catch { }
        }
    }
}
