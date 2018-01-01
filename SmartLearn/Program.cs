using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartLearn
{
	static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Directory.CreateDirectory("cache");

			var Login = new LoginForm();
			Application.Run(Login);
			var jar = Login.jar;

			Application.Run(new Form1(jar));
		}
	}
}
