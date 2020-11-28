
namespace HomeWork_8
{
    partial class frmTrueOrNotGame
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rtbQuestion = new System.Windows.Forms.RichTextBox();
            this.pnlPanel = new System.Windows.Forms.Panel();
            this.btnTrue = new System.Windows.Forms.Button();
            this.btnFalse = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.pnlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNewGame,
            this.miExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(527, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miNewGame
            // 
            this.miNewGame.Name = "miNewGame";
            this.miNewGame.Size = new System.Drawing.Size(50, 20);
            this.miNewGame.Text = "Game";
            this.miNewGame.Click += new System.EventHandler(this.miNewGame_Click);
            this.miNewGame.MouseEnter += new System.EventHandler(this.btnMouseEnter);
            this.miNewGame.MouseLeave += new System.EventHandler(this.btnMouseLeave);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(38, 20);
            this.miExit.Text = "Exit";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            this.miExit.MouseEnter += new System.EventHandler(this.btnMouseEnter);
            this.miExit.MouseLeave += new System.EventHandler(this.btnMouseLeave);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // rtbQuestion
            // 
            this.rtbQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbQuestion.Location = new System.Drawing.Point(0, 24);
            this.rtbQuestion.Name = "rtbQuestion";
            this.rtbQuestion.ReadOnly = true;
            this.rtbQuestion.Size = new System.Drawing.Size(527, 275);
            this.rtbQuestion.TabIndex = 2;
            this.rtbQuestion.Text = "";
            // 
            // pnlPanel
            // 
            this.pnlPanel.Controls.Add(this.btnFalse);
            this.pnlPanel.Controls.Add(this.btnTrue);
            this.pnlPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPanel.Location = new System.Drawing.Point(0, 243);
            this.pnlPanel.Name = "pnlPanel";
            this.pnlPanel.Size = new System.Drawing.Size(527, 56);
            this.pnlPanel.TabIndex = 3;
            // 
            // btnTrue
            // 
            this.btnTrue.Location = new System.Drawing.Point(181, 21);
            this.btnTrue.Name = "btnTrue";
            this.btnTrue.Size = new System.Drawing.Size(75, 23);
            this.btnTrue.TabIndex = 0;
            this.btnTrue.Text = "Верю";
            this.btnTrue.UseVisualStyleBackColor = true;
            this.btnTrue.Click += new System.EventHandler(this.btnClick);
            this.btnTrue.MouseEnter += new System.EventHandler(this.btnMouseEnter);
            this.btnTrue.MouseLeave += new System.EventHandler(this.btnMouseLeave);
            // 
            // btnFalse
            // 
            this.btnFalse.Location = new System.Drawing.Point(262, 21);
            this.btnFalse.Name = "btnFalse";
            this.btnFalse.Size = new System.Drawing.Size(75, 23);
            this.btnFalse.TabIndex = 1;
            this.btnFalse.Text = "Не верю";
            this.btnFalse.UseVisualStyleBackColor = true;
            this.btnFalse.Click += new System.EventHandler(this.btnClick);
            this.btnFalse.MouseEnter += new System.EventHandler(this.btnMouseEnter);
            this.btnFalse.MouseLeave += new System.EventHandler(this.btnMouseLeave);
            // 
            // frmTrueOrNotGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 299);
            this.Controls.Add(this.pnlPanel);
            this.Controls.Add(this.rtbQuestion);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmTrueOrNotGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Игра Верю - Не верю";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miNewGame;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.RichTextBox rtbQuestion;
        private System.Windows.Forms.Panel pnlPanel;
        private System.Windows.Forms.Button btnFalse;
        private System.Windows.Forms.Button btnTrue;
    }
}