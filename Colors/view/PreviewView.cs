using Colors.controller;
using Colors.util;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Colors.view {
    public partial class PreviewView : Form {
        public PreviewView() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void PreviewView_Load(object sender, EventArgs e) {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            Color black = Constants.CONTROLS_GENERAL_COLOR_ONE;
            Color white = Color.White;

            this.BackColor = black;

            CloseBtn.BackColor = black;
            SaveBtn.BackColor = black;
            CloseBtn.ForeColor = white;
            SaveBtn.ForeColor = white;

            PreviewTextField.BackColor = black;
            PreviewTextField.ForeColor = white;
            PreviewTextField.ReadOnly = true;
            PreviewTextField.Text = ColorsController.getDecryptTextForPreview();
            
        }

        private void CloseBtn_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e) {
            File.WriteAllText(Constants.SAVE_DECRYPTED_TEXT_PATH, PreviewTextField.Text);
            ColorsController.callColorsMessageBox(Constants.COLORS_MSG_BOX_HEIGHT, Constants.COLORS_MSG_BOX_INFO, Constants.SAVE_DECRYPT_TEXT, false);
            this.Close();
        }
    }
}
