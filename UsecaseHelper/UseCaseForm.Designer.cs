namespace UsecaseHelper
{
    partial class UseCaseForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.txtActors = new System.Windows.Forms.TextBox();
            this.txtAssumptions = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtExceptions = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblSummary = new System.Windows.Forms.Label();
            this.lblActors = new System.Windows.Forms.Label();
            this.lblAssumptions = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblExceptions = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(165, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(329, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtSummary
            // 
            this.txtSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSummary.Location = new System.Drawing.Point(165, 38);
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Size = new System.Drawing.Size(329, 20);
            this.txtSummary.TabIndex = 2;
            // 
            // txtActors
            // 
            this.txtActors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtActors.Enabled = false;
            this.txtActors.Location = new System.Drawing.Point(165, 64);
            this.txtActors.Name = "txtActors";
            this.txtActors.ReadOnly = true;
            this.txtActors.Size = new System.Drawing.Size(329, 20);
            this.txtActors.TabIndex = 3;
            // 
            // txtAssumptions
            // 
            this.txtAssumptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssumptions.Location = new System.Drawing.Point(165, 90);
            this.txtAssumptions.Name = "txtAssumptions";
            this.txtAssumptions.Size = new System.Drawing.Size(329, 20);
            this.txtAssumptions.TabIndex = 4;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(165, 116);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(329, 77);
            this.txtDescription.TabIndex = 5;
            // 
            // txtExceptions
            // 
            this.txtExceptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExceptions.Location = new System.Drawing.Point(165, 199);
            this.txtExceptions.Multiline = true;
            this.txtExceptions.Name = "txtExceptions";
            this.txtExceptions.Size = new System.Drawing.Size(329, 77);
            this.txtExceptions.TabIndex = 6;
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(165, 282);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(329, 20);
            this.txtResult.TabIndex = 7;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(419, 308);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "OK";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Location = new System.Drawing.Point(12, 41);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(53, 13);
            this.lblSummary.TabIndex = 9;
            this.lblSummary.Text = "Summary:";
            // 
            // lblActors
            // 
            this.lblActors.AutoSize = true;
            this.lblActors.Location = new System.Drawing.Point(12, 67);
            this.lblActors.Name = "lblActors";
            this.lblActors.Size = new System.Drawing.Size(40, 13);
            this.lblActors.TabIndex = 10;
            this.lblActors.Text = "Actors:";
            // 
            // lblAssumptions
            // 
            this.lblAssumptions.AutoSize = true;
            this.lblAssumptions.Location = new System.Drawing.Point(12, 93);
            this.lblAssumptions.Name = "lblAssumptions";
            this.lblAssumptions.Size = new System.Drawing.Size(69, 13);
            this.lblAssumptions.TabIndex = 11;
            this.lblAssumptions.Text = "Assumptions:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 119);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "Description:";
            // 
            // lblExceptions
            // 
            this.lblExceptions.AutoSize = true;
            this.lblExceptions.Location = new System.Drawing.Point(12, 202);
            this.lblExceptions.Name = "lblExceptions";
            this.lblExceptions.Size = new System.Drawing.Size(62, 13);
            this.lblExceptions.TabIndex = 13;
            this.lblExceptions.Text = "Exceptions:";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(12, 285);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(40, 13);
            this.lblResult.TabIndex = 14;
            this.lblResult.Text = "Result:";
            // 
            // UseCaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(506, 342);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblExceptions);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblAssumptions);
            this.Controls.Add(this.lblActors);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtExceptions);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtAssumptions);
            this.Controls.Add(this.txtActors);
            this.Controls.Add(this.txtSummary);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Name = "UseCaseForm";
            this.Text = "UseCaseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.TextBox txtActors;
        private System.Windows.Forms.TextBox txtAssumptions;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtExceptions;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Label lblActors;
        private System.Windows.Forms.Label lblAssumptions;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblExceptions;
        private System.Windows.Forms.Label lblResult;
    }
}