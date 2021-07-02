namespace TheLittleMethod
{
    partial class Form1
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
            this.citiesNumberLabel = new System.Windows.Forms.Label();
            this.nextBtn = new System.Windows.Forms.Button();
            this.citiesNumberUpDown = new System.Windows.Forms.NumericUpDown();
            this.calcBtn = new System.Windows.Forms.Button();
            this.cityNameCheckBox = new System.Windows.Forms.CheckBox();
            this.cityNameBox = new System.Windows.Forms.TextBox();
            this.nextCityNameBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.citiesNumberUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // citiesNumberLabel
            // 
            this.citiesNumberLabel.AutoSize = true;
            this.citiesNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.citiesNumberLabel.Location = new System.Drawing.Point(160, 32);
            this.citiesNumberLabel.Name = "citiesNumberLabel";
            this.citiesNumberLabel.Size = new System.Drawing.Size(178, 29);
            this.citiesNumberLabel.TabIndex = 1;
            this.citiesNumberLabel.Text = "Кількість міст:";
            // 
            // nextBtn
            // 
            this.nextBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nextBtn.Location = new System.Drawing.Point(515, 30);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(116, 34);
            this.nextBtn.TabIndex = 3;
            this.nextBtn.Text = "Далі";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // citiesNumberUpDown
            // 
            this.citiesNumberUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.citiesNumberUpDown.Location = new System.Drawing.Point(358, 31);
            this.citiesNumberUpDown.Maximum = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.citiesNumberUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.citiesNumberUpDown.Name = "citiesNumberUpDown";
            this.citiesNumberUpDown.Size = new System.Drawing.Size(138, 30);
            this.citiesNumberUpDown.TabIndex = 2;
            this.citiesNumberUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.citiesNumberUpDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.citiesNumberUpDown_KeyUp);
            // 
            // calcBtn
            // 
            this.calcBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.calcBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.calcBtn.Location = new System.Drawing.Point(120, 408);
            this.calcBtn.Name = "calcBtn";
            this.calcBtn.Size = new System.Drawing.Size(492, 35);
            this.calcBtn.TabIndex = 5;
            this.calcBtn.Text = "Обрахувати";
            this.calcBtn.UseVisualStyleBackColor = true;
            this.calcBtn.Visible = false;
            this.calcBtn.Click += new System.EventHandler(this.calcBtn_Click);
            // 
            // cityNameCheckBox
            // 
            this.cityNameCheckBox.AutoSize = true;
            this.cityNameCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cityNameCheckBox.Location = new System.Drawing.Point(165, 78);
            this.cityNameCheckBox.Name = "cityNameCheckBox";
            this.cityNameCheckBox.Size = new System.Drawing.Size(148, 21);
            this.cityNameCheckBox.TabIndex = 6;
            this.cityNameCheckBox.Text = "Ввести назви міст";
            this.cityNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // cityNameBox
            // 
            this.cityNameBox.Location = new System.Drawing.Point(3, 8);
            this.cityNameBox.Name = "cityNameBox";
            this.cityNameBox.Size = new System.Drawing.Size(137, 22);
            this.cityNameBox.TabIndex = 7;
            this.cityNameBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cityNameBox_KeyUp);
            // 
            // nextCityNameBtn
            // 
            this.nextCityNameBtn.Location = new System.Drawing.Point(156, 6);
            this.nextCityNameBtn.Name = "nextCityNameBtn";
            this.nextCityNameBtn.Size = new System.Drawing.Size(116, 27);
            this.nextCityNameBtn.TabIndex = 8;
            this.nextCityNameBtn.Text = "Наступне";
            this.nextCityNameBtn.UseVisualStyleBackColor = true;
            this.nextCityNameBtn.Click += new System.EventHandler(this.nextCityNameBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cityNameBox);
            this.panel1.Controls.Add(this.nextCityNameBtn);
            this.panel1.Location = new System.Drawing.Point(358, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 35);
            this.panel1.TabIndex = 9;
            this.panel1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(732, 453);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cityNameCheckBox);
            this.Controls.Add(this.calcBtn);
            this.Controls.Add(this.citiesNumberUpDown);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.citiesNumberLabel);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(120, 20, 120, 10);
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.citiesNumberUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label citiesNumberLabel;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.NumericUpDown citiesNumberUpDown;
        private System.Windows.Forms.Button calcBtn;
        private System.Windows.Forms.CheckBox cityNameCheckBox;
        private System.Windows.Forms.TextBox cityNameBox;
        private System.Windows.Forms.Button nextCityNameBtn;
        private System.Windows.Forms.Panel panel1;
    }
}

