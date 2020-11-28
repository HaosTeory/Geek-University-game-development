
namespace HomeWork_8
{
    partial class frmTrueOrNotDesigner
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miNew = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.miSave = new System.Windows.Forms.ToolStripMenuItem();
            this.miSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tboxQuestion = new System.Windows.Forms.RichTextBox();
            this.pnlCntrls = new System.Windows.Forms.Panel();
            this.cboxTrue = new System.Windows.Forms.CheckBox();
            this.nudNumber = new System.Windows.Forms.NumericUpDown();
            this.btnSaveQuest = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.pnlCntrls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(545, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNew,
            this.miOpen,
            this.miSave,
            this.miSaveAs,
            this.toolStripMenuItem2,
            this.miExit});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(37, 20);
            this.miFile.Text = "File";
            this.miFile.MouseEnter += new System.EventHandler(this.btnMouseEnter);
            this.miFile.MouseLeave += new System.EventHandler(this.btnMouseLeave);
            // 
            // miNew
            // 
            this.miNew.Name = "miNew";
            this.miNew.Size = new System.Drawing.Size(143, 22);
            this.miNew.Text = "New";
            this.miNew.Click += new System.EventHandler(this.miNew_Click);
            this.miNew.MouseEnter += new System.EventHandler(this.btnMouseEnter);
            this.miNew.MouseLeave += new System.EventHandler(this.btnMouseLeave);
            // 
            // miOpen
            // 
            this.miOpen.Name = "miOpen";
            this.miOpen.Size = new System.Drawing.Size(143, 22);
            this.miOpen.Text = "Open";
            this.miOpen.Click += new System.EventHandler(this.miOpen_Click);
            this.miOpen.MouseEnter += new System.EventHandler(this.btnMouseEnter);
            this.miOpen.MouseLeave += new System.EventHandler(this.btnMouseLeave);
            // 
            // miSave
            // 
            this.miSave.Name = "miSave";
            this.miSave.Size = new System.Drawing.Size(143, 22);
            this.miSave.Text = "Save in file";
            this.miSave.Click += new System.EventHandler(this.miSave_Click);
            this.miSave.MouseEnter += new System.EventHandler(this.btnMouseEnter);
            this.miSave.MouseLeave += new System.EventHandler(this.btnMouseLeave);
            // 
            // miSaveAs
            // 
            this.miSaveAs.Name = "miSaveAs";
            this.miSaveAs.Size = new System.Drawing.Size(143, 22);
            this.miSaveAs.Text = "SaveAs in file";
            this.miSaveAs.Click += new System.EventHandler(this.miSaveAs_Click);
            this.miSaveAs.MouseEnter += new System.EventHandler(this.btnMouseEnter);
            this.miSaveAs.MouseLeave += new System.EventHandler(this.btnMouseLeave);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(140, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(143, 22);
            this.miExit.Text = "Exit";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            this.miExit.MouseEnter += new System.EventHandler(this.btnMouseEnter);
            this.miExit.MouseLeave += new System.EventHandler(this.btnMouseLeave);
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(94, 20);
            this.miAbout.Text = "О программе";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            this.miAbout.MouseEnter += new System.EventHandler(this.btnMouseEnter);
            this.miAbout.MouseLeave += new System.EventHandler(this.btnMouseLeave);
            // 
            // tboxQuestion
            // 
            this.tboxQuestion.Dock = System.Windows.Forms.DockStyle.Top;
            this.tboxQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tboxQuestion.Location = new System.Drawing.Point(0, 24);
            this.tboxQuestion.Name = "tboxQuestion";
            this.tboxQuestion.Size = new System.Drawing.Size(545, 219);
            this.tboxQuestion.TabIndex = 2;
            this.tboxQuestion.Text = "";
            // 
            // pnlCntrls
            // 
            this.pnlCntrls.Controls.Add(this.cboxTrue);
            this.pnlCntrls.Controls.Add(this.nudNumber);
            this.pnlCntrls.Controls.Add(this.btnSaveQuest);
            this.pnlCntrls.Controls.Add(this.btnDelete);
            this.pnlCntrls.Controls.Add(this.btnAdd);
            this.pnlCntrls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCntrls.Location = new System.Drawing.Point(0, 243);
            this.pnlCntrls.Name = "pnlCntrls";
            this.pnlCntrls.Size = new System.Drawing.Size(545, 51);
            this.pnlCntrls.TabIndex = 8;
            // 
            // cboxTrue
            // 
            this.cboxTrue.AutoSize = true;
            this.cboxTrue.Location = new System.Drawing.Point(444, 14);
            this.cboxTrue.Name = "cboxTrue";
            this.cboxTrue.Size = new System.Drawing.Size(64, 17);
            this.cboxTrue.TabIndex = 12;
            this.cboxTrue.Text = "Правда";
            this.cboxTrue.UseVisualStyleBackColor = true;
            // 
            // nudNumber
            // 
            this.nudNumber.Location = new System.Drawing.Point(387, 13);
            this.nudNumber.Name = "nudNumber";
            this.nudNumber.Size = new System.Drawing.Size(51, 20);
            this.nudNumber.TabIndex = 11;
            this.nudNumber.ValueChanged += new System.EventHandler(this.nudNumber_ValueChanged);
            // 
            // btnSaveQuest
            // 
            this.btnSaveQuest.Location = new System.Drawing.Point(140, 13);
            this.btnSaveQuest.Name = "btnSaveQuest";
            this.btnSaveQuest.Size = new System.Drawing.Size(75, 23);
            this.btnSaveQuest.TabIndex = 10;
            this.btnSaveQuest.Text = "Save";
            this.btnSaveQuest.UseVisualStyleBackColor = true;
            this.btnSaveQuest.Click += new System.EventHandler(this.btnSaveQuest_Click);
            this.btnSaveQuest.MouseEnter += new System.EventHandler(this.btnMouseEnter);
            this.btnSaveQuest.MouseLeave += new System.EventHandler(this.btnMouseLeave);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(221, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.MouseEnter += new System.EventHandler(this.btnMouseEnter);
            this.btnDelete.MouseLeave += new System.EventHandler(this.btnMouseLeave);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(22, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.MouseEnter += new System.EventHandler(this.btnMouseEnter);
            this.btnAdd.MouseLeave += new System.EventHandler(this.btnMouseLeave);
            // 
            // frmTrueOrNotDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(545, 294);
            this.Controls.Add(this.pnlCntrls);
            this.Controls.Add(this.tboxQuestion);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmTrueOrNotDesigner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Верю - Не верю, редактор вопросов";
            this.TransparencyKey = System.Drawing.Color.Crimson;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlCntrls.ResumeLayout(false);
            this.pnlCntrls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miNew;
        private System.Windows.Forms.ToolStripMenuItem miOpen;
        private System.Windows.Forms.ToolStripMenuItem miSave;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.RichTextBox tboxQuestion;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.Panel pnlCntrls;
        private System.Windows.Forms.CheckBox cboxTrue;
        private System.Windows.Forms.NumericUpDown nudNumber;
        private System.Windows.Forms.Button btnSaveQuest;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ToolStripMenuItem miSaveAs;
    }
}

