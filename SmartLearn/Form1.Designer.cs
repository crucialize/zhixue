namespace SmartLearn
{
	partial class Form1
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.metroListView1 = new MetroFramework.Controls.MetroListView();
			this.metroButton1 = new MetroFramework.Controls.MetroButton();
			this.SuspendLayout();
			// 
			// metroListView1
			// 
			this.metroListView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.metroListView1.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.metroListView1.FullRowSelect = true;
			this.metroListView1.Location = new System.Drawing.Point(20, 60);
			this.metroListView1.MultiSelect = false;
			this.metroListView1.Name = "metroListView1";
			this.metroListView1.OwnerDraw = true;
			this.metroListView1.Size = new System.Drawing.Size(618, 559);
			this.metroListView1.TabIndex = 0;
			this.metroListView1.UseCompatibleStateImageBehavior = false;
			this.metroListView1.UseSelectable = true;
			this.metroListView1.View = System.Windows.Forms.View.List;
			// 
			// metroButton1
			// 
			this.metroButton1.Location = new System.Drawing.Point(644, 63);
			this.metroButton1.Name = "metroButton1";
			this.metroButton1.Size = new System.Drawing.Size(75, 23);
			this.metroButton1.TabIndex = 1;
			this.metroButton1.Text = "获取";
			this.metroButton1.UseSelectable = true;
			this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(881, 639);
			this.Controls.Add(this.metroButton1);
			this.Controls.Add(this.metroListView1);
			this.Name = "Form1";
			this.Text = "SmartLearn";
			this.ResumeLayout(false);

		}

		#endregion

		private MetroFramework.Controls.MetroListView metroListView1;
		private MetroFramework.Controls.MetroButton metroButton1;
	}
}

