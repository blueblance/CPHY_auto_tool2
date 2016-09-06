using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPHY_auto_tool
{
    public class MIPI
    {
        /// <summary>
        /// CPHY 參數設定於此
        /// </summary>
        /// 
        private static double symbol_bitrate = 2.28;
        private double HS_High_voltage, HS_Low_voltage, LP_Low_voltage, LP_High_voltage , symbolrate , framerate ,lp_freq;
        private int hbp, hfp, hsa, hact, vbp, vfp, vsa, vact, lane , pixelformat;
        private bool Hbp_LP_blanking, Hsa_LP_blanking, Hfp_LP_blanking, V_LP_blanking , burst_mode , pulse_mode;
        private enum videotype_select {nonburst_pulse , nonburst_event , burst_event };        
        private double linetime;


        ///
        /// 定義參數寫入的method
        ///
        public MIPI()
        {
            HS_High_voltage = 0.4D;
            HS_Low_voltage = 0;
            LP_High_voltage = 1.2D;
            LP_Low_voltage = 0;
            hbp = hfp = hsa = 40;
            vbp = vfp = vsa = 8;
            lane = 4;
            hact = 1080;
            vact = 1920;
            framerate = 60;
            symbolrate = 1000 * 1E+6;
            pixelformat = 24;
            Hbp_LP_blanking = Hsa_LP_blanking = Hfp_LP_blanking = V_LP_blanking = true; ///true = LP-11 , false = HS
            lp_freq = (double)10e+6;
            

        }

        public void set_porch(int hbp , int hfp , int hsa , int hact ,int vbp ,int vfp , int vsa , int vact)
        {
            this.hbp = hbp;
            this.hfp = hfp;
            this.hsa = hsa;
            this.vbp = vbp;
            this.vfp = vfp;
            this.vsa = vsa;
            this.hact = hact;
            this.vact = vact;
        }

        public void set_resloution(int hact , int vact)
        {
            this.hact = hact;
            this.vact = vact;
        }

        public void set_lanecnt(int lane)
        {
            this.lane = lane;
        }

        public void set_hs_volt(int hs_high , int hs_low)
        {
            this.HS_High_voltage = hs_high;
            this.HS_Low_voltage = hs_low;
        }

        public void set_lp_volt(int lp_high , int lp_low)
        {
            this.LP_High_voltage = lp_high;
            this.LP_Low_voltage = lp_low;
        }
        
        public void set_blanking_type(bool hsync , bool hbp , bool hfp , bool vblank) ///  true = lp-11 ,false = hs
        {
            this.Hsa_LP_blanking = hsync;
            this.Hbp_LP_blanking = hbp;
            this.Hfp_LP_blanking = hfp;
            this.V_LP_blanking = vblank;
        }

        public void set_pixel_format(int pixelformat)
        {
            if (pixelformat == 24 || pixelformat == 18 || pixelformat == 16)
            {
                this.pixelformat = pixelformat;
            }
            else
                this.pixelformat = 24;
        }

        public void set_videotype(bool pulsemode)
        {            
            this.pulse_mode = pulsemode;
        }

        public void set_video_burst(bool burstmode)
        {
            this.burst_mode = burstmode;
        }
        ///
        /// 取得狀態
        ///

        public int[] get_porch_setting()
        {
            int[] porch = { hbp , hfp , hsa , hact ,vbp , vfp ,vsa ,vact};
            return porch;
        }

        public double get_framerate()
        {
            return framerate;
        }

        public double get_symbolrate()
        {
            return symbolrate;
        }

        public double[] get_phy_volt()
        {
            double[] phy_volt = { HS_High_voltage, HS_Low_voltage, LP_High_voltage, LP_Low_voltage };
            return phy_volt;
        }

        public int get_lane()
        {
            return lane;
        }

        public double get_lp_freq()
        {
            return lp_freq;
        }

        public bool[] get_blanking_type()
        {
            bool[] blanking_type = { Hsa_LP_blanking, Hbp_LP_blanking, Hfp_LP_blanking, V_LP_blanking };
            return blanking_type;
        }

        public bool[] get_video_type() // arg1 : burst mode , arg2 pulse mode
        {
            bool[] video_type = { burst_mode, pulse_mode };
            return video_type;
        }

        public int get_pixel_format()
        {
            return pixelformat;
        }



        ///
        /// 計算功能
        ///

        public double cnt_symbolrate() // 計算當前porch,lane,framerate的需求下所需要的symbol rate
        {
            symbolrate = (((hbp + hfp + hsa + hact) * (vbp + vfp + vsa + vact) * pixelformat * framerate) / lane / symbol_bitrate);
            return symbolrate;
        }

        public double cnt_linetime()
        {
            linetime = 1 / 60 / (vact + vbp + vfp + vsa);
            return linetime;
            
        }
        
        
    }
}
