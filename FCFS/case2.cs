using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FCFS
{
    public partial class case2 : Form
    {
        public case2()
        {
            InitializeComponent();
        }

        private void case2_FormClosing(object sender, FormClosingEventArgs e)
        {
            var form = new mainForm();
            form.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] process = new string[]
            {
                Convert.ToString(processTB1.Text),
                Convert.ToString(processTB2.Text),
                Convert.ToString(processTB3.Text),
                Convert.ToString(processTB4.Text)
            };
            string swapProcess;
            int[] burst = new int[]
            {
                Convert.ToInt32(burstTB1.Text),
                Convert.ToInt32(burstTB2.Text),
                Convert.ToInt32(burstTB3.Text),
                Convert.ToInt32(burstTB4.Text)
            };
            int[] arrive = new int[]
            {
                Convert.ToInt32(arrivalTB1.Text),
                Convert.ToInt32(arrivalTB2.Text),
                Convert.ToInt32(arrivalTB3.Text),
                Convert.ToInt32(arrivalTB4.Text)
            };
            int swapArrive, swapBurst;
            for (int i = 0; i <= arrive.Length; i++)
            {
                if (arrive[i] > arrive[i + 1])
                {
                    // arrival time sort
                    swapArrive = arrive[i];
                    arrive[i] = arrive[i + 1];
                    arrive[i + 1] = swapArrive;

                    // burst time sort
                    swapBurst = burst[i];
                    burst[i] = burst[i + 1];
                    burst[i + 1] = swapBurst;

                    // process names sort
                    swapProcess = process[i];
                    process[i] = process[i + 1];
                    process[i + 1] = swapProcess;
                }
            }
        }
    }
}
