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
        

        public static OpenFileDialog open_lcm_init_file = new OpenFileDialog();
        public static MIPI dut = new MIPI();
        public static PG_control pgcontrol = new PG_control();
        private string lcm_initial_code;
        
        public Form1()
        {
            
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Red;
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
                        
            while (dut.cnt_symbolrate() < 1200*1E6)
            {
                pgcontrol.set_prameter(dut);
                int[] porch = dut.get_porch_setting();
                dut.set_porch(porch[0] + 8, porch[1] + 8, porch[2] + 8, porch[3], porch[4], porch[5], porch[6], porch[7]);
                Thread.Sleep(50);
                
                
                dut.cnt_symbolrate();
                mipi_out_form();



            }
        }

        int set_video_condition()
        {
            if(checklistbox_videotype.GetItemChecked(0))
            {
                dut.set_pixel_format(24);
                return 1;
            }
            if(checklistbox_videotype.GetItemChecked(1))
            {
                dut.set_pixel_format(18);
                return 1;
            }
            if (checklistbox_videotype.GetItemChecked(2))
            {
                dut.set_pixel_format(16);
                return 1;
            }
            return 0;
        }

        private void btn_video_auto_Click(object sender, EventArgs e)
        {

        }

        private void btn_load_ini_Click(object sender, EventArgs e)
        {
            
            open_lcm_init_file.Filter = "txt file | *.txt";
            if(open_lcm_init_file.ShowDialog() == DialogResult.OK)
            {
                lcm_initial_code = open_lcm_init_file.FileName;
            }
        }




        ///
        ///
        /// 將MIPI class內容輸出到textbox
        ///
        ///

        private void mipi_out_form()
        {
            from_delegate controlform = new from_delegate();
            int[] porch = dut.get_porch_setting();
            bool[] blanking_type = dut.get_blanking_type();
            controlform.Settextbox(textbox_hbp, porch[0].ToString());
            controlform.Settextbox(textbox_hfp, porch[1].ToString());
            controlform.Settextbox(textbox_hsa, porch[2].ToString());
            controlform.Settextbox(textbox_hact, porch[3].ToString());
            controlform.Settextbox(textbox_vbp, porch[4].ToString());
            controlform.Settextbox(textbox_vfp, porch[5].ToString());
            controlform.Settextbox(textbox_vsa, porch[6].ToString());
            controlform.Settextbox(textbox_vact, porch[7].ToString());
            controlform.Settextbox(textbox_symrate, (dut.get_symbolrate() /1E6).ToString());
            controlform.Settextbox(textbox_framerate, dut.get_framerate().ToString());
            if(blanking_type[0])
            {
                controlform.Settextbox(textbox_hsa, Color.Aqua);
            }
            else
            {
                controlform.Settextbox(textbox_hsa, Color.DodgerBlue);
            }
            if (blanking_type[0])
            {
                controlform.Settextbox(textbox_hbp, Color.Aqua);
            }
            else
            {
                controlform.Settextbox(textbox_hbp, Color.DodgerBlue);
            }
            if (blanking_type[0])
            {
                controlform.Settextbox(textbox_hfp, Color.Aqua);
            }
            else
            {
                controlform.Settextbox(textbox_hfp, Color.DodgerBlue);
            }
            if (blanking_type[0])
            {
                controlform.Settextbox(textbox_vsa, Color.Aqua);
                controlform.Settextbox(textbox_vbp, Color.Aqua);
                controlform.Settextbox(textbox_vfp, Color.Aqua);
            }
            else
            {
                controlform.Settextbox(textbox_vsa, Color.DodgerBlue);
                controlform.Settextbox(textbox_vbp, Color.DodgerBlue);
                controlform.Settextbox(textbox_vfp, Color.DodgerBlue);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Bitmap pic;
            OpenFileDialog openbmp = new OpenFileDialog();
            if (openbmp.ShowDialog() == DialogResult.OK)
            {
                pic = new Bitmap(openbmp.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = pic;

            }
        }
    }
}
