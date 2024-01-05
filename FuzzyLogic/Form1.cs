using System;
using System.Threading;
using System.Windows.Forms;

namespace FuzzyLogic
{
    public partial class Form1 : Form
    {
        private Maze maze;
        private bool keepRunning;
        string mazeString;

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            button2.Enabled = false;

            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "5";

            textBox9.Text = "1";
            textBox8.Text = "5";
            textBox7.Text = "1000";
            textBox6.Text = "1000";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            keepRunning = true;
            comboBox1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = true;

            if(comboBox1.SelectedIndex == 3)
            {
                mazeString = textBox1.Text;
            }

            double startNear = double.Parse(textBox2.Text);
            double minPeakNear = double.Parse(textBox3.Text);
            double maxPeakNear = double.Parse(textBox4.Text);
            double endNear = double.Parse(textBox5.Text);

            double startFar = double.Parse(textBox9.Text);
            double minPeakFar = double.Parse(textBox8.Text);
            double maxPeakFar = double.Parse(textBox7.Text);
            double endFar = double.Parse(textBox6.Text);

            double[] parametersNear = { startNear, minPeakNear, maxPeakNear, endNear };
            double[] parametersFar = { startFar, minPeakFar, maxPeakFar, endFar };
            maze = new Maze(mazeString, parametersNear, parametersFar);
            Thread Thread = new Thread(movement);
            Thread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            keepRunning = false;
            comboBox1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void movement()
        {
            while (keepRunning)
            {
                Invoke((MethodInvoker)delegate
                {
                    char[,] array = maze.movement();
                    if (array.Length == 1)
                    {
                        keepRunning = false;
                        comboBox1.Enabled = true;
                        button1.Enabled = true;
                        button2.Enabled = false;
                        MessageBox.Show(
                            "The robot is trapped",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    } 
                    else
                    {
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
                    }
                });
                Thread.Sleep(200);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    mazeString = "ooooooo\r\n" + "o-r---o\r\n" + "o-ooo-o\r\n" + "o-ooo-o\r\n" + "o-----o\r\n" + "ooooooo";
                    textBox1.Text = mazeString;
                    textBox1.ReadOnly = true;
                    break;
                case 1:
                    mazeString = "ooooooo\r\no---o-o\r\no-o-o-o\r\no-o-o-o\r\no-o-o-o\r\noro---o\r\nooooooo";
                    textBox1.Text = mazeString;
                    textBox1.ReadOnly = true;
                    break;
                case 2:
                    mazeString = "ooooooo\r\no---oro\r\no-ooo-o\r\no-----o\r\no-ooo-o\r\no-o---o\r\nooooooo";
                    textBox1.Text = mazeString;
                    textBox1.ReadOnly = true;
                    break;
                case 3:
                    textBox1.Text = "";
                    textBox1.ReadOnly = false;
                    break;
            }
        }
    }
}