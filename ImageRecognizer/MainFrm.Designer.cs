namespace ImageRecognizer
{
    partial class MainFrm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._pbImg1 = new System.Windows.Forms.PictureBox();
            this._pbImg2 = new System.Windows.Forms.PictureBox();
            this._pbImg3 = new System.Windows.Forms.PictureBox();
            this._pbMain = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._pb1 = new System.Windows.Forms.PictureBox();
            this._pb2 = new System.Windows.Forms.PictureBox();
            this._pb3 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._cbxExample = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pbImg1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._pbImg2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._pbImg3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._pbMain)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._pb2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._pb3)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._pbImg1);
            this.groupBox1.Controls.Add(this._pbImg2);
            this.groupBox1.Controls.Add(this._pbImg3);
            this.groupBox1.Location = new System.Drawing.Point(12, 198);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 78);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Исходные изображения";
            // 
            // _pbImg1
            // 
            this._pbImg1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pbImg1.Location = new System.Drawing.Point(6, 19);
            this._pbImg1.Name = "_pbImg1";
            this._pbImg1.Size = new System.Drawing.Size(78, 50);
            this._pbImg1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._pbImg1.TabIndex = 12;
            this._pbImg1.TabStop = false;
            // 
            // _pbImg2
            // 
            this._pbImg2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pbImg2.Location = new System.Drawing.Point(89, 19);
            this._pbImg2.Name = "_pbImg2";
            this._pbImg2.Size = new System.Drawing.Size(78, 50);
            this._pbImg2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._pbImg2.TabIndex = 11;
            this._pbImg2.TabStop = false;
            // 
            // _pbImg3
            // 
            this._pbImg3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pbImg3.Location = new System.Drawing.Point(173, 19);
            this._pbImg3.Name = "_pbImg3";
            this._pbImg3.Size = new System.Drawing.Size(78, 50);
            this._pbImg3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._pbImg3.TabIndex = 10;
            this._pbImg3.TabStop = false;
            // 
            // _pbMain
            // 
            this._pbMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pbMain.Location = new System.Drawing.Point(6, 19);
            this._pbMain.Name = "_pbMain";
            this._pbMain.Size = new System.Drawing.Size(245, 128);
            this._pbMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._pbMain.TabIndex = 0;
            this._pbMain.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this._pb1);
            this.groupBox2.Controls.Add(this._pb2);
            this.groupBox2.Controls.Add(this._pb3);
            this.groupBox2.Location = new System.Drawing.Point(12, 313);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 105);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Что видит программа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = " в сопоставлении с исходными изображениями";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Фрагменты анализуемого изображения";
            // 
            // _pb1
            // 
            this._pb1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pb1.Location = new System.Drawing.Point(6, 19);
            this._pb1.Name = "_pb1";
            this._pb1.Size = new System.Drawing.Size(78, 50);
            this._pb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._pb1.TabIndex = 9;
            this._pb1.TabStop = false;
            // 
            // _pb2
            // 
            this._pb2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pb2.Location = new System.Drawing.Point(89, 19);
            this._pb2.Name = "_pb2";
            this._pb2.Size = new System.Drawing.Size(78, 50);
            this._pb2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._pb2.TabIndex = 8;
            this._pb2.TabStop = false;
            // 
            // _pb3
            // 
            this._pb3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pb3.Location = new System.Drawing.Point(173, 19);
            this._pb3.Name = "_pb3";
            this._pb3.Size = new System.Drawing.Size(78, 50);
            this._pb3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._pb3.TabIndex = 7;
            this._pb3.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._pbMain);
            this.groupBox3.Location = new System.Drawing.Point(12, 39);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(258, 153);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Анализируемое изображение";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "img1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 287);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "img2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(207, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "img3";
            // 
            // _cbxExample
            // 
            this._cbxExample.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbxExample.FormattingEnabled = true;
            this._cbxExample.Location = new System.Drawing.Point(74, 12);
            this._cbxExample.Name = "_cbxExample";
            this._cbxExample.Size = new System.Drawing.Size(189, 21);
            this._cbxExample.TabIndex = 16;
            this._cbxExample.SelectedIndexChanged += new System.EventHandler(this.cbxExample_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Пример:";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 424);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._cbxExample);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Распознавание";
            this.Shown += new System.EventHandler(this._mainFrm_Shown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pbImg1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._pbImg2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._pbImg3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._pbMain)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._pb2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._pb3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox _pbMain;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox _pb1;
        private System.Windows.Forms.PictureBox _pb2;
        private System.Windows.Forms.PictureBox _pb3;
        private System.Windows.Forms.PictureBox _pbImg1;
        private System.Windows.Forms.PictureBox _pbImg2;
        private System.Windows.Forms.PictureBox _pbImg3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox _cbxExample;
        private System.Windows.Forms.Label label6;
    }
}

