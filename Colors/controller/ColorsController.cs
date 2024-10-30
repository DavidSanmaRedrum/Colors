using Colors.util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using Colors.model;

namespace Colors.controller {
    class ColorsController {
        private static int nColorsQuantityInKey = -1;
        private static int letterColorsQuantity = 0;
        private static string textDataWithoutFile = "";
        private static Icon icon;
        private static Dictionary<char, string[]> mapListEncryptKeyValues = new Dictionary<char, string[]>();
        private static Dictionary<string, char> mapListDecryptKeyValues = new Dictionary<string, char>();

        public static bool keyFileExists() {
            return File.Exists(Constants.KEY_IN_CURRENT_DIR);
        }

        public static void createKeyFile(int nColorsByCharacter) {
            string keyPath = Constants.KEY_IN_CURRENT_DIR;
            string colorsSeparator;
            string fileData = "";
            string colorsLine;
            int positionCounter = 0;
            try {
                HashSet<string> colorValues = new HashSet<string>(1); // HashSet no acepta valores repetidos.
                Random argbRandom = new Random();
                string argbSeparator = Constants.KEY_VALUE_COLOR_ARGB_SEPARATOR + "";
                while (colorValues.Count < (Constants.CHARACTERS.Length * nColorsByCharacter)) // Carácteres (Filas)
                {
                    for (int i = 0; i < nColorsByCharacter; i++) { // Colores por carácter (Columnas)
                        // Rango de 0 a 255
                        int alpha = argbRandom.Next(0, Constants.MAX_LIMIT_ARGB + 1);
                        int red = argbRandom.Next(0, Constants.MAX_LIMIT_ARGB + 1);
                        int green = argbRandom.Next(0, Constants.MAX_LIMIT_ARGB + 1);
                        int blue = argbRandom.Next(0, Constants.MAX_LIMIT_ARGB + 1);
                        string color = alpha + argbSeparator + red + argbSeparator + green + argbSeparator + blue;
                        colorValues.Add(color);
                    }
                }
                string[] colorValuesArr = colorValues.ToArray(); // Lo traducimos a array para hacer más sencillo el proceso.
                for (int i = 0; i < Constants.CHARACTERS.Length; i++) { // Letra
                    colorsLine = "";
                    colorsSeparator = Constants.KEY_VALUE_COLOR_SEPARATOR + "";
                    for (int j = 0; j < nColorsByCharacter; j++) { // número de colores por carácter.
                        string value = colorValuesArr[positionCounter];
                        if (j == nColorsByCharacter - 1) colorsSeparator = "";
                        colorsLine += value + colorsSeparator;
                        positionCounter++;
                    }
                    fileData += Constants.CHARACTERS[i].ToString() + Constants.KEY_VALUE_SQUARE + colorsLine + Constants.KEY_VALUE_COLOR_SEPARATOR + "\n";
                }
                File.WriteAllText(keyPath, fileData);
            } catch (Exception e) {
                e.ToString(); // No debe caer nunca en la excepción.
            }
        }

