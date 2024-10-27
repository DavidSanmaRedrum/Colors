
namespace Colors
{
    partial class ColorsMainView
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorsMainView));
            this.ColorsToolStrip = new System.Windows.Forms.ToolStrip();
            this.OpenFileBtn = new System.Windows.Forms.ToolStripButton();
            this.SeparatorOne = new System.Windows.Forms.ToolStripSeparator();
            this.TextWithoutFileBtn = new System.Windows.Forms.ToolStripButton();
            this.SeparatorTwo = new System.Windows.Forms.ToolStripSeparator();
            this.AboutBtn = new System.Windows.Forms.ToolStripButton();
            this.SeparatorThree = new System.Windows.Forms.ToolStripSeparator();
            this.DestroyKeyBtn = new System.Windows.Forms.ToolStripButton();
            this.ColorsImageList = new System.Windows.Forms.ImageList(this.components);
            this.ActionBtn = new System.Windows.Forms.Button();
            this.ColorsToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ColorsToolStrip
            // 
            this.ColorsToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ColorsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileBtn,
            this.SeparatorOne,
            this.TextWithoutFileBtn,
            this.SeparatorTwo,
            this.DestroyKeyBtn,
            this.SeparatorThree,
            this.AboutBtn});
            this.ColorsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ColorsToolStrip.Name = "ColorsToolStrip";
            this.ColorsToolStrip.Size = new System.Drawing.Size(400, 27);
            this.ColorsToolStrip.TabIndex = 0;
            this.ColorsToolStrip.Text = "toolStrip1";
            // 
            // OpenFileBtn
            // 
            this.OpenFileBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenFileBtn.Image = ((System.Drawing.Image)(resources.GetObject("OpenFileBtn.Image")));
            this.OpenFileBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenFileBtn.Name = "OpenFileBtn";
            this.OpenFileBtn.Size = new System.Drawing.Size(29, 24);
            this.OpenFileBtn.Text = "Open file";
            this.OpenFileBtn.Click += new System.EventHandler(this.OpenFileBtn_Click);
            // 
            // SeparatorOne
            // 
            this.SeparatorOne.Name = "SeparatorOne";
            this.SeparatorOne.Size = new System.Drawing.Size(6, 27);
            // 
            // TextWithoutFileBtn
            // 
            this.TextWithoutFileBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TextWithoutFileBtn.Image = ((System.Drawing.Image)(resources.GetObject("TextWithoutFileBtn.Image")));
            this.TextWithoutFileBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TextWithoutFileBtn.Name = "TextWithoutFileBtn";
            this.TextWithoutFileBtn.Size = new System.Drawing.Size(29, 24);
            this.TextWithoutFileBtn.Text = "Text without file";
            this.TextWithoutFileBtn.Click += new System.EventHandler(this.TextWithoutFileBtn_Click);
            // 
            // SeparatorTwo
            // 
            this.SeparatorTwo.Name = "SeparatorTwo";
            this.SeparatorTwo.Size = new System.Drawing.Size(6, 27);
            // 
            // AboutBtn
            // 
            this.AboutBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AboutBtn.Image = ((System.Drawing.Image)(resources.GetObject("AboutBtn.Image")));
            this.AboutBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AboutBtn.Name = "AboutBtn";
            this.AboutBtn.Size = new System.Drawing.Size(29, 24);
            this.AboutBtn.Text = "About";
            this.AboutBtn.Click += new System.EventHandler(this.AboutBtn_Click);
            // 
            // SeparatorThree
            // 
            this.SeparatorThree.Name = "SeparatorThree";
            this.SeparatorThree.Size = new System.Drawing.Size(6, 27);
            // 
            // DestroyKeyBtn
            // 
            this.DestroyKeyBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DestroyKeyBtn.Image = ((System.Drawing.Image)(resources.GetObject("DestroyKeyBtn.Image")));
            this.DestroyKeyBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DestroyKeyBtn.Name = "DestroyKeyBtn";
            this.DestroyKeyBtn.Size = new System.Drawing.Size(29, 24);
            this.DestroyKeyBtn.Text = "Destroy key";
            this.DestroyKeyBtn.Click += new System.EventHandler(this.DestroyKeyBtn_Click);
            // 
            // ColorsImageList
            // 
            this.ColorsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ColorsImageList.ImageStream")));
            this.ColorsImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ColorsImageList.Images.SetKeyName(0, "ColorsIcon.ico");
            // 
            // ActionBtn
            // 
            this.ActionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActionBtn.Location = new System.Drawing.Point(123, 55);
            this.ActionBtn.Name = "ActionBtn";
            this.ActionBtn.Size = new System.Drawing.Size(152, 46);
            this.ActionBtn.TabIndex = 3;
            this.ActionBtn.UseVisualStyleBackColor = true;
            this.ActionBtn.Click += new System.EventHandler(this.ActionBtn_Click);
            // 
            // ColorsMainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 127);
            this.Controls.Add(this.ActionBtn);
            this.Controls.Add(this.ColorsToolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ColorsMainView";
            this.Text = "Colors";
            this.Load += new System.EventHandler(this.ColorsMainView_Load);
            this.ColorsToolStrip.ResumeLayout(false);
            this.ColorsToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ColorsToolStrip;
        private System.Windows.Forms.ToolStripButton OpenFileBtn;
        private System.Windows.Forms.ImageList ColorsImageList;
        private System.Windows.Forms.ToolStripSeparator SeparatorOne;
        private System.Windows.Forms.Button ActionBtn;
        private System.Windows.Forms.ToolStripButton AboutBtn;
        private System.Windows.Forms.ToolStripButton TextWithoutFileBtn;
        private System.Windows.Forms.ToolStripSeparator SeparatorTwo;
        private System.Windows.Forms.ToolStripSeparator SeparatorThree;
        private System.Windows.Forms.ToolStripButton DestroyKeyBtn;
    }
}

