namespace Rashodka
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
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_consumables = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_region = new System.Windows.Forms.ComboBox();
            this.btn_issue = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.бДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.регионToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расходныйМатериалToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.регионToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_edit = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(6, 67);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowTemplate.Height = 25;
            this.dgv1.Size = new System.Drawing.Size(955, 383);
            this.dgv1.TabIndex = 8;
            this.dgv1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cb_consumables);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cb_region);
            this.groupBox1.Controls.Add(this.btn_issue);
            this.groupBox1.Controls.Add(this.dgv1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(967, 456);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выдача";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Материал";
            // 
            // cb_consumables
            // 
            this.cb_consumables.FormattingEnabled = true;
            this.cb_consumables.Location = new System.Drawing.Point(6, 38);
            this.cb_consumables.Name = "cb_consumables";
            this.cb_consumables.Size = new System.Drawing.Size(121, 23);
            this.cb_consumables.TabIndex = 0;
            this.cb_consumables.TextUpdate += new System.EventHandler(this.cb_consumables_TextUpdate);
            this.cb_consumables.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Количество";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(260, 37);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(805, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "обновить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Район";
            // 
            // cb_region
            // 
            this.cb_region.FormattingEnabled = true;
            this.cb_region.Location = new System.Drawing.Point(133, 38);
            this.cb_region.Name = "cb_region";
            this.cb_region.Size = new System.Drawing.Size(121, 23);
            this.cb_region.TabIndex = 1;
            this.cb_region.TextUpdate += new System.EventHandler(this.cb_Region_TextUpdate);
            // 
            // btn_issue
            // 
            this.btn_issue.Location = new System.Drawing.Point(886, 37);
            this.btn_issue.Name = "btn_issue";
            this.btn_issue.Size = new System.Drawing.Size(75, 23);
            this.btn_issue.TabIndex = 3;
            this.btn_issue.Text = "Выдать";
            this.btn_issue.UseVisualStyleBackColor = true;
            this.btn_issue.Click += new System.EventHandler(this.btn_Extradition_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.бДToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(989, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // бДToolStripMenuItem
            // 
            this.бДToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.регионToolStripMenuItem});
            this.бДToolStripMenuItem.Name = "бДToolStripMenuItem";
            this.бДToolStripMenuItem.Size = new System.Drawing.Size(34, 20);
            this.бДToolStripMenuItem.Text = "БД";
            // 
            // регионToolStripMenuItem
            // 
            this.регионToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.расходныйМатериалToolStripMenuItem1,
            this.регионToolStripMenuItem1});
            this.регионToolStripMenuItem.Name = "регионToolStripMenuItem";
            this.регионToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.регионToolStripMenuItem.Text = "Добавить запись";
            // 
            // расходныйМатериалToolStripMenuItem1
            // 
            this.расходныйМатериалToolStripMenuItem1.Name = "расходныйМатериалToolStripMenuItem1";
            this.расходныйМатериалToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.расходныйМатериалToolStripMenuItem1.Text = "Новый материал";
            this.расходныйМатериалToolStripMenuItem1.Click += new System.EventHandler(this.расходныйМатериалToolStripMenuItem1_Click);
            // 
            // регионToolStripMenuItem1
            // 
            this.регионToolStripMenuItem1.Name = "регионToolStripMenuItem1";
            this.регионToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.регионToolStripMenuItem1.Text = "Регион";
            this.регионToolStripMenuItem1.Click += new System.EventHandler(this.регионToolStripMenuItem1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(989, 498);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(981, 470);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Выдача";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.btn_edit);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(981, 470);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Склад";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(277, 6);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(75, 24);
            this.btn_edit.TabIndex = 11;
            this.btn_edit.Text = "Добавить";
            this.btn_edit.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(965, 383);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 522);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Расходные материалы";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataGridView dgv1;
        private GroupBox groupBox1;
        private Button btn_issue;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem бДToolStripMenuItem;
        private ToolStripMenuItem регионToolStripMenuItem;
        private ToolStripMenuItem расходныйМатериалToolStripMenuItem1;
        private ToolStripMenuItem регионToolStripMenuItem1;
        private ComboBox cb_region;
        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button button1;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private Label label3;
        private ComboBox cb_consumables;
        private Button btn_edit;
        private DataGridView dataGridView1;
    }
}