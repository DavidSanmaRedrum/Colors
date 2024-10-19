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
            KeyAcceptBtn.BackColor = black;
            ColorsQuantCombo.BackColor = black;
            ColorsQuantCombo.ForeColor = white;

            for (int i = Constants.MIN_LIMIT_COLOR; i <= Constants.MAX_LIMIT_COLOR; i++) {
                this.ColorsQuantCombo.Items.Add(i);
            }
        }

        private void KeyAcceptBtn_Click(object sender, EventArgs e) {
            object selectedItem = this.ColorsQuantCombo.SelectedItem;
            if (null != selectedItem) {
                ColorsController.setLetterColorsQuantity(Convert.ToInt16(selectedItem.ToString()));
                this.Close();
            } else {
                ColorsController.callColorsMessageBox(
                    Constants.COLORS_MSG_BOX_HEIGHT,
                    Constants.COLORS_MSG_BOX_WARINING,
                    Constants.NO_COLOR_QUANTITY_VALUE,
                    false
                );
            }
        }
    }
}
