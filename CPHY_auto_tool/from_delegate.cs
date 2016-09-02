using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace CPHY_auto_tool
{
    class from_delegate
    {
        public delegate void Settextboxcallback(TextBox tb, String data);
        public void Settextbox(TextBox tb, String data)
        {
            if (tb.InvokeRequired)
            {
                Settextboxcallback Sb = new Settextboxcallback(Settextbox);
                tb.BeginInvoke(Sb, new object[] { tb, data });
            }
            else
            {
                tb.Text = data;
            }
        }

        public delegate void DisplayOnPictureBoxcallback(PictureBox pb, Bitmap Bp);
        public void DisplayOnPictureBox(PictureBox pb, Bitmap Bp)
        {
            if (pb.InvokeRequired)
            {
                DisplayOnPictureBoxcallback Db = new DisplayOnPictureBoxcallback(DisplayOnPictureBox);
                pb.BeginInvoke(Db, new object[] { pb, Bp });
            }
            else
            {
                pb.Image = Bp;
            }

        }
    }
}
