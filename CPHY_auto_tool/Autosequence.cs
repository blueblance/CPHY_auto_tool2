using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CPHY_auto_tool
{
    class Autosequence:Form
    {
        public void video_auto(MIPI mipi, double target_symbol_rate)
        {
            from_delegate controlform = new from_delegate();
            int[] porch = mipi.get_porch_setting();
            while (mipi.cnt_symbolrate() < target_symbol_rate)
            {
                mipi.set_porch(porch[0] + 8, porch[1] + 8, porch[2] + 8, porch[3], porch[4], porch[5], porch[6], porch[7]);
                Thread.Sleep(500);
                

            }
        }
    }
}
