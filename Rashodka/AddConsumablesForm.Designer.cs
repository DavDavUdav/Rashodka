namespace Rashodka
{
    partial class AddConsumablesForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.NumUD_count = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NumUD_count)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(135, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 23);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Наименование";
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(12, 64);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(281, 29);
            this.btn_add.TabIndex = 3;
            this.btn_add.Text = "Добавить";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Количество";
            // 
            // NumUD_count
            // 
            this.NumUD_count.Location = new System.Drawing.Point(135, 35);
            this.NumUD_count.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumUD_count.Name = "NumUD_count";
            this.NumUD_count.Size = new System.Drawing.Size(158, 23);
            this.NumUD_count.TabIndex = 8;
            this.NumUD_count.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // AddConsumablesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 101);
            this.Controls.Add(this.NumUD_count);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_add);
            this.Name = "AddConsumablesForm";
            this.Text = "Добавление нового материала";
            ((System.ComponentModel.ISupportInitialize)(this.NumUD_count)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Button btn_add;
        private Label label2;
        private NumericUpDown NumUD_count;
    }
}