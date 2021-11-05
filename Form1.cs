using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadsAsync
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            

            Thread[] threadPoll = new Thread[2];
            for (var i = 0; i < threadPoll.Length; i++)
            {
                JobDoer jobDoer = new JobDoer();
                jobDoer.IsWorking = true;
                threadPoll[i] = new Thread(() =>
                {
                    jobDoer.doJob();
                });
            }

            foreach (var thread in threadPoll)
            {
                thread.Start();
            }
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            Context context = new Context();
            context.Delay = 10000;
            TaskQueue.addTask(context);
        }
    }
}
