using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace UI
{
    public class UIDesign
    {

        #region 窗体阴影API
        private const int CS_DropSHADOW = 0x20000;
        private const int GCL_STYLE = (-26);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetClassLong(IntPtr hwnd, int nIndex);
        /// <summary>
        /// 设置窗体阴影
        /// </summary>
        /// <param name="form"></param>
        public static void SetFormClass(FormLogin form)
        {
            SetClassLong(form.Handle, UIDesign.GCL_STYLE, UIDesign.GetClassLong(form.Handle, UIDesign.GCL_STYLE) | UIDesign.CS_DropSHADOW);
        }
        #endregion

        #region 窗体移动API
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int IParam);
        [DllImport("user32")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam);
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0xF010;
        private const int HTCAPTION = 0x0002;
        private const int WM_SETREDRAW = 0xB;
        /// <summary>
        /// 设置窗体可拖动
        /// </summary>
        /// <param name="form"></param>
        public static void SetFormMove(FormLogin form)
        {
            if (form.WindowState == FormWindowState.Normal)
            {
                ReleaseCapture();
                SendMessage(form.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            }
        }
        #endregion


        #region  设置圆角
        public static void SetWindowRegion(Form form, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath FormPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, form.Width, form.Height);
            FormPath = GetRoundedRectPath(rect, radius);
            form.Region = new Region(FormPath);
        }
        public static void SetWindowRegion(Panel panel, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath FormPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, panel.Width, panel.Height);
            FormPath = GetRoundedRectPath(rect, radius);
            panel.Region = new Region(FormPath);
        }
        public static void SetWindowRegion(Button button, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath FormPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, button.Width, button.Height);
            FormPath = GetRoundedRectPath(rect, radius);
            button.Region = new Region(FormPath);
        }
        private static GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            Rectangle arcRect = new Rectangle(rect.Location, new Size(radius, radius));
            GraphicsPath path = new GraphicsPath();

            path.AddArc(arcRect, 180, 90);//左上角

            arcRect.X = rect.Right - radius;//右上角
            path.AddArc(arcRect, 270, 90);

            arcRect.Y = rect.Bottom - radius;// 右下角
            path.AddArc(arcRect, 0, 90);

            arcRect.X = rect.Left;// 左下角
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }
        #endregion

        #region  只显示一个panel
        public static void showPanel(Panel[] panels, int n)
        {
            for (int i = 0; i < 5 ; i++)
            {
                panels[i].Visible = false;
            }
            panels[n].Visible = true;
            panels[n].Location = new System.Drawing.Point(119, 81);
            panels[n].Size = new System.Drawing.Size(960, 562);
        }
        #endregion
    }
}
