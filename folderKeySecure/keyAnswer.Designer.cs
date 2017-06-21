namespace folderKeySecure
{
    partial class keyAsker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(keyAsker));
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.vkAuthRequest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Для доступа к папке введите код.\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(277, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Открыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonClick);
            // 
            // password
            // 
            this.password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.password.Location = new System.Drawing.Point(15, 33);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(340, 20);
            this.password.TabIndex = 0;
            this.password.UseSystemPasswordChar = true;
            this.password.WordWrap = false;
            this.password.Enter += new System.EventHandler(this.password_Enter);
            this.password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressed);
            // 
            // vkAuthRequest
            // 
            this.vkAuthRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.vkAuthRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(135)))), ((int)(((byte)(174)))));
            this.vkAuthRequest.FlatAppearance.BorderSize = 0;
            this.vkAuthRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vkAuthRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vkAuthRequest.ForeColor = System.Drawing.Color.White;
            this.vkAuthRequest.Location = new System.Drawing.Point(196, 66);
            this.vkAuthRequest.Name = "vkAuthRequest";
            this.vkAuthRequest.Size = new System.Drawing.Size(75, 23);
            this.vkAuthRequest.TabIndex = 4;
            this.vkAuthRequest.Text = "ВКонтакте";
            this.vkAuthRequest.UseVisualStyleBackColor = false;
            this.vkAuthRequest.Click += new System.EventHandler(this.vkAuthRequest_Click);
            // 
            // keyAsker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 101);
            this.Controls.Add(this.vkAuthRequest);
            this.Controls.Add(this.password);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(380, 140);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(380, 140);
            this.Name = "keyAsker";
            this.Text = "Введите пароль для доступа к папке";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button vkAuthRequest;
    }
}

