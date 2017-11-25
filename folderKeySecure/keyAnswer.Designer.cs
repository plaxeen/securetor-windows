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
            this.informer = new System.Windows.Forms.Label();
            this.buttonAuthOpen = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.passwordChangerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // informer
            // 
            this.informer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.informer.AutoSize = true;
            this.informer.Location = new System.Drawing.Point(12, 9);
            this.informer.Name = "informer";
            this.informer.Size = new System.Drawing.Size(181, 13);
            this.informer.TabIndex = 3;
            this.informer.Text = "Для доступа к папке введите код.\r\n";
            this.informer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonAuthOpen
            // 
            this.buttonAuthOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAuthOpen.AutoSize = true;
            this.buttonAuthOpen.FlatAppearance.BorderSize = 0;
            this.buttonAuthOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAuthOpen.Location = new System.Drawing.Point(274, 66);
            this.buttonAuthOpen.Name = "buttonAuthOpen";
            this.buttonAuthOpen.Size = new System.Drawing.Size(78, 23);
            this.buttonAuthOpen.TabIndex = 1;
            this.buttonAuthOpen.Text = "Открыть";
            this.buttonAuthOpen.UseVisualStyleBackColor = true;
            this.buttonAuthOpen.Click += new System.EventHandler(this.authButton);
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
            // passwordChangerButton
            // 
            this.passwordChangerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordChangerButton.AutoSize = true;
            this.passwordChangerButton.Location = new System.Drawing.Point(15, 33);
            this.passwordChangerButton.Name = "passwordChangerButton";
            this.passwordChangerButton.Size = new System.Drawing.Size(121, 23);
            this.passwordChangerButton.TabIndex = 4;
            this.passwordChangerButton.Text = "Изменить пароль";
            this.passwordChangerButton.UseVisualStyleBackColor = true;
            this.passwordChangerButton.Visible = false;
            this.passwordChangerButton.Click += new System.EventHandler(this.showPasswordChangerDialog);
            // 
            // keyAsker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 101);
            this.Controls.Add(this.passwordChangerButton);
            this.Controls.Add(this.password);
            this.Controls.Add(this.buttonAuthOpen);
            this.Controls.Add(this.informer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(380, 140);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(380, 140);
            this.Name = "keyAsker";
            this.Text = "Введите пароль для доступа к папке";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.keyAsker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label informer;
        private System.Windows.Forms.Button buttonAuthOpen;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button passwordChangerButton;
    }
}

