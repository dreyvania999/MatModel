using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static int sizeMatrix;
        public Form1()
        {

            InitializeComponent();
            MessageBox.Show(
                        "Найти определитель матрицы методом Гаусса",
                        "Сообщение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text)>=2)
            {
sizeMatrix = Convert.ToInt32(textBox1.Text);
            dataGridView1.ColumnCount = sizeMatrix;
            dataGridView1.RowCount = sizeMatrix;
            dataGridView1.AutoResizeColumns();
            }
            else
            {
                
                    MessageBox.Show(
                        "Вы ввели размерность меньше 2",
                        "Сообщение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double kst;
            double[,] a = new double[sizeMatrix, sizeMatrix];
            for (int i = 0; i < sizeMatrix; i++)
            {
                for (int j = 0; j < sizeMatrix; j++)
                {
                    a[i, j] = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value);
                }
            }
            textBox2.Text = Convert.ToString(GetDeterminant(a));
        }

        static public double GetDeterminant(double[,] matrix)
        {

            int i, j, p, k = 0;


            double det = 1;
            
            //подсчет методом гаусса 
            for (p = 0; p < sizeMatrix; p++)
            {
                for (j = p + 1; j < sizeMatrix; j++) //цикл по строкам 
                {
                    double Mult = matrix[j, p] / matrix[p, p];
                    for (i = p; i < sizeMatrix; i++) //цикл по столбцам 
                    {
                        matrix[j, i] = matrix[j, i] - Mult * matrix[p, i];
                    }
                }
            }

            for (p = 0; p < sizeMatrix; p++)
            {
                for (j = p + 1; j < sizeMatrix; j++) //цикл по строкам 
                {
                    p++;
                    det = det * matrix[j, p];
                }
            }
            det *= matrix[0, 0]; //нахождение определителя 

          
            return det;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < sizeMatrix; i++)
            {
                for (int j = 0; j < sizeMatrix; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = random.Next(-1, 20);
                }
            }
        }

        private void tb(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void fff(object sender, DataGridViewCellValidatingEventArgs e)
        {

            const string disallowed = @"[^0-9-]";
            var newText = Regex.Replace(e.FormattedValue.ToString(), disallowed, string.Empty);
            dataGridView1.Rows[e.RowIndex].ErrorText = "";
            if (dataGridView1.Rows[e.RowIndex].IsNewRow) return;
            if (string.CompareOrdinal(e.FormattedValue.ToString(), newText) == 0) return;
            e.Cancel = true;
            dataGridView1.Rows[e.RowIndex].ErrorText = "Некорректный символ!";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            sizeMatrix = Convert.ToInt32(textBox1.Text);
            dataGridView1.ColumnCount = sizeMatrix;
            dataGridView1.RowCount = sizeMatrix;
            dataGridView1.AutoResizeColumns();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

}
