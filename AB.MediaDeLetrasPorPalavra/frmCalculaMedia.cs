using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AB.MediaDeLetrasPorPalavra
{
    public partial class frmCalculaMedia : Form
    {
        public frmCalculaMedia()
        {
            InitializeComponent();
        }

        private void frmCalculaMedia_Load(object sender, EventArgs e)
        {
            lblResult.Text = string.Empty;
        }

        private static int GetMedia(List<Texto> lstPalavras)
        {
            var totMedia = 0;

            foreach (var item in lstPalavras)
            {
                totMedia += item.TotLetras;
            }

            return totMedia / lstPalavras.Count;

        }

        public static List<Texto> CarregaLista(string texto)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            string[] palavras = texto.Split(delimiterChars);

            var lstTexto = new List<Texto>();

            foreach (var item in palavras)
            {
                lstTexto.AddRange(new[] { new Texto(item.Length, item) });
            }

            return lstTexto;

        }

        private void txtCalcular_Click(object sender, EventArgs e)
        {
            lblResult.Text = $"Média de letras por palavra = " + GetMedia(CarregaLista(txtParametro.Text));
        }

        private void txtLimpar_Click(object sender, EventArgs e)
        {
            txtParametro.Text = string.Empty;
            lblResult.Text = string.Empty;

        }

        #region "Classe responsável pelo Texto"
        public class Texto
        {
            public int TotLetras { get; set; }
            public string Palavra { get; set; } = string.Empty;
            public Texto() { }

            public Texto(int totLetras, string palavra)
            {
                TotLetras = totLetras;
                Palavra = palavra;
            }

        }

        #endregion

    }
}
