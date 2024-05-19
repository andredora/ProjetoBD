namespace TrabalhoFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PesquisarAA_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PesquisarNomeAA.Clear(); // Limpa o texto na textBox PesquisarNome de artigo académico

            FiltrarLojaAcademico.SelectedIndex = -1;
            FiltrarArtigoAcademico.SelectedIndex = -1;
            FiltarTipoAcademico.SelectedIndex = -1;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            PesquisarNomePapelaria.Clear(); // Limpa o texto na TextBox1

            FiltrarLojaPapelaria.SelectedIndex = -1; // Redefine a seleção na ComboBox1
            FiltrarArtigoPapelaria.SelectedIndex = -1; // Redefine a seleção na ComboBox2
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void FiltarTipoAcademico_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void PesquisarAA_Click_1(object sender, EventArgs e)
        {

        }
    }
}
