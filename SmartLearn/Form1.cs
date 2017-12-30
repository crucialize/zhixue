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
using Newtonsoft.Json;
using MetroFramework;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace SmartLearn
{
	public partial class Form1 : MetroFramework.Forms.MetroForm
	{
		const string UrlGetExam = "zhixuebao/zhixuebao/main/getUserExamList/?actualPosition={1}&pageIndex={0}&pageSize=10";

		CookieContainer jar;
		RestClient client;
		ExamInfos.Exam[] examList;
		List<StudentInfo> infos = new List<StudentInfo>();
		Dictionary<string, StudentInfo> ReferList = new Dictionary<string, StudentInfo>();
		string[] classList;

		public Form1(CookieContainer CookieJar)
		{
			CheckForIllegalCrossThreadCalls = false;
			HashSet<string> classList = new HashSet<string>();
			InitializeComponent();

			//Load studentList

			try
			{
				infos=StudentInfo.LoadFromFile("refer.txt");
			}
			catch (Exception)
			{
				MetroMessageBox.Show(this, "未找到学生信息", "");
				Environment.Exit(0);
			}

			ReferList = StudentInfo.LoadToRefer(infos);

			//Load classes

			foreach(var stud in infos)
			{
				classList.Add(stud.ClassID);
			}

			foreach(var c in classList)
			{
				var item = new ListViewItem(c);
				metroListView2.Items.Add(item);
			}

			this.classList = classList.ToArray();
			

			//Get Exam list
			jar = CookieJar;
			client = new RestClient("http://www.zhixue.com");
			client.CookieContainer = jar;

			var UrlGetExamFormatted = string.Format(UrlGetExam, 1, 0);
			var ReqGetExam = new RestRequest(UrlGetExamFormatted, Method.GET);
			var Exams = JsonConvert.DeserializeObject<ExamInfos>(client.Execute(ReqGetExam).Content);

			examList = Exams.examList;

			foreach (var exam in examList)
			{
				var item = new ListViewItem();
				item.Text = exam.examName;
				metroListView1.Items.Add(item);
			}
			
			
		}

		private void metroButton1_Click(object sender, EventArgs e)
		{
			metroProgressSpinner1.Visible = true;
			metroButton1.Enabled = false;
			metroListView2.Enabled = false;

			var reGet = metroCheckBox1.Checked;

			new Thread(() =>
			{
				var SelectedItem = metroListView1.SelectedItems;
				var ExamIndices = metroListView1.SelectedIndices;
				var ClassIndecies = metroListView2.CheckedIndices;

				if (ExamIndices.Count == 0)
				{
					MetroMessageBox.Show(this, "未选择考试", "");
				}
				else if (ClassIndecies.Count == 0)
				{
					MetroMessageBox.Show(this, "未选择班级", "");
				}
				else if (ExamIndices.Count == 1)
				{


					var examId = examList[metroListView1.SelectedIndices[0]].examId;



					//Get ScoreJson DATAMODEL from Cache or Web:
					List<ScoreJson> ScoreCollection = new List<ScoreJson>();

					if (File.Exists("cache\\" + examId)&&!reGet)
					{
						//from cache:
						using (var fs = File.OpenRead("cache\\" + examId))
						{
							ScoreCollection = (List<ScoreJson>)new BinaryFormatter().Deserialize(fs);
						}
					}
					else
					{
						//from web:
						foreach (var stud in infos)
						{

							bool flag = false;
							for (int i = 0; i < ClassIndecies.Count; i++)
							{
								flag |= classList[ClassIndecies[i]] == stud.ClassID;
							}
							if (flag == false)
								break;

							try
							{
								var scoreJ = GetScore(examId, stud);
								scoreJ.BackId = stud.BackID;
								scoreJ.FrontId = stud.FrontId;
								ScoreCollection.Add(scoreJ);
							}
							catch (Exception)
							{

							}
						}

						//save into cache:
						using (var fs = File.OpenWrite("cache\\" + examId))
						{
							new BinaryFormatter().Serialize(fs, ScoreCollection);
						}
					}


					//Generate ViewModel:
					var table = new DataTable();

					//get subject list
					var subjectList = new HashSet<string>();
					foreach (var j in ScoreCollection)
					{
						foreach (var k in j.subjectList)
							subjectList.Add(k.subjectName);
					}

					//table column structure

					table.Columns.Add("id");
					table.Columns.Add("姓名");
					table.Columns.Add("班级");
					table.Columns.Add("总分");
					table.Columns.Add("总分r");

					foreach (var sn in subjectList)
					{
						table.Columns.Add(sn);
						table.Columns.Add(sn + "r");
					}

					//fill the table
					foreach (var stud in ScoreCollection)
					{
						var row = table.NewRow();

						row["id"] = stud.FrontId;
						row["姓名"] = ReferList[stud.FrontId].Name;
						row["班级"] = ReferList[stud.FrontId].ClassID;
						row["总分"] = (from o in stud.subjectList select o).Sum(p => p.score);

						foreach (var sn in subjectList)
						{
							row[sn] = 0.0;
							foreach (var c in from o in stud.subjectList where o.subjectName == sn select o)
								row[sn] = c.score;
						}

						table.Rows.Add(row);
					}

					//to do:rank


					new Thread(() =>
					{
						var ResultVU = new ResultView(table);
						ResultVU.ShowDialog();
					}).Start();


					metroProgressSpinner1.Visible = false;
					metroButton1.Enabled = true;
					metroListView2.Enabled = true;

				}
			}).Start();
		}

		private ScoreJson GetScore(string examId,StudentInfo stud)
		{
			const string pk_pattern = "/zhixuebao/zhixuebao/personal/studentPkData/?examId={0}&pkId={1}";

			var pk_url = string.Format(pk_pattern, examId, stud.BackID);
			var req = new RestRequest(pk_url, Method.GET);
			var resBody = client.Execute(req).Content;

			var json = JsonConvert.DeserializeObject<ScoreJson[]>(resBody);
			return json[1];
		}

	}
}
