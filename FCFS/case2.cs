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
            double[] burst = new double[]
            {
                Convert.ToInt32(burstTB1.Text),
                Convert.ToInt32(burstTB2.Text),
                Convert.ToInt32(burstTB3.Text),
                Convert.ToInt32(burstTB4.Text)
            };
            double[] arrive = new double[]
            {
                Convert.ToInt32(arrivalTB1.Text),
                Convert.ToInt32(arrivalTB2.Text),
                Convert.ToInt32(arrivalTB3.Text),
                Convert.ToInt32(arrivalTB4.Text)
            };
            double swapArrive, swapBurst;
            for (int i = 0; i < arrive.Length - 1; i++)
            {
                for (int j = i + 1; j < arrive.Length; j++)
                {
                    if (arrive[i] > arrive[j])
                    {
                        // arrival time sort
                        swapArrive = arrive[i];
                        arrive[i] = arrive[j];
                        arrive[j] = swapArrive;

                        // burst time sort
                        swapBurst = burst[i];
                        burst[i] = burst[j];
                        burst[j] = swapBurst;

                        // process names sort
                        swapProcess = process[i];
                        process[i] = process[j];
                        process[j] = swapProcess;
                    }
                }
            }
            double process1Srat = 0;
            double process2Srat = burst[0];
            double process3Srat = burst[0] + burst[1];
            double process4Srat = burst[0] + burst[1] + burst[2];

            double waiting1 = process1Srat - arrive[0];
            double waiting2 = process2Srat - arrive[1];
            double waiting3 = process3Srat - arrive[2];
            double waiting4 = process4Srat - arrive[3];

            // gantt chart 
            // process 1
            timeLbl1.Text = "0";
            pLbl1.Text = process[0];
            timeLbl2.Text = Convert.ToString(burst[0]);
            waitingTB1.Text = Convert.ToString(process1Srat + " - " + arrive[0] + " = " + waiting1);

            // process 2
            timeLbl3.Text = Convert.ToString(burst[0]);
            pLbl2.Text = process[1];
            timeLbl4.Text = Convert.ToString(burst[0] + burst[1]);
            waitingTB2.Text = Convert.ToString(process2Srat + " - " + arrive[1] + " = " + waiting2);

            // process 3
            timeLbl5.Text = Convert.ToString(burst[0] + burst[1]);
            pLbl3.Text = process[2];
            timeLbl6.Text = Convert.ToString(burst[0] + burst[1] + burst[2]);
            waitingTB3.Text = Convert.ToString(process3Srat + " - " + arrive[2] + " = " + waiting3);

            // process 4
            timeLbl7.Text = Convert.ToString(burst[0] + burst[1] + burst[2]);
            pLbl4.Text = process[3];
            timeLbl8.Text = Convert.ToString(burst[0] + burst[1] + burst[2] + burst[3]);
            waitingTB4.Text = Convert.ToString(process4Srat + " - " + arrive[3] + " = " + waiting4);

            // average waiting time
            double average = (waiting1 + waiting2 + waiting3 + waiting4) / process.Length;
            valuelbl.Text = Convert.ToString("( " + waiting1 + " + " + waiting2 + " + " + waiting3 + " + " + waiting4 + " ) /" + process.Length + " = " + Math.Round(average, 2));
            valuelbl.Visible = true;
            awtlbl.Visible = true;
        }

        private void ganttPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
