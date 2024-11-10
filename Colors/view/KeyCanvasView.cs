using Colors.controller;
using Colors.util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Colors.view {
    public partial class KeyCanvasView : Form {

        private bool isAcceptButtonPressed = false;
        private HashSet<string> keyARGBManualParams = new HashSet<string>();
        private int keyARGBSize = 0;
        private bool firstTurn = true;
        private bool isPickupActivated = true;
        private string argbColor = "";
        private char argbSeparator = Constants.KEY_VALUE_COLOR_ARGB_SEPARATOR;
        

        public KeyCanvasView() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void KeyCanvasView_Load(object sender, EventArgs e) {
            int canvasSize = Constants.MAX_LIMIT_ARGB + 3; // Le sumo 3 porque por algún fallo gráfico solo llega hasta 252. (El 0 lo respeta)
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            KeyCanvas.Size = new Size(canvasSize, canvasSize);
            int margin = Constants.CANVAS_TOP_LEFT_MARGIN;
            KeyCanvas.Location = new Point(margin, margin);
            KeyCanvas.BorderStyle = BorderStyle.FixedSingle;

            Color black = Constants.CONTROLS_GENERAL_COLOR_ONE;
            this.BackColor = black;

            AcceptBtn.Enabled = false;
            AcceptBtn.BackColor = black;

            InfoLbl.Text = Constants.KEY_MANUAL_CREATION_INFO;
            // AcceptBtn.ForeColor = Color.Gray;

            this.keyARGBSize = Constants.CHARACTERS.Length * ColorsController.getLetterColorsQuantity();
            PickupFrecuencyIndicatorTimer.Start();
        }

        private void KeyCanvas_MouseMove(object sender, MouseEventArgs e) {
            if (this.keyARGBManualParams.Count < this.keyARGBSize) {
                int xPos = Convert.ToInt32(e.X);
                int yPos = Convert.ToInt32(e.Y);
                if (this.firstTurn) {
                    this.firstTurn = false;
                    this.argbColor = xPos.ToString() + this.argbSeparator + yPos.ToString() + this.argbSeparator;
                } else {
                    this.firstTurn = true;
                    this.argbColor += xPos.ToString() + this.argbSeparator + yPos.ToString();
                    this.keyARGBManualParams.Add(this.argbColor);
                }
            } else {
                PickupFrecuencyIndicatorTimer.Stop();  
                ColorsController.setManuallyCreatedColors(this.keyARGBManualParams.ToArray());
                KeyCanvas.Enabled = false;
                AcceptBtn.Enabled = true;
                InfoLbl.BackColor = Color.Yellow;
                AcceptBtn.ForeColor = Color.White;
            }
        }

        public bool show() {
            this.ShowDialog();
            return isAcceptButtonPressed;
        }

        private void AcceptBtn_Click(object sender, EventArgs e) {
            this.isAcceptButtonPressed = true;
            this.Close();
        }

        private void PickupFrecuencyIndicatorTimer_Tick(object sender, EventArgs e) {
            if (isPickupActivated) {
                isPickupActivated = false;
                InfoLbl.BackColor = Color.Green;
            } else {
                isPickupActivated = true;
                InfoLbl.BackColor = Color.Blue;
            }
        }
    }
}
