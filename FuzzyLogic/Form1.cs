using System;
using System.Threading;
using System.Windows.Forms;

namespace FuzzyLogic
{
    public partial class Form1 : Form
    {
        private Maze maze;
        private bool keepRunning = true;

        public Form1()
        {
            InitializeComponent();
            string mazeString = "ooooooo\r\n" + "o-r---o\r\n" + "o-ooo-o\r\n" + "o-ooo-o\r\n" + "o-----o\r\n" + "ooooooo\r\n";
            textBox1.Text = "o\to\to\to\to\to\to\r\n" + "o\t-\tr\t-\t-\t-\to\r\n" + "o\t-\to\to\to\t-\to\r\n" + "o\t-\to\to\to\t-\to\r\n" + "o\t-\t-\t-\t-\t-\to\r\n" + "o\to\to\to\to\to\to\r\n";
            int[] parametersNear = { 0, 0, 0, 5 };
            int[] parametersFar = { 1, 5, int.MaxValue, int.MaxValue };
            maze = new Maze(mazeString, parametersNear, parametersFar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            keepRunning = true;
            Thread Thread = new Thread(movement);
            Thread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            keepRunning = false;
        }

        private void movement()
        {
            while (keepRunning)
            {
                Invoke((MethodInvoker)delegate
                {
                    char[,] array = maze.movement();
                    string str = "";
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            str += array[i, j] + "\t";
                        }
                        str += "\r\n";
                    }
                    textBox1.Text = str;
                });
                Thread.Sleep(500);
            }
        }
    }
}