using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabulate
{
    public partial class Component2 : RichTextBox
    {
        //https://stackoverflow.com/questions/16050249/transparency-for-windows-forms-textbox
        public Component2()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor |
                 //ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;

        }

        public Component2(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor |
                 //ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;
        }
        //https://stackoverflow.com/questions/34462497/transparent-textbox-not-showing-text-after-i-leave-the-textbox
        private void redrawText()
        {
            using (Graphics graphics = this.CreateGraphics())
            using (SolidBrush brush = new SolidBrush(this.ForeColor))
                graphics.DrawString(this.Text, this.Font, brush, 0, 0); //play around with how you draw string more to suit your original
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            redrawText();
        }
        //to fix the background's issue with showing shadow images
        public void Redraw()
        {
            BackColor = Color.Transparent;
        }
    }
}
