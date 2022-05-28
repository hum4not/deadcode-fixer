using System;
using System.Windows.Forms;

namespace Error_Detector_DeadCode;

internal static class Program
{
	[STAThread]
	private static void Main()
	{
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		Application.Run(new Form1());
	}
}
