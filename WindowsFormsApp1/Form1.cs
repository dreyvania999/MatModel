using System;
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

            double det=1;
            int RowAm = sizeMatrix;
            double[,] MatrixCoef = new double[RowAm, RowAm];
            double Multi1, Multi2;
            

            for (int i = 0; i < RowAm; i++)
            {
                for (int j = 0; j < RowAm; j++)
                {
                    MatrixCoef[i, j] = matrix[i, j];
                }

            }


            for (int k = 0; k < RowAm; k++)
            {
                for (int j = k + 1; j < RowAm; j++)
                {
                    Multi1 = MatrixCoef[j, k] / MatrixCoef[k, k];
                    for (int i = k; i < RowAm; i++)
                    {
                        MatrixCoef[j, i] = MatrixCoef[j, i] - Multi1 * MatrixCoef[k, i];
                    }
                }
            }
            for (int i = 0; i < RowAm; i++)
            {
                det *= MatrixCoef[i, i];

            }
            
            
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


    }

}
