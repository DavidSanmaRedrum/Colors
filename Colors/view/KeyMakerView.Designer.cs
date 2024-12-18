﻿
namespace Colors.view
{
    partial class KeyMakerView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyMakerView));
            this.KeyParamsBox = new System.Windows.Forms.GroupBox();
            this.ManualBtn = new System.Windows.Forms.Button();
            this.AutomaticBtn = new System.Windows.Forms.Button();
            this.ColorsQuantCombo = new System.Windows.Forms.ComboBox();
            this.KeyMakerKLengthLbl = new System.Windows.Forms.Label();
            this.KeyParamsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // KeyParamsBox
            // 
            this.KeyParamsBox.Controls.Add(this.ManualBtn);
            this.KeyParamsBox.Controls.Add(this.AutomaticBtn);
            this.KeyParamsBox.Controls.Add(this.ColorsQuantCombo);
            this.KeyParamsBox.Controls.Add(this.KeyMakerKLengthLbl);
            this.KeyParamsBox.Location = new System.Drawing.Point(12, 12);
            this.KeyParamsBox.Name = "KeyParamsBox";
            this.KeyParamsBox.Size = new System.Drawing.Size(386, 142);
            this.KeyParamsBox.TabIndex = 0;
            this.KeyParamsBox.TabStop = false;
            this.KeyParamsBox.Text = "Key maker";
            // 
            // ManualBtn
            // 
            this.ManualBtn.Location = new System.Drawing.Point(203, 85);
            this.ManualBtn.Name = "ManualBtn";
            this.ManualBtn.Size = new System.Drawing.Size(143, 40);
            this.ManualBtn.TabIndex = 4;
            this.ManualBtn.Text = "Manual creation";
            this.ManualBtn.UseVisualStyleBackColor = true;
            this.ManualBtn.Click += new System.EventHandler(this.ManualBtn_Click);
            // 
            // AutomaticBtn
            // 
            this.AutomaticBtn.Location = new System.Drawing.Point(42, 85);
            this.AutomaticBtn.Name = "AutomaticBtn";
            this.AutomaticBtn.Size = new System.Drawing.Size(143, 40);
            this.AutomaticBtn.TabIndex = 3;
            this.AutomaticBtn.Text = "Automatic creation";
            this.AutomaticBtn.UseVisualStyleBackColor = true;
            this.AutomaticBtn.Click += new System.EventHandler(this.AutomaticBtn_Click);
            // 
            // ColorsQuantCombo
            // 
            this.ColorsQuantCombo.FormattingEnabled = true;
            this.ColorsQuantCombo.Location = new System.Drawing.Point(226, 42);
            this.ColorsQuantCombo.Name = "ColorsQuantCombo";
            this.ColorsQuantCombo.Size = new System.Drawing.Size(102, 24);
            this.ColorsQuantCombo.TabIndex = 2;
            // 
            // KeyMakerKLengthLbl
            // 
            this.KeyMakerKLengthLbl.AutoSize = true;
            this.KeyMakerKLengthLbl.Location = new System.Drawing.Point(57, 45);
            this.KeyMakerKLengthLbl.Name = "KeyMakerKLengthLbl";
            this.KeyMakerKLengthLbl.Size = new System.Drawing.Size(167, 17);
            this.KeyMakerKLengthLbl.TabIndex = 1;
            this.KeyMakerKLengthLbl.Text = "Colors quantity per letter:";
            // 
            // KeyMakerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 166);
            this.Controls.Add(this.KeyParamsBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KeyMakerView";
            this.Text = "Colors";
            this.Load += new System.EventHandler(this.KeyMakerView_Load);
            this.KeyParamsBox.ResumeLayout(false);
            this.KeyParamsBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox KeyParamsBox;
        private System.Windows.Forms.Label KeyMakerKLengthLbl;
        private System.Windows.Forms.ComboBox ColorsQuantCombo;
        private System.Windows.Forms.Button AutomaticBtn;
        private System.Windows.Forms.Button ManualBtn;
    }
}