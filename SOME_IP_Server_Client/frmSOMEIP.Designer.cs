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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_LoadData = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_Send = new System.Windows.Forms.Button();
            this.PlayBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Choice = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbLog
            // 
            this.tbLog.Enabled = false;
            this.tbLog.Location = new System.Drawing.Point(13, 324);
            this.tbLog.Margin = new System.Windows.Forms.Padding(4);
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(801, 163);
            this.tbLog.TabIndex = 0;
            this.tbLog.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(347, 293);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btn_LoadData
            // 
            this.btn_LoadData.Location = new System.Drawing.Point(533, 112);
            this.btn_LoadData.Name = "btn_LoadData";
            this.btn_LoadData.Size = new System.Drawing.Size(124, 29);
            this.btn_LoadData.TabIndex = 2;
            this.btn_LoadData.Text = "Load Data";
            this.btn_LoadData.UseVisualStyleBackColor = true;
            this.btn_LoadData.Click += new System.EventHandler(this.Btn_LoadData_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(367, 74);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(448, 22);
            this.textBox1.TabIndex = 3;
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(691, 288);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(124, 29);
            this.btn_connect.TabIndex = 4;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.Btn_connect_Click);
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(533, 161);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(124, 29);
            this.btn_Send.TabIndex = 5;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.Btn_Send_Click);
            // 
            // PlayBtn
            // 
            this.PlayBtn.Enabled = false;
            this.PlayBtn.Location = new System.Drawing.Point(365, 288);
            this.PlayBtn.Name = "PlayBtn";
            this.PlayBtn.Size = new System.Drawing.Size(124, 29);
            this.PlayBtn.TabIndex = 6;
            this.PlayBtn.Text = "Play sound";
            this.PlayBtn.UseVisualStyleBackColor = true;
            this.PlayBtn.Click += new System.EventHandler(this.PlayBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(382, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Choose what to send:";
            // 
            // cb_Choice
            // 
            this.cb_Choice.FormattingEnabled = true;
            this.cb_Choice.Items.AddRange(new object[] {
            "Text",
            "Picture",
            "Sound"});
            this.cb_Choice.Location = new System.Drawing.Point(577, 22);
            this.cb_Choice.Name = "cb_Choice";
            this.cb_Choice.Size = new System.Drawing.Size(173, 24);
            this.cb_Choice.TabIndex = 8;
            // 
            // Client_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 500);
            this.Controls.Add(this.cb_Choice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlayBtn);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_LoadData);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbLog);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Client_Form";
            this.Text = "SOME/IP";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox tbLog;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_LoadData;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Button PlayBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_Choice;
    }
}

