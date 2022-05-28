using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsApp3;

public class CastomButton : Button
{
	private StringFormat SF = new StringFormat();

	private bool MouseEntered;

	private new bool MouseDown;

	public CastomButton()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		DoubleBuffered = true;
		base.Size = new Size(100, 30);
		BackColor = Color.Brown;
		ForeColor = Color.White;
		Cursor = Cursors.Hand;
		SF.Alignment = StringAlignment.Center;
		SF.LineAlignment = StringAlignment.Center;
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		Graphics graphics = e.Graphics;
		graphics.SmoothingMode = SmoothingMode.HighQuality;
		graphics.Clear(base.Parent.BackColor);
		Rectangle rectangle = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
		graphics.DrawRectangle(new Pen(BackColor), rectangle);
		graphics.FillRectangle(new SolidBrush(BackColor), rectangle);
		if (MouseEntered)
		{
			graphics.DrawRectangle(new Pen(Color.FromArgb(50, Color.White)), rectangle);
			graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.White)), rectangle);
		}
		if (MouseDown)
		{
			graphics.DrawRectangle(new Pen(Color.FromArgb(255, Color.FromArgb(0, 0, 0, 0))), rectangle);
			graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, Color.FromArgb(0, 0, 0, 0))), rectangle);
		}
		graphics.DrawString(Text, Font, new SolidBrush(ForeColor), rectangle, SF);
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		base.OnMouseEnter(e);
		MouseEntered = true;
		Invalidate();
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		MouseEntered = false;
		Invalidate();
	}

	protected override void OnMouseDown(MouseEventArgs mevent)
	{
		base.OnMouseDown(mevent);
		MouseDown = true;
		Invalidate();
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		base.OnMouseUp(mevent);
		MouseDown = false;
		Invalidate();
	}
}
