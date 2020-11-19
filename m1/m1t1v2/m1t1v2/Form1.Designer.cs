namespace m1t1v2
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
            this.tName = new System.Windows.Forms.TextBox();
            this.lNamePerson = new System.Windows.Forms.Label();
            this.lNamePersonUtils = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tName
            // 
            this.tName.Location = new System.Drawing.Point(60, 34);
            this.tName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(177, 22);
            this.tName.TabIndex = 0;
            this.tName.Text = "Enter your name here";
            this.tName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tName_KeyUp);
            // 
            // lNamePerson
            // 
            this.lNamePerson.AutoSize = true;
            this.lNamePerson.Location = new System.Drawing.Point(56, 98);
            this.lNamePerson.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lNamePerson.Name = "lNamePerson";
            this.lNamePerson.Size = new System.Drawing.Size(0, 17);
            this.lNamePerson.TabIndex = 1;
            // 
            // lNamePersonUtils
            // 
            this.lNamePersonUtils.AutoSize = true;
            this.lNamePersonUtils.Location = new System.Drawing.Point(57, 125);
            this.lNamePersonUtils.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lNamePersonUtils.Name = "lNamePersonUtils";
            this.lNamePersonUtils.Size = new System.Drawing.Size(0, 17);
            this.lNamePersonUtils.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 203);
            this.Controls.Add(this.lNamePersonUtils);
            this.Controls.Add(this.lNamePerson);
            this.Controls.Add(this.tName);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tName;
        private System.Windows.Forms.Label lNamePerson;
        private System.Windows.Forms.Label lNamePersonUtils;
    }
}

