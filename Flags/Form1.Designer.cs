namespace Flags
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
            this.buttonSAR = new System.Windows.Forms.Button();
            this.buttonPakistan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSAR
            // 
            this.buttonSAR.Location = new System.Drawing.Point(12, 47);
            this.buttonSAR.Name = "buttonSAR";
            this.buttonSAR.Size = new System.Drawing.Size(26, 100);
            this.buttonSAR.TabIndex = 0;
            this.buttonSAR.Text = "ЮАР";
            this.buttonSAR.UseVisualStyleBackColor = true;
            this.buttonSAR.Click += new System.EventHandler(this.buttonSAR_Click);
            // 
            // buttonPakistan
            // 
            this.buttonPakistan.Location = new System.Drawing.Point(12, 153);
            this.buttonPakistan.Name = "buttonPakistan";
            this.buttonPakistan.Size = new System.Drawing.Size(26, 100);
            this.buttonPakistan.TabIndex = 1;
            this.buttonPakistan.Text = "Пакистан";
            this.buttonPakistan.UseVisualStyleBackColor = true;
            this.buttonPakistan.Click += new System.EventHandler(this.buttonPakistan_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonPakistan);
            this.Controls.Add(this.buttonSAR);
            this.MinimumSize = new System.Drawing.Size(0, 295);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSAR;
        private System.Windows.Forms.Button buttonPakistan;
    }
}

