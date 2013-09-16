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

        public frmMain()
        {
            InitializeComponent();
            blink1.open();
            _timer = new System.Timers.Timer(6000);
            //_timer = new System.Timers.Timer(100);
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
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
            this.UIThread(() => btnStartStopPomodoro.Text = "Stop Pomodoro");
            counter = 1;
            timerEnabled = true;
            _timer.Enabled = true;
        }

        private void disableTimer()
        {
            blink5x();
            this.UIThread(() => btnStartStopPomodoro.Text = "Start Pomodoro");
            this.UIThread(() => lblTimeLeft.Text = "Time Left: 25m");
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
                blink1.fadeToRGB(500, 0, 0, 255);
            }
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (counter < 250)
            {
                r -= 1;
                b += 1;
                updateRGB();
                
                this.UIThread(() => lblTimeLeft.Text = "Time Left: " + Math.Round(25.0 - (counter/10.0), 1) + "m");
                this.UIThread(() => pgbTimeLeft.PerformStep());
                counter = counter + 1;
            }
            else
            {
                this.UIThread(disableTimer);
            }
                
        }
    }

    public static class ControlExtensions
    {
        /// <summary>
        /// Executes the Action asynchronously on the UI thread, does not block execution on the calling thread.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="code"></param>
        public static void UIThread(this Control @this, Action code)
        {
            if (@this.InvokeRequired)
            {
                @this.BeginInvoke(code);
            }
            else
            {
                code.Invoke();
            }
        }
    }
}
