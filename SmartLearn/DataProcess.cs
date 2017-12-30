using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn
{
	[Serializable]
	class ScoreJson
	{

		public subject[] subjectList;
		public string BackId,FrontId;

		[Serializable]
		public struct subject
		{
			public string subjectName;
			public double score;
		}

	}

	class StudentInfo
	{

		public string BackID, FrontId, ClassID, Name;

		public static List<StudentInfo> LoadFromFile(string filename)
		{
			var InfoTextArr = File.ReadAllLines(filename);
			var InfoList = new List<StudentInfo>();

			foreach (var a in InfoTextArr)
			{
				try
				{
					var ss = a.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
					var stud = new StudentInfo();
					stud.FrontId = ss[0];
					stud.Name = ss[1];
					stud.ClassID = ss[2];
					stud.BackID = GetBackID(stud.FrontId);

					InfoList.Add(stud);
				}
				catch (Exception)
				{
					
				}
			}

			return InfoList;
		}

		public static Dictionary<string,StudentInfo> LoadToRefer(List<StudentInfo> InfoList)
		{
			var ReferList = new Dictionary<string, StudentInfo>();
			
			foreach(var stud in InfoList)
			{
				ReferList[stud.FrontId] = stud;
			}

			return ReferList;
		}

		private const long CBackID = 4444000020018399573;
		private const int CID = 35380636;

		public static string GetFrontID(long BackstageID)
		{
			var result = BackstageID - CBackID + CID;
			return result.ToString();
		}

		public static string GetFrontID(string BackstageID)
		{
			return GetFrontID(long.Parse(BackstageID));
		}

		public static string GetBackID(int FrontID)
		{
			var r = FrontID - CID + CBackID;
			return r.ToString();
		}

		public static string GetBackID(string FrontID)
		{
			return GetBackID(int.Parse(FrontID));
		}
	}




	class ExamInfos
	{
		public class Exam
		{
			public string examId, examName;
		}
		public Exam[] examList;
	}

}
