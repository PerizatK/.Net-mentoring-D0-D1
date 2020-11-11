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
            this.lName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tName
            // 
            this.tName.Location = new System.Drawing.Point(45, 28);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(134, 20);
            this.tName.TabIndex = 0;
            this.tName.Text = "Enter your name here";
            this.tName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tName_KeyUp);
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(42, 80);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(0, 13);
            this.lName.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 165);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.tName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tName;
        private System.Windows.Forms.Label lName;
    }
}

