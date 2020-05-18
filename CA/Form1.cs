using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            //TEST; TEST 2
            InitializeComponent();
        }

        static int N = 100;
        Random rand = new Random();
        bool cl;
        Graphics g, g1, g2, g3;
        int count = 1, V = 1, sh = 1, T, qu = 1000;
            double R = 8.31,
            E1 = 76000.0, // энергия связи (активации), Дж/моль
            E2 = 355000.0,
            E3 = 347000.0,
            E4 = 67000.0,
            E5 = -28000.0,
            E6 = 104000.0,
            kb = 1.38 * Math.Pow(10, -23), // постоянная Больцмана, определяющая связь между температурой и энергией, Дж/К
            P, p1, p2,
            kk = Math.Pow(10, 13), //? 10 в 13 степени
            n, n1, n2,nn1,nn2,K1,K2,K3,K4,K5,K6,
            percent;

        Cell[,,] cell = new Cell[N, N, N];
        Boolean f;

        #region
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        #endregion

        public void firstStep()
        {
            count = 0;
            pictureBox1.Refresh();
            pictureBox2.Refresh();
            pictureBox3.Refresh();
            pictureBox4.Refresh();
            label1.Text = "Step  " + count++;
            int i, j,k;

            for (i = 0; i < N; i++)
                for (j = 0; j < N; j++)
                    for (k = 0; k < N; k++)
                        cell[i, j,k] = new Cell(0);
            for (i = 1; i < N - 1; i++)
                for (j = 1; j < N - 1; j++)
                {
                    cell[i, j, 0].a = 1;
                    //cell[i, j, 0].a = 7;
                }
        }
        
        public void nextStep()
        {
            int i, j, k;
            for (i = 1; i < N - 1; i++)
                for (j = 1; j < N - 1; j++)
                    for (k = 0; k < N - 1; k++)
                    {
                        cellDestiny(cell, i, j, k);
                    }

        }
        
        public void cellDestiny(Cell[,,] cell, int i, int j, int k)
        {
            int q;
            int p = Convert.ToInt32(Math.Pow(-1.0, i % 2));
            //1-h
            if (cell[i, j, k].a == 1)
            {
                q = rand.Next(qu); // Возвращает неотрицательное случайное целое число, которое меньше указанного максимального значения. qu = 1000
                if (q < K1)
                {
                    cell[i, j, k].a = 2;
                    concentrate(n1, E1, nn1, K1);
                }

                if (cell[i, j + 1, k].a == 1)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 5;

                        cell[i, j + 1, k].a = 5;

                        concentrate(n1, E5, nn1, K5);
                    }

                }
                if (cell[i, j - 1, k].a == 1)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 5;

                        cell[i, j - 1, k].a = 5;

                        concentrate(n1, E5, nn1, K5);
                    }

                }
                if (cell[i + 1, j - p, k].a == 1)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 5;

                        cell[i + 1, j - p, k].a = 5;

                        concentrate(n1, E5, nn1, K5);
                    }
                }
                if (cell[i - 1, j - p, k].a == 1)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 5;
                        cell[i - 1, j - p, k].a = 5;

                        concentrate(n1, E5, nn1, K5);
                    }
                }
                if (cell[i, j - 1, k].a == 1)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 5;

                        cell[i, j - 1, k].a = 5;

                        concentrate(n1, E5, nn1, K5);
                    }
                }
                if (cell[i - 1, j + i % 2 - 1, k].a == 1)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 5;

                        cell[i - 1,j +i % 2 - 1, k].a = 5;

                        concentrate(n1, E5, nn1, K5);
                    }
                }
                if (cell[i + 1, j+ i% 2 - 1, k].a == 1)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 5;

                        cell[i + 1, j + i % 2 - 1, k].a = 5;

                        concentrate(n1, E5, nn1, K5);
                    }
                }
            }
            //2-*
            if (cell[i, j, k].a == 2)
            {
                q = rand.Next(qu);
                if (q < K2)
                {
                    cell[i, j, k].a = 1;
                    concentrate(n1, E2, nn1, K2);
                }
                if (q < K3)
                {
                    cell[i, j, k].a = 3;
                    concentrate(n2, E3, nn2, K3);
                }
            }
            //3-ch3
            if (cell[i, j, k].a == 3)
            {
                q = rand.Next(qu);
                if (q < K4)
                {
                    cell[i, j, k].a = 2;
                    concentrate(n2, E4, nn2, K4);
                }

                if (cell[i, j + i % 2 - 1, k].a == 2)
                {
                    q = rand.Next(qu);
                    if (q < K2)
                    {
                        cell[i, j, k].a = 4;
                        cell[i, j + i % 2 - 1, k].a = 1;
                        concentrate(n1, E1, nn1, K1);
                        concentrate(n1, E2, nn1, K2);
                    }
                }
                if (cell[i + 1, j - p, k].a == 2)
                {
                    q = rand.Next(qu);
                    if (q < K2)
                    {
                        cell[i, j, k].a = 4;
                        cell[i + 1, j - p, k].a = 1;
                        concentrate(n1, E1, nn1, K1);
                        concentrate(n1, E2, nn1, K2);
                    }
                   
                }
                if (cell[i - 1, j - p, k].a == 2)
                {
                    q = rand.Next(qu);
                    if (q < K2)
                    {
                        cell[i, j, k].a = 4;
                        cell[i - 1, j - p, k].a = 1;
                        concentrate(n1, E1, nn1, K1);
                        concentrate(n1, E2, nn1, K2);
                    }
                }
                if (cell[i, j - 1, k].a == 2)
                {
                    q = rand.Next(qu);
                    if (q < K2)
                    {
                        cell[i, j, k].a = 4;
                        concentrate(n1, E1, nn1, K1);
                        cell[i, j - 1, k].a = 1;
                        concentrate(n1, E2, nn1, K2);
                    }
                }
                if (cell[i - 1, j + i % 2 - 1, k].a == 2)
                {
                    q = rand.Next(qu);
                    if (q < K2)
                    {
                        cell[i, j, k].a = 4;
                        cell[i - 1, j + i % 2 - 1, k].a = 1;
                        concentrate(n1, E1, nn1, K1);
                        concentrate(n1, E2, nn1, K2);
                    }
                }
                if (cell[i + 1, j + i % 2 - 1, k].a == 2)
                {
                    q = rand.Next(qu);
                    if (q < K2)
                    {
                        cell[i, j, k].a = 4;
                        cell[i + 1, j + i % 2 - 1, k].a = 1;
                        concentrate(n1, E1, nn1, K1);
                        concentrate(n1, E2, nn1, K2);
                    }
                }

                if (cell[i, j + 1, k].a == 4)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 4;
                        cell[i, j + 1, k].a = 6;
                        concentrate(n1, E5, nn1, K5);
                    }
                }
                if (cell[i + 1, j - p, k].a == 4)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 4;
                        cell[i + 1, j - p, k].a = 6;
                        concentrate(n1, E5, nn1, K5);
                    }
                }
                if (cell[i - 1, j - p, k].a == 4)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 4;
                        cell[i - 1, j - p, k].a = 6;
                        concentrate(n1, E5, nn1, K5);
                    }
                }
                if (cell[i, j - 1, k].a == 3)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 4;
                        cell[i, j - 1, k].a = 6;
                        concentrate(n1, E5, nn1, K5);
                    }
                }
                if (cell[i - 1, j + i % 2 - 1, k].a == 4)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 4;
                        cell[i - 1, j + i % 2 - 1, k].a = 6;
                        concentrate(n1, E5, nn1, K5);
                    }
                }
                if (cell[i + 1, j + i % 2 - 1, k].a == 4)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 4;
                        cell[i + 1, j + i % 2 - 1, k].a = 6;
                        concentrate(n1, E5, nn1, K5);
                    }
                }

                if (cell[i, j + 1, k].a == 3)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 4;
                        cell[i, j + 1, k].a = 4;
                        concentrate(n1, E5, nn1, K5);
                    }
                }
                if (cell[i + 1, j - p, k].a == 3)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 4;
                        cell[i + 1, j - p, k].a = 4;
                        concentrate(n1, E5, nn1, K5);
                    }
                }
                if (cell[i - 1, j - p, k].a == 3)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 4;
                        cell[i - 1, j - p, k].a = 4;
                        concentrate(n1, E5, nn1, K5);
                    }
                }
                if (cell[i, j - 1, k].a == 3)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 4;
                        cell[i, j - 1, k].a = 4;
                        concentrate(n1, E5, nn1, K5);
                    }
                }
                if (cell[i - 1, j + i % 2 - 1, k].a == 3)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 4;

                        cell[i - 1, j + i % 2 - 1, k].a = 4;

                        concentrate(n1, E5, nn1, K5);
                    }
                }
                if (cell[i + 1, j + i % 2 - 1, k].a == 3)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 4;

                        cell[i + 1, j + i % 2 - 1, k].a = 4;

                        concentrate(n1, E5, nn1, K5);
                    }
                }

            }
            //4-ch2
            if (cell[i, j, k].a == 4)
            {
                q = rand.Next(qu);
                if (q < K2)
                {
                    cell[i, j, k].a = 3;
                    concentrate(n1, E2, nn1, K2);
                }
                if (q < K4)
                {
                    cell[i, j, k].a = 2;
                    concentrate(n2, E4, nn2, K4);
                }
                if (cell[i, j + i % 2 - 1, k].a == 2)
                {
                    q = rand.Next(qu);
                    if (q < K2)
                    {
                        cell[i, j, k].a = 6;
                        cell[i, j + i % 2 - 1, k].a = 1;
                        concentrate(n1, E1, nn1, K1);
                        concentrate(n1, E2, nn1, K2);
                    }
                }
                if (cell[i + 1, j - p, k].a == 2)
                {
                    q = rand.Next(qu);
                    if (q < K2)
                    {
                        cell[i, j, k].a = 6;
                        cell[i + 1, j - p, k].a = 1;
                        concentrate(n1, E1, nn1, K1);
                        concentrate(n1, E2, nn1, K2);
                    }

                }
                if (cell[i - 1, j - p, k].a == 2)
                {
                    q = rand.Next(qu);
                    if (q < K2)
                    {
                        cell[i, j, k].a = 6;
                        cell[i - 1, j - p, k].a = 1;
                        concentrate(n1, E1, nn1, K1);
                        concentrate(n1, E2, nn1, K2);
                    }
                }
                if (cell[i, j - 1, k].a == 2)
                {
                    q = rand.Next(qu);
                    if (q < K2)
                    {
                        cell[i, j, k].a = 6;
                        cell[i, j - 1, k].a = 1;
                        concentrate(n1, E2, nn1, K2);
                        concentrate(n1, E1, nn1, K1);
                    }
                }
                if (cell[i - 1, j + i % 2 - 1, k].a == 2)
                {
                    q = rand.Next(qu);
                    if (q < K2)
                    {
                        cell[i, j, k].a = 6;
                        cell[i - 1, j + i % 2 - 1, k].a = 1;
                        concentrate(n1, E1, nn1, K1);
                        concentrate(n1, E2, nn1, K2);
                    }
                }
                if (cell[i + 1, j + i % 2 - 1, k].a == 2)
                {
                    q = rand.Next(qu);
                    if (q < K2)
                    {
                        cell[i, j, k].a =6;
                        cell[i + 1, j + i % 2 - 1, k].a = 1;
                        concentrate(n1, E1, nn1, K1);
                        concentrate(n1, E2, nn1, K2);
                    }
                }

                if (cell[i, j + 1, k].a == 4)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 6;
                        cell[i, j + 1, k].a = 6;
                        concentrate(n1, E5, nn1, K5);
                    }
                    q = rand.Next(qu);
                    if (q < K3)
                    {
                        if (cell[i - 1, j + i % 2 - 1, k].a == 2)
                        {
                            cell[i, j, k].a = 2;
                            cell[i - 1, j + i % 2 - 1, k].a = 4;
                        }
                       else if (cell[i + 1, j + i % 2 - 1, k].a == 2)
                        {
                            cell[i, j, k].a = 2;
                            cell[i + 1, j + i % 2 - 1, k].a = 4;
                        }
                    }
                }
                if (cell[i + 1, j - p, k].a == 4)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 6;
                        cell[i + 1, j - p, k].a = 6;
                        concentrate(n1, E5, nn1, K5);
                    }
                    q = rand.Next(qu);
                    if (q < K3)
                    {
                        if (cell[i, j - 1, k].a == 2)
                        {
                            cell[i, j - 1, k].a = 4;
                            cell[i, j, k].a = 2;
                        }

                        else if (cell[i + 1, j + i % 2 - 1, k].a == 2)
                        {
                            cell[i + 1, j + i % 2 - 1, k].a = 4;
                            cell[i, j, k].a = 2;
                        }
                    }
                }
                if (cell[i - 1, j - p, k].a == 4)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 6;
                        cell[i - 1, j - p, k].a = 6;
                        concentrate(n1, E5, nn1, K5);
                    }
                    q = rand.Next(qu);
                    if (q < K3)
                    {
                        if (cell[i, j - 1, k].a == 2)
                        {
                            cell[i, j - 1, k].a = 4;
                            cell[i, j, k].a = 2;
                        }
                        else if(cell[i - 1, j + i % 2 - 1, k].a == 2)
                        {
                            cell[i - 1, j + i % 2 - 1, k].a = 4;
                            cell[i, j, k].a = 2;
                        }
                    }
                }
                if (cell[i, j - 1, k].a == 4)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 6;
                        cell[i, j - 1, k].a = 6;
                        concentrate(n1, E5, nn1, K5);
                    }
                    q = rand.Next(qu);
                    if (q < K3)
                    {
                        if (cell[i - 1, j - p, k].a == 2)
                        {
                            cell[i - 1, j - p, k].a = 4;
                            cell[i, j, k].a = 2;
                        }
                        else if(cell[i + 1, j - p, k].a == 2)
                        {
                            cell[i + 1, j - p, k].a = 4;
                            cell[i, j, k].a = 2;
                        }
                    }
                }
                if (cell[i - 1, j + i % 2 - 1, k].a == 4)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 6;

                        cell[i - 1, j + i % 2 - 1, k].a = 6;

                        concentrate(n1, E5, nn1, K5);
                    }
                    q = rand.Next(qu);
                    if (q < K3)
                    {

                        if (cell[i - 1, j - p, k].a == 2)
                        { cell[i - 1, j - p, k].a = 4;
                            cell[i, j, k].a = 2; }
                        else if(cell[i, j + 1, k].a == 2)
                        {
                            cell[i, j + 1, k].a = 4;
                            cell[i, j, k].a = 2;
                        }
                    }
                }
                if (cell[i + 1, j + i % 2 - 1, k].a == 4)
                {
                    q = rand.Next(qu);
                    if (q < K5)
                    {
                        cell[i, j, k].a = 6;

                        cell[i + 1, j + i % 2 - 1, k].a = 6;

                        concentrate(n1, E5, nn1, K5);
                    }
                    q = rand.Next(qu);
                    if (q < K3)
                    {
                        if (cell[i, j + 1, k].a == 2)
                        {
                            cell[i, j + 1, k].a = 4;
                            cell[i, j, k].a = 2;
                        }
                        else if (cell[i + 1, j - p, k].a == 2)
                        {
                            cell[i + 1, j - p, k].a = 4;
                            cell[i, j, k].a = 2;
                        }
                    }
                }
            }
            //5-=
            if (cell[i, j, k].a == 5)
            {
                q = rand.Next(qu);
                if (q < K6)
                {
                    cell[i, j, k].a = 1;
                    concentrate(n1, E6, nn1, K6);
                }
                if (cell[i, j + i % 2 - 1, k].a != 5 &&
                    cell[i + 1, j - p, k].a != 5 &&
                    cell[i - 1, j - p, k].a != 5 &&
                    cell[i, j - 1, k].a != 5 &&
                    cell[i - 1, j + i % 2 - 1, k].a != 5 &&
                    cell[i + 1, j + i % 2 - 1, k].a != 5)
                {
                    cell[i, j, k].a = 1;
                    concentrate(n1, E2, nn1, K2);
                }
                
            }
            //6-ch1
            if (cell[i, j, k].a == 6)
            {
                q = rand.Next(qu);
                if (q < K2)
                {
                    cell[i, j, k].a = 4;
                    concentrate(n1, E1, nn1, K1);
                }
                if (cell[i, j + 1, k].a == 6)
                {
                    q = rand.Next(qu);
                    if (q < K3)
                    {
                        if (cell[i - 1, j + i % 2 - 1, k].a == 2)
                        {
                            cell[i, j, k].a = 2;
                            cell[i - 1, j + i % 2 - 1, k].a = 6;
                        }
                        else if (cell[i + 1, j + i % 2 - 1, k].a == 2)
                        {
                            cell[i, j, k].a = 2;
                            cell[i + 1, j + i % 2 - 1, k].a = 6;
                        }
                    }
                }
                if (cell[i + 1, j - p, k].a == 6)
                {
                    q = rand.Next(qu);
                    if (q < K3)
                    {
                        if (cell[i, j - 1, k].a == 2)
                        {
                            cell[i, j - 1, k].a = 6;
                            cell[i, j, k].a = 2;
                        }

                        else if (cell[i + 1, j + i % 2 - 1, k].a == 2)
                        {
                            cell[i + 1, j + i % 2 - 1, k].a = 6;
                            cell[i, j, k].a = 2;
                        }
                    }
                }
                if (cell[i - 1, j - p, k].a == 6)
                {
                    q = rand.Next(qu);
                    if (q < K3)
                    {
                        if (cell[i, j - 1, k].a == 2)
                        {
                            cell[i, j - 1, k].a = 6;
                            cell[i, j, k].a = 2;
                        }
                        else if (cell[i - 1, j + i % 2 - 1, k].a == 2)
                        {
                            cell[i - 1, j + i % 2 - 1, k].a = 6;
                            cell[i, j, k].a = 2;
                        }
                    }
                }
                if (cell[i, j - 1, k].a == 6)
                {
                    q = rand.Next(qu);
                    if (q < K3)
                    {
                        if (cell[i - 1, j - p, k].a == 2)
                        {
                            cell[i - 1, j - p, k].a =6;
                            cell[i, j, k].a = 2;
                        }
                        else if (cell[i + 1, j - p, k].a == 2)
                        {
                            cell[i + 1, j - p, k].a = 6;
                            cell[i, j, k].a = 2;
                        }
                    }
                }
                if (cell[i - 1, j + i % 2 - 1, k].a == 6)
                {
                    q = rand.Next(qu);
                    if (q < K3)
                    {

                        if (cell[i - 1, j - p, k].a == 2)
                        {
                            cell[i - 1, j - p, k].a =6;
                            cell[i, j, k].a = 2;
                        }
                        else if (cell[i, j + 1, k].a == 2)
                        {
                            cell[i, j + 1, k].a = 6;
                            cell[i, j, k].a = 2;
                        }
                    }
                }
                if (cell[i + 1, j + i % 2 - 1, k].a == 6)
                {
                    q = rand.Next(qu);
                    if (q < K3)
                    {
                        if (cell[i, j + 1, k].a == 2)
                        {
                            cell[i, j + 1, k].a = 6;
                            cell[i, j, k].a = 2;
                        }
                        else if (cell[i + 1, j - p, k].a == 2)
                        {
                            cell[i + 1, j - p, k].a = 6;
                            cell[i, j, k].a = 2;
                        }
                    }
                }

                if (cell[i - 1, j - p, k].a == 6 && cell[i - 1, j + i % 2 - 1, k].a == 6 ||
                    cell[i - 1, j - p, k].a == 7 && cell[i - 1, j + i % 2 - 1, k].a == 7 ||
                    cell[i - 1, j - p, k].a == 7 && cell[i - 1, j + i % 2 - 1, k].a == 6 ||
                    cell[i - 1, j - p, k].a == 6 && cell[i - 1, j + i % 2 - 1, k].a == 7
                    )
                {
                    if (q < K1)
                    {
                        cell[i, j, k].a = 7;
                        cell[i - 1, j - p, k].a = 7;
                        cell[i - 1, j + i % 2 - 1, k].a = 7;
                        cell[i - 1, j - p, k + 1].a = 1;

                        concentrate(n1, E1, nn1, K1);
                    }
                }

                if (cell[i + 1, j - p, k].a == 6 && cell[i, j - 1, k].a == 6 ||
                     cell[i + 1, j - p, k].a == 7 && cell[i, j - 1, k].a == 7 ||
                     cell[i + 1, j - p, k].a == 6 && cell[i, j - 1, k].a == 7 ||
                     cell[i + 1, j - p, k].a == 7 && cell[i, j - 1, k].a == 6
                    )
                {
                    {
                        if (q < K1)
                        {
                            cell[i, j, k].a = 7;
                            cell[i + 1, j - p, k].a = 7;
                            cell[i, j - 1, k].a = 7;
                            cell[i, j - 1, k + 1].a = 1;

                            concentrate(n1, E1, nn1, K1);
                        }
                    }
                }

                if (cell[i + 1, j - p, k].a == 6 && cell[i, j + 1, k].a == 6 ||
                    cell[i + 1, j - p, k].a == 7 && cell[i, j + 1, k].a == 7 ||
                    cell[i + 1, j - p, k].a == 7 && cell[i, j + 1, k].a == 6 ||
                    cell[i + 1, j - p, k].a == 6 && cell[i, j + 1, k].a == 7)
                {
                    if (q < K1)
                    {

                        cell[i, j, k].a = 7;
                        cell[i + 1, j - p, k].a = 7;
                        cell[i, j + i % 2 - 1, k].a = 7;
                        cell[i, j, k + 1].a = 1;

                        concentrate(n1, E1, nn1, K1);
                    }
                }
            }
        }
    
        void showMatrix()
        {
            g = pictureBox1.CreateGraphics();
            g1 = pictureBox2.CreateGraphics();
            g2 = pictureBox3.CreateGraphics();
            g3 = pictureBox4.CreateGraphics();

            SolidBrush pen = new SolidBrush(Color.Blue);
            SolidBrush pen1 = new SolidBrush(Color.White);
            SolidBrush pen2 = new SolidBrush(Color.DarkGreen);
            SolidBrush pen3 = new SolidBrush(Color.Green);
            SolidBrush pen4 = new SolidBrush(Color.LightGreen);
            SolidBrush pen5 = new SolidBrush(Color.Orange);
            SolidBrush pen6 = new SolidBrush(Color.LightBlue);

            int i, j,k=0,z=0;

            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    if (j % 2 != 0) z = pictureBox1.Width / 3 / N + 1;
                    if (!cl)
                    {
                        if (cell[i, j, k].a == 1)
                            g.FillEllipse(pen, i * pictureBox1.Width / N + z, j * pictureBox1.Width / N, pictureBox1.Width * 2 / 3 / N, pictureBox1.Width * 2 / 3 / N);
                        if (cell[i, j, k].a == 2)
                            g.FillEllipse(pen1, i * pictureBox1.Width / N + z, j * pictureBox1.Width / N, pictureBox1.Width * 2 / 3 / N, pictureBox1.Width * 2 / 3 / N);
                        if (cell[i, j, k].a == 3)
                            g.FillEllipse(pen2, i * pictureBox1.Width / N + z, j * pictureBox1.Width / N, pictureBox1.Width * 2 / 3 / N, pictureBox1.Width * 2 / 3 / N);
                        if (cell[i, j, k].a == 4)
                            g.FillEllipse(pen3, i * pictureBox1.Width / N + z, j * pictureBox1.Width / N, pictureBox1.Width * 2 / 3 / N, pictureBox1.Width * 2 / 3 / N);
                        if (cell[i, j, k].a == 5)
                            g.FillEllipse(pen4, i * pictureBox1.Width / N + z, j * pictureBox1.Width / N, pictureBox1.Width * 2 / 3 / N, pictureBox1.Width * 2 / 3 / N);
                        if (cell[i, j, k].a == 6)
                            g.FillEllipse(pen5, i * pictureBox1.Width / N + z, j * pictureBox1.Width / N, pictureBox1.Width * 2 / 3 / N, pictureBox1.Width * 2 / 3 / N);
                        
                        if (cell[i, j, k + 1].a == 1)
                            g1.FillEllipse(pen, i * pictureBox2.Width / N + z, j * pictureBox2.Width / N, pictureBox2.Width * 2 / 3 / N, pictureBox2.Width * 2 / 3 / N);
                        if (cell[i, j, k + 1].a == 2)
                            g1.FillEllipse(pen1, i * pictureBox2.Width / N + z, j * pictureBox2.Width / N, pictureBox2.Width * 2 / 3 / N, pictureBox2.Width * 2 / 3 / N);
                        if (cell[i, j, k + 1].a == 3)
                            g1.FillEllipse(pen2, i * pictureBox2.Width / N + z, j * pictureBox2.Width / N, pictureBox2.Width * 2 / 3 / N, pictureBox2.Width * 2 / 3 / N);
                        if (cell[i, j, k + 1].a == 4)
                            g1.FillEllipse(pen3, i * pictureBox2.Width / N + z, j * pictureBox2.Width / N, pictureBox2.Width * 2 / 3 / N, pictureBox2.Width * 2 / 3 / N);
                        if (cell[i, j, k + 1].a == 5)
                            g1.FillEllipse(pen4, i * pictureBox2.Width / N + z, j * pictureBox2.Width / N, pictureBox2.Width * 2 / 3 / N, pictureBox2.Width * 2 / 3 / N);
                        if (cell[i, j, k + 1].a == 6)
                            g1.FillEllipse(pen5, i * pictureBox2.Width / N + z, j * pictureBox2.Width / N, pictureBox2.Width * 2 / 3 / N, pictureBox2.Width * 2 / 3 / N);
                        
                        if (cell[i, j, k + 2].a == 1)
                            g2.FillEllipse(pen, i * pictureBox3.Width / N + z, j * pictureBox3.Width / N, pictureBox3.Width * 2 / 3 / N, pictureBox3.Width * 2 / 3 / N);
                        if (cell[i, j, k + 2].a == 2)
                            g2.FillEllipse(pen1, i * pictureBox3.Width / N + z, j * pictureBox3.Width / N, pictureBox3.Width * 2 / 3 / N, pictureBox3.Width * 2 / 3 / N);
                        if (cell[i, j, k + 2].a == 3)
                            g2.FillEllipse(pen2, i * pictureBox3.Width / N + z, j * pictureBox3.Width / N, pictureBox3.Width * 2 / 3 / N, pictureBox3.Width * 2 / 3 / N);
                        if (cell[i, j, k + 2].a == 4)
                            g2.FillEllipse(pen3, i * pictureBox3.Width / N + z, j * pictureBox3.Width / N, pictureBox3.Width * 2 / 3 / N, pictureBox3.Width * 2 / 3 / N);
                        if (cell[i, j, k + 2].a == 6)
                            g2.FillEllipse(pen5, i * pictureBox3.Width / N + z, j * pictureBox3.Width / N, pictureBox3.Width * 2 / 3 / N, pictureBox3.Width * 2 / 3 / N);
                        
                        if (cell[i, j, k + 3].a == 1)
                            g3.FillEllipse(pen, i * pictureBox3.Width / N + z, j * pictureBox3.Width / N, pictureBox3.Width * 2 / 3 / N, pictureBox3.Width * 2 / 3 / N);
                        if (cell[i, j, k + 3].a == 2)
                            g3.FillEllipse(pen1, i * pictureBox3.Width / N + z, j * pictureBox3.Width / N, pictureBox3.Width * 2 / 3 / N, pictureBox3.Width * 2 / 3 / N);
                        if (cell[i, j, k + 3].a == 3)
                            g3.FillEllipse(pen2, i * pictureBox3.Width / N + z, j * pictureBox3.Width / N, pictureBox3.Width * 2 / 3 / N, pictureBox3.Width * 2 / 3 / N);
                        if (cell[i, j, k + 3].a == 4)
                            g3.FillEllipse(pen3, i * pictureBox3.Width / N + z, j * pictureBox3.Width / N, pictureBox3.Width * 2 / 3 / N, pictureBox3.Width * 2 / 3 / N);
                        if (cell[i, j, k + 3].a == 6)
                            g3.FillEllipse(pen5, i * pictureBox3.Width / N + z, j * pictureBox3.Width / N, pictureBox3.Width * 2 / 3 / N, pictureBox3.Width * 2 / 3 / N);
                      }

                    if (cell[i, j, k].a == 7)
                        g.FillEllipse(pen6, i * pictureBox1.Width / N + z, j * pictureBox1.Width / N, pictureBox1.Width * 2 / 3 / N, pictureBox1.Width * 2 / 3 / N);
                    if (cell[i, j, k + 1].a == 7)
                        g1.FillEllipse(pen6, i * pictureBox2.Width / N + z, j * pictureBox2.Width / N, pictureBox2.Width * 2 / 3 / N, pictureBox2.Width * 2 / 3 / N);
                    if (cell[i, j, k + 2].a == 7)
                        g2.FillEllipse(pen6, i * pictureBox3.Width / N + z, j * pictureBox3.Width / N, pictureBox3.Width * 2 / 3 / N, pictureBox3.Width * 2 / 3 / N);
                    if (cell[i, j, k + 3].a == 7)
                        g3.FillEllipse(pen6, i * pictureBox4.Width / N + z, j * pictureBox4.Width / N, pictureBox4.Width * 2 / 3 / N, pictureBox4.Width * 2 / 3 / N);

                    z = 0;
                }
            }
        }
        
        public void concentrate(double n, double E, double nn,double K)
        {
            n = n * Math.Exp(-kk * count * Math.Exp(-E / R * T));
            K = (nn - n) / count;
            label2.Refresh();
        }
        
        public double speed(double E,double K,double n)
        {
            double ar = N;
             return K = kk * Math.Exp(-E / R / T)*n/ar/ar/ 1000000000 / 1000000000 / 1000000000 / 1000;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            f = true;
            int P, T;
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            while (f)
            {
                P = trackBar2.Value;
                T = trackBar3.Value;
                p1 = P * percent;
                p2 = P * (1 - percent);
                n = P / T / kb; // p = n * k * T; n - концентрация молекул (Концентрация – это число частиц в единице объёма)
                n1 = p1 / T / kb;
                n2 = p2 / T / kb;
                nn1 = n1;
                nn2 = n2;
                cl = checkBox1.Checked;
                percent = trackBar1.Value / 100.0;
                nextStep();
                label1.Text = count++ + " сек  " + count/1000;
                label2.Text = " | давление: " + P + "| температура: " + T + "| соотношение:  " + trackBar1.Value + "%";
                int.TryParse(textBox2.Text, out sh);
                label2.Refresh();
                label1.Refresh();
                if(count%sh==0)
                    showMatrix();
            }
        }
        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            label4.Text = label4.Text + ": " + trackBar1.Value;
            label4.Refresh();
            label5.Text = label5.Text + ": " + trackBar2.Value;
            label5.Refresh();
            label6.Text = label6.Text + ": " + trackBar3.Value;
            label6.Refresh();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            f = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            P = trackBar2.Value;
            T = trackBar3.Value;
            int.TryParse(textBox1.Text, out N);
            percent = trackBar1.Value / 100.0;
            p1 = P * percent;
            p2 = P * (1 - percent);
            n = P / T / kb;  // концентрация частиц n, выведенная из уравнения состояния идеального газа (Менделеева-Клапейрона)
            n1 = p1 / T / kb; 
            n2 = p2 / T / kb;
            nn1 = n1;
            nn2 = n2;
            int.TryParse(textBox2.Text, out sh); // парсит значение textBox2 в sh;
            cl = checkBox1.Checked; // clear - чистые углероды
            firstStep(); // запускаем Шаг 1;
            showMatrix(); // рисуем матрицы?
            
            K1 = speed(E1, K1, nn1);
            K2 = speed(E2, K2, nn1);
            K3 = speed(E3, K3, nn2);
            K4 = speed(E4, K4, nn2);
            K5 = speed(E5, K5, nn1);
            K6 = speed(E6, K6, nn1);

            label2.Text = " | давление: " + P + " температура: " + T + " соотношение:  " + trackBar1.Value+"%";

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
           
        }
    }
    public class Cell
    {
        public int a;
        //public int bonds;
        //private int v;

        public Cell(int b)
        {
            a = b;
        }
    }
}