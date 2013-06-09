﻿namespace PomodoroBlink
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStartStopPomodoro = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblTimeLeft = new System.Windows.Forms.Label();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnStartStopPomodoro
            // 
            this.btnStartStopPomodoro.Location = new System.Drawing.Point(12, 76);
            this.btnStartStopPomodoro.Name = "btnStartStopPomodoro";
            this.btnStartStopPomodoro.Size = new System.Drawing.Size(238, 23);
            this.btnStartStopPomodoro.TabIndex = 0;
            this.btnStartStopPomodoro.Text = "Start Pomodoro";
            this.btnStartStopPomodoro.UseVisualStyleBackColor = true;
            this.btnStartStopPomodoro.Click += new System.EventHandler(this.btnStartStopPomodoro_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 29);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(120, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.AutoSize = true;
            this.lblTimeLeft.Location = new System.Drawing.Point(160, 34);
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Size = new System.Drawing.Size(77, 13);
            this.lblTimeLeft.TabIndex = 2;
            this.lblTimeLeft.Text = "Time Left: 25m";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 111);
            this.Controls.Add(this.lblTimeLeft);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnStartStopPomodoro);
            this.Name = "frmMain";
            this.Text = "Pomodoro Timer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartStopPomodoro;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblTimeLeft;
        private System.Windows.Forms.Timer tmrTimer;
    }
}

