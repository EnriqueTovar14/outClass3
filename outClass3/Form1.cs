using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Enrique Tovar
namespace outClass3
{
    public partial class Form1 : Form
    {
        public static System.IO.StreamWriter sw;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sw = System.IO.File.CreateText("Sample.dat");
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);

                //Find longest words

                string longestWord = "";
                string firstAlpha = "";
                string allText = sr.ReadToEnd();
                string[] words = allText.Split();

                for (int i = 0; i < words.Length; i++)
                {
                    words[i] = words[i].ToLower();

                    if (i == 0)
                    {
                        longestWord = words[i]; firstAlpha = words[i];
                    }
                    if (longestWord.Length < words[i].Length)
                    {
                        longestWord = words[i];
                    }
                    this.richTextBox1.Text += words[i] + "\n";
                }
                this.richTextBox1.Text += "\n" + "\nThe longest word is: " + longestWord;

                //Find first and last words

                string alphaFirst = "";
                string alphaLast = "";

                for (int i = 0; i < words.Length; i++)
                {
                    if (i == 0)
                    {
                        alphaFirst = words[i];
                        alphaLast = words[i];
                    }
                    if (alphaFirst.CompareTo(words[i]) > 0 && words[i].Length > 0)
                    {
                        alphaFirst = words[i];
                    }
                    else if (alphaLast.CompareTo(words[i]) < 0)
                    {
                        alphaLast = words[i];
                    }
                }
                this.richTextBox1.Text += "\n" + "The first word is: " + alphaFirst + "\n" + "The last word is: " + alphaLast;

                //Find word with most vowels

                int count = 0;
                int countMost = 0;
                string mostVowel = "";

                for (int i = 0; i < words.Length; i++)
                {
                    string textWord = words[i];

                    for (int v = 0; v < textWord.Length; v++)
                    {
                        if (textWord[v] == 'a' || textWord[v] == 'e' || textWord[v] == 'i' || textWord[v] == 'o' || textWord[v] == 'u')
                        {
                            count++;
                        }
                    }
                    if (count > countMost)
                    {
                        countMost = count;
                        mostVowel = textWord;
                    }
                    count = 0;
                }
                richTextBox1.Text += "\n" + "The word with the most vowels is: " + mostVowel;
            }
            sw.Close();
        }

        private object tolower(object p)
        {
            throw new NotImplementedException();
        }
    }
}
