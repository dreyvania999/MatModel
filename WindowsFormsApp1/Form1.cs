using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static int sizeMatrix;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sizeMatrix = Convert.ToInt32(textBox1.Text);
            dataGridView1.ColumnCount = sizeMatrix;
            dataGridView1.RowCount = sizeMatrix;
            dataGridView1.AutoResizeColumns();

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
           
            // Если матрица 2*2, то возвращаем определитель по формуле Крамера
            if (matrix.GetLength(0) == 2)
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            int sign = 1;//Знак минора
            double result = 0;
            int j = 0;//Номер столбца, по которому раскладывается матрица
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                // Если номер столбца и строки одновременно чётные, то знак будет «+», иначе — «-»
                sign = ((i + 1) % 2 == (j + 1) % 2) ? 1 : -1;
                result += sign * matrix[i, j] * GetDeterminant(GetMinorMatrix(matrix, i, j));
            }
            return result;
        }

        static int minorN, minorM;

        static double[,] minor;

        private void button3_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < sizeMatrix; i++)
            {
                for (int j = 0; j < sizeMatrix; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = random.Next(-1,20) ;
                }
            }
        }

        static public double[,] GetMinorMatrix(double[,] matrix, int row, int col)
        {
            minorN = matrix.GetLength(0) - 1;// уменьшаем размер матрицы
            minorM = matrix.GetLength(1) - 1;
            double[,] result = new double[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            int m = 0, k;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == row) continue;
                k = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == col) continue;
                    result[m, k++] = matrix[i, j];
                }
                m++;
            }
            minor = result;
            return result;
        }
    }

}
