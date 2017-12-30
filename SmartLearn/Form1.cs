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
using RestSharp;
using MetroFramework;

namespace SmartLearn
{
	public partial class Form1 : MetroFramework.Forms.MetroForm
	{

		const string UrlGetExam = "zhixuebao/zhixuebao/main/getUserExamList/?actualPosition={1}&pageIndex={0}&pageSize=10";

		CookieContainer jar;
		RestClient client;

		class ExamInfos
		{
			public class Exam
			{
				public string examId, examName;
			}
			public Exam[] examList;
		}

		public Form1(CookieContainer CookieJar)
		{
			InitializeComponent();

			//Get Exams
			jar = CookieJar;
			client = new RestClient("http://www.zhixue.com");
			client.CookieContainer = jar;

			var UrlGetExamFormatted = string.Format(UrlGetExam, 1, 0);
			var ReqGetExam = new RestRequest(UrlGetExamFormatted, Method.GET);
			var Exams = Newtonsoft.Json.JsonConvert.DeserializeObject<ExamInfos>(client.Execute(ReqGetExam).Content);

			foreach (var exam in Exams.examList)
			{
				var item = new ListViewItem();
				item.Text = exam.examName;
				metroListView1.Items.Add(item);
			}
			
			
		}

		private void metroButton1_Click(object sender, EventArgs e)
		{
			var SelectedItem = metroListView1.SelectedItems;
			if (SelectedItem.Count == 0)
			{
				MetroMessageBox.Show(this, "未选择考试", "");
			}
			else if (SelectedItem.Count == 1)
			{


			}
		}
	}
}
