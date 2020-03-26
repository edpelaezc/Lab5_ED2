using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CipherMethods
{
    public class ZigZag
    {
        string fileName { get; set; }
        int rails { get; set; }
        public void calculate(int rails, string text, string fileName) {
            this.fileName = fileName;
            this.rails = rails;
            int charQty = 1 + 1 + (2 * (rails - 2)); //cantidad de caracteres por ola 
            float unit = charQty / (charQty * charQty); //decimal correspondiente a un caracter
            float waves = text.Length / charQty;
            double rest = waves  - Math.Truncate(waves); //parte decimal de las olas 
            
            rest = 1 - rest; //completar 
            rest = rest / unit; //cantidad de caracteres especiales que hay que completar

            for (int i = 0; i < rest; i++)
            {
                text += "#"; //para completar la ola
            }

            fillMatrix(rails, text);

        }
        public void fillMatrix(int rails, string text) {
            string[,] matrix = new string[rails, text.Length];
            int cont = 0;
            while (cont != text.Length) //recorrer toda la cadena
            {                
                for (int j = 0; j < rails; j++)
                {
                    matrix[j, cont] = text[cont].ToString();
                    cont++;
                }

                for (int i = rails - 2; i > 0; i--)
                {
                    matrix[i, cont] = text[cont].ToString();
                    cont++;
                }
                                            
            }

            
        }

        public void cipher(string[,] matrix) {
            string encryptedText = "";
            string folder = @"C:\Cipher\";
            string fullPath = folder + fileName;

            for (int i = 0; i < rails; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    if (matrix[i, j] != "")
                    {
                        encryptedText += matrix[i, j];
                    }
                }
            }


        }
    }
}
