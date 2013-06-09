using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using Blink1Lib;

namespace PomodoroBlink
{
    public partial class frmMain : Form
    {
        static System.Timers.Timer _timer;
        private Blink1 blink1 = new Blink1();
        private bool timerEnabled = false;
        private int counter = 1;
        private int r = 255;
        private int b = 0;
        private BackgroundWorker backgroundWorker1;

        public frmMain()
        {
            InitializeComponent();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.ProgressChanged +=
                new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProcessChanged);
            blink1.open();
            _timer = new System.Timers.Timer(100);
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
        }

        private void backgroundWorker1_ProcessChanged(object sender, ProgressChangedEventArgs e)
        {
            lblTimeLeft.Text = "foobarcar";
        }

        private void btnStartStopPomodoro_Click(object sender, EventArgs e)
        {
            if (timerEnabled)
            {
                disableTimer();
            }
            else
            {
                enableTimer();
            }
        }

        private void enableTimer()
        {
            r = 255;
            b = 0;
            updateRGB();
            this.btnStartStopPomodoro.Text = "Stop Pomodoro";
            counter = 1;
            timerEnabled = true;
            _timer.Enabled = true;
        }

        private void disableTimer()
        {
            this.btnStartStopPomodoro.Text = "Start Pomodoro";
            this.lblTimeLeft.Text = "Time Left: 25m";
            blink1.setRGB(0, 0, 0);
            timerEnabled = false;
            _timer.Enabled = false;
        }

        private void updateRGB()
        {
            blink1.setRGB(r, 0, b);    
        }

        private void blink5x()
        {
            for (int c = 0; c < 5; c++)
            {
                blink1.fadeToRGB(500, 255, 0, 0);
                System.Threading.Thread.Sleep(200);
                blink1.fadeToRGB(500, 255, 0, 0);
            }
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (counter < 250)
            {
                r -= 1;
                b += 1;
                updateRGB();
                backgroundWorker1.ReportProgress(1);
            }
            else
            {
                disableTimer();
            }
                
        }
    }
}
