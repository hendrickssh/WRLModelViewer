namespace Program2
{
   partial class Form1
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
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
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
            this.glControl1 = new OpenTK.GLControl();
            this.tbXEye = new System.Windows.Forms.TrackBar();
            this.tbYEye = new System.Windows.Forms.TrackBar();
            this.tbZEye = new System.Windows.Forms.TrackBar();
            this.btnResetView = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.lblXVal = new System.Windows.Forms.Label();
            this.lblYVal = new System.Windows.Forms.Label();
            this.lblZVal = new System.Windows.Forms.Label();
            this.lblCurrentFile = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbXEye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbYEye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbZEye)).BeginInit();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(12, 40);
            this.glControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(541, 518);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            // 
            // tbXEye
            // 
            this.tbXEye.Location = new System.Drawing.Point(559, 40);
            this.tbXEye.Maximum = 25;
            this.tbXEye.Minimum = -25;
            this.tbXEye.Name = "tbXEye";
            this.tbXEye.Size = new System.Drawing.Size(193, 45);
            this.tbXEye.SmallChange = 5;
            this.tbXEye.TabIndex = 5;
            this.tbXEye.Value = 5;
            this.tbXEye.Scroll += new System.EventHandler(this.tbXEye_Scroll);
            // 
            // tbYEye
            // 
            this.tbYEye.Location = new System.Drawing.Point(559, 91);
            this.tbYEye.Maximum = 25;
            this.tbYEye.Minimum = -25;
            this.tbYEye.Name = "tbYEye";
            this.tbYEye.Size = new System.Drawing.Size(193, 45);
            this.tbYEye.TabIndex = 5;
            this.tbYEye.Value = 5;
            this.tbYEye.Scroll += new System.EventHandler(this.tbYEye_Scroll);
            // 
            // tbZEye
            // 
            this.tbZEye.Location = new System.Drawing.Point(559, 142);
            this.tbZEye.Maximum = 25;
            this.tbZEye.Minimum = -25;
            this.tbZEye.Name = "tbZEye";
            this.tbZEye.Size = new System.Drawing.Size(193, 45);
            this.tbZEye.TabIndex = 3;
            this.tbZEye.Value = 5;
            this.tbZEye.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // btnResetView
            // 
            this.btnResetView.Location = new System.Drawing.Point(559, 193);
            this.btnResetView.Name = "btnResetView";
            this.btnResetView.Size = new System.Drawing.Size(193, 45);
            this.btnResetView.TabIndex = 6;
            this.btnResetView.Text = "Reset View";
            this.btnResetView.UseVisualStyleBackColor = true;
            this.btnResetView.Click += new System.EventHandler(this.btnResetView_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "File";
            this.openFile.Filter = "(*.wrl)|*.wrl";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(12, 11);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 7;
            this.btnOpenFile.Text = "Load File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // lblXVal
            // 
            this.lblXVal.AutoSize = true;
            this.lblXVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXVal.Location = new System.Drawing.Point(759, 40);
            this.lblXVal.Name = "lblXVal";
            this.lblXVal.Size = new System.Drawing.Size(62, 25);
            this.lblXVal.TabIndex = 8;
            this.lblXVal.Text = "X = 5";
            // 
            // lblYVal
            // 
            this.lblYVal.AutoSize = true;
            this.lblYVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYVal.Location = new System.Drawing.Point(758, 91);
            this.lblYVal.Name = "lblYVal";
            this.lblYVal.Size = new System.Drawing.Size(63, 25);
            this.lblYVal.TabIndex = 9;
            this.lblYVal.Text = "Y = 5";
            // 
            // lblZVal
            // 
            this.lblZVal.AutoSize = true;
            this.lblZVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZVal.Location = new System.Drawing.Point(759, 142);
            this.lblZVal.Name = "lblZVal";
            this.lblZVal.Size = new System.Drawing.Size(61, 25);
            this.lblZVal.TabIndex = 10;
            this.lblZVal.Text = "Z = 5";
            // 
            // lblCurrentFile
            // 
            this.lblCurrentFile.AutoSize = true;
            this.lblCurrentFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentFile.Location = new System.Drawing.Point(560, 241);
            this.lblCurrentFile.Name = "lblCurrentFile";
            this.lblCurrentFile.Size = new System.Drawing.Size(132, 24);
            this.lblCurrentFile.TabIndex = 11;
            this.lblCurrentFile.Text = "Current File: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 562);
            this.Controls.Add(this.lblCurrentFile);
            this.Controls.Add(this.lblZVal);
            this.Controls.Add(this.lblYVal);
            this.Controls.Add(this.lblXVal);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.btnResetView);
            this.Controls.Add(this.tbZEye);
            this.Controls.Add(this.tbYEye);
            this.Controls.Add(this.tbXEye);
            this.Controls.Add(this.glControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Program 2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.tbXEye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbYEye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbZEye)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private OpenTK.GLControl glControl1;
      private System.Windows.Forms.TrackBar tbXEye;
      private System.Windows.Forms.TrackBar tbYEye;
      private System.Windows.Forms.TrackBar tbZEye;
      private System.Windows.Forms.Button btnResetView;
      private System.Windows.Forms.OpenFileDialog openFile;
      private System.Windows.Forms.Button btnOpenFile;
      private System.Windows.Forms.Label lblXVal;
      private System.Windows.Forms.Label lblYVal;
      private System.Windows.Forms.Label lblZVal;
        private System.Windows.Forms.Label lblCurrentFile;
    }
}

