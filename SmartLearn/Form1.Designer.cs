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
			this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
			this.metroListView2 = new MetroFramework.Controls.MetroListView();
			this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
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
			this.metroListView1.Size = new System.Drawing.Size(717, 640);
			this.metroListView1.TabIndex = 0;
			this.metroListView1.UseCompatibleStateImageBehavior = false;
			this.metroListView1.UseSelectable = true;
			this.metroListView1.View = System.Windows.Forms.View.List;
			// 
			// metroButton1
			// 
			this.metroButton1.Location = new System.Drawing.Point(784, 412);
			this.metroButton1.Name = "metroButton1";
			this.metroButton1.Size = new System.Drawing.Size(75, 23);
			this.metroButton1.TabIndex = 1;
			this.metroButton1.Text = "获取";
			this.metroButton1.UseSelectable = true;
			this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
			// 
			// metroProgressSpinner1
			// 
			this.metroProgressSpinner1.Location = new System.Drawing.Point(877, 415);
			this.metroProgressSpinner1.Maximum = 100;
			this.metroProgressSpinner1.Name = "metroProgressSpinner1";
			this.metroProgressSpinner1.Size = new System.Drawing.Size(20, 20);
			this.metroProgressSpinner1.TabIndex = 2;
			this.metroProgressSpinner1.UseSelectable = true;
			this.metroProgressSpinner1.Visible = false;
			// 
			// metroListView2
			// 
			this.metroListView2.CheckBoxes = true;
			this.metroListView2.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.metroListView2.FullRowSelect = true;
			this.metroListView2.Location = new System.Drawing.Point(784, 60);
			this.metroListView2.Name = "metroListView2";
			this.metroListView2.OwnerDraw = true;
			this.metroListView2.Size = new System.Drawing.Size(151, 297);
			this.metroListView2.TabIndex = 3;
			this.metroListView2.UseCompatibleStateImageBehavior = false;
			this.metroListView2.UseSelectable = true;
			this.metroListView2.View = System.Windows.Forms.View.List;
			// 
			// metroCheckBox1
			// 
			this.metroCheckBox1.AutoSize = true;
			this.metroCheckBox1.Location = new System.Drawing.Point(784, 375);
			this.metroCheckBox1.Name = "metroCheckBox1";
			this.metroCheckBox1.Size = new System.Drawing.Size(101, 15);
			this.metroCheckBox1.TabIndex = 4;
			this.metroCheckBox1.Text = "完全重新获取";
			this.metroCheckBox1.UseSelectable = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1280, 720);
			this.Controls.Add(this.metroCheckBox1);
			this.Controls.Add(this.metroListView2);
			this.Controls.Add(this.metroProgressSpinner1);
			this.Controls.Add(this.metroButton1);
			this.Controls.Add(this.metroListView1);
			this.Name = "Form1";
			this.Resizable = false;
			this.Text = "SmartLearn";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MetroFramework.Controls.MetroListView metroListView1;
		private MetroFramework.Controls.MetroButton metroButton1;
		private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
		private MetroFramework.Controls.MetroListView metroListView2;
		private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
	}
}

