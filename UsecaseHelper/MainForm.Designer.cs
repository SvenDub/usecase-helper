namespace UsecaseHelper
{
    partial class MainForm
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
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.gbxMode = new System.Windows.Forms.GroupBox();
            this.rdiModeSelect = new System.Windows.Forms.RadioButton();
            this.rdiModeCreate = new System.Windows.Forms.RadioButton();
            this.gbxElement = new System.Windows.Forms.GroupBox();
            this.rdiElementLine = new System.Windows.Forms.RadioButton();
            this.rdiElementUseCase = new System.Windows.Forms.RadioButton();
            this.rdiElementActor = new System.Windows.Forms.RadioButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.imgDrawing = new System.Windows.Forms.PictureBox();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.rdiModeDelete = new System.Windows.Forms.RadioButton();
            this.rdiModeUnlink = new System.Windows.Forms.RadioButton();
            this.btnExport = new System.Windows.Forms.Button();
            this.pnlControls.SuspendLayout();
            this.gbxMode.SuspendLayout();
            this.gbxElement.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgDrawing)).BeginInit();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.SystemColors.Window;
            this.pnlControls.Controls.Add(this.btnExport);
            this.pnlControls.Controls.Add(this.btnClearAll);
            this.pnlControls.Controls.Add(this.gbxMode);
            this.pnlControls.Controls.Add(this.gbxElement);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(652, 132);
            this.pnlControls.TabIndex = 0;
            // 
            // btnClearAll
            // 
            this.btnClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearAll.Location = new System.Drawing.Point(565, 12);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(75, 23);
            this.btnClearAll.TabIndex = 2;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // gbxMode
            // 
            this.gbxMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbxMode.Controls.Add(this.rdiModeUnlink);
            this.gbxMode.Controls.Add(this.rdiModeDelete);
            this.gbxMode.Controls.Add(this.rdiModeSelect);
            this.gbxMode.Controls.Add(this.rdiModeCreate);
            this.gbxMode.Location = new System.Drawing.Point(168, 12);
            this.gbxMode.Name = "gbxMode";
            this.gbxMode.Size = new System.Drawing.Size(150, 114);
            this.gbxMode.TabIndex = 1;
            this.gbxMode.TabStop = false;
            this.gbxMode.Text = "Mode";
            // 
            // rdiModeSelect
            // 
            this.rdiModeSelect.AutoSize = true;
            this.rdiModeSelect.Location = new System.Drawing.Point(7, 43);
            this.rdiModeSelect.Name = "rdiModeSelect";
            this.rdiModeSelect.Size = new System.Drawing.Size(55, 17);
            this.rdiModeSelect.TabIndex = 1;
            this.rdiModeSelect.TabStop = true;
            this.rdiModeSelect.Text = "Select";
            this.rdiModeSelect.UseVisualStyleBackColor = true;
            // 
            // rdiModeCreate
            // 
            this.rdiModeCreate.AutoSize = true;
            this.rdiModeCreate.Checked = true;
            this.rdiModeCreate.Location = new System.Drawing.Point(7, 20);
            this.rdiModeCreate.Name = "rdiModeCreate";
            this.rdiModeCreate.Size = new System.Drawing.Size(56, 17);
            this.rdiModeCreate.TabIndex = 0;
            this.rdiModeCreate.TabStop = true;
            this.rdiModeCreate.Text = "Create";
            this.rdiModeCreate.UseVisualStyleBackColor = true;
            // 
            // gbxElement
            // 
            this.gbxElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbxElement.Controls.Add(this.rdiElementLine);
            this.gbxElement.Controls.Add(this.rdiElementUseCase);
            this.gbxElement.Controls.Add(this.rdiElementActor);
            this.gbxElement.Location = new System.Drawing.Point(12, 12);
            this.gbxElement.Name = "gbxElement";
            this.gbxElement.Size = new System.Drawing.Size(150, 114);
            this.gbxElement.TabIndex = 0;
            this.gbxElement.TabStop = false;
            this.gbxElement.Text = "Element";
            // 
            // rdiElementLine
            // 
            this.rdiElementLine.AutoSize = true;
            this.rdiElementLine.Location = new System.Drawing.Point(6, 65);
            this.rdiElementLine.Name = "rdiElementLine";
            this.rdiElementLine.Size = new System.Drawing.Size(45, 17);
            this.rdiElementLine.TabIndex = 2;
            this.rdiElementLine.TabStop = true;
            this.rdiElementLine.Text = "Line";
            this.rdiElementLine.UseVisualStyleBackColor = true;
            // 
            // rdiElementUseCase
            // 
            this.rdiElementUseCase.AutoSize = true;
            this.rdiElementUseCase.Location = new System.Drawing.Point(6, 42);
            this.rdiElementUseCase.Name = "rdiElementUseCase";
            this.rdiElementUseCase.Size = new System.Drawing.Size(70, 17);
            this.rdiElementUseCase.TabIndex = 1;
            this.rdiElementUseCase.TabStop = true;
            this.rdiElementUseCase.Text = "Use case";
            this.rdiElementUseCase.UseVisualStyleBackColor = true;
            // 
            // rdiElementActor
            // 
            this.rdiElementActor.AutoSize = true;
            this.rdiElementActor.Checked = true;
            this.rdiElementActor.Location = new System.Drawing.Point(6, 19);
            this.rdiElementActor.Name = "rdiElementActor";
            this.rdiElementActor.Size = new System.Drawing.Size(50, 17);
            this.rdiElementActor.TabIndex = 0;
            this.rdiElementActor.TabStop = true;
            this.rdiElementActor.Text = "Actor";
            this.rdiElementActor.UseVisualStyleBackColor = true;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.imgDrawing);
            this.pnlContent.Controls.Add(this.statusBar);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 132);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(652, 354);
            this.pnlContent.TabIndex = 1;
            // 
            // imgDrawing
            // 
            this.imgDrawing.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgDrawing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgDrawing.Location = new System.Drawing.Point(0, 0);
            this.imgDrawing.Name = "imgDrawing";
            this.imgDrawing.Size = new System.Drawing.Size(652, 332);
            this.imgDrawing.TabIndex = 1;
            this.imgDrawing.TabStop = false;
            this.imgDrawing.Paint += new System.Windows.Forms.PaintEventHandler(this.imgDrawing_Paint);
            this.imgDrawing.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imgDrawing_MouseClick);
            this.imgDrawing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgDrawing_MouseDown);
            this.imgDrawing.MouseLeave += new System.EventHandler(this.imgDrawing_MouseLeave);
            this.imgDrawing.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgDrawing_MouseMove);
            this.imgDrawing.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgDrawing_MouseUp);
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.SystemColors.Window;
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 332);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(652, 22);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "statusStrip1";
            // 
            // statusBarLabel
            // 
            this.statusBarLabel.Name = "statusBarLabel";
            this.statusBarLabel.Size = new System.Drawing.Size(83, 17);
            this.statusBarLabel.Text = "statusBarLabel";
            // 
            // rdiModeDelete
            // 
            this.rdiModeDelete.AutoSize = true;
            this.rdiModeDelete.Location = new System.Drawing.Point(7, 66);
            this.rdiModeDelete.Name = "rdiModeDelete";
            this.rdiModeDelete.Size = new System.Drawing.Size(56, 17);
            this.rdiModeDelete.TabIndex = 2;
            this.rdiModeDelete.TabStop = true;
            this.rdiModeDelete.Text = "Delete";
            this.rdiModeDelete.UseVisualStyleBackColor = true;
            // 
            // rdiModeUnlink
            // 
            this.rdiModeUnlink.AutoSize = true;
            this.rdiModeUnlink.Location = new System.Drawing.Point(7, 89);
            this.rdiModeUnlink.Name = "rdiModeUnlink";
            this.rdiModeUnlink.Size = new System.Drawing.Size(55, 17);
            this.rdiModeUnlink.TabIndex = 3;
            this.rdiModeUnlink.TabStop = true;
            this.rdiModeUnlink.Text = "Unlink";
            this.rdiModeUnlink.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(565, 41);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 486);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlControls);
            this.Name = "MainForm";
            this.Text = "Use Case Helper";
            this.pnlControls.ResumeLayout(false);
            this.gbxMode.ResumeLayout(false);
            this.gbxMode.PerformLayout();
            this.gbxElement.ResumeLayout(false);
            this.gbxElement.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgDrawing)).EndInit();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.GroupBox gbxElement;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusBarLabel;
        private System.Windows.Forms.GroupBox gbxMode;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.PictureBox imgDrawing;
        private System.Windows.Forms.RadioButton rdiModeSelect;
        private System.Windows.Forms.RadioButton rdiModeCreate;
        private System.Windows.Forms.RadioButton rdiElementLine;
        private System.Windows.Forms.RadioButton rdiElementUseCase;
        private System.Windows.Forms.RadioButton rdiElementActor;
        private System.Windows.Forms.RadioButton rdiModeDelete;
        private System.Windows.Forms.RadioButton rdiModeUnlink;
        private System.Windows.Forms.Button btnExport;
    }
}

