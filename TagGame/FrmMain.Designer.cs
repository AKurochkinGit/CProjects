namespace Пятнашки
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.NewGameButton = new System.Windows.Forms.Button();
            this.RepeatGameButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblMotion = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.textBoxMot = new System.Windows.Forms.TextBox();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.textBoxPlayer = new System.Windows.Forms.TextBox();
            this.btnTopTime = new System.Windows.Forms.Button();
            this.btnTopMove = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // NewGameButton
            // 
            this.NewGameButton.Location = new System.Drawing.Point(558, 472);
            this.NewGameButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(152, 85);
            this.NewGameButton.TabIndex = 0;
            this.NewGameButton.Text = "Новая игра";
            this.NewGameButton.UseVisualStyleBackColor = true;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // RepeatGameButton
            // 
            this.RepeatGameButton.Location = new System.Drawing.Point(768, 472);
            this.RepeatGameButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RepeatGameButton.Name = "RepeatGameButton";
            this.RepeatGameButton.Size = new System.Drawing.Size(152, 85);
            this.RepeatGameButton.TabIndex = 1;
            this.RepeatGameButton.Text = "Повторить игру";
            this.RepeatGameButton.UseVisualStyleBackColor = true;
            this.RepeatGameButton.Click += new System.EventHandler(this.RepeatGameButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView1.Location = new System.Drawing.Point(45, 94);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 75;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(452, 463);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lblMotion
            // 
            this.lblMotion.AutoSize = true;
            this.lblMotion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblMotion.Location = new System.Drawing.Point(375, 35);
            this.lblMotion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMotion.Name = "lblMotion";
            this.lblMotion.Size = new System.Drawing.Size(81, 29);
            this.lblMotion.TabIndex = 3;
            this.lblMotion.Text = "Ходы:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTime.Location = new System.Drawing.Point(39, 38);
            this.lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(158, 29);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "Время игры:";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(201, 38);
            this.textBoxTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(148, 26);
            this.textBoxTime.TabIndex = 5;
            this.textBoxTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxMot
            // 
            this.textBoxMot.Location = new System.Drawing.Point(466, 35);
            this.textBoxMot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxMot.Name = "textBoxMot";
            this.textBoxMot.ReadOnly = true;
            this.textBoxMot.Size = new System.Drawing.Size(148, 26);
            this.textBoxMot.TabIndex = 6;
            this.textBoxMot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPlayer.Location = new System.Drawing.Point(674, 35);
            this.lblPlayer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(88, 29);
            this.lblPlayer.TabIndex = 7;
            this.lblPlayer.Text = "Игрок:";
            // 
            // textBoxPlayer
            // 
            this.textBoxPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPlayer.Location = new System.Drawing.Point(768, 35);
            this.textBoxPlayer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxPlayer.Name = "textBoxPlayer";
            this.textBoxPlayer.Size = new System.Drawing.Size(148, 33);
            this.textBoxPlayer.TabIndex = 8;
            this.textBoxPlayer.Text = "Player1";
            this.textBoxPlayer.TextChanged += new System.EventHandler(this.textBoxPlayer_TextChanged);
            // 
            // btnTopTime
            // 
            this.btnTopTime.Location = new System.Drawing.Point(584, 143);
            this.btnTopTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTopTime.Name = "btnTopTime";
            this.btnTopTime.Size = new System.Drawing.Size(152, 75);
            this.btnTopTime.TabIndex = 9;
            this.btnTopTime.Text = "10 лучших результатов по времени";
            this.btnTopTime.UseVisualStyleBackColor = true;
            this.btnTopTime.Click += new System.EventHandler(this.btnTopTime_Click);
            // 
            // btnTopMove
            // 
            this.btnTopMove.Location = new System.Drawing.Point(744, 143);
            this.btnTopMove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTopMove.Name = "btnTopMove";
            this.btnTopMove.Size = new System.Drawing.Size(152, 75);
            this.btnTopMove.TabIndex = 10;
            this.btnTopMove.Text = "10 лучших результатов по ходам";
            this.btnTopMove.UseVisualStyleBackColor = true;
            this.btnTopMove.Click += new System.EventHandler(this.btnTopMove_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(584, 228);
            this.btnLast.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(152, 75);
            this.btnLast.TabIndex = 11;
            this.btnLast.Text = "10 последних результатов";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(744, 228);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(152, 75);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Удалить результаты, начиная с даты";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblDate.Location = new System.Drawing.Point(627, 311);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(73, 29);
            this.lblDate.TabIndex = 13;
            this.lblDate.Text = "Дата:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(714, 311);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(180, 26);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 692);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnTopMove);
            this.Controls.Add(this.btnTopTime);
            this.Controls.Add(this.textBoxPlayer);
            this.Controls.Add(this.lblPlayer);
            this.Controls.Add(this.textBoxMot);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblMotion);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.RepeatGameButton);
            this.Controls.Add(this.NewGameButton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Пятнашки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.Button RepeatGameButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblMotion;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.TextBox textBoxMot;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.TextBox textBoxPlayer;
        private System.Windows.Forms.Button btnTopTime;
        private System.Windows.Forms.Button btnTopMove;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}

