using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.IO;

namespace CipherMethods
{
    public class Caesar
    {
        string keyWord { get; set; }
        List<char> newAlphabet = new List<char>();
        List<char> originalAlphabet = new List<char>();

        public Caesar(string word) {
            keyWord = word;
        }

        public void buildAlphabet() {
            List<byte> modified = new List<byte>();
            List<byte> original = new List<byte>();

            byte[] keyWrdByt = Encoding.ASCII.GetBytes(keyWord);
            modified.AddRange(keyWrdByt);

            for (int i = 97; i < 123; i++)
            {
                original.Add((byte)i);
                modified.Add((byte)i);
            }
           
            modified = modified.Distinct().ToList();

            for (int i = 0; i < original.Count; i++)
            {
                originalAlphabet.Add(Convert.ToChar(original[i]));
            }

            for (int i = 0; i < modified.Count; i++)
            {
                newAlphabet.Add(Convert.ToChar(modified[i]));
            }


        }

        private int searchInAlphabet(char character) {
            for (int i = 0; i < originalAlphabet.Count; i++)
            {
                if (character == originalAlphabet[i] || character == Char.ToUpper(originalAlphabet[i]))                
                    return i;                
            }
            return -1;
        }

        public void cipher(StringBuilder input, string fileName) {
            string encryptedText = "";
            string text = input.ToString();
            text = input.ToString();
            //eliminar el caracter \r\n que agrega el stringbuilder al final de todo el texto
            text = text.Remove(text.Length - 1);
            text = text.Remove(text.Length - 1);

            for (int i = 0; i < text.Length; i++)
            {
                if (searchInAlphabet(text[i]) == -1)
                {
                    encryptedText += text[i];
                }
                else
                {
                    encryptedText += newAlphabet[searchInAlphabet(text[i])];
                }
            }

            //escribir archivo 
            string folder = @"C:\Cipher\";
            string fullPath = folder + fileName;
            // crear el directorio
            DirectoryInfo directory = Directory.CreateDirectory(folder);

            using (StreamWriter file = new StreamWriter(fullPath))
            {
                file.WriteLine(encryptedText);
                file.Close();
            }
        }
    }
}
