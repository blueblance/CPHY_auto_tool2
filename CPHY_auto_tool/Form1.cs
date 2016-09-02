using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPhyGenCtlRPC;
using System.Threading;
using System.Diagnostics;


namespace CPHY_auto_tool
{
    public partial class Form1 : Form
    {
        public static MIPI dut = new MIPI();
        public static PG_control pgcontrol = new PG_control();
        public Form1()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            PG_control p339 = new PG_control();
            //textBox1.Text = dut.get_framerate().ToString();
            //Thread p = new Thread()
            ParameterizedThreadStart myPar = new ParameterizedThreadStart(video_auto);
            Thread myThread01 = new Thread(myPar);
            myThread01.Start(1200);


        }

        void video_auto(object o)
        {
            double target_symbol_rate = Convert.ToDouble(o);
            target_symbol_rate = target_symbol_rate * 1000000;

            from_delegate controlform = new from_delegate();
            
            while (dut.cnt_symbolrate() < 1200*1E6)
            {
                pgcontrol.set_prameter(dut);
                int[] porch = dut.get_porch_setting();
                dut.set_porch(porch[0] + 8, porch[1] + 8, porch[2] + 8, porch[3], porch[4], porch[5], porch[6], porch[7]);
                Thread.Sleep(500);
                controlform.Settextbox(textBox1, porch[0].ToString());
                dut.cnt_symbolrate();
               

            }
        }

        void testcnt(object o)
        {
            int target = Convert.ToInt32(o);
            from_delegate controlform = new from_delegate();
            for(int i = 0; i<target; i++)
            {
                controlform.Settextbox(textBox1, i.ToString());
                Thread.Sleep(500);

            }
        }

        

    }
}