        public static string isKeyFileFormatCorrect() {
            int nColorsQuantity = -1;
            string line;
            int nLine = 1;
            string allColors = "";
            string currentKey = "";
            try {
                StreamReader sr = new StreamReader(Constants.KEY_IN_CURRENT_DIR);
                while (null != (line = sr.ReadLine())) {
                    if (nLine == 1) {
                        nColorsQuantity = line.Split(new char[] { Constants.KEY_VALUE_COLOR_SEPARATOR }).Length - 1;
                        nColorsQuantityInKey = nColorsQuantity;
                    }
                    int currentNColorsQuantity = line.Split(new char[] { Constants.KEY_VALUE_COLOR_SEPARATOR }).Length - 1;
                    if (Regex.IsMatch(line, "^.{1}[■]([0-9]{1,3}[≡]{1}[0-9]{1,3}[≡]{1}[0-9]{1,3}[≡]{1}[0-9]{1,3}[║]){" + nColorsQuantity + "}")) { // Control REGEX
                        // Control de número de colores por letra. (Lo pillará cuando la línea siguiente tenga más colores que la primera de todas).
                        // Si son menos lo pillará la regex, si son más, la regex la tomará como buena ignorando el color extra.
                        if (currentNColorsQuantity == nColorsQuantity) {
                            line = line.Substring(0, line.Length - 1); // Recortamos el último separador usado para la regex y para que no pete el programa en el split de abajo.
                            char letter = line[0];
                            line = line.Substring(2); // Recortamos el inicio, el caracter y el cuadrado.
                            string[] colors = line.Split(new char[] { Constants.KEY_VALUE_COLOR_SEPARATOR });

                            string[] argbValues = new string[colors.Length];
                            for (int i = 0; i < colors.Length; i++) { // Control ARGB
                                string[] argb = colors[i].Split(new char[] { Constants.KEY_VALUE_COLOR_ARGB_SEPARATOR });
                                if (Convert.ToInt16(argb[0]) > Constants.MAX_LIMIT_ARGB || // A
                                    Convert.ToInt16(argb[1]) > Constants.MAX_LIMIT_ARGB || // R
                                    Convert.ToInt16(argb[2]) > Constants.MAX_LIMIT_ARGB || // G
                                    Convert.ToInt16(argb[3]) > Constants.MAX_LIMIT_ARGB)    // B
                                {
                                    sr.Close();
                                    return Constants.ARGB_FAILURE + nLine;
                                }
                                argbValues[i] = argb[0] + Constants.KEY_VALUE_COMMA + argb[1] + Constants.KEY_VALUE_COMMA + argb[2] + Constants.KEY_VALUE_COMMA + argb[3]; // Adición del valor completo del color ARGB.
                                currentKey = argbValues[i];
                                mapListDecryptKeyValues.Add(currentKey, letter); // Mapa de desencriptar. (Le quitamos el contador)
                            }
                            currentKey = letter + "";
                            mapListEncryptKeyValues.Add(letter, argbValues); // Mapa de encriptar.
                            allColors += line + Constants.KEY_VALUE_COLOR_SEPARATOR; // Volvemos a añadir el último separador para juntar todo.
                        } else {
                            sr.Close();
                            return Constants.INCORRECT_NUMBER_OF_COLORS + nLine;
                        }
                    } else {
                        sr.Close();
                        return Constants.PATTERN_FAILURE + nLine;
                    }
                    nLine++;
                }
                sr.Close();
                return "";
            } catch (Exception e) { 
                if (e.StackTrace.Contains(Constants.STACK_TRACE_DICTIONARY)) { // La key se repite en uno de los mapas.
                    if (currentKey.Length > 1) return Constants.REPEAT_COLORS_KEY_FILE + currentKey;
                    return Constants.REPEAT_CHARS_KEY_FILE + currentKey;
                }
                return Constants.FILE_PROBLEMS;
            }
        }

        public static Bitmap encryptText(string textOfFile) {
            textOfFile = textOfFile.ToUpper(); // Traducción a mayúsculas de lo que lea en el fichero.
            // Si algún char no está contemplado dentro de characters no lo va a poner, en ese caso, se reducirá la longitud del texto, luego se compensará en los while con espacios.
            textOfFile = encryptOrDecryptTextOnly(textOfFile, letterColorsQuantity, true); // La key se sacará del número de colores que tenga asignado cada letra.
            int pixelCounter = 0;
            int width = -1;
            int height = -1;
            int i = 1;

            while (width == -1) {
                if (textOfFile.Length % i == 0 && i < textOfFile.Length && i > 2) {
                    width = i;
                } else if (i == textOfFile.Length) {
                    string characters = Constants.CHARACTERS;
                    textOfFile += characters[characters.IndexOf(Constants.SPACE) + letterColorsQuantity]; // Ciframos los espacios extra con la key.
                    i = 0;
                    width = -1;
                }
                i++;
            }
            i = 1;
            while (height == -1) {
                if (width * i == textOfFile.Length) height = i;
                i++;
            }

            Random randomPosition = new Random();
            Bitmap bitmap = new Bitmap(width, height);
            for (int nRow = 0; nRow < bitmap.Width; nRow++) {
                for (int nCol = 0; nCol < bitmap.Height; nCol++) {
                    string[] characterColors = mapListEncryptKeyValues[textOfFile[pixelCounter]]; // Obtener el valor/Color con la clave (la clave, es el char actual).
                    int[] currentColor = arrayStringToArrayInt(characterColors[randomPosition.Next(0, nColorsQuantityInKey)]
                        .Split(new char[] { Constants.KEY_VALUE_COMMA })); // Elección de color (Rango de 0 a nColorsQuantityInKey -> Posición 0 del array tenida en cuenta)
                    bitmap.SetPixel(nRow, nCol, Color.FromArgb(currentColor[0], currentColor[1], currentColor[2], currentColor[3]));
                    pixelCounter++;
                }
            }
            return bitmap;
        }

