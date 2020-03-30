using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace CipherMethods
{
    public class Route
    {
        int m { get; set; }
        int n { get; set; }
        string text { get; set; }
        string fileName { get; set; }

        char[,] matrix; 

        public Route(int m, int n, string text, string fileName) {
            this.m = m;
            this.n = n;            
            this.fileName = fileName; 
            matrix = new char[m, n];

            //eliminar el caracter \r\n que agrega el stringbuilder al final de todo el texto
            text = text.Remove(text.Length - 1);
            text = text.Remove(text.Length - 1);
            this.text = text;
        }

        public void vertical() {
            //fill matrix
            int cont = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (cont != text.Length)
                        matrix[j, i] = text[cont];
                    else
                        matrix[j, i] = '#';

                    cont++;
                }
            }

            string outPut = "";
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    outPut += matrix[i, j];
                }
            }

            //escribir archivo 
            string folder = @"C:\Cipher\";
            string fullPath = folder + fileName;
            // crear el directorio
            DirectoryInfo directory = Directory.CreateDirectory(folder);

            using (StreamWriter file = new StreamWriter(fullPath))
            {
                file.WriteLine(outPut);
                file.Close();
            }
        }

        public void decipherVertical() {
            int cont = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = text[cont];
                    cont++;
                }
            }

            string outPut = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    outPut += matrix[j, i];
                }
            }

            outPut = outPut.Replace('#', ' ');

            //escribir archivo 
            string folder = @"C:\Cipher\";
            string fullPath = folder + fileName;
            // crear el directorio
            DirectoryInfo directory = Directory.CreateDirectory(folder);

            using (StreamWriter file = new StreamWriter(fullPath))
            {
                file.WriteLine(outPut);
                file.Close();
            }
        }

        public void spiral() { }
    }
}
