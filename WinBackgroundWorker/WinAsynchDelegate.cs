﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinBackgroundWorker
{
    public partial class WinAsynchDelegate : Form
    {
        public WinAsynchDelegate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimeConsulmingMethodDelegate del = new TimeConsulmingMethodDelegate(TimeConsulmingMethod);
            del.BeginInvoke(int.Parse(textBox1.Text), null, null);
        }

        private void WinAsynchDelegate_Load(object sender, EventArgs e)
        {

        }
        private void TimeConsulmingMethod(int seconds)


        {
            bool Cancel;
            Cancel = false;
            for (int j = 1; j <= seconds; j++)
            {
                System.Threading.Thread.Sleep(1000);
                SetProgress((int)(j * 100 / seconds));

                if (Cancel)
                {
                    break;
                }
            }
            if (Cancel)
            {
                System.Windows.Forms.MessageBox.Show("Canceled");
                Cancel = false;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Complete");
            }
        }
        public void SetProgress(int val)
        {
            if (progressBar1.InvokeRequired)
            {
                SetProgressDelegate del = new SetProgressDelegate(SetProgress);
                this.Invoke(del, new object[] { val });
            }
            else
            {
                progressBar1.Value = val;
            }
        }
        private delegate void TimeConsulmingMethodDelegate(int seconds);

        public delegate void SetProgressDelegate(int val);

        private void button2_Click(object sender, EventArgs e)
        {
           bool Cancel = true;
        }
    }
}
