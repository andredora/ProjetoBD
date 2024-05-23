using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TrabalhoFinal
{
    public partial class Form1 : Form
    {
        private SqlConnection conn;
        public Form1()
        {
            InitializeComponent();
            checkDBConn();
            PreencherListBox2(GetArtigosPapelaria()); // Chama o método para preencher a ListBox ao iniciar o formulário
            PreencherListBox1(GetArtigosAcademico());
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            listBoxAA.SelectedIndexChanged += listBoxAA_SelectedIndexChanged;

        }

        private SqlConnection getSqlConn()
        {
            return new SqlConnection("data source = tcp:mednat.ieeta.pt\\SQLSERVER, 8101; Initial Catalog = p4g7; uid = p4g7; password = EuTuSQL19");
        }

        private bool checkDBConn()
        {
            if (conn == null)
                conn = getSqlConn();

            if (conn.State != ConnectionState.Open)
                conn.Open();

            return conn.State == ConnectionState.Open;
        }

        private List<string> GetArtigosPapelaria()
        {
            List<string> artigosPapelaria = new List<string>();

            try
            {
                using (SqlConnection conn = getSqlConn())
                {
                    conn.Open();
                    string query = "SELECT ID, Nome FROM Artigo_Papelaria";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Concatenar ID e Nome
                                string item = $"{reader["ID"]} - {reader["Nome"]}";
                                artigosPapelaria.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar artigos de papelaria: " + ex.Message);
            }

            return artigosPapelaria;
        }


        private List<string> PesquisarArtigosPapelaria(string nome)
        {
            List<string> artigosPapelaria = new List<string>();

            try
            {
                using (SqlConnection conn = getSqlConn())
                {
                    conn.Open();
                    string query = "SELECT ID, Nome FROM Artigo_Papelaria WHERE Nome LIKE @nome"; // Ajuste a query conforme sua necessidade

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Usando parâmetros para evitar SQL Injection
                        cmd.Parameters.AddWithValue("@nome", "%" + nome + "%");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Concatenar ID e Nome
                                string item = $"{reader["ID"]} - {reader["Nome"]}";
                                artigosPapelaria.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar artigos de papelaria: " + ex.Message);
            }

            return artigosPapelaria;
        }

        private void PreencherListBox2(List<string> artigosPapelaria)
        {
            listBox2.Items.Clear(); // Limpa os itens existentes

            foreach (string artigo in artigosPapelaria)
            {
                listBox2.Items.Add(artigo);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null)
                return;

            string selectedItem = listBox2.SelectedItem.ToString();
            string selectedId = selectedItem.Split('-')[0].Trim();

            // Limpa os Labels
            LabelMarcaAP.Text = string.Empty;
            LabelQuantidadeAP.Text = string.Empty;
            LabelEnderecoAP.Text = string.Empty;
            LabelTipoAP.Text = string.Empty;
            LabelCorAP.Text = string.Empty;
            LabelDurezaAP.Text = string.Empty;

            try
            {
                using (SqlConnection conn = getSqlConn())
                {
                    conn.Open();
                    string query = "SELECT Marca, Quantidade, End_Loja FROM Artigo_Papelaria WHERE ID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                LabelMarcaAP.Text = reader["Marca"].ToString();
                                LabelQuantidadeAP.Text = reader["Quantidade"].ToString();
                                LabelEnderecoAP.Text = reader["End_Loja"].ToString();
                            }
                        }
                    }

                    char thirdChar = selectedId.Length > 2 ? selectedId[2] : '\0';

                    if (thirdChar == 'C')
                    {
                        query = "SELECT Tipo, Cor FROM Caneta WHERE ID = @id";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", selectedId);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    LabelTipoAP.Text = reader["Tipo"].ToString();
                                    LabelCorAP.Text = reader["Cor"].ToString();
                                }
                            }
                        }
                    }
                    else if (thirdChar == 'L')
                    {
                        query = "SELECT Dureza FROM Lapis WHERE ID = @id";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", selectedId);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    LabelDurezaAP.Text = reader["Dureza"].ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar detalhes do artigo de papelaria: " + ex.Message);
            }
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
            PesquisarNomeAA.Clear(); // Limpa o texto na textBox PesquisarNome de artigo acadêmico

            FiltrarLojaAcademico.SelectedIndex = -1;
            FiltrarArtigoAcademico.SelectedIndex = -1;
            FiltarTipoAcademico.SelectedIndex = -1;
        }

        private void PreencherListBox1(List<string> artigosAcademico)
        {
            listBoxAA.Items.Clear(); // Limpa os itens existentes

            foreach (string artigo in artigosAcademico)
            {
                listBoxAA.Items.Add(artigo);
            }
        }

        private List<string> GetArtigosAcademico()
        {
            List<string> artigosAcademico = new List<string>();

            try
            {
                using (SqlConnection conn = getSqlConn())
                {
                    conn.Open();
                    string query = "SELECT ID, Nome FROM Artigo_Academico";

                    using (SqlCommand c = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = c.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Concatenar ID e Nome
                                string item = $"{reader["ID"]} - {reader["Nome"]}";
                                artigosAcademico.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar artigos de academico: " + ex.Message);
            }

            return artigosAcademico;
        }

        private List<string> PesquisarArtigosAcademico(string nome)
        {
            List<string> artigosAcademico = new List<string>();

            try
            {
                using (SqlConnection conn = getSqlConn())
                {
                    conn.Open();
                    string query = "SELECT ID, Nome FROM Artigo_Academico WHERE Nome LIKE @nome"; // Ajuste a query conforme sua necessidade

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Usando parâmetros para evitar SQL Injection
                        cmd.Parameters.AddWithValue("@nome", "%" + nome + "%");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Concatenar ID e Nome
                                string item = $"{reader["ID"]} - {reader["Nome"]}";
                                artigosAcademico.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar artigos de academico: " + ex.Message);
            }

            return artigosAcademico;
        }



        private void PesquisarAA_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            PesquisarNomePapelaria.Clear(); // Limpa o texto na TextBox1
            FiltrarLojaAP.SelectedIndex = -1; // Redefine a seleção na ComboBox1
            FiltrarArtigoPapelaria.SelectedIndex = -1; // Redefine a seleção na ComboBox2
            LabelCorAP.Text = string.Empty;
            LabelEnderecoAP.Text = string.Empty;
            LabelMarcaAP.Text = string.Empty;
            LabelQuantidadeAP.Text = string.Empty;
            LabelTipoAP.Text = string.Empty;
            LabelDurezaAP.Text = string.Empty;


            List<string> artigosPapelaria = GetArtigosPapelaria(); // Obtém todos os artigos de papelaria novamente
            PreencherListBox2(artigosPapelaria); // Atualiza a listBox2 com os artigos de papelaria
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            string nome = PesquisarNomePapelaria.Text;
            List<string> artigosPapelaria = PesquisarArtigosPapelaria(nome);
            PreencherListBox2(artigosPapelaria);
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
            string nome = PesquisarNomeAA.Text; // Assumindo que PesquisarNomeAA é o TextBox onde o nome é inserido
            List<string> resultados = PesquisarArtigosAcademico(nome);
            PreencherListBox1(resultados); // Atualiza a ListBox com os resultados da pesquisa

        }

        private void PesquisarNomeTraje_TextChanged(object sender, EventArgs e)
        {

        }

        private void LimparTraje_Click(object sender, EventArgs e)
        {
            PesquisarNomeTraje.Clear(); // Limpa o texto na TextBox1
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void FiltrarLojaAP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FiltrarLojaAcademico_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelEnderecoAA_Click(object sender, EventArgs e)
        {

        }

        private void listBoxAA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAA.SelectedItem == null)
                return;

            string selectedItemAA = listBoxAA.SelectedItem.ToString();
            string selectedIdAA = selectedItemAA.Split('-')[0].Trim();

            // Limpa os Labels
            labelNomeAA.Text = string.Empty;
            labelQuantidadeAA.Text = string.Empty;
            labelEnderecoAA.Text = string.Empty;
            labelTipoAA.Text = string.Empty;
            labelCor1AA.Text = string.Empty;
            labelCor2AA.Text = string.Empty;
            labelFormaAA.Text = string.Empty;
            labelUniversidadeAA.Text = string.Empty;

            try
            {
                using (SqlConnection conn = getSqlConn())
                {
                    conn.Open();
                    string query = "SELECT Nome, Quantidade, End_Loja FROM Artigo_Academico WHERE ID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedIdAA);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                labelNomeAA.Text = reader["Nome"].ToString();
                                labelQuantidadeAA.Text = reader["Quantidade"].ToString();
                                labelEnderecoAA.Text = reader["End_Loja"].ToString();
                            }
                        }
                    }

                    char thirdChar = selectedIdAA.Length > 2 ? selectedIdAA[2] : '\0';

                    if (thirdChar == 'E')
                    {
                        query = "SELECT Forma, Tipo FROM Emblemas WHERE ID = @id";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", selectedIdAA);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    labelFormaAA.Text = reader["Forma"].ToString();
                                    labelTipoAA.Text = reader["Tipo"].ToString();
                                }
                            }
                        }
                    }
                    else if (thirdChar == 'P')
                    {
                        query = "SELECT Tipo FROM Pins WHERE ID = @id";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", selectedIdAA);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    labelTipoAA.Text = reader["Tipo"].ToString();
                                }
                            }
                        }
                    }
                    else if (thirdChar == 'T')
                    {
                        query = "SELECT Tipo FROM Pastas WHERE ID = @id";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", selectedIdAA);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    labelTipoAA.Text = reader["Tipo"].ToString();
                                }
                            }
                        }
                    }
                    else if (thirdChar == 'C')
                    {
                        query = "SELECT Universidade FROM Chapeus WHERE ID = @id";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", selectedIdAA);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    labelUniversidadeAA.Text = reader["Universidade"].ToString();
                                }
                            }
                        }
                    }
                    else if (thirdChar == 'N')
                    {
                        query = "SELECT Tipo, Cor1, Cor2 FROM Nos WHERE ID = @id";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", selectedIdAA);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    labelTipoAA.Text = reader["Tipo"].ToString();
                                    labelCor1AA.Text = reader["Cor1"].ToString();
                                    labelCor2AA.Text = reader["Cor2"].ToString();

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar detalhes do artigo de papelaria: " + ex.Message);
            }
        }

        private void labelNomeAA_Click(object sender, EventArgs e)
        {

        }
    }
}
