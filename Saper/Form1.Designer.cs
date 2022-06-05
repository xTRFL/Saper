
namespace Saper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NewGameBtn = new System.Windows.Forms.Button();
            this.TBwys = new System.Windows.Forms.TextBox();
            this.TBszer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Maly = new System.Windows.Forms.RadioButton();
            this.Sredni = new System.Windows.Forms.RadioButton();
            this.Duzy = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.Custom = new System.Windows.Forms.RadioButton();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.DifficultyLabel = new System.Windows.Forms.Label();
            this.customDifficulty = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customDifficulty)).BeginInit();
            this.SuspendLayout();
            // 
            // NewGameBtn
            // 
            this.NewGameBtn.Location = new System.Drawing.Point(152, 257);
            this.NewGameBtn.Name = "NewGameBtn";
            this.NewGameBtn.Size = new System.Drawing.Size(132, 51);
            this.NewGameBtn.TabIndex = 0;
            this.NewGameBtn.Text = "Rozpocznij nową grę";
            this.NewGameBtn.UseVisualStyleBackColor = true;
            this.NewGameBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // TBwys
            // 
            this.TBwys.Location = new System.Drawing.Point(10, 49);
            this.TBwys.Name = "TBwys";
            this.TBwys.Size = new System.Drawing.Size(86, 20);
            this.TBwys.TabIndex = 1;
            this.TBwys.Visible = false;
            // 
            // TBszer
            // 
            this.TBszer.Location = new System.Drawing.Point(10, 89);
            this.TBszer.Name = "TBszer";
            this.TBszer.Size = new System.Drawing.Size(86, 20);
            this.TBszer.TabIndex = 1;
            this.TBszer.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Wysokość";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Szerokość";
            this.label2.Visible = false;
            // 
            // Maly
            // 
            this.Maly.AutoSize = true;
            this.Maly.Location = new System.Drawing.Point(132, 49);
            this.Maly.Name = "Maly";
            this.Maly.Size = new System.Drawing.Size(49, 17);
            this.Maly.TabIndex = 4;
            this.Maly.TabStop = true;
            this.Maly.Text = "Mały";
            this.Maly.UseVisualStyleBackColor = true;
            // 
            // Sredni
            // 
            this.Sredni.AutoSize = true;
            this.Sredni.Location = new System.Drawing.Point(132, 70);
            this.Sredni.Name = "Sredni";
            this.Sredni.Size = new System.Drawing.Size(55, 17);
            this.Sredni.TabIndex = 5;
            this.Sredni.TabStop = true;
            this.Sredni.Text = "Średni";
            this.Sredni.UseVisualStyleBackColor = true;
            // 
            // Duzy
            // 
            this.Duzy.AutoSize = true;
            this.Duzy.Location = new System.Drawing.Point(132, 92);
            this.Duzy.Name = "Duzy";
            this.Duzy.Size = new System.Drawing.Size(49, 17);
            this.Duzy.TabIndex = 6;
            this.Duzy.TabStop = true;
            this.Duzy.Text = "Duży";
            this.Duzy.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Rozmiar planszy:";
            // 
            // Custom
            // 
            this.Custom.AutoSize = true;
            this.Custom.Location = new System.Drawing.Point(132, 114);
            this.Custom.Name = "Custom";
            this.Custom.Size = new System.Drawing.Size(62, 17);
            this.Custom.TabIndex = 8;
            this.Custom.TabStop = true;
            this.Custom.Text = "Własny";
            this.Custom.UseVisualStyleBackColor = true;
            this.Custom.CheckedChanged += new System.EventHandler(this.Custom_CheckedChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(10, 188);
            this.trackBar1.Maximum = 4;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(272, 45);
            this.trackBar1.TabIndex = 9;
            this.trackBar1.Value = 1;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Poziom trudności";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 26);
            this.label5.TabIndex = 11;
            this.label5.Text = "Łatwy\r\n10%";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(88, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 26);
            this.label6.TabIndex = 12;
            this.label6.Text = "Średni\r\n17%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(167, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 26);
            this.label7.TabIndex = 13;
            this.label7.Text = "Trudny\r\n25%";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(242, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Własny";
            // 
            // DifficultyLabel
            // 
            this.DifficultyLabel.AutoSize = true;
            this.DifficultyLabel.Enabled = false;
            this.DifficultyLabel.Location = new System.Drawing.Point(10, 257);
            this.DifficultyLabel.Name = "DifficultyLabel";
            this.DifficultyLabel.Size = new System.Drawing.Size(109, 13);
            this.DifficultyLabel.TabIndex = 16;
            this.DifficultyLabel.Text = "Wartość procentowa:";
            this.DifficultyLabel.Visible = false;
            // 
            // customDifficulty
            // 
            this.customDifficulty.Enabled = false;
            this.customDifficulty.Location = new System.Drawing.Point(13, 273);
            this.customDifficulty.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.customDifficulty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.customDifficulty.Name = "customDifficulty";
            this.customDifficulty.Size = new System.Drawing.Size(63, 20);
            this.customDifficulty.TabIndex = 17;
            this.customDifficulty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.customDifficulty.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 390);
            this.Controls.Add(this.customDifficulty);
            this.Controls.Add(this.DifficultyLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.Custom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Duzy);
            this.Controls.Add(this.Sredni);
            this.Controls.Add(this.Maly);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBszer);
            this.Controls.Add(this.TBwys);
            this.Controls.Add(this.NewGameBtn);
            this.Name = "Form1";
            this.Text = "Minesweeper";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customDifficulty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewGameBtn;
        private System.Windows.Forms.TextBox TBwys;
        private System.Windows.Forms.TextBox TBszer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton Maly;
        private System.Windows.Forms.RadioButton Sredni;
        private System.Windows.Forms.RadioButton Duzy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton Custom;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label DifficultyLabel;
        private System.Windows.Forms.NumericUpDown customDifficulty;
    }
}

