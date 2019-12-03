using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace SzyfrDeszyfr
{
    public partial class SzyfrowanieDeszyfrowanie : Form
    {

        //C:\Users\mikol\Desktop\PlikTestowy.txt
        //C:\Users\mikol\Desktop\TestFile.txt
        //C:\Users\mikol\Desktop\TestingFile.txt
        //C:\Users\mikol\Desktop\tescikDesz.txt
        //C:\Users\mikol\Desktop\tescikDesz — kopia - deszeszeszeszeszeszeszeszeszesze.txt
        public String path;
        public String fileName;

        public bool AES;
        public const int miniLength = 4;
        public const int AESLength = 32;
        String hex;

        public SzyfrowanieDeszyfrowanie()
        {
            InitializeComponent();
            //Test();
        }

        String GetKey()
        {
            return CreateKey(txtKey.Text);
        }

        private void BtnSzyfr_Click(object sender, EventArgs e)
        {
            if ((AES && txtKey.Text.Length == AESLength) || (!AES && txtKey.Text.Length == miniLength))
            {
                //SetNameAndPath(txtPath.Text, "zaszyfrowane");

                if (LoadAndHex(txtPath.Text, out hex))
                {
                    //Console.WriteLine(hex);

                    String cypher = TrueEncryption(hex, GetKey());
                    SetNameAndPath(txtPath.Text, "zaszyfrowane");
                    using (StreamWriter outputFile = new StreamWriter(path + fileName, false, Encoding.UTF8))
                    {
                        outputFile.WriteLine(cypher);
                        outputFile.Close();
                    }
                    /*if (!SaveAndUnhex(cypher))
                    {
                        MessageBox.Show("Błąd przy zapisie pliku", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }*/

                    MessageBox.Show("Zaszyfrowano plik", "Zaszyfrowano", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Błąd przy szyfrowaniu pliku", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nieprawidłowa ilość znaków w kluczu", "Błąd", MessageBoxButtons.OK);
            }
        }

        private void BtnDeszyfr_Click(object sender, EventArgs e)
        {
            if ((AES && txtKey.Text.Length == AESLength) || (!AES && txtKey.Text.Length == miniLength))
            {
                String[] lines = File.ReadAllLines(txtPath.Text, Encoding.UTF8);
                String hexToEncryption = "";
                foreach (String line in lines)
                {
                    hexToEncryption += line;
                }

                String text = TrueDecryption(hexToEncryption, GetKey());

                //if (SaveAndUnhex(txtPath.Text))
                if (SaveAndUnhex(text))
                {

                    /*if (!SaveAndUnhex(text))
                    {
                        MessageBox.Show("Błąd przy zapisie pliku", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }*/

                    MessageBox.Show("Odszyfrowano plik", "Odszyfrowano", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Błąd przy deszyfrowaniu pliku", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nieprawidłowa ilość znaków w kluczu", "Błąd", MessageBoxButtons.OK);
            }
        }

        public void SetNameAndPath(String text, String add)
        {
            String[] pathOrginal = text.Split('\\');

            path = "";
            for (int i = 0; i < pathOrginal.Length - 1; i++)
            {
                path += pathOrginal[i] + "\\";
            }

            String[] nameOriginal = pathOrginal[pathOrginal.Length - 1].Split('.');
            nameOriginal[0] += " ";
            nameOriginal[0] += add;

            fileName = nameOriginal[0] + "." + nameOriginal[1];
        }


        String CreateKey(String preKey)
        {
            String key = "";
            CultureInfo culture = new CultureInfo("pl-PL");

            for (int i = 0; i < preKey.Length; i++)
            {
                String outHex = "0";
                int b = Convert.ToInt32(preKey[i], culture);
                String hex = b.ToString("x");
                if (hex.Length > 2)
                {
                    outHex = hex;
                }
                else
                {
                    outHex += hex;
                }
                key += outHex[2];
            }
            return key;
        }

        String TrueEncryption(String hex, String key)
        {
            Cypher cypher = new Cypher();
            if (AES)
                return cypher.AESEncryption(hex, key);

            return cypher.MiniAESEncryption(hex, key);
        }

        String TrueDecryption(String hex, String key)
        {
            Cypher cypher = new Cypher();
            if (AES)
                return cypher.AESDecryption(hex, key);

            return cypher.MiniAESDecryption(hex, key);
        }

        public void Test()
        {
            //String test = "ąćżźęńó";

            //SaveTest(test);
            String test = LoadTest();

            for (int i = 0; i < test.Length; i++)
            {
                Char ch = test[i];
                String hex = HexChar(ch);
                //SaveTest(hex);
                //String loadedHex = LoadTest();
                Char afterCh = CharHex(hex);

                //Console.WriteLine(ch + " -> " + hex + " -> " + afterCh);
            }
        }

        public void SaveTest(String text)
        {
            //SetNameAndPath("");
            using (StreamWriter outputFile = new StreamWriter("C:\\Users\\Emejpi\\Desktop\\Char.txt", false, Encoding.UTF8))
            {
                outputFile.WriteLine(text);
                outputFile.Close();
            }
        }

        public String LoadTest()
        {
            String[] lines = File.ReadAllLines("C:\\Users\\Emejpi\\Desktop\\Char.txt", GetEncoding("C:\\Users\\Emejpi\\Desktop\\Char.txt"));
            return lines[0];
        }

        private static Encoding GetEncoding(string filename)
        {
            using (var reader = new StreamReader(filename, Encoding.Default, true))
            {
                if (reader.Peek() >= 0)
                    reader.Read();

                return reader.CurrentEncoding;
            }
        }

        public Char CharHex(String hex)
        {
            CultureInfo culture = new CultureInfo("pl-PL");

            int i = 0;
            String outText = hex;

            if (outText[i].Equals('0') && outText[i + 1].Equals('0') && outText[i + 2].Equals('0') && outText[i + 3].Equals('0'))
            {
                return '\n';
            }
            else
            {
                String sign = "";
                sign += outText[i];
                sign += outText[i + 1];
                sign += outText[i + 2];
                sign += outText[i + 3];
                int number = Int32.Parse(sign, System.Globalization.NumberStyles.HexNumber);
                return Convert.ToChar(number, culture);
            }
        }

        public String HexChar(Char sign)
        {
            CultureInfo culture = new CultureInfo("pl-PL");

            String outHex = "";
            int b = Convert.ToInt32(sign, culture);
            String hex = b.ToString("x");
            if (hex.Length > 4)
            {
                return "XXXX";
            }
            else if (hex.Length == 4)
            {
                outHex = hex;
            }
            else if (hex.Length == 3)
            {
                outHex = "0";
                outHex += hex;
            }
            else if (hex.Length == 2)
            {
                outHex = "00";
                outHex += hex;
            }
            else
            {
                outHex = "000";
                outHex += hex;
            }
            return outHex;
        }

        public bool LoadAndHex(String file, out String outText)
        {
            CultureInfo culture = new CultureInfo("pl-PL");
            try
            {
                String[] lines = File.ReadAllLines(file, GetEncoding(file));
                outText = "";
                foreach (String line in lines)
                {
                    foreach (Char sign in line)
                    {
                        String outHex = "";
                        int b = Convert.ToInt32(sign, culture);
                        String hex = b.ToString("x");
                        if (hex.Length > 4)
                        {
                            return false;
                        }
                        else if (hex.Length == 4)
                        {
                            outHex = hex;
                        }
                        else if (hex.Length == 3)
                        {
                            outHex = "0";
                            outHex += hex;
                        }
                        else if (hex.Length == 2)
                        {
                            outHex = "00";
                            outHex += hex;
                        }
                        else
                        {
                            outHex = "000";
                            outHex += hex;
                        }
                        outText += outHex;
                    }
                    outText += "0000";
                }


                return true;
            }
            catch (FileNotFoundException exnotfound)
            {
                MessageBox.Show("Nie znaleziono ścieżki", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                outText = "";
                return false;
            }
        }

        public bool SaveAndUnhex(String hextext)
        {
            CultureInfo culture = new CultureInfo("pl-PL");
            try
            {
                //String[] lines = File.ReadAllLines(file, Encoding.UTF8);
                //outText = "";
                //foreach (String line in lines)
                //{
                //    outText += line;
                //}

                String outText = hextext;

                if (outText.Length % 4 != 0)
                {
                    return false;
                    //MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SetNameAndPath(txtPath.Text, "odszyfrowane");
                    using (StreamWriter outputFile = new StreamWriter(path + fileName, false, Encoding.UTF8))
                    {
                        for (int i = 0; i < outText.Length; i += 4)
                        {
                            if (outText[i].Equals('0') && outText[i + 1].Equals('0') && outText[i + 2].Equals('0') && outText[i + 3].Equals('0'))
                            {
                                outputFile.WriteLine();
                            }
                            else
                            {
                                String sign = "";
                                sign += outText[i];
                                sign += outText[i + 1];
                                sign += outText[i + 2];
                                sign += outText[i + 3];
                                int hex = Int32.Parse(sign, System.Globalization.NumberStyles.HexNumber);
                                outputFile.Write(Convert.ToChar(hex, culture));
                            }
                        }
                        outputFile.Close();
                        return true;
                    }

                }
            }
            catch (FileNotFoundException exnotfound)
            {
                MessageBox.Show("Nie znaleziono ścieżki", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void RbAES_CheckedChanged(object sender, EventArgs e)
        {
            AES = true;
            txtKey.Text = "";
            txtKey.MaxLength = 32;
            btnDeszyfr.Enabled = true;
            btnSzyfr.Enabled = true;
        }

        private void RbMINIAES_CheckedChanged(object sender, EventArgs e)
        {
            AES = false;
            txtKey.Text = "";
            txtKey.MaxLength = 4;
            btnDeszyfr.Enabled = true;
            btnSzyfr.Enabled = true;
        }
    }
}
