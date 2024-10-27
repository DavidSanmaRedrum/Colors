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

            ActionBtn.BackColor = Color.WhiteSmoke;
            refreshActionBtn();

            string output;

            if (!ColorsController.keyFileExists()) {
                KeyMakerView keyCreator = new KeyMakerView();
                keyCreator.ShowDialog();
                int colorsQuantity = ColorsController.getLetterColorsQuantity();
                if (colorsQuantity > 0) {
                    ColorsController.createKeyFile(colorsQuantity);
                    ColorsController.callColorsMessageBox(Constants.COLORS_MSG_BOX_HEIGHT, Constants.COLORS_MSG_BOX_INFO, Constants.NO_EXISTS_KEY_FILE_MSG, false, false);
                }
                this.Close();
            } else if (!(output = ColorsController.isKeyFileFormatCorrect()).Equals("")) {
                ColorsController.callColorsMessageBox(Constants.COLORS_MSG_BOX_HEIGHT, Constants.COLORS_MSG_BOX_ERROR, output, false, false);
                this.Close();
            } else {
                this.Opacity = 1;
            }
        }

        private void OpenFileBtn_Click(object sender, EventArgs e) {
            ColorsController.setTextDataWithoutFile(""); // Vaciar esto por si acaso.
            refreshActionBtn();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = Constants.OPEN_FILE_DIALOG_TITLE;
            openFileDialog.Filter = Constants.OPEN_FILE_DIALOG_FILTER;

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                this.filePath = openFileDialog.FileName;
                string actionButtonTitle = Constants.ACTION_BUTTON_ENCRYPT;
                if (!this.filePath.EndsWith(Constants.TXT_EXTENSION)) {
                    ActionBtn.ForeColor = Color.Red;
                    actionButtonTitle = Constants.ACTION_BUTTON_DECRYPT;
                } else {
                    ActionBtn.ForeColor = Color.Blue;
                }
                
                ActionBtn.Text = actionButtonTitle;
                ActionBtn.Enabled = true;
                DestroyKeyBtn.Enabled = false;
            }
        }

        private void TextWithoutFileBtn_Click(object sender, EventArgs e) {
            this.filePath = ""; // Vaciar esto por si acaso.
            refreshActionBtn();
            CommonTextView textWithoutFileInput = new CommonTextView();
            textWithoutFileInput.setIsPreviewActivated(false);
            if (textWithoutFileInput.show() == Constants.TEXT_WITHOUT_FILE_FUNCTIONALITY_CODE) {
                ActionBtn.ForeColor = Color.Green;
                ActionBtn.Text = Constants.ACTION_BUTTON_ENCRYPT;
                ActionBtn.Enabled = true;
                DestroyKeyBtn.Enabled = false;
            }
        }

        private void DestroyKeyBtn_Click(object sender, EventArgs e) {
            if (ColorsController.callColorsMessageBox(Constants.COLORS_MSG_BOX_HEIGHT, Constants.COLORS_MSG_BOX_WARNING, Constants.DELETE_KEY_ALERT, true, false)
                == Constants.DEFAULT_COMMONS_FUNCTIONALITY_CODE) {

                if (!ColorsController.destroyKey()) {
                    ColorsController.callColorsMessageBox(Constants.COLORS_MSG_BOX_HEIGHT, Constants.COLORS_MSG_BOX_ERROR, Constants.DELETE_KEY_PROBLEMS, false, false);
                } else {
                    //File.Delete(Constants.KEY_IN_CURRENT_DIR);
                    ColorsController.callColorsMessageBox(Constants.COLORS_MSG_BOX_HEIGHT, Constants.COLORS_MSG_BOX_INFO, Constants.DELETE_KEY_TRUE, false, false);
                    this.Close();
                }
            }
        }

        private void AboutBtn_Click(object sender, EventArgs e) {
            AboutColors about = new AboutColors();
            about.ShowDialog();
        }

        private void ActionBtn_Click(object sender, EventArgs e) {
            refreshActionBtn();
            string path = this.filePath;
            string data = ColorsController.getTextDataWithoutFile();
            if (path.EndsWith(Constants.TXT_EXTENSION) || data.Length > 0) {
                if (data.Length == 0) data = ColorsController.getFileData(path);
                string title = Constants.COLORS_MSG_BOX_ERROR;
                string message = Constants.FILE_PROBLEMS;
                if (!data.Equals("")) {
                    Bitmap encryptedImage = ColorsController.encryptText(data);
                    encryptedImage.Save(Constants.SAVE_ENCRYPTED_IMAGE_PATH);
                    title = Constants.COLORS_MSG_BOX_INFO;
                    message = Constants.SAVE_ENCRYPT_IMAGE;
                }
                ColorsController.callColorsMessageBox(Constants.COLORS_MSG_BOX_HEIGHT, title, message, false, false);
            } else {
                Bitmap encryptedImage = new Bitmap(path);
                string decryptedText = ColorsController.decryptImage(encryptedImage);
                int dialogCode = Constants.CANCEL_FUNCTIONALITY_CODE;
                if (!decryptedText.Equals(Constants.INVALID_IMAGE)
                    && (dialogCode = ColorsController.callColorsMessageBox(Constants.COLORS_MSG_BOX_HEIGHT, Constants.COLORS_MSG_BOX_INFO, Constants.SAVE_OR_PREVIEW, false, true)) == Constants.DEFAULT_COMMONS_FUNCTIONALITY_CODE) {
                    File.WriteAllText(Constants.SAVE_DECRYPTED_TEXT_PATH, decryptedText);
                    ColorsController.callColorsMessageBox(Constants.COLORS_MSG_BOX_HEIGHT, Constants.COLORS_MSG_BOX_INFO, Constants.SAVE_DECRYPT_TEXT, false, false);
                } else if (!decryptedText.Equals(Constants.INVALID_IMAGE) && dialogCode == Constants.PREVIEW_FUNCTIONALITY_CODE) {
                    CommonTextView previewView = new CommonTextView();
                    previewView.setIsPreviewActivated(true);
                    previewView.setDecryptTextForPreview(decryptedText);
                    previewView.show();
                } else if (decryptedText.Equals(Constants.INVALID_IMAGE)) {
                    ColorsController.callColorsMessageBox(Constants.COLORS_MSG_BOX_HEIGHT, Constants.COLORS_MSG_BOX_ERROR, decryptedText, false, false);
                }
                encryptedImage.Dispose(); // Hacer que el programa deje de usar la imagen.
            }
            DestroyKeyBtn.Enabled = true;
            this.filePath = "";
        }

        private void refreshActionBtn() {
            ActionBtn.Text = Constants.ACTION_BUTTON_NEUTRAL;
            ActionBtn.Enabled = false;
        }

    }
}
