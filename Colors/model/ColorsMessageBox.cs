using Colors.util;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Colors.model
{
    class ColorsMessageBox
    {
        private Form colorsMessageBox;
        private int functionality = Constants.CANCEL_FUNCTIONALITY_CODE;

        public ColorsMessageBox(int height, string title, string message, bool preview, Icon icon)
        {
            // Longitud del mensaje * ancho en píxeles de una letra mayúscula.
            int messageWidth = message.Length * Constants.COLORS_MSG_BOX_LETTER_WIDTH;

            this.colorsMessageBox = new Form();
            this.colorsMessageBox.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.colorsMessageBox.StartPosition = FormStartPosition.CenterScreen;
            this.colorsMessageBox.Size = new Size(messageWidth + Constants.COLORS_MSG_BOX_RIGHT_SPACE, height);
            this.colorsMessageBox.MinimizeBox = false;
            this.colorsMessageBox.MaximizeBox = false;
            this.colorsMessageBox.Text = title;
            this.colorsMessageBox.Icon = icon;
            this.colorsMessageBox.BackColor = Constants.CONTROLS_GENERAL_COLOR_ONE;

            Color white = Color.White;

            // Mensaje
            Label msg = new Label();
            msg.Text = message;
            msg.Width = messageWidth;
            msg.Location = new Point(Constants.COLORS_MSG_BOX_LABEL_X, Constants.COLORS_MSG_BOX_LABEL_Y);
            msg.ForeColor = white;
            this.colorsMessageBox.Controls.Add(msg);


            string buttonMessage = Constants.COLORS_MSG_BOX_ACCEPT_BUTTON;

            if (preview) {
                buttonMessage = Constants.COLORS_MSG_BOX_SAVE_BUTTON;
                Button previewBtn = new Button();
                previewBtn.Click += new EventHandler(previewBtn_Click);
                previewBtn.Text = Constants.COLORS_MSG_BOX_PREVIEW_BUTTON;
                previewBtn.Location = new Point(messageWidth - previewBtn.Width * 2, Constants.COLORS_MSG_BOX_BUTTON_Y);
                previewBtn.ForeColor = white;
                this.colorsMessageBox.Controls.Add(previewBtn);
            }

            // Botón por defecto, aceptar o guardar.
            Button defaultBtn = new Button();
            defaultBtn.Click += new EventHandler(defaultBtn_Click);
            defaultBtn.Text = buttonMessage;
            defaultBtn.Location = new Point(messageWidth - defaultBtn.Width, Constants.COLORS_MSG_BOX_BUTTON_Y);
            defaultBtn.ForeColor = white;
            this.colorsMessageBox.Controls.Add(defaultBtn);
        }

        public int show() {
            this.colorsMessageBox.ShowDialog();
            return this.functionality;
        }

        private void previewBtn_Click(object sender, EventArgs e) {
            this.functionality = Constants.PREVIEW_FUNCTIONALITY_CODE;
            this.colorsMessageBox.Close();
        }

        private void defaultBtn_Click(object sender, EventArgs e)
        {
            this.functionality = Constants.SAVE_FUNCTIONALITY_CODE;
            this.colorsMessageBox.Close();
        }
     
    }
}
