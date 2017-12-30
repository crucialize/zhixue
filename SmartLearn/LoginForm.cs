using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartLearn
{
	public partial class LoginForm : MetroFramework.Forms.MetroForm
	{
		public CookieContainer jar;

		public LoginForm()
		{
			InitializeComponent();
			webBrowser1.ScriptErrorsSuppressed = true;
			webBrowser1.Navigate("http://www.zhixue.com");
			timer1.Start();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if(webBrowser1.Url.ToString()== "http://www.zhixue.com/container/container/student/index/")
			{
				timer1.Stop();

				this.jar = ParseCookie(webBrowser1.Document.Cookie);
				webBrowser1.Document.Cookie = null;//clear WebBrowser cookie

				webBrowser1.Dispose();
				this.Dispose();
			}
		}

		private CookieContainer ParseCookie(string CookieString)
		{
			CookieContainer myCookieContainer = new CookieContainer();

			string cookieStr = webBrowser1.Document.Cookie;
			string[] cookstr = cookieStr.Split(';');
			foreach (string str in cookstr)
			{
				var str1 = str.Replace(",", "|");
				string[] cookieNameValue = str1.Split('=');
				Cookie ck = new Cookie(cookieNameValue[0].Trim().ToString(), cookieNameValue[1].Trim().ToString());
				ck.Domain = "www.zhixue.com";
				myCookieContainer.Add(ck);
			}

			return myCookieContainer;
		}
	}
}
