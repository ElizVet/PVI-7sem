namespace WindowsFormsApp1a
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
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxEquals = new System.Windows.Forms.TextBox();
            this.lab = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxX
            // 
            this.textBoxX.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.textBoxX.Location = new System.Drawing.Point(41, 29);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(206, 28);
            this.textBoxX.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Location = new System.Drawing.Point(41, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(206, 57);
            this.button1.TabIndex = 3;
            this.button1.Text = "посчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxY
            // 
            this.textBoxY.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.textBoxY.Location = new System.Drawing.Point(41, 110);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(206, 28);
            this.textBoxY.TabIndex = 4;
            // 
            // textBoxEquals
            // 
            this.textBoxEquals.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.textBoxEquals.Location = new System.Drawing.Point(41, 348);
            this.textBoxEquals.Name = "textBoxEquals";
            this.textBoxEquals.Size = new System.Drawing.Size(206, 28);
            this.textBoxEquals.TabIndex = 5;
            // 
            // lab
            // 
            this.lab.AutoSize = true;
            this.lab.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lab.Location = new System.Drawing.Point(131, 66);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(32, 36);
            this.lab.TabIndex = 6;
            this.lab.Text = "+";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.Location = new System.Drawing.Point(131, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 36);
            this.label1.TabIndex = 7;
            this.label1.Text = "=";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lab);
            this.Controls.Add(this.textBoxEquals);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxX);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxEquals;
        private System.Windows.Forms.Label lab;
        private System.Windows.Forms.Label label1;
    }
}

