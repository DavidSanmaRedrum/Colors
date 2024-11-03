
using System.Drawing;

namespace Colors.util
{
    class Constants
    {
        public const int MAX_LIMIT_ARGB = 255;
        public const int ARGB_LENGTH = 4;
        public const int MIN_LIMIT_COLOR = 4;
        public const int MAX_LIMIT_COLOR = 15; // Dejarlo en 10

        public const int CANCEL_FUNCTIONALITY_CODE = 0;
        public const int PREVIEW_FUNCTIONALITY_CODE = 1;
        public const int DEFAULT_COMMONS_FUNCTIONALITY_CODE = 2;
        public const int TEXT_WITHOUT_FILE_FUNCTIONALITY_CODE = 3;

        public const int COLORS_MSG_BOX_HEIGHT = 110;
        public const int COLORS_MSG_BOX_RIGHT_SPACE = 27;
        public const int COLORS_MSG_BOX_LABEL_X = 10;
        public const int COLORS_MSG_BOX_LABEL_Y = 15;

        public const int COLORS_MSG_BOX_BUTTON_Y = 40;

        public const int COLORS_MSG_BOX_LETTER_WIDTH = 6;
        public const string COLORS_MSG_BOX_ERROR = "Colors: Error";
        public const string COLORS_MSG_BOX_INFO = "Colors: Information";
        public const string COLORS_MSG_BOX_WARNING = "Colors: Warning";
        public const string COLORS_MSG_BOX_ACCEPT_BUTTON = "Accept";
        public const string COLORS_MSG_BOX_CANCEL_BUTTON = "Cancel";
        public const string COLORS_MSG_BOX_SAVE_BUTTON = "Save";
        public const string COLORS_MSG_BOX_PREVIEW_BUTTON = "Preview";

        public const string COLORS_ACCEPT = "Accept";
        public const string COLORS_SAVE = "Save";

        public const string DELETE_KEY_REGEX = "\\d";

        public const string OPEN_FILE_DIALOG_TITLE = "Open file";
        public const string OPEN_FILE_DIALOG_FILTER = "TXT (*.txt)|*.txt|JPG (*.jpg)|*.jpg";
        public const string TXT_EXTENSION = ".txt";

        public const string ACTION_BUTTON_ENCRYPT = "ENCRYPT TEXT";
        public const string ACTION_BUTTON_DECRYPT = "DECRYPT IMAGE";
        public const string ACTION_BUTTON_NEUTRAL = "· · ·";

        public const string SAVE_ENCRYPTED_IMAGE_PATH = "./encryptedImage.jpg";
        public const string SAVE_DECRYPTED_TEXT_PATH = "./decryptedText.txt";

        public const string KEY_IN_CURRENT_DIR = "./key";
        public const string CHARACTERS = " ◙©0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZÁÉÍÓÚÀÈÌÒÙ.,:;¿?¡!+-*_@#~$%&/()=";
        public const string ONLY_NUMBERS_REGEX = "\\d+";
        public const string END_SPACE = "©";
        public const string HASHTAG = "#";
        public const char KEY_VALUE_COLOR_SEPARATOR = '║';
        public const char KEY_VALUE_COLOR_ARGB_SEPARATOR = '≡';
        public const char KEY_VALUE_SQUARE = '■';
        public const char KEY_VALUE_LINE_FEED = '◙';
        public const char KEY_VALUE_LINE_FEED_TWO = '\n';
        public const char KEY_VALUE_COMMA = ',';
        public const char DELETE_KEY_LINE_FEED = '¥'; // Este valor no debe estar en CHARACTERS si no hará un error en el split.
        // Errores de clave:
        public const string NO_EXISTS_KEY_FILE_MSG = "A new key has been created in this folder.";
        public const string PATTERN_FAILURE = "KEY - Pattern error in line: ";
        public const string ARGB_FAILURE = "KEY - ARGB error in line: ";
        public const string MIN_LIMIT_COLOR_FAILURE = "KEY - Number colors below 3 error in line: ";
        public const string REPEAT_COLORS_KEY_FILE = "KEY - Repeated color: ";
        public const string REPEAT_CHARS_KEY_FILE = "KEY - Repeated character: ";
        public const string INCORRECT_NUMBER_OF_COLORS = "KEY - Incorrect number of colors in line: ";
        public const string MISSING_CHARACTER = "KEY - Missing character: ";
        // Parametros de clave:
        public const string NO_COLOR_QUANTITY_VALUE = "Colors number per letter has not been selected.";
        // Imagen no controlada:
        public const string INVALID_IMAGE = "Image not controlled by the application.";
        // Guardar o no texto descifrado:
        public const string SAVE_OR_PREVIEW = "You want to save the text or preview it?";
        // TextBox de entrada sin fichero vacía:
        public const string VOID_INPUT_TEXT_WITHOUT_FILE = "The text field is void.";
        // Aviso guardar texto descifrado:
        public const string SAVE_DECRYPT_TEXT = "The file with decrypt text has been saved in this folder.";
        // Aviso guardar imagen cifrada:
        public const string SAVE_ENCRYPT_IMAGE = "The image with encrypt text has been saved in this folder.";
        // Aviso problemas de lectura:
        public const string FILE_PROBLEMS = "Problems reading this information.";
        // Alerta de borrado de clave:
        public const string DELETE_KEY_ALERT = "Are you sure you want to destroy the key?";
        // Aviso problemas de borrado de clave:
        public const string DELETE_KEY_PROBLEMS = "Problems destroying this file.";
        // Aviso clave borrada correctamente:
        public const string DELETE_KEY_TRUE = "The key file has been destroyed.";
        // Stack trace Dictionary:
        public const string STACK_TRACE_DICTIONARY = "System.Collections.Generic.Dictionary";

        // Color formulario y controles
        public static Color CONTROLS_GENERAL_COLOR_ONE = Color.FromArgb(32, 32, 32);
        public static Color CONTROLS_GENERAL_COLOR_TWO = Color.FromArgb(25, 25, 25);
    }
}
