using Colors.controller;
using Colors.util;
using Colors.view;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Colors {
    public partial class ColorsMainView : Form {
        public ColorsMainView() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Opacity = 0;
        }

        private string filePath = "";

        private void ColorsMainView_Load(object sender, EventArgs e) {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Constants.CONTROLS_GENERAL_COLOR_ONE;
            ColorsToolStrip.BackColor = Constants.CONTROLS_GENERAL_COLOR_TWO;
            
            ColorsController.setIcon(Icon.FromHandle(((Bitmap)ColorsImageList.Images[0]).GetHicon()));

            FileActionBtn.BackColor = Color.WhiteSmoke;
            FileActionBtn.Text = Constants.ACTION_BUTTON_NEUTRAL;
            FileActionBtn.Enabled = false;

            string output;

            if (!ColorsController.keyFileExists()) {
                KeyMakerView keyCreator = new KeyMakerView();
                keyCreator.ShowDialog();
                int colorsQuantity = ColorsController.getLetterColorsQuantity();
                if (colorsQuantity > 0) {
                    ColorsController.createKeyFile(colorsQuantity);
                    ColorsController.callColorsMessageBox(Constants.COLORS_MSG_BOX_HEIGHT, Constants.COLORS_MSG_BOX_INFO, Constants.NO_EXISTS_KEY_FILE_MSG, false);
                    this.Close();
                } else {
                    this.Close();
                }
            } else if (!(output = ColorsController.isKeyFileFormatCorrect()).Equals("")) {
                ColorsController.callColorsMessageBox(Constants.COLORS_MSG_BOX_HEIGHT, Constants.COLORS_MSG_BOX_ERROR, output, false);
                this.Close();
            } else {
                this.Opacity = 1;
            }
        }

        private void OpenFileBtn_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = Constants.OPEN_FILE_DIALOG_TITLE;
            openFileDialog.Filter = Constants.OPEN_FILE_DIALOG_FILTER;

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                this.filePath = openFileDialog.FileName;
                string actionButtonTitle = Constants.ACTION_BUTTON_ENCRYPT;
                if (!this.filePath.EndsWith(Constants.TXT_EXTENSION)) {
                    FileActionBtn.ForeColor = Color.Red;
                    actionButtonTitle = Constants.ACTION_BUTTON_DECRYPT;
                } else {
                    FileActionBtn.ForeColor = Color.Blue;
                }

                FileActionBtn.Text = actionButtonTitle;
                FileActionBtn.Enabled = true;
            }
        }

        private void AboutBtn_Click(object sender, EventArgs e) {
            AboutColors about = new AboutColors();
            about.ShowDialog();
        }

        private void FileActionBtn_Click(object sender, EventArgs e) {
            FileActionBtn.Text = Constants.ACTION_BUTTON_NEUTRAL;
            FileActionBtn.Enabled = false;
            string path = this.filePath;
            if (path.EndsWith(Constants.TXT_EXTENSION)) {
                string fileData = ColorsController.getFileData(path);
                Bitmap encryptedImage = ColorsController.encryptText(fileData);
                encryptedImage.Save(Constants.SAVE_ENCRYPTED_IMAGE_PATH);
                ColorsController.callColorsMessageBox(Constants.COLORS_MSG_BOX_HEIGHT, Constants.COLORS_MSG_BOX_INFO, Constants.SAVE_ENCRYPT_IMAGE, false);
            } else {
                Bitmap encryptedImage = new Bitmap(path);
                string text = ColorsController.decryptImage(encryptedImage);
                int dialogCode = Constants.CANCEL_FUNCTIONALITY_CODE;
                if (!text.Equals(Constants.INVALID_IMAGE)
                    && (dialogCode = ColorsController.callColorsMessageBox(Constants.COLORS_MSG_BOX_HEIGHT, Constants.COLORS_MSG_BOX_INFO, Constants.SAVE_OR_PREVIEW, true)) == Constants.SAVE_FUNCTIONALITY_CODE) {
                    File.WriteAllText(Constants.SAVE_DECRYPTED_TEXT_PATH, text);
                    ColorsController.callColorsMessageBox(Constants.COLORS_MSG_BOX_HEIGHT, Constants.COLORS_MSG_BOX_INFO, Constants.SAVE_DECRYPT_TEXT, false);
                } else if (!text.Equals(Constants.INVALID_IMAGE) && dialogCode == Constants.PREVIEW_FUNCTIONALITY_CODE) {
                    ColorsController.setDecryptTextForPreview(text);
                    PreviewView previewView = new PreviewView();
                    previewView.ShowDialog();
                } else if (text.Equals(Constants.INVALID_IMAGE)) {
                    ColorsController.callColorsMessageBox(Constants.COLORS_MSG_BOX_HEIGHT, Constants.COLORS_MSG_BOX_ERROR, text, false);
                }
                encryptedImage.Dispose(); // Hacer que el programa deje de usar la imagen.
            }
            this.filePath = "";
        }

    }
}
