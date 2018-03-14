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


namespace Practica_Bits_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            FileStream archivo = new FileStream(openFileDialog1.FileName, FileMode.Open);
            BinaryReader br = new BinaryReader(archivo);
            char c1 = br.ReadChar();
            char c2 = br.ReadChar();
            if (c1 == 'B' && c2 == 'M')
            {
                //si es BMP
                int tam = br.ReadInt32();     //son 4 bites  4 bits
                br.ReadInt64();               //son 64 bites 8 bits
                br.ReadInt32();
                archivo.Seek(12, SeekOrigin.Current);

                int ancho = br.ReadInt32();
                int alto = br.ReadInt32();
                archivo.Seek(28, SeekOrigin.Current);
                br.ReadInt16();
                Int16 bitsxpicel;
                bitsxpicel = br.ReadInt16();
            }

            br.Close();
        }
        
    }
}

