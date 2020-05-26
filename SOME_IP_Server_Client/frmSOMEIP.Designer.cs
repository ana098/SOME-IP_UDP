namespace SOME_IP_Server_Client
{
    partial class Client_Form
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
            this.tbLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tbLog
            // 
            this.tbLog.Enabled = false;
            this.tbLog.Location = new System.Drawing.Point(12, 160);
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(493, 167);
            this.tbLog.TabIndex = 0;
            this.tbLog.Text = "";
            // 
            // Client_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 339);
            this.Controls.Add(this.tbLog);
            this.Name = "Client_Form";
            this.Text = "SOME/IP";
            this.Load += new System.EventHandler(this.Client_Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox tbLog;

    }
}

