using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPhyGenCtlRPC;

namespace CPHY_auto_tool
{
    public partial class PG_control:CPhyGenCtlRPCClient
    {
        /// <summary>
        /// PGremote 基本參數
        /// </summary>
        public const int SERVER_PORT = 2799;
        public const int INST_SER_NUM = 1502;
        public static bool m_isCSI = false;

        public static string m_fn = "";
        public static string m_eMsg = "";
        public static string m_sMsg = "";
        public static string m_appDir = "";
        public static int m_VC = 0;
        public static CPhyGenCtlRPCClient client = new CPhyGenCtlRPCClient();


        public int set_prameter(MIPI mipi)
        {
            int rc =client.Connect("", SERVER_PORT);
            if(rc <0)
            {
                return 0;
            }
            int[] porch = mipi.get_porch_setting();
            double fr = mipi.get_framerate();
            double[] phy_volt = mipi.get_phy_volt();
            
            RPCCmd(RPCCmds.SET_TIMING_HBPORCH, porch[0]);
            RPCCmd(RPCCmds.SET_TIMING_HFPORCH, porch[1]);
            RPCCmd(RPCCmds.SET_TIMING_HSYNC, porch[2]);                        
            RPCCmd(RPCCmds.SET_TIMING_HACTIVE, porch[3]);
            RPCCmd(RPCCmds.SET_TIMING_VBPORCH, porch[4]);
            RPCCmd(RPCCmds.SET_TIMING_VFPORCH, porch[5]);
            RPCCmd(RPCCmds.SET_TIMING_VSYNC, porch[6]);                        
            RPCCmd(RPCCmds.SET_TIMING_VACTIVE, porch[7]);
            RPCCmd(RPCCmds.SET_HS_HIGH_VOLT, 1, phy_volt[0]);
            RPCCmd(RPCCmds.SET_HS_LOW_VOLT, 1, phy_volt[1]);
            RPCCmd(RPCCmds.SET_LP_HIGH_VOLT, phy_volt[2]);
            RPCCmd(RPCCmds.SET_LP_LOW_VOLT, phy_volt[3]);
            
            return 0;

        }

        public void set_blanking(MIPI mipi)
        {
            bool[] blanking_type = mipi.get_blanking_type();
            if(blanking_type[0])
                RPCCmd(RPCCmds.SET_TIMING_HSYNC_BLANKING_MODE, RPCDefs.LP11_BLANK_MODE);
            else
                RPCCmd(RPCCmds.SET_TIMING_HSYNC_BLANKING_MODE, RPCDefs.HS_BLANK_MODE);
            if (blanking_type[1])
                RPCCmd(RPCCmds.SET_TIMING_HBPORCH_BLANKING_MODE, RPCDefs.LP11_BLANK_MODE);
            else
                RPCCmd(RPCCmds.SET_TIMING_HBPORCH_BLANKING_MODE, RPCDefs.HS_BLANK_MODE);
            if (blanking_type[2])
                RPCCmd(RPCCmds.SET_TIMING_HFPORCH_BLANKING_MODE, RPCDefs.LP11_BLANK_MODE);
            else
                RPCCmd(RPCCmds.SET_TIMING_HFPORCH_BLANKING_MODE, RPCDefs.HS_BLANK_MODE);
            if (blanking_type[3])
                RPCCmd(RPCCmds.SET_TIMING_VERTICAL_BLANKING_MODE, RPCDefs.LP11_BLANK_MODE);
            else
                RPCCmd(RPCCmds.SET_TIMING_VERTICAL_BLANKING_MODE, RPCDefs.HS_BLANK_MODE);
        }


    }
}
