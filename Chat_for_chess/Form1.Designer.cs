namespace Chat_for_chess
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Client2GroupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Client2PortBox = new System.Windows.Forms.TextBox();
            this.Client2IPBox = new System.Windows.Forms.TextBox();
            this.Client1GroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Client1PortBox = new System.Windows.Forms.TextBox();
            this.Client1IPBox = new System.Windows.Forms.TextBox();
            this.listMessage = new System.Windows.Forms.ListBox();
            this.SendBox = new System.Windows.Forms.TextBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.SendButton = new System.Windows.Forms.Button();
            this.pField = new System.Windows.Forms.Panel();
            this.WhiteButton = new System.Windows.Forms.Button();
            this.BlackButton = new System.Windows.Forms.Button();
            this.CPortBox1 = new System.Windows.Forms.TextBox();
            this.CPortBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Client2GroupBox.SuspendLayout();
            this.Client1GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Client2GroupBox
            // 
            this.Client2GroupBox.Controls.Add(this.label5);
            this.Client2GroupBox.Controls.Add(this.CPortBox2);
            this.Client2GroupBox.Controls.Add(this.label4);
            this.Client2GroupBox.Controls.Add(this.label3);
            this.Client2GroupBox.Controls.Add(this.Client2PortBox);
            this.Client2GroupBox.Controls.Add(this.Client2IPBox);
            this.Client2GroupBox.Location = new System.Drawing.Point(205, 12);
            this.Client2GroupBox.Name = "Client2GroupBox";
            this.Client2GroupBox.Size = new System.Drawing.Size(200, 100);
            this.Client2GroupBox.TabIndex = 0;
            this.Client2GroupBox.TabStop = false;
            this.Client2GroupBox.Text = "Client2";
            this.Client2GroupBox.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "PORT";
            this.label4.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "IP";
            this.label3.UseWaitCursor = true;
            // 
            // Client2PortBox
            // 
            this.Client2PortBox.Location = new System.Drawing.Point(137, 46);
            this.Client2PortBox.Name = "Client2PortBox";
            this.Client2PortBox.Size = new System.Drawing.Size(57, 20);
            this.Client2PortBox.TabIndex = 1;
            this.Client2PortBox.UseWaitCursor = true;
            this.Client2PortBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Client2IPBox
            // 
            this.Client2IPBox.Location = new System.Drawing.Point(94, 19);
            this.Client2IPBox.Name = "Client2IPBox";
            this.Client2IPBox.Size = new System.Drawing.Size(100, 20);
            this.Client2IPBox.TabIndex = 0;
            this.Client2IPBox.UseWaitCursor = true;
            // 
            // Client1GroupBox
            // 
            this.Client1GroupBox.Controls.Add(this.label6);
            this.Client1GroupBox.Controls.Add(this.CPortBox1);
            this.Client1GroupBox.Controls.Add(this.label2);
            this.Client1GroupBox.Controls.Add(this.label1);
            this.Client1GroupBox.Controls.Add(this.Client1PortBox);
            this.Client1GroupBox.Controls.Add(this.Client1IPBox);
            this.Client1GroupBox.Location = new System.Drawing.Point(12, 12);
            this.Client1GroupBox.Name = "Client1GroupBox";
            this.Client1GroupBox.Size = new System.Drawing.Size(200, 100);
            this.Client1GroupBox.TabIndex = 1;
            this.Client1GroupBox.TabStop = false;
            this.Client1GroupBox.Text = "Client 1";
            this.Client1GroupBox.Enter += new System.EventHandler(this.Client1GroupBox_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "PORT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Client1PortBox
            // 
            this.Client1PortBox.Location = new System.Drawing.Point(137, 45);
            this.Client1PortBox.Name = "Client1PortBox";
            this.Client1PortBox.Size = new System.Drawing.Size(57, 20);
            this.Client1PortBox.TabIndex = 1;
            // 
            // Client1IPBox
            // 
            this.Client1IPBox.Location = new System.Drawing.Point(94, 19);
            this.Client1IPBox.Name = "Client1IPBox";
            this.Client1IPBox.Size = new System.Drawing.Size(100, 20);
            this.Client1IPBox.TabIndex = 0;
            // 
            // listMessage
            // 
            this.listMessage.FormattingEnabled = true;
            this.listMessage.Location = new System.Drawing.Point(497, 15);
            this.listMessage.Name = "listMessage";
            this.listMessage.Size = new System.Drawing.Size(146, 303);
            this.listMessage.TabIndex = 2;
            // 
            // SendBox
            // 
            this.SendBox.Location = new System.Drawing.Point(478, 340);
            this.SendBox.Name = "SendBox";
            this.SendBox.Size = new System.Drawing.Size(165, 20);
            this.SendBox.TabIndex = 3;
            this.SendBox.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(411, 57);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 55);
            this.ConnectButton.TabIndex = 4;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(564, 367);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 60);
            this.SendButton.TabIndex = 5;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // pField
            // 
            this.pField.Location = new System.Drawing.Point(12, 118);
            this.pField.Name = "pField";
            this.pField.Size = new System.Drawing.Size(460, 309);
            this.pField.TabIndex = 6;
            // 
            // WhiteButton
            // 
            this.WhiteButton.Location = new System.Drawing.Point(426, 1);
            this.WhiteButton.Name = "WhiteButton";
            this.WhiteButton.Size = new System.Drawing.Size(60, 21);
            this.WhiteButton.TabIndex = 7;
            this.WhiteButton.Text = "White";
            this.WhiteButton.UseVisualStyleBackColor = true;
            this.WhiteButton.Click += new System.EventHandler(this.WhiteButton_Click);
            // 
            // BlackButton
            // 
            this.BlackButton.Location = new System.Drawing.Point(426, 29);
            this.BlackButton.Name = "BlackButton";
            this.BlackButton.Size = new System.Drawing.Size(60, 21);
            this.BlackButton.TabIndex = 8;
            this.BlackButton.Text = "Black";
            this.BlackButton.UseVisualStyleBackColor = true;
            this.BlackButton.Click += new System.EventHandler(this.BlackButton_Click);
            // 
            // CPortBox1
            // 
            this.CPortBox1.Location = new System.Drawing.Point(137, 72);
            this.CPortBox1.Name = "CPortBox1";
            this.CPortBox1.Size = new System.Drawing.Size(57, 20);
            this.CPortBox1.TabIndex = 4;
            // 
            // CPortBox2
            // 
            this.CPortBox2.Location = new System.Drawing.Point(137, 73);
            this.CPortBox2.Name = "CPortBox2";
            this.CPortBox2.Size = new System.Drawing.Size(57, 20);
            this.CPortBox2.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "C_PORT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "C_PORT";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 439);
            this.Controls.Add(this.BlackButton);
            this.Controls.Add(this.WhiteButton);
            this.Controls.Add(this.pField);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.SendBox);
            this.Controls.Add(this.listMessage);
            this.Controls.Add(this.Client1GroupBox);
            this.Controls.Add(this.Client2GroupBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Client2GroupBox.ResumeLayout(false);
            this.Client2GroupBox.PerformLayout();
            this.Client1GroupBox.ResumeLayout(false);
            this.Client1GroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Client2GroupBox;
        private System.Windows.Forms.TextBox Client2PortBox;
        private System.Windows.Forms.TextBox Client2IPBox;
        private System.Windows.Forms.GroupBox Client1GroupBox;
        private System.Windows.Forms.TextBox Client1PortBox;
        private System.Windows.Forms.TextBox Client1IPBox;
        private System.Windows.Forms.ListBox listMessage;
        private System.Windows.Forms.TextBox SendBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Panel pField;
        private System.Windows.Forms.Button WhiteButton;
        private System.Windows.Forms.Button BlackButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox CPortBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CPortBox1;
    }
}

