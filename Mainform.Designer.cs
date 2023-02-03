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
            this.Button_Install = new System.Windows.Forms.Button();
            this.Button_Browse = new System.Windows.Forms.Button();
            this.Button_RestoreBackups = new System.Windows.Forms.Button();
            this.FileDialog_Browse = new System.Windows.Forms.OpenFileDialog();
            this.Value_FogEndDist = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Value_FogEndDist)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_Install
            // 
            this.Button_Install.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Button_Install.Location = new System.Drawing.Point(204, 56);
            this.Button_Install.Name = "Button_Install";
            this.Button_Install.Size = new System.Drawing.Size(98, 24);
            this.Button_Install.TabIndex = 83;
            this.Button_Install.Text = "Install";
            this.Button_Install.UseVisualStyleBackColor = true;
            this.Button_Install.Click += new System.EventHandler(this.Button_Install_Click);
            // 
            // Button_Browse
            // 
            this.Button_Browse.AllowDrop = true;
            this.Button_Browse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Button_Browse.Location = new System.Drawing.Point(12, 14);
            this.Button_Browse.Name = "Button_Browse";
            this.Button_Browse.Size = new System.Drawing.Size(128, 24);
            this.Button_Browse.TabIndex = 82;
            this.Button_Browse.Text = "Load Dark Souls exe";
            this.Button_Browse.UseVisualStyleBackColor = true;
            this.Button_Browse.Click += new System.EventHandler(this.Button_Browse_Click);
            // 
            // Button_RestoreBackups
            // 
            this.Button_RestoreBackups.AllowDrop = true;
            this.Button_RestoreBackups.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Button_RestoreBackups.Location = new System.Drawing.Point(12, 56);
            this.Button_RestoreBackups.Name = "Button_RestoreBackups";
            this.Button_RestoreBackups.Size = new System.Drawing.Size(128, 24);
            this.Button_RestoreBackups.TabIndex = 86;
            this.Button_RestoreBackups.Text = "Restore Backups";
            this.Button_RestoreBackups.UseVisualStyleBackColor = true;
            this.Button_RestoreBackups.Click += new System.EventHandler(this.Button_RestoreBackups_Click);
            // 
            // FileDialog_Browse
            // 
            this.FileDialog_Browse.Filter = "Dark Souls executable|DarkSoulsRemastered.exe; DARKSOULS.exe|All Files|*.*";
            // 
            // Value_FogEndDist
            // 
            this.Value_FogEndDist.Location = new System.Drawing.Point(221, 27);
            this.Value_FogEndDist.Name = "Value_FogEndDist";
            this.Value_FogEndDist.Size = new System.Drawing.Size(81, 23);
            this.Value_FogEndDist.TabIndex = 87;
            this.Value_FogEndDist.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 88;
            this.label1.Text = "Fog Thickness";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 90);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Value_FogEndDist);
            this.Controls.Add(this.Button_RestoreBackups);
            this.Controls.Add(this.Button_Browse);
            this.Controls.Add(this.Button_Install);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Value_FogEndDist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button Button_Install;
        private Button Button_Browse;
        private Button Button_RestoreBackups;
        private OpenFileDialog FileDialog_Browse;
        private NumericUpDown Value_FogEndDist;
        private Label label1;
    }
}