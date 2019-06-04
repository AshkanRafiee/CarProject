using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace CarProject
{
    
    public partial class Form1 : Form
    {
        int H, M, S;
        DateTime time;
        int speed = 0;
        double milage = 0;
        double gas = 40;

        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("Welcome to The Car Application!");
            statusBox.Text = "Engine is Off!";
            csBox.Text = speed + " km/h".ToString();
            cgBox.Text = "N";
        }

        Timer t1;
        Stopwatch s1;
        Stopwatch s2;
        Stopwatch s3;

        private Timer timer1;

        private void kahande()
        {
                timer1 = new Timer();
                timer1.Tick += new EventHandler(GpullButton_Click);
                timer1.Interval = 1000; // in miliseconds
                timer1.Start();
        }

        private void getAOGM()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(Button1_Click);
            timer1.Interval = 1000; // in miliseconds
            timer1.Start();
        }

        private void T1_Tick(object sender, EventArgs e)
        {
            etBox.Text = s1.Elapsed.ToString("hh\\:mm\\:ss");
            etBox.Text = s2.Elapsed.ToString("hh\\:mm\\:ss");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Car Mashin = new Car();

            if (comboBox1.SelectedIndex == 0)
            {
                clearBox();
                companyBox.Text = Mashin.CarsDetail[0, 1];
                cylinderBox.Text = Mashin.CarsDetail[0, 2];
                togBox.Text = Mashin.CarsDetail[0, 3];
                if (colorBox.SelectedIndex == 0)
                {
                    pictureBox1.Image = Properties.Resources.x6b;
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.x6w;
                }

            }
            if (comboBox1.SelectedIndex == 1)
            {
                clearBox();
                companyBox.Text = Mashin.CarsDetail[1, 1];
                cylinderBox.Text = Mashin.CarsDetail[1, 2];
                togBox.Text = Mashin.CarsDetail[1, 3];
                if (colorBox.SelectedIndex == 0)
                {
                    pictureBox1.Image = Properties.Resources.mb;
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.mw;
                }
            }
            if (comboBox1.SelectedIndex == 2)
            {
                clearBox();
                companyBox.Text = Mashin.CarsDetail[2, 1];
                cylinderBox.Text = Mashin.CarsDetail[2, 2];
                togBox.Text = Mashin.CarsDetail[2, 3];
                if (colorBox.SelectedIndex == 0)
                {
                    pictureBox1.Image = Properties.Resources.l90b;
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.l90w;
                }
            }
        }

        void clearBox()
        {
            companyBox.Clear();
            cylinderBox.Clear();
            togBox.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearBox();
        }

        private void GpushButton_Click(object sender, EventArgs e)
        {
            timer1.Tick -= new EventHandler(GpullButton_Click);
            if (speed < 200)
            {
                speed += 5;
                csBox.Text = speed + " km/h".ToString();
                if (speed < 20 && speed > 0)
                {
                    statusBox.Text = "Mashin dar hale harekat!";
                    cgBox.Text = 1.ToString();
                }
                if (speed < 40 && speed >= 20)
                {
                    statusBox.Text = "Mashin dar hale harekat!";
                    cgBox.Text = 2.ToString();
                }
                if (speed < 70 && speed >= 40)
                {
                    statusBox.Text = "Mashin dar hale harekat!";
                    cgBox.Text = 3.ToString();
                }
                if (speed < 100 && speed >= 70)
                {
                    statusBox.Text = "Mashin dar hale harekat!";
                    cgBox.Text = 4.ToString();
                }
                if (speed < 200 && speed >= 100)
                {
                    statusBox.Text = "Mashin dar hale harekat!";
                    cgBox.Text = 5.ToString();
                }
            }
            else if (speed >= 200)
            {
                statusBox.Text = "Mashin Monfajer Shod!";
                speed = 0;
                cgBox.Text = "N";
                csBox.Text = speed + " km/h".ToString();
            }
        }

        private void GpullButton_Click(object sender, EventArgs e)
        {
            if (speed > 0)
            {
                speed -= 5;
                csBox.Text = speed + " km/h".ToString();
                if (speed < 20 && speed > 0)
                {
                    cgBox.Text = 1.ToString();
                    statusBox.Text = "Mashin dar hale harekat!";
                }
                if (speed < 40 && speed >= 20)
                {
                    cgBox.Text = 2.ToString();
                    statusBox.Text = "Mashin dar hale harekat!";
                }
                if (speed < 70 && speed >= 40)
                {
                    cgBox.Text = 3.ToString();
                    statusBox.Text = "Mashin dar hale harekat!";
                }
                if (speed < 100 && speed >= 70)
                {
                    cgBox.Text = 4.ToString();
                    statusBox.Text = "Mashin dar hale harekat!";
                }
                if (speed < 200 && speed >= 100)
                {
                    cgBox.Text = 5.ToString();
                    statusBox.Text = "Mashin dar hale harekat!";
                }
            }
            else
            {
                speed = 0;
                csBox.Text = speed + " km/h".ToString();
                cgBox.Text = "N";
                statusBox.Text = "Mashin Khamoosh kard!";
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            s1 = new Stopwatch();
            s2 = new Stopwatch();
            s3 = new Stopwatch();

            t1 = new Timer();
            t1.Interval = 1;
            t1.Tick += T1_Tick;
            t1.Start();
            getAOGM();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            double temp = (speed * 0.000277777778);

            milage += temp;
            cmBox.Text = milage.ToString();
            double masraf = milage/10;
            aogBox.Text = (40-masraf).ToString();

        }
        private void Button1_Click_1(object sender, EventArgs e)
        {
            timer1.Tick -= new EventHandler(GpullButton_Click);
            speed = 0;
            gas = 40;
            milage = 0;
            statusBox.Text = "Engine is Off!";
            csBox.Text = speed + " km/h".ToString();
            cgBox.Text = "N";
            s1.Stop();
            s2.Stop();
            s3.Stop();
            s1.Reset();
            s2.Reset();
            s3.Reset();
            clearBox();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timer1.Tick -= new EventHandler(GpullButton_Click);
            s1.Start();
            s2.Start();
            statusBox.Text = "Mashin Roshan Shod!";
            DateTime starttime = new DateTime();
            starttime = DateTime.Now;
            stBox.Text = starttime.ToString("HH:mm:ss");
            H = starttime.Hour;
            M = starttime.Minute;
            S = starttime.Second;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            s1.Stop();
            s2.Stop();
            kahande();
        }
    }
}
