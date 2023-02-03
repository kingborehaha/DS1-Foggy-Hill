namespace FogMod
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Button_Install = new System.Windows.Forms.Button();
            this.FileDialog_Browse = new System.Windows.Forms.OpenFileDialog();
            this.Value_FogEndDist = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Button_RestoreBackups = new System.Windows.Forms.Button();
            this.Button_Browse = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.Value_FogBrightness = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.Value_LockOnDist = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Value_FogEndDist)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Value_FogBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Value_LockOnDist)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_Install
            // 
            this.Button_Install.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Button_Install.Location = new System.Drawing.Point(212, 83);
            this.Button_Install.Name = "Button_Install";
            this.Button_Install.Size = new System.Drawing.Size(86, 24);
            this.Button_Install.TabIndex = 83;
            this.Button_Install.Text = "Install";
            this.Button_Install.UseVisualStyleBackColor = true;
            this.Button_Install.Click += new System.EventHandler(this.Button_Install_Click);
            // 
            // FileDialog_Browse
            // 
            this.FileDialog_Browse.Filter = "Dark Souls executable|DarkSoulsRemastered.exe; DARKSOULS.exe|All Files|*.*";
            // 
            // Value_FogEndDist
            // 
            this.Value_FogEndDist.Location = new System.Drawing.Point(213, 84);
            this.Value_FogEndDist.Name = "Value_FogEndDist";
            this.Value_FogEndDist.Size = new System.Drawing.Size(73, 23);
            this.Value_FogEndDist.TabIndex = 87;
            this.toolTip1.SetToolTip(this.Value_FogEndDist, "Distance until fog becomes 100% thick");
            this.Value_FogEndDist.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 88;
            this.label1.Text = "Max fog distance";
            this.toolTip1.SetToolTip(this.label1, "Distance until fog becomes 100% thick");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(315, 144);
            this.tabControl1.TabIndex = 89;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Button_RestoreBackups);
            this.tabPage1.Controls.Add(this.Button_Install);
            this.tabPage1.Controls.Add(this.Button_Browse);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(307, 116);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Button_RestoreBackups
            // 
            this.Button_RestoreBackups.AllowDrop = true;
            this.Button_RestoreBackups.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Button_RestoreBackups.Location = new System.Drawing.Point(8, 83);
            this.Button_RestoreBackups.Name = "Button_RestoreBackups";
            this.Button_RestoreBackups.Size = new System.Drawing.Size(86, 24);
            this.Button_RestoreBackups.TabIndex = 88;
            this.Button_RestoreBackups.Text = "Uninstall";
            this.Button_RestoreBackups.UseVisualStyleBackColor = true;
            this.Button_RestoreBackups.Click += new System.EventHandler(this.Button_RestoreBackups_Click);
            // 
            // Button_Browse
            // 
            this.Button_Browse.AllowDrop = true;
            this.Button_Browse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Button_Browse.Location = new System.Drawing.Point(8, 20);
            this.Button_Browse.Name = "Button_Browse";
            this.Button_Browse.Size = new System.Drawing.Size(86, 24);
            this.Button_Browse.TabIndex = 87;
            this.Button_Browse.Text = "Browse";
            this.Button_Browse.UseVisualStyleBackColor = true;
            this.Button_Browse.Click += new System.EventHandler(this.Button_Browse_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.Value_FogBrightness);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.Value_LockOnDist);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.Value_FogEndDist);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(307, 116);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Options";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 15);
            this.label3.TabIndex = 92;
            this.label3.Text = "Fog Brightness (%)";
            this.toolTip1.SetToolTip(this.label3, "Brightness of fog. 100 = 100% (white), 0 = 0% (black)");
            // 
            // Value_FogBrightness
            // 
            this.Value_FogBrightness.Location = new System.Drawing.Point(213, 31);
            this.Value_FogBrightness.Name = "Value_FogBrightness";
            this.Value_FogBrightness.Size = new System.Drawing.Size(73, 23);
            this.Value_FogBrightness.TabIndex = 91;
            this.toolTip1.SetToolTip(this.Value_FogBrightness, "Brightness of fog. 100 = 100% (white), 0 = 0% (black)");
            this.Value_FogBrightness.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 15);
            this.label2.TabIndex = 90;
            this.label2.Text = "Lock-On Distance";
            this.toolTip1.SetToolTip(this.label2, "Max distance enemies can be locked onto");
            // 
            // Value_LockOnDist
            // 
            this.Value_LockOnDist.Location = new System.Drawing.Point(20, 31);
            this.Value_LockOnDist.Name = "Value_LockOnDist";
            this.Value_LockOnDist.Size = new System.Drawing.Size(73, 23);
            this.Value_LockOnDist.TabIndex = 89;
            this.toolTip1.SetToolTip(this.Value_LockOnDist, "Max distance enemies can be locked onto");
            this.Value_LockOnDist.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 142);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Value_FogEndDist)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Value_FogBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Value_LockOnDist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Button Button_Install;
        private OpenFileDialog FileDialog_Browse;
        private NumericUpDown Value_FogEndDist;
        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button Button_RestoreBackups;
        private Button Button_Browse;
        private TabPage tabPage2;
        private Label label2;
        private NumericUpDown Value_LockOnDist;
        private Label label3;
        private NumericUpDown Value_FogBrightness;
        private ToolTip toolTip1;
    }
}