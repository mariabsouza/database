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

namespace database
{
    public partial class Form1 : Form
    {
        
        public void LoadFiles()

        {
            listBox1.Items.Clear();

            string strPath = @"E:\Code\Etec\P.A\C#\database\bin\Debug\netcoreapp3.1\files\";

            DirectoryInfo di = new DirectoryInfo(strPath);
            FileInfo[] files = di.GetFiles("*.txt");
            foreach (FileInfo file in files)
            {
                //MessageBox.Show(file.Name);
                listBox1.Items.Add(file.Name);
            }
        }

        public void SaveFiles ()
        {
            string fileName = textBox5.Text;
            richTextBox1.SaveFile(@"E:\Code\Etec\P.A\C#\database\bin\Debug\netcoreapp3.1\files\" + fileName + ".txt", RichTextBoxStreamType.PlainText);

            

        }

            public Form1()
        {
            InitializeComponent();
            //richTextBox1.LoadFile("agenda.cad", RichTextBoxStreamType.PlainText);
            LoadFiles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Abrir    
            //richTextBox1.LoadFile("agenda.cad", RichTextBoxStreamType.PlainText);
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Não foi selecionado nenhum arquivo. Favor selecionar e tentar novamente");
            }
            else
            {
                richTextBox1.LoadFile(@"E:\Code\Etec\P.A\C#\database\bin\Debug\netcoreapp3.1\files\" + listBox1.SelectedItem.ToString(), RichTextBoxStreamType.PlainText);
                string selectedFile = listBox1.SelectedItem.ToString();
                textBox5.Text = selectedFile.Remove(selectedFile.Length-4);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Salvar          
            //richTextBox1.SaveFile("agenda.cad", RichTextBoxStreamType.PlainText);
            SaveFiles();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Limpar
            richTextBox1.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //add + salvar + limpar os textbox

            richTextBox1.Text += textBox1.Text + " | " + textBox2.Text + " | " + textBox3.Text + "\n";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            string fileName = textBox5.Text;
            //richTextBox1.SaveFile(@"E:\Code\Etec\P.A\C#\database\bin\Debug\netcoreapp3.1\files\" + fileName.Remove(fileName.Length-4) + ".txt", RichTextBoxStreamType.PlainText);
            //richTextBox1.SaveFile("agenda.cad", RichTextBoxStreamType.PlainText);
            SaveFiles();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int consulta = int.Parse(textBox4.Text);

            //string[] linhas = richTextBox1.Text.Split("\n");
            //string[] dado = linhas[consulta].Split(" | ");

            string linhaInteira = richTextBox1.Lines[consulta];
            string[] dado = linhaInteira.Split(" | ");

            textBox1.Text = dado[0];
            textBox2.Text = dado[1];
            textBox3.Text = dado[2];
        }
    }
}
