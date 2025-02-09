﻿using Colors.controller;
using Colors.util;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Colors.view {
    public partial class CommonTextView : Form {

        private int functionality = Constants.CANCEL_FUNCTIONALITY_CODE;
        private bool isPreviewActivated;
        private bool isPasteActivated;
        private string decryptTextForPreview;

        public CommonTextView() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void CommonTextView_Load(object sender, EventArgs e) {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.isPasteActivated = false;

            this.isPreviewActivated = ColorsController.getIsPreviewActivated();
            this.decryptTextForPreview = ColorsController.getDecryptTextForPreview();

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
                ColorsController.callColorsMessageBox(Constants.COLORS_MSG_BOX_HEIGHT, Constants.COLORS_MSG_BOX_INFO, Constants.SAVE_DECRYPT_TEXT, false, false);
                this.decryptTextForPreview = "";
                this.Close();
            } else if (!CommonTextField.Text.Equals("")) {
                ColorsController.setTextDataWithoutFile(CommonTextField.Text);
                this.functionality = Constants.TEXT_WITHOUT_FILE_FUNCTIONALITY_CODE;
                this.Close();
            } else {
                ColorsController.callColorsMessageBox(Constants.COLORS_MSG_BOX_HEIGHT, Constants.COLORS_MSG_BOX_ERROR, Constants.VOID_INPUT_TEXT_WITHOUT_FILE, false, false);
            }
        }

        private void CommonTextField_KeyDown(object sender, KeyEventArgs e) {
            Keys currentKeyPressed = e.KeyCode;
            if (currentKeyPressed.Equals(Keys.Enter)) {
                e.SuppressKeyPress = true;
                string text = CommonTextField.Text;
                text += Constants.KEY_VALUE_LINE_FEED;
                CommonTextField.Text = text;
                CommonTextField.SelectionStart = text.Length;
            } else if (e.Control && currentKeyPressed.Equals(Keys.V)) {
                // El replace lo hago en el evento KeyUp porque si se hace aquí, el primer texto obtenido está vacío,
                // en el evento KeyUp ya tiene registro de lo que se acaba de pegar, al hacer CTRL + V aquí y hacer
                // Console.WriteLine(CommonTextField.Text) va a devolver vacío y en el KeyUp al levantar la tecla
                // ya va a haber información.
                this.isPasteActivated = true;
            }
        }

        private void CommonTextField_KeyUp(object sender, KeyEventArgs e) {
            // Si no le pongo este if me pone un duplicado extra, uno por soltar la tecla CTRL y el otro por soltar la tecla V.
            if (this.isPasteActivated) {
                this.isPasteActivated = false;
                string text = CommonTextField.Text;
                text = text.Replace(Constants.KEY_VALUE_LINE_FEED_TWO, Constants.KEY_VALUE_LINE_FEED);
                CommonTextField.Text = text;
                CommonTextField.SelectionStart = text.Length;
            }
        }
    }
}
