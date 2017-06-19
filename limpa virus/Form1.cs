using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace limpa_virus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pic_status.BackgroundImage = limpa_virus.Properties.Resources.ok;
        }
        public string diretorio="vazio";
        
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd1 = new FolderBrowserDialog();
            fbd1.Description = "Selecione uma pasta para realizar o Backup";
            fbd1.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd1.ShowNewFolderButton = true;
            fbd1.ShowDialog();
            diretorio = fbd1.SelectedPath.ToString();
            txt_diretorio.Text = diretorio;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string teste = MessageBox.Show("Deseja limpar o vírus do Pendrive?", "Tem certeza?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation).ToString();
            
            if (teste != "OK") 
                return;

            if (diretorio != "vazio")
            {
                pic_status.BackgroundImage = limpa_virus.Properties.Resources.update;
                //Process.Start("attrib", "-h -r -s /s /d" + diretorio + "*. *");
                pic_status.BackgroundImage = limpa_virus.Properties.Resources.ok;
                MessageBox.Show("Seu Pendrive foi limpo", "Pronto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else 
            {
                pic_status.BackgroundImage = limpa_virus.Properties.Resources.erro;
                MessageBox.Show("Ocorreu um erro, verifique se você selecionou um Pendrive", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }

            string antigo = diretorio + ' ';
            string novo = diretorio + "arquivos";
            try
            {
                DirectoryInfo pasta = new DirectoryInfo(@diretorio);
                Directory.Move(antigo, novo);
            }
            catch 
            { 
            }
        }
    }
}
