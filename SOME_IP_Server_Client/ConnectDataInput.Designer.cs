namespace SOME_IP_Server_Client
{
    partial class ConnectDataInput
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.portTxtBox = new System.Windows.Forms.TextBox();
            this.EPtxtBox = new System.Windows.Forms.TextBox();
            this.InputDataBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(184, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the connection data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(21, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(21, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "EndPoint:";
            // 
            // portTxtBox
            // 
            this.portTxtBox.Location = new System.Drawing.Point(134, 77);
            this.portTxtBox.Name = "portTxtBox";
            this.portTxtBox.Size = new System.Drawing.Size(100, 22);
            this.portTxtBox.TabIndex = 3;
            // 
            // EPtxtBox
            // 
            this.EPtxtBox.Location = new System.Drawing.Point(134, 126);
            this.EPtxtBox.Name = "EPtxtBox";
            this.EPtxtBox.Size = new System.Drawing.Size(100, 22);
            this.EPtxtBox.TabIndex = 4;
            // 
            // InputDataBtn
            // 
            this.InputDataBtn.Location = new System.Drawing.Point(486, 163);
            this.InputDataBtn.Name = "InputDataBtn";
            this.InputDataBtn.Size = new System.Drawing.Size(126, 34);
            this.InputDataBtn.TabIndex = 5;
            this.InputDataBtn.Text = "OK";
            this.InputDataBtn.UseVisualStyleBackColor = true;
            this.InputDataBtn.Click += new System.EventHandler(this.InputDataBtn_Click);
            // 
            // ConnectDataInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 224);
            this.Controls.Add(this.InputDataBtn);
            this.Controls.Add(this.EPtxtBox);
            this.Controls.Add(this.portTxtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ConnectDataInput";
            this.Text = "ConnectDataInput";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox portTxtBox;
        private System.Windows.Forms.TextBox EPtxtBox;
        private System.Windows.Forms.Button InputDataBtn;
    }
}