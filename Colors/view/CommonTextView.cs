using Colors.controller;
using Colors.util;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Colors.view {
    public partial class CommonTextView : Form {

        private string decryptTextForPreview = "";
        private bool isPreviewActivated;
        private int functionality = Constants.CANCEL_FUNCTIONALITY_CODE;

        public CommonTextView() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void CommonTextView_Load(object sender, EventArgs e) {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            Color black = Constants.CONTROLS_GENERAL_COLOR_ONE;
            Color white = Color.White;

            this.BackColor = black;

            CloseBtn.BackColor = black;
            CommonBtn.BackColor = black;
            CloseBtn.ForeColor = white;
            CommonBtn.ForeColor = white;

            CommonTextField.BackColor = black;
            CommonTextField.ForeColor = white;
            CommonTextField.ReadOnly = this.isPreviewActivated;
            
            if (this.isPreviewActivated) {
                CommonTextField.Text = this.decryptTextForPreview;
                CommonBtn.Text = Constants.COLORS_SAVE;
            } else {
                
                CommonBtn.Text = Constants.COLORS_ACCEPT;
            }
            
        }

        public int show() {
            this.ShowDialog();
            return this.functionality;
        }

        private void CloseBtn_Click(object sender, EventArgs e) {
            this.decryptTextForPreview = "";
            this.Close();
        }

        private void CommonBtn_Click(object sender, EventArgs e) {
            if (this.isPreviewActivated) {
                File.WriteAllText(Constants.SAVE_DECRYPTED_TEXT_PATH, CommonTextField.Text);
                ColorsController.callColorsMessageBox(Constants.COLORS_MSG_BOX_HEIGHT, Constants.COLORS_MSG_BOX_INFO, Constants.SAVE_DECRYPT_TEXT, false);
                this.decryptTextForPreview = "";
                this.Close();
            } else if (!CommonTextField.Text.Equals("")) {
                ColorsController.setTextDataWithoutFile(CommonTextField.Text);
                this.functionality = Constants.TEXT_WITHOUT_FILE_FUNCTIONALITY_CODE;
                this.Close();
            } else {
                ColorsController.callColorsMessageBox(Constants.COLORS_MSG_BOX_HEIGHT, Constants.COLORS_MSG_BOX_ERROR, Constants.VOID_INPUT_TEXT_WITHOUT_FILE, false);
            }
        }

        public void setDecryptTextForPreview(string decryptText) {
            this.decryptTextForPreview = decryptText;
        }

        public void setIsPreviewActivated(bool isPreviewView) {
            this.isPreviewActivated = isPreviewView;
        }

        private void CommonTextField_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode.Equals(Keys.Enter)) {
                e.SuppressKeyPress = true;
                string text = CommonTextField.Text;
                text += Constants.KEY_VALUE_LINE_FEED + "";
                CommonTextField.Text = text;
                CommonTextField.SelectionStart = text.Length;
            } else if (e.Control) {
                e.SuppressKeyPress = true;
            }
        }
    }
}
