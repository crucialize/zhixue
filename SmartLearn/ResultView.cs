using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartLearn
{
	public partial class ResultView : MetroFramework.Forms.MetroForm
	{

		DataTable table;
		public ResultView(DataTable t)
		{
			InitializeComponent();
			table = t;
			metroGrid1.DataSource = table;
			metroGrid1.Sort(metroGrid1.Columns["总分"], ListSortDirection.Descending);
		}
	}
}
