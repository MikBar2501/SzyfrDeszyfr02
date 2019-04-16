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
        public string path;
        public string fileName;

        public SzyfrowanieDeszyfrowanie()
        {
            InitializeComponent();
        }

        private void BtnSzyfr_Click(object sender, EventArgs e)
        {
            SetNameAndPath(txtPath.Text,"zaszyfrowane");

            string hex;
            if(LoadAndHex(txtPath.Text, out hex))
            {
                string cypher = TrueEncryption(hex, "??");
                if(!SaveAndUnhex(cypher))
                {
                    MessageBox.Show("Błąd przy zapisie pliku", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Zaszyfrowano plik", "Zaszyfrowano", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Błąd przy szyfrowaniu pliku", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeszyfr_Click(object sender, EventArgs e)
        {
            SetNameAndPath(txtPath.Text,"odszyfrowane");

            string hex;
            if (LoadAndHex(txtPath.Text, out hex))
            {
                string text = TrueDecryption(hex, "??");
                if (!SaveAndUnhex(text))
                {
                    MessageBox.Show("Błąd przy zapisie pliku", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Odszyfrowano plik", "Odszyfrowano", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Błąd przy deszyfrowaniu pliku", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SetNameAndPath(string text, string add)
        {
            string[] pathOrginal = text.Split('\\');

            path = "";
            for (int i = 0; i < pathOrginal.Length - 1; i++)
            {
                path += pathOrginal[i] + "\\";
            }

            string[] nameOriginal = pathOrginal[pathOrginal.Length - 1].Split('.');
            nameOriginal[0] += " ";
            nameOriginal[0] += add;

            fileName = nameOriginal[0] + "." + nameOriginal[1];
        }


        string CreateKey(string preKey)
        {
            string key = "";
            CultureInfo culture = new CultureInfo("pl-PL");
            if (preKey.Length < 11)
            {
                int countTo11 = 11 - preKey.Length;
                for (int i = 0; i < countTo11; i++)
                {
                    preKey += "0";
                }

            }

            for (int i = 0; i < preKey.Length; i++)
            {
                string outHex = "0";
                int b = Convert.ToInt32(preKey[i], culture);
                string hex = b.ToString("x");
                if (hex.Length > 2)
                {
                    outHex = hex;
                }
                else
                {
                    outHex += hex;
                }
                key += outHex;
            }

            string lastKey = "";
            for (int i = 0; i < key.Length - 1; i++)
            {
                lastKey += key[i];
            }

            return lastKey;
        }

        string TrueEncryption(string hex, string key)
        {
            string cyther = "";

            return hex;
        }

        string TrueDecryption(string hex, string key)
        {
            string text = "";

            return hex;
        }

        public bool LoadAndHex(string file, out string outText) 
        {
            CultureInfo culture = new CultureInfo("pl-PL");
            try
            {
                string[] lines = File.ReadAllLines(file, Encoding.UTF8);
                outText = "";
                foreach (string line in lines)
                {
                    foreach (char sign in line)
                    {
                        string outHex = "00";
                        int b = Convert.ToInt32(sign, culture);
                        string hex = b.ToString("x");
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
                        else
                        {
                            outHex += hex;
                        }
                        outText += outHex;
                    }
                    outText += "0000";
                }
                //using (StreamWriter outputFile = new StreamWriter(path + fileName, false, Encoding.UTF8))
                //{
                //    outputFile.WriteLine(cypher);
                //    outputFile.Close();
                //}

                return true;
            }
            catch (FileNotFoundException exnotfound)
            {
                MessageBox.Show("Nie znaleziono ścieżki", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                outText = "";
                return false;
            }
        }

        public bool SaveAndUnhex(string hextext)
        {
            CultureInfo culture = new CultureInfo("pl-PL");
            try
            {
                //string[] lines = File.ReadAllLines(file, Encoding.UTF8);
                //outText = "";
                //foreach (string line in lines)
                //{
                //    outText += line;
                //}

                string outText = hextext;

                if (outText.Length % 4 != 0)
                {
                    return false;
                    //MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
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
                                string sign = "";
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
    }
}
