using Colors.controller;
using Colors.util;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Colors.view {
    public partial class KeyMakerView : Form {

        public KeyMakerView() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void KeyMakerView_Load(object sender, EventArgs e) {
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ColorsQuantCombo.DropDownStyle = ComboBoxStyle.DropDownList;

            Color black = Constants.CONTROLS_GENERAL_COLOR_ONE;
            Color white = Color.White;

            this.BackColor = black;
            KeyParamsBox.ForeColor = white;
            AutomaticBtn.BackColor = black;
            ManualBtn.BackColor = black;
            ColorsQuantCombo.BackColor = black;
            ColorsQuantCombo.ForeColor = white;

            for (int i = Constants.MIN_LIMIT_COLOR; i <= Constants.MAX_LIMIT_COLOR; i++) {
                this.ColorsQuantCombo.Items.Add(i);
            }
        }

        private void AutomaticBtn_Click(object sender, EventArgs e) {
            object selectedItem = this.ColorsQuantCombo.SelectedItem;
            if (null != selectedItem) {
                ColorsController.setIsKeyCreationAuto(Constants.COLORS_KEY_AUTO_CREATION_TYPE);
                ColorsController.setLetterColorsQuantity(Convert.ToInt16(selectedItem.ToString()));
                this.Close();
            } else {
                this.showErrorMessage();
            }
        }

        private void ManualBtn_Click(object sender, EventArgs e) {
            object selectedItem = this.ColorsQuantCombo.SelectedItem;
            if (null != selectedItem) {
                ColorsController.setIsKeyCreationAuto(Constants.COLORS_KEY_MANUAL_CREATION_TYPE);
                ColorsController.setLetterColorsQuantity(Convert.ToInt16(selectedItem.ToString()));
                KeyCanvasView keyCanvas = new KeyCanvasView();
                int dialogResponse = -1;
                int acceptDialogResponse = Constants.DEFAULT_COMMONS_FUNCTIONALITY_CODE;
                bool isAcceptButtonPressed = keyCanvas.show();
                if (null == ColorsController.getManuallyCreatedColors()) {
                    ColorsController.setIsKeyCreationAuto(-1);
                } else if (!isAcceptButtonPressed && (dialogResponse = ColorsController.callColorsMessageBox(
                    Constants.COLORS_MSG_BOX_HEIGHT,
                    Constants.COLORS_MSG_BOX_WARNING,
                    Constants.KEY_MANUAL_CREATION_CLOSE_SAVE_ALERT,
                    true,
                    false)) == acceptDialogResponse) {
                    this.Close();
                } else if (!isAcceptButtonPressed && dialogResponse != acceptDialogResponse) {
                    ColorsController.setManuallyCreatedColors(null);
                } else {
                    this.Close();
                }
            } else {
                this.showErrorMessage();
            } 
        }

        private void showErrorMessage() {
            ColorsController.callColorsMessageBox(
                Constants.COLORS_MSG_BOX_HEIGHT,
                Constants.COLORS_MSG_BOX_WARNING,
                Constants.NO_COLOR_QUANTITY_VALUE,
                false,
                false
            );
        }
    }
}
