using GUIA_8.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIA_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Multa> multas = new List<Multa>();

        private void button1_Click(object sender, EventArgs e)
        {


            string path = "C:\\Users\\Usuario\\Desktop\\patente;importe.txt";

            string[] linias = File.ReadAllLines(path);

            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Archivos TXT|*.txt|todos los archivos|*.*";


            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string name = ofd.FileName;
                FileStream fs = null;
                StreamReader sr = null;

                try
                {
                    fs = new FileStream(name, FileMode.Open, FileAccess.Read);
                    sr = new StreamReader(fs);

                    sr.ReadLine();
                    while (sr.EndOfStream != true)
                    {
                        string cadena = sr.ReadLine().Trim();

                        Multa multa = new Multa();
                        multa.Importar(cadena);
                        multas.Add(multa);
                    }


                    foreach (Multa m in multas)
                    {
                       comboBox1.Items.Add(m.Cadena());
                    }
                }
                catch (PatenteExeption ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sr != null) sr.Close();
                    if (fs != null) fs.Close();
                }


                if (multas.Count != 0)
                {

                    foreach (string line in linias)
                    {
                        string[] s = line.Split(';');
                        textBox1.Text += s[0] + "-" + s[1] + "\r\n";

                    }
                }
                //comboBox1.SelectedIndex = 0;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivos TXT|*.txt|Todos los archivos|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string name = sfd.FileName;
                FileStream fs = null;
                StreamWriter sw = null;

                try
                {
                    fs = new FileStream(name, FileMode.OpenOrCreate, FileAccess.Write);
                    sw = new StreamWriter(fs);

                    foreach (Multa v in multas)
                    {
                        string cadena = v.Cadena();
                        sw.WriteLine(cadena);
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sw != null) sw.Close();
                    if (fs != null) fs.Close();
                }
            }
        }
    }
}
