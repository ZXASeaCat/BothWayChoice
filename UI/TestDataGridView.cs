using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    /// <summary>

    /// 自定义DataGridView控件

    /// </summary>

    public class TestDataGridView : System.Windows.Forms.DataGridView
    {

        public static int _RowHeadWidth = 12;

        public TestDataGridView()
        {
            this.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.RowHeadersVisible = true;
            this.RowsDefaultCellStyle.BackColor = Color.White; 
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(167, 222, 214);
            this.DefaultCellStyle.SelectionBackColor = Color.FromArgb(114, 206, 202);
            this.DefaultCellStyle.SelectionForeColor = Color.White;
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.EnableHeadersVisualStyles = false;
        }


        /// <summary>
        /// 重绘Column、Row
        /// </summary>
        /// <param name="e"></param>
        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            //通过e.RowIndex == -1可以判断当前重绘区域是否Column
            if (e.RowIndex == -1)
            {
                drawColumnAndRow(e);
                //e.Handled = true是告诉系统，哥已经自己重绘过了，你任务到此结束。
                e.Handled = true;
            }
            //通过e.ColumnIndex < 0 && e.RowIndex >= 0可以判断当前重绘区域是否RowHeader
            else if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                drawColumnAndRow(e);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Column和RowHeader绘制
        /// </summary>
        /// <param name="e"></param>
        void drawColumnAndRow(DataGridViewCellPaintingEventArgs e)
        {
            //绘制背景色
            //创建渐变画刷
            using (LinearGradientBrush backbrush =
                new LinearGradientBrush(e.CellBounds,
                    Color.FromArgb(200,191,131),
                    //ProfessionalColors.MenuItemPressedGradientBegin,
                    //ProfessionalColors.MenuItemPressedGradientMiddle
                    Color.FromArgb(52,186,209), LinearGradientMode.Vertical))
            {
                Rectangle border = e.CellBounds;
                border.Width -= 1;
                //当前区域内绘制画刷效果
                e.Graphics.FillRectangle(backbrush, border);
                //绘制Column、Row的Text信息
                e.PaintContent(border);
                //绘制边框
                //ControlPaint.DrawBorder3D(e.Graphics, border, Border3DStyle.Etched);
            }

        }


        /// <summary>
        /// Row重绘前处理
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRowPrePaint(DataGridViewRowPrePaintEventArgs e)
        {
            base.OnRowPrePaint(e);
            //是否是选中状态
            if ((e.State & DataGridViewElementStates.Selected) ==
                        DataGridViewElementStates.Selected)
            {
                // 计算选中区域Size
                int width = this.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + _RowHeadWidth;
                Rectangle rowBounds = new Rectangle(
                  0, e.RowBounds.Top, width,
                    e.RowBounds.Height);
                // 绘制选中背景色
                using (LinearGradientBrush backbrush =
                    new LinearGradientBrush(rowBounds,
                        Color.FromArgb(167, 222, 214),
                        Color.FromArgb(167, 222, 214),
                        //e.InheritedRowStyle.ForeColor, 
                        90.0f))
                {
                    e.Graphics.FillRectangle(backbrush, rowBounds);
                    e.PaintCellsContent(rowBounds);
                    e.Handled = true;
                }



            }

        }

        /// <summary>
        /// Row重绘后处理
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {

            base.OnRowPostPaint(e);

            int width = this.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + _RowHeadWidth;

            Rectangle rowBounds = new Rectangle(

                   0, e.RowBounds.Top, width, e.RowBounds.Height);



            if (this.CurrentCellAddress.Y == e.RowIndex)
            {

                //设置选中边框

                e.DrawFocus(rowBounds, true);

            }

        }
    }
}
