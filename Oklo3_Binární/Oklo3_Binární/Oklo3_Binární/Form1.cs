using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oklo3_Binární
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream datovytok = new FileStream("texty.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(datovytok, Encoding.GetEncoding("windows-1250"));
            bw.Write("Ondřej Zelený zvedl 130 na Bench.");
            bw.Write("Což je dosti podobné váze Davida Suchého.");
            bw.Write("Nebo dokonce dvojnásobek váhy Kubího.");
            FileStream datovytok2 = new FileStream("textyverze2.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryReader ctenar = new BinaryReader(datovytok, Encoding.GetEncoding("windows-1250"));
            BinaryWriter zapisovac = new BinaryWriter(datovytok2, Encoding.GetEncoding("windows-1250"));
            ctenar.BaseStream.Position = 0;
            while (ctenar.BaseStream.Position < ctenar.BaseStream.Length)
            {
                string text = ctenar.ReadString();
                foreach (char znak in text)
                {
                    if (znak == '.')
                    {
                        text.Replace('.', '!');
                    }
                }
                zapisovac.Write(text);
            }
            datovytok.Close();
            datovytok2.Close();
            ctenar.Close();
            zapisovac.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            FileStream datovytok2 = new FileStream("textyverze2.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryReader ctenar = new BinaryReader(datovytok2, Encoding.GetEncoding("windows-1250"));
            ctenar.BaseStream.Position = 0;
            while (ctenar.BaseStream.Position < ctenar.BaseStream.Length)
            {
                listBox1.Items.Add(ctenar.ReadString());
            }
            datovytok2.Close();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {

        }
    }
}
