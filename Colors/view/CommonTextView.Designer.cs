
namespace Colors.view {
    partial class CommonTextView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommonTextView));
            this.CommonTextField = new System.Windows.Forms.RichTextBox();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.CommonBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CommonTextField
            // 
            this.CommonTextField.Location = new System.Drawing.Point(12, 12);
            this.CommonTextField.Name = "CommonTextField";
            this.CommonTextField.Size = new System.Drawing.Size(661, 305);
            this.CommonTextField.TabIndex = 0;
            this.CommonTextField.Text = "";
            this.CommonTextField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CommonTextField_KeyDown);
            this.CommonTextField.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CommonTextField_KeyUp);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(419, 323);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(124, 39);
            this.CloseBtn.TabIndex = 1;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // CommonBtn
            // 
            this.CommonBtn.Location = new System.Drawing.Point(549, 323);
            this.CommonBtn.Name = "CommonBtn";
            this.CommonBtn.Size = new System.Drawing.Size(124, 39);
            this.CommonBtn.TabIndex = 2;
            this.CommonBtn.UseVisualStyleBackColor = true;
            this.CommonBtn.Click += new System.EventHandler(this.CommonBtn_Click);
            // 
            // CommonTextView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 374);
            this.Controls.Add(this.CommonBtn);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.CommonTextField);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CommonTextView";
            this.Text = "Colors";
            this.Load += new System.EventHandler(this.CommonTextView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox CommonTextField;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button CommonBtn;
    }
}