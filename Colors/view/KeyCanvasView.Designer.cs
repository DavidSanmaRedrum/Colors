
namespace Colors.view {
    partial class KeyCanvasView {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyCanvasView));
            this.KeyCanvas = new System.Windows.Forms.PictureBox();
            this.AcceptBtn = new System.Windows.Forms.Button();
            this.PickupFrecuencyIndicatorTimer = new System.Windows.Forms.Timer(this.components);
            this.InfoLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.KeyCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // KeyCanvas
            // 
            this.KeyCanvas.Image = ((System.Drawing.Image)(resources.GetObject("KeyCanvas.Image")));
            this.KeyCanvas.Location = new System.Drawing.Point(12, 12);
            this.KeyCanvas.Name = "KeyCanvas";
            this.KeyCanvas.Size = new System.Drawing.Size(255, 255);
            this.KeyCanvas.TabIndex = 0;
            this.KeyCanvas.TabStop = false;
            this.KeyCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.KeyCanvas_MouseMove);
            // 
            // AcceptBtn
            // 
            this.AcceptBtn.Location = new System.Drawing.Point(232, 371);
            this.AcceptBtn.Name = "AcceptBtn";
            this.AcceptBtn.Size = new System.Drawing.Size(127, 44);
            this.AcceptBtn.TabIndex = 1;
            this.AcceptBtn.Text = "Accept";
            this.AcceptBtn.UseVisualStyleBackColor = true;
            this.AcceptBtn.Click += new System.EventHandler(this.AcceptBtn_Click);
            // 
            // PickupFrecuencyIndicatorTimer
            // 
            this.PickupFrecuencyIndicatorTimer.Tick += new System.EventHandler(this.PickupFrecuencyIndicatorTimer_Tick);
            // 
            // InfoLbl
            // 
            this.InfoLbl.AutoSize = true;
            this.InfoLbl.Location = new System.Drawing.Point(40, 339);
            this.InfoLbl.Name = "InfoLbl";
            this.InfoLbl.Size = new System.Drawing.Size(40, 17);
            this.InfoLbl.TabIndex = 2;
            this.InfoLbl.Text = "INFO";
            // 
            // KeyCanvasView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 427);
            this.Controls.Add(this.InfoLbl);
            this.Controls.Add(this.AcceptBtn);
            this.Controls.Add(this.KeyCanvas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KeyCanvasView";
            this.Text = "Colors";
            this.Load += new System.EventHandler(this.KeyCanvasView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KeyCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox KeyCanvas;
        private System.Windows.Forms.Button AcceptBtn;
        private System.Windows.Forms.Timer PickupFrecuencyIndicatorTimer;
        private System.Windows.Forms.Label InfoLbl;
    }
}