        public static string decryptImage(Bitmap image) {
            string output = "";
            string key = "";
            char comma = Constants.KEY_VALUE_COMMA;
            try {
                for (int nRow = 0; nRow < image.Width; nRow++) {
                    for (int nCol = 0; nCol < image.Height; nCol++) {
                        Color pixel = image.GetPixel(nRow, nCol);
                        MatchCollection matches = Regex.Matches(pixel.ToString(), Constants.ONLY_NUMBERS_REGEX);
                        key = matches[0].ToString() + comma + matches[1].ToString() + comma + matches[2].ToString() + comma + matches[3].ToString();
                        output += mapListDecryptKeyValues[key];
                        key = "";
                    }
                }
            } catch (KeyNotFoundException knfe) {
                knfe.ToString();
                return Constants.INVALID_IMAGE;
            } 
            return encryptOrDecryptTextOnly(output, letterColorsQuantity, false);
        }

        public static string getFileData(string path) {
            string line;
            string output = "";
            try {
                StreamReader sr = new StreamReader(path);
                while (null != (line = sr.ReadLine())) {
                    output += line + Constants.KEY_VALUE_LINE_FEED + "";
                }
                sr.Close();
                return output; // Pondrá un salto de línea extra. //output.Substring(0, output.Length - 1);
            } catch (Exception e) {
                return "";
            }
        }

        public static bool destroyKey() {
            string line;
            string output = "";
            string keyPath = Constants.KEY_IN_CURRENT_DIR;
            try {
                StreamReader sr = new StreamReader(keyPath);
                while (null != (line = sr.ReadLine())) {
                    output += line + Constants.DELETE_KEY_LINE_FEED + "";
                }
                sr.Close();
                StreamWriter sw = new StreamWriter(keyPath);
                string[] keyLines = output.Split(new char[] { Constants.DELETE_KEY_LINE_FEED });
                for (int i = 0; i < keyLines.Length; i ++) {
                    keyLines[i] = Regex.Replace(keyLines[i], Constants.DELETE_KEY_REGEX, Constants.HASHTAG);
                    sw.WriteLine(keyLines[i]);
                }
                sw.Close();
                return true;
            } catch (Exception e) {
                return false;
            }
        }

        private static string encryptOrDecryptTextOnly(string text, int key, bool mode) // César
        {
            string output = "";
            string characters = Constants.CHARACTERS;
            int charactersLength = characters.Length;
            int position;
            for (int i = 0; i < text.Length; i++) {
                for (int j = 0; j < charactersLength; j++) {
                    if (characters[j] == text[i] && mode) {
                        position = j + key;
                        if (position > charactersLength) position = Math.Abs(position - charactersLength);
                        output += characters[position];
                        j = charactersLength;
                    } else if (characters[j] == text[i]) {
                        position = j - key;
                        if (position < 0) position = (charactersLength - Math.Abs(position));
                        output += characters[position];
                        j = charactersLength;
                    }
                }
            }
            if (!mode) return output.Replace(Constants.KEY_VALUE_LINE_FEED, Constants.KEY_VALUE_LINE_FEED_TWO);
            return output;
        }

        private static int[] arrayStringToArrayInt(string[] arr) {
            int[] output = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++) {
                output[i] = Convert.ToInt16(arr[i]);
            }
            return output;
        }

        public static int callColorsMessageBox(int height, string title, string message, bool acceptAndCancel, bool preview) {
            ColorsMessageBox messageBox = new ColorsMessageBox(height, title, message, acceptAndCancel, preview, icon);
            return messageBox.show();
        }

        public static void setLetterColorsQuantity(int colorsQuantity) {
            letterColorsQuantity = colorsQuantity;
        }

        public static int getLetterColorsQuantity() {
            return letterColorsQuantity;
        }

        public static void setTextDataWithoutFile(string text) {
            textDataWithoutFile = text;
        }

        public static string getTextDataWithoutFile() {
            return textDataWithoutFile;
        }

        public static void setIcon(Icon iconImage) {
            icon = iconImage;
        }

    }
}
