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

        public delegate void Settextboxcolorback(TextBox tb, Color cr);

        public void Settextbox(TextBox tb , Color cr)
        {
            if (tb.InvokeRequired)
            {
                Settextboxcolorback sb = new Settextboxcolorback(Settextbox);
                tb.BeginInvoke(sb, new object[] { tb, cr });
            }
            else
            {
                tb.BackColor = cr;
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

        public delegate void changechecklistboxcallback(CheckedListBox cb, int item ,bool check);

        public void changechecklistbox(CheckedListBox cb, int item, bool check)
        {
            if (cb.InvokeRequired)
            {
                changechecklistboxcallback Db = new changechecklistboxcallback(changechecklistbox);
                cb.BeginInvoke(Db, new object[] { cb, item , check });
                
            }
            else
            {
                cb.SetItemChecked(item, check);
            }
        }


    }
}
