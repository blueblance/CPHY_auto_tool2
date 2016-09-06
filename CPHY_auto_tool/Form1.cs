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
        private bool[] video_auto_videotype_item = { false, false, false, false, false, false };
        private bool[] video_auto_pixelformat_item = { false, false, false};


        public Form1()
        {
            
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            for(i = 0; i<3; i++)
            {
                video_auto_pixelformat_item[i] = checklistbox_pixelstream.GetItemChecked(i);
            }
            for(i = 0; i < 6; i++)
            {
                video_auto_videotype_item[i] = checklistbox_videotype.GetItemChecked(i);
            }
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

        int set_video_pixelformat() ///判斷勾選項目,判斷完成後點掉,並將設定寫入mipi class,回傳值1代表有勾選項目,0代表已沒有勾選項目
        {
            if(checklistbox_videotype.GetItemChecked(0))
            {
                checklistbox_videotype.SetItemChecked(0, false);
                dut.set_pixel_format(24);
                return 1;
            }
            if(checklistbox_videotype.GetItemChecked(1))
            {
                checklistbox_videotype.SetItemChecked(1, false);
                dut.set_pixel_format(18);
                return 1;
            }
            if (checklistbox_videotype.GetItemChecked(2))
            {
                checklistbox_videotype.SetItemChecked(2, false);
                dut.set_pixel_format(16);
                return 1;
            }
            return 0;
        }

        int set_videotype()
        {
            if(checklistbox_videotype.GetItemChecked(0))
            {
                dut.set_blanking_type(true, true, true, true);
                dut.set_video_burst(false);
                dut.set_videotype(false);
                checklistbox_videotype.SetItemChecked(0, false);
                return 1;
            }
            if (checklistbox_videotype.GetItemChecked(1))
            {
                dut.set_blanking_type(true, true, true, true);
                dut.set_video_burst(false);
                dut.set_videotype(true);
                checklistbox_videotype.SetItemChecked(1, false);
                return 1;
            }
            if (checklistbox_videotype.GetItemChecked(2))
            {
                dut.set_blanking_type(true, true, true, true);
                dut.set_video_burst(true);
                dut.set_videotype(false);
                checklistbox_videotype.SetItemChecked(2, false);
                return 1;
            }
            if (checklistbox_videotype.GetItemChecked(3))
            {
                dut.set_blanking_type(true, true, true, true);
                dut.set_video_burst(false);
                dut.set_videotype(false);
                checklistbox_videotype.SetItemChecked(3, false);
                return 1;
            }
            if (checklistbox_videotype.GetItemChecked(4))
            {
                dut.set_blanking_type(true, true, true, true);
                dut.set_video_burst(false);
                dut.set_videotype(true);
                checklistbox_videotype.SetItemChecked(4, false);
                return 1;
            }
            if (checklistbox_videotype.GetItemChecked(5))
            {
                dut.set_blanking_type(true, true, true, true);
                dut.set_video_burst(true);
                dut.set_videotype(false);
                checklistbox_videotype.SetItemChecked(5, false);
                return 1;
            }
            return 0;

        }

        private void btn_video_auto_Click(object sender, EventArgs e)
        {
            checklistbox_videotype.SetItemChecked(0, false);
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


        private void callback_video_setting()
        {
            from_delegate controlform = new from_delegate();
            for (int i = 0; i < 3; i++)
            {
                controlform.changechecklistbox(checklistbox_pixelstream, i, video_auto_pixelformat_item[i]);
            }
            for (int i = 0; i < 6; i++)
            {
                controlform.changechecklistbox(checklistbox_videotype, i, video_auto_pixelformat_item[i]);
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

        private void button2_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(textbox_auto_script_loopcnt.Text);
            ComboBox[] auto_script = new ComboBox[i];

            for(int k = 0; k < i; k++)
            {
                auto_script[k] = new ComboBox();
                auto_script[k].Name = "combox_script" + k;
                auto_script[k].Height = 20;
                auto_script[k].Width = 80;
                auto_script[k].Items.Add("Video_mode");
                auto_script[k].Items.Add("Delay");
                auto_script[k].Items.Add("Read Check");
                auto_script[k].Items.Add("Write CMD");
                auto_script[k].Items.Add("Reset");
                auto_script[k].Items.Add("Take Picture");
                auto_script[k].Items.Add("get fluke");
                auto_script[k].Items.Add("BTA");
                auto_script[k].Location = new Point(10, 10 + k * 25);
                auto_script[k].SelectedIndexChanged += new System.EventHandler(ComboBox_selectchanged);
                panel1.Controls.Add(auto_script[k]);


            }
        }

        private void ComboBox_selectchanged(object sender , System.EventArgs s)
        {
            TextBox[] auto_script_arg = new TextBox[2];            
            ComboBox cb = (ComboBox)sender;
            cb.BackColor = Color.Red;
            textBox1.Text = ((ComboBox)(sender)).Name.ToString();
                      
            for(int i = 0; i < 2; i++)
            {
                string cbname = ((ComboBox)(sender)).Name;
                auto_script_arg[i] = new TextBox();
                auto_script_arg[i].Name = "textbox_" + cbname + i;
                auto_script_arg[i].Height = 20;
                auto_script_arg[i].Width = 40;
                auto_script_arg[i].Location = new Point(((ComboBox)(sender)).Location.X + 90 + 45*i , ((ComboBox)(sender)).Location.Y);
                panel1.Controls.Add(auto_script_arg[i]);
            }
            
        }

        public void auto_script_method()
        {

        }
    }
}
