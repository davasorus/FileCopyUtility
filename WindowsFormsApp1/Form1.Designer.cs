namespace WindowsFormsApp1
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
            this.Help_Button = new System.Windows.Forms.Button();
            this.Copy_Button = new System.Windows.Forms.Button();
            this.Location_Copy_From = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Location_Copy_To = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Async_File_Copy = new System.Windows.Forms.CheckBox();
            this.Normal_File_Copy = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Location_ZipFIle_To = new System.Windows.Forms.TextBox();
            this.CompressedFileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSL = new System.Windows.Forms.ToolStripLabel();
            this.TSProgBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Help_Button
            // 
            this.Help_Button.Location = new System.Drawing.Point(292, 13);
            this.Help_Button.Name = "Help_Button";
            this.Help_Button.Size = new System.Drawing.Size(75, 23);
            this.Help_Button.TabIndex = 0;
            this.Help_Button.Text = "Help";
            this.Help_Button.UseVisualStyleBackColor = true;
            this.Help_Button.Click += new System.EventHandler(this.Help_Button_Click);
            // 
            // Copy_Button
            // 
            this.Copy_Button.Location = new System.Drawing.Point(292, 185);
            this.Copy_Button.Name = "Copy_Button";
            this.Copy_Button.Size = new System.Drawing.Size(75, 23);
            this.Copy_Button.TabIndex = 5;
            this.Copy_Button.Text = "Copy";
            this.Copy_Button.UseVisualStyleBackColor = true;
            this.Copy_Button.Click += new System.EventHandler(this.Copy_Button_Click);
            // 
            // Location_Copy_From
            // 
            this.Location_Copy_From.Location = new System.Drawing.Point(1, 68);
            this.Location_Copy_From.Name = "Location_Copy_From";
            this.Location_Copy_From.Size = new System.Drawing.Size(360, 20);
            this.Location_Copy_From.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Location you are copy from";
            // 
            // Location_Copy_To
            // 
            this.Location_Copy_To.Location = new System.Drawing.Point(1, 107);
            this.Location_Copy_To.Name = "Location_Copy_To";
            this.Location_Copy_To.Size = new System.Drawing.Size(360, 20);
            this.Location_Copy_To.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Location you are copying to";
            // 
            // Async_File_Copy
            // 
            this.Async_File_Copy.AutoSize = true;
            this.Async_File_Copy.Location = new System.Drawing.Point(13, 13);
            this.Async_File_Copy.Name = "Async_File_Copy";
            this.Async_File_Copy.Size = new System.Drawing.Size(101, 17);
            this.Async_File_Copy.TabIndex = 100;
            this.Async_File_Copy.Text = "Async File Copy";
            this.Async_File_Copy.UseVisualStyleBackColor = true;
            // 
            // Normal_File_Copy
            // 
            this.Normal_File_Copy.AutoSize = true;
            this.Normal_File_Copy.Location = new System.Drawing.Point(146, 13);
            this.Normal_File_Copy.Name = "Normal_File_Copy";
            this.Normal_File_Copy.Size = new System.Drawing.Size(106, 17);
            this.Normal_File_Copy.TabIndex = 101;
            this.Normal_File_Copy.Text = "Normal FIle Copy";
            this.Normal_File_Copy.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-2, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Compression Folder";
            // 
            // Location_ZipFIle_To
            // 
            this.Location_ZipFIle_To.Location = new System.Drawing.Point(1, 185);
            this.Location_ZipFIle_To.Name = "Location_ZipFIle_To";
            this.Location_ZipFIle_To.Size = new System.Drawing.Size(134, 20);
            this.Location_ZipFIle_To.TabIndex = 4;
            // 
            // CompressedFileName
            // 
            this.CompressedFileName.Location = new System.Drawing.Point(1, 146);
            this.CompressedFileName.Name = "CompressedFileName";
            this.CompressedFileName.Size = new System.Drawing.Size(360, 20);
            this.CompressedFileName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Name of Compressed File";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSL,
            this.TSProgBar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 211);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(373, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TSL
            // 
            this.TSL.Name = "TSL";
            this.TSL.Size = new System.Drawing.Size(0, 22);
            // 
            // TSProgBar
            // 
            this.TSProgBar.Name = "TSProgBar";
            this.TSProgBar.Size = new System.Drawing.Size(100, 22);
            this.TSProgBar.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 236);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CompressedFileName);
            this.Controls.Add(this.Location_ZipFIle_To);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Normal_File_Copy);
            this.Controls.Add(this.Async_File_Copy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Location_Copy_To);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Location_Copy_From);
            this.Controls.Add(this.Copy_Button);
            this.Controls.Add(this.Help_Button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Help_Button;
        private System.Windows.Forms.Button Copy_Button;
        private System.Windows.Forms.TextBox Location_Copy_From;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Location_Copy_To;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox Async_File_Copy;
        private System.Windows.Forms.CheckBox Normal_File_Copy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Location_ZipFIle_To;
        private System.Windows.Forms.TextBox CompressedFileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel TSL;
        private System.Windows.Forms.ToolStripProgressBar TSProgBar;
    }
}

