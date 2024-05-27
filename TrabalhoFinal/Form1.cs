using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;
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
            PreencherlistBoxTrajes(GetTraje());
            PreencherPecasDoTraje(GetPecasDoTraje());


            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            listBoxAA.SelectedIndexChanged += listBoxAA_SelectedIndexChanged;

            // Adicione estas linhas
            List<string> lojasAcademico = GetLojasAcademico();
            List<string> lojasPapelaria = GetLojasPapelaria();
            PreencherComboBoxLojasAcademico(lojasAcademico);
            PreencherComboBoxLojasPapelaria(lojasPapelaria);

            // PREencher as cenas dos filtros confia
            PreencherFiltrarArtigoAcademico();
            PreencherFiltrarArtigoPapelaria();
            FiltarTipoAcademico.Enabled = false;
            NumeroItemsTraje.Text = $"0";

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
                    string query = "GetArtigosPapelaria";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
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
        private List<string> GetPecasDoTraje()
        {
            List<string> pecasTraje = new List<string>();

            try
            {
                using (SqlConnection conn = getSqlConn())
                {
                    conn.Open();
                    string query = "GetPecasDoTraje";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string item = $"{reader["ID"]} - {reader["Nome"]} ({reader["Tamanho"]})";
                                pecasTraje.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar peças do traje: " + ex.Message);
            }

            return pecasTraje;
        }

        private List<string> PesquisarArtigosPapelaria(string nome)
        {
            List<string> artigosPapelaria = new List<string>();

            try
            {
                using (SqlConnection conn = getSqlConn())
                {
                    conn.Open();
                    string query = "PesquisarArtigosPapelaria";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nome", nome);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
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

        private void PreencherPecasDoTraje(List<String> pecasDoTraje)
        {
            listBox3.Items.Clear(); // Limpa os itens existentes

            foreach (string artigo in pecasDoTraje)
            {
                listBox3.Items.Add(artigo);
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
                    string query = "GetArtigoPapelariaDetalhes";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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
                        query = "GetCanetaDetalhes";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
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
                        query = "GetLapisDetalhes";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
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
            SetLabelColor(LabelMarcaAP);
            SetLabelColor(LabelQuantidadeAP);
            SetLabelColor(LabelEnderecoAP);
            SetLabelColor(LabelTipoAP);
            SetLabelColor(LabelCorAP);
            SetLabelColor(LabelDurezaAP);

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void PreencherFiltrarArtigoAcademico()
        {
            List<string> artigos = ["Chapéus", "Emblemas", "Nós", "Pastas", "Pins"];
            foreach (string artigo in artigos)
            {
                FiltrarArtigoAcademico.Items.Add(artigo);
            }
        }

        private void PreencherFiltrarArtigoPapelaria()
        {
            List<string> artigos = ["Caneta", "Lápis"];
            foreach (string artigo in artigos)
            {
                FiltrarArtigoPapelaria.Items.Add(artigo);
            }

        }


        private void FiltrarArtigoAcademico_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltarTipoAcademicoMudarLista();
        }

        private void FiltarTipoAcademicoMudarLista()
        {
            // Obtem o item selecionado no ComboBox FiltrarArtigoAcademico
            string selecionado = FiltrarArtigoAcademico.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selecionado))
            {
                FiltarTipoAcademico.Enabled = false;
                FiltarTipoAcademico.Items.Clear();
                return;
            }

            List<string> itens = null;
            List<string> items = null;


            switch (selecionado)
            {
                case "Nós":
                    FiltarTipoAcademico.SelectedIndex = -1;
                    itens = new List<string> { "Azelha", "Coxim Redondo" };
                    selecionado = "NoA";
                    break;
                case "Emblemas":
                    FiltarTipoAcademico.SelectedIndex = -1;
                    itens = new List<string>
            {
                "AAUAv", "Animais", "Cidades", "Clash Royale", "Comida",
                "Cursos", "Familia", "Harry Potter", "Países e Regiões",
                "Séries", "Signos", "Super Heróis", "Universidades"
            };
                    selecionado = "Emblema";

                    break;
                case "Pins":
                    FiltarTipoAcademico.SelectedIndex = -1;
                    itens = new List<string> { "Alfinete", "Tacha" };
                    selecionado = "Pin";
                    break;
                case "Pastas":
                    selecionado = "Pasta";
                    break;
                case "Chapéus":
                    selecionado = "Chapeu";
                    break;
                default:
                    FiltarTipoAcademico.SelectedIndex = -1;
                    FiltarTipoAcademico.Enabled = false;
                    FiltarTipoAcademico.Items.Clear();
                    return;
            }

            // Preenche o ComboBox FiltarTipoAcademico com os itens correspondentes

            FiltarTipoAcademico.DataSource = itens;

            items = GetItensPorTipo(selecionado);

            // Ativa o ComboBox FiltarTipoAcademico
            FiltarTipoAcademico.Enabled = true;
            if (itens == null)
            {
                FiltarTipoAcademico.Enabled = false;
            }
            listBoxAA.Items.Clear();
            foreach (string item in items)
            {
                listBoxAA.Items.Add(item);
            }

        }


        private List<string> GetItensPorTipo(string tipo)
        {
            List<string> itens = new List<string>();

            try
            {
                using (SqlConnection conn = getSqlConn())
                {
                    conn.Open();
                    // Lista de tabelas válidas
                    List<string> validTables = new List<string> { "NoA", "Emblema", "Pin", "Pasta", "Chapeu" };

                    if (!validTables.Contains(tipo))
                    {
                        throw new ArgumentException("Tipo inválido.");
                    }

                    // Query SQL construída dinamicamente para fazer a junção
                    string query = $@"
                SELECT {tipo}.ID, artigo_academico.Nome
                FROM {tipo}
                INNER JOIN artigo_academico ON {tipo}.ID = artigo_academico.ID;
            ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string item = $"{reader["ID"]} - {reader["Nome"]}";
                                itens.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar itens por tipo: " + ex.Message);
            }

            return itens;
        }







        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void PesquisarAA_Click(object sender, EventArgs e)
        {

        }

        private void LimparButtonAA_Click(object sender, EventArgs e)
        {
            PesquisarNomeAA.Clear(); // Limpa o texto na textBox PesquisarNome de artigo acadêmico
            labelNomeAA.Text = string.Empty;
            labelQuantidadeAA.Text = string.Empty;
            labelEnderecoAA.Text = string.Empty;
            labelTipoAA.Text = string.Empty;
            labelCor1AA.Text = string.Empty;
            labelCor2AA.Text = string.Empty;
            labelFormaAA.Text = string.Empty;
            labelUniversidadeAA.Text = string.Empty;
            FiltrarLojaAcademico.SelectedIndex = -1;
            FiltrarArtigoAcademico.SelectedIndex = -1;
            FiltrarArtigoAcademico.Text = string.Empty;
            FiltarTipoAcademico.Enabled = false;
            FiltarTipoAcademico.SelectedIndex = -1;
            FiltarTipoAcademico.Text = string.Empty;
            List<string> artigosAcademico = GetArtigosAcademico(); // Obtém todos os artigos de academico novamente
            PreencherListBox1(artigosAcademico); // Atualiza a listBox1 com os artigos de academico
        }

        private void PreencherListBox1(List<string> artigosAcademico)
        {
            listBoxAA.Items.Clear(); // Limpa os itens existentes

            foreach (string artigo in artigosAcademico)
            {
                listBoxAA.Items.Add(artigo);
            }
        }

        private void PreencherlistBoxTrajes(List<string> Trajes)
        {
            listBoxTrajes.Items.Clear(); // Limpa os itens existentes

            foreach (string traje in Trajes)
            {
                listBoxTrajes.Items.Add(traje);
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
                    string query = "GetArtigosAcademico";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string item = $"{reader["ID"]} - {reader["Nome"]}";
                                artigosAcademico.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar artigos acadêmicos: " + ex.Message);
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
                    string query = "PesquisarArtigosAcademico";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nome", nome);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string item = $"{reader["ID"]} - {reader["Nome"]}";
                                artigosAcademico.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar artigos acadêmicos: " + ex.Message);
            }

            return artigosAcademico;
        }



        private void PesquisarAA_TextChanged(object sender, EventArgs e)
        {

        }

        private void RemoverButtonAA_Click_1(object sender, EventArgs e)
        {
            if (listBoxAA.SelectedItem != null)
            {
                string selectedItem = listBoxAA.SelectedItem.ToString();
                string selectedId = selectedItem.Split('-')[0].Trim();

                // Chama a stored procedure para deletar o artigo
                DeleteArtigo(selectedId);
                PreencherListBox1(GetArtigosAcademico());
                listBoxItems.Items.Clear();

            }
            else
            {
                MessageBox.Show("Por favor, selecione um item.");
            }
        }

        private void DeleteArtigo(string idArtigo)
        {

            using (SqlConnection conn = getSqlConn())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DeleteArtigo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDARTIGO", idArtigo);

                    cmd.ExecuteNonQuery();

                    // Exibe a mensagem de sucesso
                    MessageBox.Show("Artigo removido com sucesso!");
                }
            }
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LimparButtonAP_Click(object sender, EventArgs e)
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

        private void PesquisarButtonAP_Click_1(object sender, EventArgs e)
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

        private void AlterarButtonAP_Click(object sender, EventArgs e)
        {

        }

        private void PesquisarAA_Click_1(object sender, EventArgs e)
        {

            string nome = PesquisarNomeAA.Text;
            List<string> artigosAcademico = PesquisarArtigosAcademico(nome);
            PreencherListBox1(artigosAcademico);
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
            // Obtem a loja selecionada
            if (FiltrarLojaAP.SelectedItem == null)
            {
                return; // Se nada estiver selecionado, não faça nada
            }
            string lojaSelecionada = FiltrarLojaAP.SelectedItem.ToString();
            List<string> artigosAcademico = new List<string>();
            try
            {
                using (SqlConnection conn = getSqlConn())
                {
                    conn.Open();
                    string query = "GetPapelariaPorLoja"; // Nome da stored procedure
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@EnderecoLoja", lojaSelecionada);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                string item = $"{reader["ID"]} - {reader["Nome"]}";
                                artigosAcademico.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar endereços das lojas acadêmicas: " + ex.Message);
            }


            PreencherListBox2(artigosAcademico);


        }

        private void FiltrarLojaAcademico_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtem a loja selecionada
            if (FiltrarLojaAcademico.SelectedItem == null)
            {
                return; // Se nada estiver selecionado, não faça nada
            }
            string lojaSelecionada = FiltrarLojaAcademico.SelectedItem.ToString();
            List<string> artigosAcademico = new List<string>();
            try
            {
                using (SqlConnection conn = getSqlConn())
                {
                    conn.Open();
                    string query = "GetArtigosPorLoja"; // Nome da stored procedure
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@EnderecoLoja", lojaSelecionada);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                string item = $"{reader["ID"]} - {reader["Nome"]}";
                                artigosAcademico.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar endereços das lojas acadêmicas: " + ex.Message);
            }


            PreencherListBox1(artigosAcademico);

        }

        private void labelEnderecoAA_Click(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedItem == null)
                return;


            string selectedItem = listBox3.SelectedItem.ToString();
            string selectedId = selectedItem.Split('-')[0].Trim();

            UniPT.Text = string.Empty;
            GeneroPT.Text = string.Empty;
            TamanhoPT.Text = string.Empty;
            LojaPT.Text = string.Empty;
            QuantPT.Text = string.Empty;
            NomePT.Text = string.Empty;

            try
            {
                using (SqlConnection conn = getSqlConn())
                {
                    conn.Open();
                    string query = "GetPecaDoTrajeDetalhes"; // Nome da stored procedure
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id", selectedId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                UniPT.Text = reader["Universidade"].ToString();
                                GeneroPT.Text = reader["Genero"].ToString();
                                TamanhoPT.Text = reader["Tamanho"].ToString();
                                LojaPT.Text = reader["End_Loja"].ToString();
                                QuantPT.Text = reader["Quantidade"].ToString();
                                NomePT.Text = reader["Nome"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar detalhes da peça: " + ex.Message);
            }



        }

        private void listBoxAA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAA.SelectedItem == null)
                return;

            string selectedItem = listBoxAA.SelectedItem.ToString();
            string selectedId = selectedItem.Split('-')[0].Trim();

            // Limpa os Labels
            labelNomeAA.Text = string.Empty;
            labelQuantidadeAA.Text = string.Empty;
            labelEnderecoAA.Text = string.Empty;
            labelFormaAA.Text = string.Empty;
            labelTipoAA.Text = string.Empty;
            labelUniversidadeAA.Text = string.Empty;
            labelCor1AA.Text = string.Empty;
            labelCor2AA.Text = string.Empty;

            try
            {
                using (SqlConnection conn = getSqlConn())
                {
                    conn.Open();

                    // Primeira parte: Obter detalhes básicos do artigo acadêmico
                    try
                    {
                        string query = "GetArtigoAcademicoDetalhes";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id", selectedId);

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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao buscar detalhes do artigo acadêmico (GetArtigoAcademicoDetalhes): " + ex.Message + "\nStackTrace: " + ex.StackTrace);
                        return;
                    }

                    char thirdChar = selectedId.Length > 2 ? selectedId[2] : '\0';

                    if (thirdChar == 'E')
                    {
                        try
                        {
                            string query = "GetEmblemaDetalhes";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@id", selectedId);

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
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao buscar detalhes do emblema: " + ex.Message);
                        }
                    }
                    else if (thirdChar == 'P')
                    {
                        try
                        {
                            string query = "GetPinDetalhes";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@id", selectedId);

                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        labelTipoAA.Text = reader["Tipo"].ToString();
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao buscar detalhes do pin: " + ex.Message);
                        }
                    }
                    else if (thirdChar == 'T')
                    {
                        try
                        {
                            string query = "GetPastaDetalhes";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@id", selectedId);

                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        labelUniversidadeAA.Text = reader["Universidade"].ToString();
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao buscar detalhes da pasta: " + ex.Message);
                        }
                    }
                    else if (thirdChar == 'C')
                    {
                        try
                        {
                            string query = "GetChapeuDetalhes";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@id", selectedId);

                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        labelUniversidadeAA.Text = reader["Universidade"].ToString();
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao buscar detalhes do chapéu: " + ex.Message);
                        }
                    }
                    else if (thirdChar == 'N')
                    {
                        try
                        {
                            string query = "GetNoDetalhes";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@id", selectedId);

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
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao buscar detalhes do nó: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message);
            }

            // Define a cor dos labels
            SetLabelColor(labelNomeAA);
            SetLabelColor(labelQuantidadeAA);
            SetLabelColor(labelEnderecoAA);
            SetLabelColor(labelFormaAA);
            SetLabelColor(labelTipoAA);
            SetLabelColor(labelUniversidadeAA);
            SetLabelColor(labelCor1AA);
            SetLabelColor(labelCor2AA);
        }

        private void SetLabelColor(Label label)
        {
            if (string.IsNullOrEmpty(label.Text))
            {
                label.BackColor = Color.Gainsboro;
            }
            else
            {
                label.BackColor = Color.LightSkyBlue;
            }
        }


        private void labelNomeAA_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private List<string> GetLojasAcademico()
        {
            List<string> lojasAcademico = new List<string>();

            try
            {
                using (SqlConnection conn = getSqlConn())
                {
                    conn.Open();
                    string query = "GetLojasAcademico"; // Nome da stored procedure

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lojasAcademico.Add(reader["End_Loja"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar endereços das lojas acadêmicas: " + ex.Message);
            }

            return lojasAcademico;
        }

        private List<string> GetLojasPapelaria()
        {
            List<string> LojasPapelaria = new List<string>();

            try
            {
                using (SqlConnection conn = getSqlConn())
                {
                    conn.Open();
                    string query = "GetLojasPapelaria"; // Nome da stored procedure

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LojasPapelaria.Add(reader["End_Loja"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar endereços das lojas com papelaria: " + ex.Message);
            }

            return LojasPapelaria;
        }
        private void PreencherComboBoxLojasAcademico(List<string> lojas)
        {
            FiltrarLojaAcademico.Items.Clear(); // Limpa os itens existentes

            foreach (string loja in lojas)
            {
                FiltrarLojaAcademico.Items.Add(loja);
            }
        }

        private void PreencherComboBoxLojasPapelaria(List<string> lojas)
        {
            FiltrarLojaAP.Items.Clear(); // Limpa os itens existentes

            foreach (string loja in lojas)
            {
                FiltrarLojaAP.Items.Add(loja);
            }
        }


        private void AlterarButtonAA_Click(object sender, EventArgs e)
        {

        }

        private void AdicionarButtonAA_Click(object sender, EventArgs e)
        {
            using (FormAdicionarAA form = new FormAdicionarAA())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {

                }
            }
            PreencherListBox1(GetArtigosAcademico());
        }
        private void AdicionarButtonAP_Click(object sender, EventArgs e)
        {
            using (FormAdicionarAP form = new FormAdicionarAP())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {

                }
            }
            PreencherListBox2(GetArtigosPapelaria());


        }

        private void RemoverButtonAP_Click(object sender, EventArgs e)
        {

        }




        private void AdicionarAoTrajebuttonAA_Click(object sender, EventArgs e)
        {
            if (listBoxAA.SelectedItem != null)
            {
                string selectedItem = listBoxAA.SelectedItem.ToString();
                string id_artigo = selectedItem.Split('-')[0].Trim();

                // Obter a lista de trajes
                List<string> trajes = GetTraje();

                // Mostrar o popup de seleção de traje
                FormSelecionarTraje popup = new FormSelecionarTraje(trajes);
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    string id_traje = popup.SelectedTrajeId;

                    // Chama a stored procedure para comprar o artigo
                    ComprarArtigo(id_artigo, id_traje);
                }
            }
            else
            {
                MessageBox.Show("Nenhum artigo selecionado!!");
            }
        }

        private void ComprarArtigo(string idArtigo, string idTraje)
        {

            using (SqlConnection conn = getSqlConn())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("ComprarArtigo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDARTIGO", idArtigo);
                    cmd.Parameters.AddWithValue("@IDTRAJE", idTraje);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        private void label68_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedItem != null)
            {
                string selectedItem = listBox3.SelectedItem.ToString();
                string id_peca = selectedItem.Split('-')[0].Trim();

                // Obter a lista de trajes
                List<string> trajes = GetTraje();

                // Mostrar o popup de seleção de traje
                FormSelecionarTraje popup = new FormSelecionarTraje(trajes);
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    string id_traje = popup.SelectedTrajeId;

                    // Chama a stored procedure para comprar a peça
                    ComprarPeca(id_peca, id_traje);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um item.");
            }
        }

        private void ComprarPeca(string idPeca, string idTraje)
        {

            using (SqlConnection conn = getSqlConn())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("ComprarPeca", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDPECA", idPeca);
                    cmd.Parameters.AddWithValue("@IDTRAJE", idTraje);

                    cmd.ExecuteNonQuery();
                }
            }
        }



        private List<string> GetTraje()
        {
            List<string> Trajes = new List<string>();

            try
            {
                using (SqlConnection conn = getSqlConn())
                {
                    conn.Open();
                    string query = "Select ID, Nome From Traje";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string item = $"{reader["ID"]} - {reader["Nome"]}";
                                Trajes.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar traje: " + ex.Message);
            }

            return Trajes;
        }
        private void listBoxTrajes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTrajes.SelectedItem == null)
                return;

            string selectedItem = listBoxTrajes.SelectedItem.ToString();
            string selectedId = selectedItem.Split('-')[0].Trim();

            preencherListBoxItemsDoTraje(selectedId);
        }

        private void preencherListBoxItemsDoTraje(string selectedId)
        {

            listBoxItems.Items.Clear();

            using (SqlConnection conn = getSqlConn())
            {
                conn.Open();
                string query = "GetItemsDoTraje";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", selectedId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Processar o primeiro conjunto de resultados
                        while (reader.Read())
                        {
                            string item = $"{reader["ID"]} - {reader["Nome"]}";
                            listBoxItems.Items.Add(item);
                        }

                        // Passar para o próximo conjunto de resultados
                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                string item = $"{reader["ID"]} - {reader["Nome"]}";
                                listBoxItems.Items.Add(item);
                            }
                        }
                    }
                }
            }
            NumeroItemsTraje.Text = $"{listBoxItems.Items.Count}";
        }

        private void NumeroItemsTraje_Click(object sender, EventArgs e)
        {

        }

        private void LimparTrajeB_Click(object sender, EventArgs e)
        {
            textBoxPesquisarTraje.Clear();
            listBoxItems.Items.Clear();
            listBoxTrajes.SelectedIndex = -1;
            NumeroItemsTraje.Text = $"0";
        }

        private void textBoxPesquisarTraje_TextChanged(object sender, EventArgs e)
        {

        }

        private void FiltrarArtigoPapelaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltarTipoPapelariaMudarLista();
        }

        private void FiltarTipoPapelariaMudarLista()
        {
            // Obtem o item selecionado no ComboBox FiltrarArtigoAcademico
            string selecionado = FiltrarArtigoPapelaria.SelectedItem?.ToString();

            List<string> items = null;

            switch (selecionado)
            {
                case "Caneta":
                    selecionado = "Caneta";
                    break;
                case "Lápis":
                    selecionado = "Lapis";
                    break;
                default:
                    return;
            }

            // Preenche o ComboBox FiltarTipoAcademico com os itens correspondentes
            items = GetPapelariaPorTipo(selecionado);
            // Ativa o ComboBox FiltarTipoAcademico
            FiltarTipoAcademico.Enabled = true;

            listBox2.Items.Clear();
            foreach (string item in items)
            {
                listBox2.Items.Add(item);
            }

        }
        private List<string> GetPapelariaPorTipo(string tipo)
        {
            List<string> itens = new List<string>();

            try
            {
                using (SqlConnection conn = getSqlConn())
                {
                    conn.Open();
                    // Lista de tabelas válidas
                    List<string> validTables = new List<string> { "Caneta", "Lapis" };

                    if (!validTables.Contains(tipo))
                    {
                        throw new ArgumentException("Tipo inválido.");
                    }

                    // Query SQL construída dinamicamente para fazer a junção
                    string query = $@"
                    SELECT {tipo}.ID, artigo_papelaria.Nome
                    FROM {tipo}
                    INNER JOIN artigo_papelaria ON {tipo}.ID = artigo_papelaria.ID;
            ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string item = $"{reader["ID"]} - {reader["Nome"]}";
                                itens.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar itens por tipo: " + ex.Message);
            }

            return itens;
        }

        private void BNovoTraje_Click(object sender, EventArgs e)
        {
            using (FormNovoTraje form = new FormNovoTraje())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string nomeTraje = form.NomeTraje;
                    AdicionarTraje(nomeTraje);
                }
            }
            PreencherlistBoxTrajes(GetTraje());
        }


        private void AdicionarTraje(string nome)
        {
            // Substitua pela sua lógica de inserção de dados, pode ser uma chamada ao procedimento armazenado.
            // Aqui está um exemplo usando ADO.NET para inserir o traje no banco de dados.
            // Coloque sua string de conexão aqui

            using (SqlConnection conn = getSqlConn())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("AddTraje", conn))
                {
                    string endereco = "Rachel Street, N.o 2, Aveiro";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@End_Loja", endereco); // Supondo que End_Loja é opcional ou passe o valor correto

                    cmd.ExecuteNonQuery();
                }
            }


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Verifica se há algum item selecionado no ListBox
            if (listBoxTrajes.SelectedItem != null)
            {
                // Captura o item selecionado e extrai o ID
                string selectedItem = listBoxTrajes.SelectedItem.ToString();
                string selectedId = selectedItem.Split('-')[0].Trim();

                // Exclui o traje com o ID selecionado do banco de dados
                DeleteTraje(selectedId);
            }
            else
            {
                MessageBox.Show("Por favor, selecione um traje para excluir.");
            }
            PreencherlistBoxTrajes(GetTraje());
            listBoxItems.Items.Clear();

        }

        private void DeleteTraje(string id)
        {
            using (SqlConnection conn = getSqlConn())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Traje WHERE ID = @ID", conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void BRemoverItem_Click(object sender, EventArgs e)
        {
            string idTraje = getIdTrajeNoItem();
             
            // Verifica se há algum item selecionado no ListBox
            if (listBoxItems.SelectedItem != null)
            {
                // Captura o item selecionado e extrai o ID
                string selectedItem = listBoxItems.SelectedItem.ToString();
                string selectedId = selectedItem.Split('-')[0].Trim();

                // Determina a tabela a ser utilizada com base no ID
                if (selectedId.StartsWith("PT"))
                {
                    // ID pertence à tabela peca_do_traje_comprada
                   DeleteItem("peca_do_traje_comprada", "ID_Peca", selectedId);
                }
                else if (selectedId.StartsWith("A"))
                {
                    // ID pertence à tabela artigo_academico_comprado
                    DeleteItem("artigo_academico_comprado", "ID_Artigo", selectedId);
                }
                else
                {
                    MessageBox.Show("Item não reconhecido.");
                    return;
                }

                // Remove o item do ListBox após a exclusão
                listBoxItems.Items.Remove(listBoxItems.SelectedItem);
            }
            else
            {
                MessageBox.Show("Por favor, selecione um item para excluir.");
            }
            preencherListBoxItemsDoTraje(idTraje);
        }

        private void DeleteItem(string tableName, string TipoID, string id)
        {

            using (SqlConnection conn = getSqlConn())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand($"DELETE FROM {tableName} WHERE {TipoID}=@ID", conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        private string getIdTrajeNoItem()
    {
        string selectedItem = listBoxItems.SelectedItem.ToString();
        string selectedId = selectedItem.Split('-')[0].Trim();

        string idTraje = null;


        using (SqlConnection conn = getSqlConn())
        {
            conn.Open();
            string query = "";

                // Determina a tabela e monta a query SQL
                if (selectedId.StartsWith("PT"))
                {
                    query = "SELECT ID_Traje FROM peca_do_traje_comprada WHERE ID_Peca = @ID";
                }
                else if (selectedId.StartsWith("A"))
                {
                    query = "SELECT ID_Traje FROM artigo_academico_comprado WHERE ID_Artigo = @ID";
                }

            // Executa a query SQL para obter o ID_Traje
            if (!string.IsNullOrEmpty(query))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", selectedId);
                    idTraje = cmd.ExecuteScalar()?.ToString();
                }
            }
        }

        return idTraje;
    }



    private void listBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

        


public partial class FormNovoTraje : Form
{
    public string NomeTraje { get; private set; }

    public FormNovoTraje()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.textBoxNome = new System.Windows.Forms.TextBox();
        this.labelNome = new System.Windows.Forms.Label();
        this.buttonConfirmar = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // textBoxNome
        // 
        this.textBoxNome.Location = new System.Drawing.Point(12, 26);
        this.textBoxNome.Name = "textBoxNome";
        this.textBoxNome.Size = new System.Drawing.Size(260, 20);
        this.textBoxNome.TabIndex = 0;
        // 
        // labelNome
        // 
        this.labelNome.Location = new System.Drawing.Point(96, 8);
        this.labelNome.Name = "textBoxNome";
        this.labelNome.Size = new System.Drawing.Size(260, 20);
        this.labelNome.TabIndex = 2;
        this.labelNome.Text = "Insira o seu nome:";
        // buttonConfirmar
        // 
        this.buttonConfirmar.Location = new System.Drawing.Point(105, 50);
        this.buttonConfirmar.Name = "buttonConfirmar";
        this.buttonConfirmar.Size = new System.Drawing.Size(75, 23);
        this.buttonConfirmar.TabIndex = 1;
        this.buttonConfirmar.Text = "Confirmar";
        this.buttonConfirmar.UseVisualStyleBackColor = true;
        this.buttonConfirmar.Click += new System.EventHandler(this.buttonConfirmar_Click);
        // 
        // FormNovoTraje
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(284, 100);
        this.Controls.Add(this.buttonConfirmar);
        this.Controls.Add(this.textBoxNome);
        this.Controls.Add(this.labelNome);
        this.Name = "FormNovoTraje";
        this.Text = "Novo Traje";
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    private void buttonConfirmar_Click(object sender, EventArgs e)
    {
        NomeTraje = textBoxNome.Text;
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private System.Windows.Forms.TextBox textBoxNome;
    private System.Windows.Forms.Button buttonConfirmar;
    private System.Windows.Forms.Label labelNome;

}



public partial class FormSelecionarTraje : Form
{
    public string SelectedTrajeId { get; private set; }

    public FormSelecionarTraje(List<string> trajes)
    {
        InitializeComponent(trajes);
    }

    private void InitializeComponent(List<string> trajes)
    {
        this.listBoxTrajes = new System.Windows.Forms.ListBox();
        this.buttonConfirmar = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // listBoxTrajes
        // 
        this.listBoxTrajes.FormattingEnabled = true;
        this.listBoxTrajes.Location = new System.Drawing.Point(12, 12);
        this.listBoxTrajes.Name = "listBoxTrajes";
        this.listBoxTrajes.Size = new System.Drawing.Size(260, 173);
        this.listBoxTrajes.TabIndex = 0;
        foreach (var traje in trajes)
        {
            this.listBoxTrajes.Items.Add(traje);
        }
        // 
        // buttonConfirmar
        // 
        this.buttonConfirmar.Location = new System.Drawing.Point(105, 200);
        this.buttonConfirmar.Name = "buttonConfirmar";
        this.buttonConfirmar.Size = new System.Drawing.Size(75, 23);
        this.buttonConfirmar.TabIndex = 1;
        this.buttonConfirmar.Text = "Confirmar";
        this.buttonConfirmar.UseVisualStyleBackColor = true;
        this.buttonConfirmar.Click += new System.EventHandler(this.buttonConfirmar_Click);
        // 
        // FormSelecionarTraje
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(284, 241);
        this.Controls.Add(this.buttonConfirmar);
        this.Controls.Add(this.listBoxTrajes);
        this.Name = "FormSelecionarTraje";
        this.Text = "Selecionar Traje";
        this.ResumeLayout(false);
    }

    private void buttonConfirmar_Click(object sender, EventArgs e)
    {
        if (listBoxTrajes.SelectedItem != null)
        {
            string selectedItemTraje = listBoxTrajes.SelectedItem.ToString();
            SelectedTrajeId = selectedItemTraje.Split('-')[0].Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        else
        {
            MessageBox.Show("Por favor, selecione um traje.");
        }
    }

    private System.Windows.Forms.ListBox listBoxTrajes;
    private System.Windows.Forms.Button buttonConfirmar;
}



public partial class FormAdicionarAA : Form
{
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button button5;

    public FormAdicionarAA()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.button1 = new System.Windows.Forms.Button();
        this.button2 = new System.Windows.Forms.Button();
        this.button3 = new System.Windows.Forms.Button();
        this.button4 = new System.Windows.Forms.Button();
        this.button5 = new System.Windows.Forms.Button();
        this.SuspendLayout();

        // 
        // button1
        // 
        this.button1.Location = new System.Drawing.Point(50, 30);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(100, 30);
        this.button1.TabIndex = 0;
        this.button1.Text = "Chapéu";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.Button1_Click);

        // 
        // button2
        // 
        this.button2.Location = new System.Drawing.Point(50, 70);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(100, 30);
        this.button2.TabIndex = 1;
        this.button2.Text = "Emblema";
        this.button2.UseVisualStyleBackColor = true;
        this.button2.Click += new System.EventHandler(this.Button2_Click);

        // 
        // button3
        // 
        this.button3.Location = new System.Drawing.Point(50, 110);
        this.button3.Name = "button3";
        this.button3.Size = new System.Drawing.Size(100, 30);
        this.button3.TabIndex = 2;
        this.button3.Text = "Pin";
        this.button3.UseVisualStyleBackColor = true;
        this.button3.Click += new System.EventHandler(this.Button3_Click);

        // 
        // button4
        // 
        this.button4.Location = new System.Drawing.Point(50, 150);
        this.button4.Name = "button4";
        this.button4.Size = new System.Drawing.Size(100, 30);
        this.button4.TabIndex = 3;
        this.button4.Text = "Pasta";
        this.button4.UseVisualStyleBackColor = true;
        this.button4.Click += new System.EventHandler(this.Button4_Click);

        // 
        // button5
        // 
        this.button5.Location = new System.Drawing.Point(50, 190);
        this.button5.Name = "button5";
        this.button5.Size = new System.Drawing.Size(100, 30);
        this.button5.TabIndex = 4;
        this.button5.Text = "Nó";
        this.button5.UseVisualStyleBackColor = true;
        this.button5.Click += new System.EventHandler(this.Button5_Click);

        // 
        // FormAdicionarAA
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(200, 250);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.button2);
        this.Controls.Add(this.button3);
        this.Controls.Add(this.button4);
        this.Controls.Add(this.button5);
        this.Name = "FormAdicionarAA";
        this.Text = "Form com Botões";
        this.ResumeLayout(false);
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        this.Close();

        using (FormAdicionarChapeu form = new FormAdicionarChapeu())
        {
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }

    private void Button2_Click(object sender, EventArgs e)
    {
        this.Close();

        using (FormAdicionarEmblema form = new FormAdicionarEmblema())
        {
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }

    private void Button3_Click(object sender, EventArgs e)
    {
        this.Close();

        using (FormAdicionarPin form = new FormAdicionarPin())
        {
            if (form.ShowDialog() == DialogResult.OK)
            {

                //AdicionarTraje(nomeTraje);
            }
        }
    }

    private void Button4_Click(object sender, EventArgs e)
    {
        this.Close();

        using (FormAdicionarPasta form = new FormAdicionarPasta())
        {
            if (form.ShowDialog() == DialogResult.OK)
            {

      }
        }
    }

    private void Button5_Click(object sender, EventArgs e)
    {
        this.Close();

        using (FormAdicionarNo form = new FormAdicionarNo())
        {
            if (form.ShowDialog() == DialogResult.OK)
            {

                //AdicionarTraje(nomeTraje);
            }
        }
    }
}
public partial class FormAdicionarChapeu : Form
{
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Button button1;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;




    public FormAdicionarChapeu()
    {
        InitializeComponent();
        List<string> lojas = GetLojasAcademico();

        PreencherComboBoxLojas(lojas);
    }

    private void InitializeComponent()
    {
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.textBox2 = new System.Windows.Forms.TextBox();
        this.textBox3 = new System.Windows.Forms.TextBox();
        this.comboBox1 = new System.Windows.Forms.ComboBox();
        this.button1 = new System.Windows.Forms.Button();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.SuspendLayout();



        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(12, 40);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(46, 13);
        this.label1.TabIndex = 0;
        this.label1.Text = "Nome :";

        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(12, 90);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(46, 13);
        this.label2.TabIndex = 1;
        this.label2.Text = "Quantidade :";

        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(12, 140);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(46, 13);
        this.label3.TabIndex = 2;
        this.label3.Text = "Universidade :";

        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(12, 190);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(38, 13);
        this.label4.TabIndex = 3;
        this.label4.Text = "Loja :";

        // 
        // textBox1
        // 
        this.textBox1.Location = new System.Drawing.Point(120, 37); // Movendo a TextBox1 para frente
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(330, 20);
        this.textBox1.TabIndex = 4;

        // 
        // textBox2
        // 
        this.textBox2.Location = new System.Drawing.Point(120, 87); // Movendo a TextBox2 para frente
        this.textBox2.Name = "textBox2";
        this.textBox2.Size = new System.Drawing.Size(330, 20);
        this.textBox2.TabIndex = 5;

        // 
        // textBox3
        // 
        this.textBox3.Location = new System.Drawing.Point(120, 137); // Movendo a TextBox3 para frente
        this.textBox3.Name = "textBox3";
        this.textBox3.Size = new System.Drawing.Size(330, 20);
        this.textBox3.TabIndex = 6;

        // 
        // comboBox1
        // 
        this.comboBox1.FormattingEnabled = true;
        this.comboBox1.Location = new System.Drawing.Point(94, 187);
        this.comboBox1.Name = "comboBox1";
        this.comboBox1.Size = new System.Drawing.Size(356, 21);
        this.comboBox1.TabIndex = 7;

        // 
        // button1
        // 
        this.button1.Location = new System.Drawing.Point(12, 230);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(438, 40); // Aumentando a altura do botão
        this.button1.TabIndex = 8;
        this.button1.Text = "Adicionar";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);


        // 
        // FormAdicionarChapeu
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(500, 320); // Aumento do tamanho da janela
        this.Controls.Add(this.button1);
        this.Controls.Add(this.comboBox1);
        this.Controls.Add(this.textBox3);
        this.Controls.Add(this.textBox2);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Name = "FormAdicionarChapeu";
        this.Text = "Adicionar Chapéu";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // Verificar se algum campo não está preenchido
        if (string.IsNullOrWhiteSpace(textBox1.Text) ||
            string.IsNullOrWhiteSpace(textBox2.Text) ||
            string.IsNullOrWhiteSpace(textBox3.Text) ||
            comboBox1.SelectedItem == null ||
            !int.TryParse(textBox2.Text, out _))
        {
            MessageBox.Show("Por favor, preencha todos os campos corretamente antes de prosseguir.", "Campos não preenchidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
            // Obter a lista de conteúdos
            List<string> conteudos = ObterConteudos();

            AdicionarChapeu(conteudos);
            this.Close();

        }
    }

    // Método separado para obter a lista de conteúdos
    private List<string> ObterConteudos()
    {
        List<string> conteudos = new List<string>
    {
        textBox1.Text, //nome
        textBox2.Text, //quantidade
        textBox3.Text, //universidade
        comboBox1.SelectedItem.ToString() //loja
    };

        return conteudos;
    }

    private void AdicionarChapeu(List<string> conteudos)
    {
        using (SqlConnection connection = getSqlConn())
        {
            using (SqlCommand command = new SqlCommand("AddChapeu", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Adicionar parâmetros à stored procedure
                command.Parameters.AddWithValue("@Nome", conteudos[0]);
                command.Parameters.AddWithValue("@Quantidade", int.Parse(conteudos[1]));  // Convertendo para int
                command.Parameters.AddWithValue("@End_Loja", conteudos[3]);
                command.Parameters.AddWithValue("@Universidade", conteudos[2]);
                
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Chapéu adicionado com sucesso!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar chapéu: " + ex.Message);
                }
               

            }
        }
    }
    private void PreencherComboBoxLojas(List<string> lojas)
    {
        comboBox1.Items.Clear(); // Limpa os itens existentes

        foreach (string loja in lojas)
        {
            comboBox1.Items.Add(loja);
        }
    }

    private List<string> GetLojasAcademico()
    {
        List<string> lojasAcademico = new List<string>();

        try
        {
            using (SqlConnection conn = getSqlConn())
            {
                conn.Open();
                string query = "GetLojasAcademico"; // Nome da stored procedure

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lojasAcademico.Add(reader["End_Loja"].ToString());
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao buscar endereços das lojas acadêmicas: " + ex.Message);
        }

        return lojasAcademico;
    }

    private SqlConnection getSqlConn()
    {
        return new SqlConnection("data source = tcp:mednat.ieeta.pt\\SQLSERVER, 8101; Initial Catalog = p4g7; uid = p4g7; password = EuTuSQL19");
    }



}

public partial class FormAdicionarEmblema : Form
{
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.TextBox textBox4;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Button button1;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;



    

    public FormAdicionarEmblema()
    {
        InitializeComponent();
        List<string> lojas = GetLojasAcademico();
        PreencherComboBoxLojas(lojas);
    }

    private void InitializeComponent()
    {

        this.textBox1 = new System.Windows.Forms.TextBox();
        this.textBox2 = new System.Windows.Forms.TextBox();
        this.textBox3 = new System.Windows.Forms.TextBox();
        this.textBox4 = new System.Windows.Forms.TextBox();
        this.comboBox1 = new System.Windows.Forms.ComboBox();
        this.button1 = new System.Windows.Forms.Button();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();

        this.SuspendLayout();

        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(12, 40);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(46, 13);
        this.label1.TabIndex = 0;
        this.label1.Text = "Nome :";

        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(12, 90);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(46, 13);
        this.label2.TabIndex = 1;
        this.label2.Text = "Quantidade :";

        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(12, 140);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(46, 13);
        this.label3.TabIndex = 2;
        this.label3.Text = "Tipo :";

        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(12, 190);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(38, 13);
        this.label4.TabIndex = 3;
        this.label4.Text = "Forma :";


        // label5
        // 
        this.label5.AutoSize = true;
        this.label5.Location = new System.Drawing.Point(12, 240);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(46, 13);
        this.label5.TabIndex = 9;
        this.label5.Text = "Loja :";

        // 
        // 
        // textBox1
        // 
        this.textBox1.Location = new System.Drawing.Point(120, 37); // Movendo a TextBox1 para frente
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(330, 20);
        this.textBox1.TabIndex = 4;

        // 
        // textBox2
        // 
        this.textBox2.Location = new System.Drawing.Point(120, 87); // Movendo a TextBox2 para frente
        this.textBox2.Name = "textBox2";
        this.textBox2.Size = new System.Drawing.Size(330, 20);
        this.textBox2.TabIndex = 5;

        // 
        // textBox3
        // 
        this.textBox3.Location = new System.Drawing.Point(120, 137); // Movendo a TextBox3 para frente
        this.textBox3.Name = "textBox3";
        this.textBox3.Size = new System.Drawing.Size(330, 20);
        this.textBox3.TabIndex = 6;

        // textBox4
        // 
        this.textBox4.Location = new System.Drawing.Point(120, 187);
        this.textBox4.Name = "textBox4";
        this.textBox4.Size = new System.Drawing.Size(330, 20);
        this.textBox4.TabIndex = 10;


        // 
        // comboBox1
        // 
        this.comboBox1.FormattingEnabled = true;
        this.comboBox1.Location = new System.Drawing.Point(120, 237);
        this.comboBox1.Name = "comboBox1";
        this.comboBox1.Size = new System.Drawing.Size(330, 21);
        this.comboBox1.TabIndex = 7;

        // 
        // button1
        // 
        this.button1.Location = new System.Drawing.Point(12, 270);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(438, 40); // Aumentando a altura do botão
        this.button1.TabIndex = 8;
        this.button1.Text = "Adicionar";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);


        // 
        // FormAdicionarEMBLEMA
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(500, 320); // Aumento do tamanho da janela
        this.Controls.Add(this.button1);
        this.Controls.Add(this.comboBox1);
        this.Controls.Add(this.textBox3);
        this.Controls.Add(this.textBox2);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.label5);
        this.Controls.Add(this.textBox4);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Name = "FormAdicionarEmblema";
        this.Text = "Adicionar Emblema";
        this.ResumeLayout(false);
        this.PerformLayout();
    }



    
    private void button1_Click(object sender, EventArgs e)
    {
        // Verificar se algum campo não está preenchido
        if (string.IsNullOrWhiteSpace(textBox1.Text) ||
            string.IsNullOrWhiteSpace(textBox2.Text) ||
            string.IsNullOrWhiteSpace(textBox3.Text) ||
            string.IsNullOrWhiteSpace(textBox4.Text) ||
            comboBox1.SelectedItem == null ||
            !int.TryParse(textBox2.Text, out _))
        {
            MessageBox.Show("Por favor, preencha todos os campos antes de prosseguir.", "Campos não preenchidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
            // Obter a lista de conteúdos
            List<string> conteudos = ObterConteudosEmblemas();

            AdicionarEmblema(conteudos);
            this.Close();
        }
    }


    // Método separado para obter a lista de conteúdos
    private List<string> ObterConteudosEmblemas()
    {
        List<string> conteudos = new List<string>
    {
        textBox1.Text, //nome
        textBox2.Text, //quantidade
        textBox3.Text, //tipo
        textBox4.Text, //forma
        comboBox1.SelectedItem.ToString() //loja
    };

        return conteudos;
    }


    private void AdicionarEmblema(List<string> conteudos)
    {
        using (SqlConnection connection = getSqlConn())
        {
            using (SqlCommand command = new SqlCommand("AddEmblema", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Adicionar parâmetros à stored procedure
                command.Parameters.AddWithValue("@Nome", conteudos[0]);
                command.Parameters.AddWithValue("@Quantidade", int.Parse(conteudos[1]));  // Convertendo para int
                command.Parameters.AddWithValue("@Tipo", conteudos[2]);
                command.Parameters.AddWithValue("@Forma", conteudos[3]);
                command.Parameters.AddWithValue("@End_Loja", conteudos[4]);


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Emblema adicionado com sucesso!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar emblema: " + ex.Message);
                }


            }
        }
    }

    private void PreencherComboBoxLojas(List<string> lojas)
    {
        comboBox1.Items.Clear(); // Limpa os itens existentes

        foreach (string loja in lojas)
        {
            comboBox1.Items.Add(loja);
        }
    }

    private List<string> GetLojasAcademico()
    {
        List<string> lojasAcademico = new List<string>();

        try
        {
            using (SqlConnection conn = getSqlConn())
            {
                conn.Open();
                string query = "GetLojasAcademico"; // Nome da stored procedure

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lojasAcademico.Add(reader["End_Loja"].ToString());
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao buscar endereços das lojas acadêmicas: " + ex.Message);
        }

        return lojasAcademico;
    }

    private SqlConnection getSqlConn()
    {
        return new SqlConnection("data source = tcp:mednat.ieeta.pt\\SQLSERVER, 8101; Initial Catalog = p4g7; uid = p4g7; password = EuTuSQL19");
    }
}


public partial class FormAdicionarPasta : Form
{
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Button button1;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;




    public FormAdicionarPasta()
    {
        InitializeComponent();
        List<string> lojas = GetLojasAcademico();
        PreencherComboBoxLojas(lojas);
    }

    private void InitializeComponent()
    {
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.textBox2 = new System.Windows.Forms.TextBox();
        this.textBox3 = new System.Windows.Forms.TextBox();
        this.comboBox1 = new System.Windows.Forms.ComboBox();
        this.button1 = new System.Windows.Forms.Button();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.SuspendLayout();



        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(12, 40);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(46, 13);
        this.label1.TabIndex = 0;
        this.label1.Text = "Nome :";

        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(12, 90);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(46, 13);
        this.label2.TabIndex = 1;
        this.label2.Text = "Quantidade :";

        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(12, 140);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(46, 13);
        this.label3.TabIndex = 2;
        this.label3.Text = "Universidade :";

        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(12, 190);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(38, 13);
        this.label4.TabIndex = 3;
        this.label4.Text = "Loja :";

        // 
        // textBox1
        // 
        this.textBox1.Location = new System.Drawing.Point(120, 37); // Movendo a TextBox1 para frente
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(330, 20);
        this.textBox1.TabIndex = 4;

        // 
        // textBox2
        // 
        this.textBox2.Location = new System.Drawing.Point(120, 87); // Movendo a TextBox2 para frente
        this.textBox2.Name = "textBox2";
        this.textBox2.Size = new System.Drawing.Size(330, 20);
        this.textBox2.TabIndex = 5;

        // 
        // textBox3
        // 
        this.textBox3.Location = new System.Drawing.Point(120, 137); // Movendo a TextBox3 para frente
        this.textBox3.Name = "textBox3";
        this.textBox3.Size = new System.Drawing.Size(330, 20);
        this.textBox3.TabIndex = 6;

        // 
        // comboBox1
        // 
        this.comboBox1.FormattingEnabled = true;
        this.comboBox1.Location = new System.Drawing.Point(94, 187);
        this.comboBox1.Name = "comboBox1";
        this.comboBox1.Size = new System.Drawing.Size(356, 21);
        this.comboBox1.TabIndex = 7;

        // 
        // button1
        // 
        this.button1.Location = new System.Drawing.Point(12, 230);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(438, 40); // Aumentando a altura do botão
        this.button1.TabIndex = 8;
        this.button1.Text = "Adicionar";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);


        // 
        // FormAdicionarChapeu
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(500, 320); // Aumento do tamanho da janela
        this.Controls.Add(this.button1);
        this.Controls.Add(this.comboBox1);
        this.Controls.Add(this.textBox3);
        this.Controls.Add(this.textBox2);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Name = "FormAdicionarPasta";
        this.Text = "Adicionar Pasta";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // Verificar se algum campo não está preenchido
        if (string.IsNullOrWhiteSpace(textBox1.Text) ||
            string.IsNullOrWhiteSpace(textBox2.Text) ||
            string.IsNullOrWhiteSpace(textBox3.Text) ||
            comboBox1.SelectedItem == null ||
            !int.TryParse(textBox2.Text, out _))
        {
            MessageBox.Show("Por favor, preencha todos os campos antes de prosseguir.", "Campos não preenchidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
            List<string> conteudos = ObterConteudosPasta();

            AdicionarPasta(conteudos);
            this.Close();
        }
    }

    // Método separado para obter a lista de conteúdos
    private List<string> ObterConteudosPasta()
    {
        List<string> conteudos = new List<string>
    {
        textBox1.Text, //nome
        textBox2.Text, //quantidade
        textBox3.Text, //universidade
        comboBox1.SelectedItem.ToString() //loja
    };

        return conteudos;
    }

    private void AdicionarPasta(List<string> conteudos)
    {
        using (SqlConnection connection = getSqlConn())
        {
            using (SqlCommand command = new SqlCommand("AddPasta", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Adicionar parâmetros à stored procedure
                command.Parameters.AddWithValue("@Nome", conteudos[0]);
                command.Parameters.AddWithValue("@Quantidade", int.Parse(conteudos[1]));  // Convertendo para int
                command.Parameters.AddWithValue("@Universidade", conteudos[2]);
                command.Parameters.AddWithValue("@End_Loja", conteudos[3]);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Pasta adicionada com sucesso!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar pasta: " + ex.Message);
                }


            }
        }
    }
    private void PreencherComboBoxLojas(List<string> lojas)
    {
        comboBox1.Items.Clear(); // Limpa os itens existentes

        foreach (string loja in lojas)
        {
            comboBox1.Items.Add(loja);
        }
    }

    private List<string> GetLojasAcademico()
    {
        List<string> lojasAcademico = new List<string>();

        try
        {
            using (SqlConnection conn = getSqlConn())
            {
                conn.Open();
                string query = "GetLojasAcademico"; // Nome da stored procedure

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lojasAcademico.Add(reader["End_Loja"].ToString());
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao buscar endereços das lojas acadêmicas: " + ex.Message);
        }

        return lojasAcademico;
    }

    private SqlConnection getSqlConn()
    {
        return new SqlConnection("data source = tcp:mednat.ieeta.pt\\SQLSERVER, 8101; Initial Catalog = p4g7; uid = p4g7; password = EuTuSQL19");
    }



}

public partial class FormAdicionarPin : Form
{
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Button button1;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;




    public FormAdicionarPin()
    {
        InitializeComponent();
        List<string> lojas = GetLojasAcademico();

        PreencherComboBoxLojas(lojas);
    }

    private void InitializeComponent()
    {
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.textBox2 = new System.Windows.Forms.TextBox();
        this.textBox3 = new System.Windows.Forms.TextBox();
        this.comboBox1 = new System.Windows.Forms.ComboBox();
        this.button1 = new System.Windows.Forms.Button();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.SuspendLayout();



        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(12, 40);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(46, 13);
        this.label1.TabIndex = 0;
        this.label1.Text = "Nome :";

        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(12, 90);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(46, 13);
        this.label2.TabIndex = 1;
        this.label2.Text = "Quantidade :";

        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(12, 140);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(46, 13);
        this.label3.TabIndex = 2;
        this.label3.Text = "Tipo :";

        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(12, 190);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(38, 13);
        this.label4.TabIndex = 3;
        this.label4.Text = "Loja :";

        // 
        // textBox1
        // 
        this.textBox1.Location = new System.Drawing.Point(120, 37); // Movendo a TextBox1 para frente
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(330, 20);
        this.textBox1.TabIndex = 4;

        // 
        // textBox2
        // 
        this.textBox2.Location = new System.Drawing.Point(120, 87); // Movendo a TextBox2 para frente
        this.textBox2.Name = "textBox2";
        this.textBox2.Size = new System.Drawing.Size(330, 20);
        this.textBox2.TabIndex = 5;

        // 
        // textBox3
        // 
        this.textBox3.Location = new System.Drawing.Point(120, 137); // Movendo a TextBox3 para frente
        this.textBox3.Name = "textBox3";
        this.textBox3.Size = new System.Drawing.Size(330, 20);
        this.textBox3.TabIndex = 6;

        // 
        // comboBox1
        // 
        this.comboBox1.FormattingEnabled = true;
        this.comboBox1.Location = new System.Drawing.Point(94, 187);
        this.comboBox1.Name = "comboBox1";
        this.comboBox1.Size = new System.Drawing.Size(356, 21);
        this.comboBox1.TabIndex = 7;

        // 
        // button1
        // 
        this.button1.Location = new System.Drawing.Point(12, 230);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(438, 40); // Aumentando a altura do botão
        this.button1.TabIndex = 8;
        this.button1.Text = "Adicionar";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);


        // 
        // FormAdicionarPin
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(500, 320); // Aumento do tamanho da janela
        this.Controls.Add(this.button1);
        this.Controls.Add(this.comboBox1); //loja
        this.Controls.Add(this.textBox3); //tipo
        this.Controls.Add(this.textBox2); //quantidade
        this.Controls.Add(this.textBox1); //nome
        this.Controls.Add(this.label4);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Name = "FormAdicionarPin";
        this.Text = "Adicionar Pin";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // Verificar se algum campo não está preenchido
        if (string.IsNullOrWhiteSpace(textBox1.Text) ||
              string.IsNullOrWhiteSpace(textBox2.Text) ||
              string.IsNullOrWhiteSpace(textBox3.Text) ||
              comboBox1.SelectedItem == null ||
              !int.TryParse(textBox2.Text, out _))
        {
            MessageBox.Show("Por favor, preencha todos os campos antes de prosseguir.", "Campos não preenchidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
            // Obter a lista de conteúdos
            List<string> conteudos = ObterConteudosPins();

            AdicionarPin(conteudos);
            this.Close();
        }
    }


    // Método separado para obter a lista de conteúdos
    private List<string> ObterConteudosPins()
    {
        List<string> conteudos = new List<string>
    {
        textBox1.Text, //nome
        textBox2.Text, //quantidade
        textBox3.Text, //tipo
        comboBox1.SelectedItem.ToString() //loja
    };

        return conteudos;
    }

    private void AdicionarPin(List<string> conteudos)
    {
        using (SqlConnection connection = getSqlConn())
        {
            using (SqlCommand command = new SqlCommand("AddPin", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Adicionar parâmetros à stored procedure
                command.Parameters.AddWithValue("@Nome", conteudos[0]);
                command.Parameters.AddWithValue("@Quantidade", int.Parse(conteudos[1]));  // Convertendo para int
                command.Parameters.AddWithValue("@Tipo", conteudos[2]);
                command.Parameters.AddWithValue("@End_Loja", conteudos[3]);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Pin adicionado com sucesso!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar pin: " + ex.Message);
                }


            }
        }
    }
    private void PreencherComboBoxLojas(List<string> lojas)
    {
        comboBox1.Items.Clear(); // Limpa os itens existentes

        foreach (string loja in lojas)
        {
            comboBox1.Items.Add(loja);
        }
    }

    private List<string> GetLojasAcademico()
    {
        List<string> lojasAcademico = new List<string>();

        try
        {
            using (SqlConnection conn = getSqlConn())
            {
                conn.Open();
                string query = "GetLojasAcademico"; // Nome da stored procedure

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lojasAcademico.Add(reader["End_Loja"].ToString());
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao buscar endereços das lojas acadêmicas: " + ex.Message);
        }

        return lojasAcademico;
    }

    private SqlConnection getSqlConn()
    {
        return new SqlConnection("data source = tcp:mednat.ieeta.pt\\SQLSERVER, 8101; Initial Catalog = p4g7; uid = p4g7; password = EuTuSQL19");
    }



}




public partial class FormAdicionarNo : Form
{
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.TextBox textBox4;
    private System.Windows.Forms.TextBox textBox5;

    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Button button1;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;






    public FormAdicionarNo()
    {
        InitializeComponent();
        List<string> lojas = GetLojasAcademico();

        PreencherComboBoxLojas(lojas);
    }

    private void InitializeComponent()
    {
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.textBox2 = new System.Windows.Forms.TextBox();
        this.textBox3 = new System.Windows.Forms.TextBox();
        this.textBox4 = new System.Windows.Forms.TextBox();
        this.textBox5 = new System.Windows.Forms.TextBox(); // Outra nova TextBox
        this.comboBox1 = new System.Windows.Forms.ComboBox();
        this.button1 = new System.Windows.Forms.Button();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.label6 = new System.Windows.Forms.Label(); // Outra nova Label
        this.SuspendLayout();

        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(12, 20);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(38, 13);
        this.label1.TabIndex = 0;
        this.label1.Text = "Nome:";

        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(12, 60);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(68, 13);
        this.label2.TabIndex = 1;
        this.label2.Text = "Quantidade:";

        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(12, 100);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(31, 13);
        this.label3.TabIndex = 2;
        this.label3.Text = "Tipo:";

        // 
        // label5
        // 
        this.label5.AutoSize = true;
        this.label5.Location = new System.Drawing.Point(12, 140);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(61, 13);
        this.label5.TabIndex = 9;
        this.label5.Text = "Cor 1:";

        // 
        // label6
        // 
        this.label6.AutoSize = true;
        this.label6.Location = new System.Drawing.Point(12, 180); // Outra nova Label
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(61, 13);
        this.label6.TabIndex = 11;
        this.label6.Text = "Cor 2:";

        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(12, 220); // Ajustado
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(30, 13);
        this.label4.TabIndex = 3;
        this.label4.Text = "Loja:";

        // 
        // textBox1
        // 
        this.textBox1.Location = new System.Drawing.Point(120, 17);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(330, 20);
        this.textBox1.TabIndex = 4;

        // 
        // textBox2
        // 
        this.textBox2.Location = new System.Drawing.Point(120, 57);
        this.textBox2.Name = "textBox2";
        this.textBox2.Size = new System.Drawing.Size(330, 20);
        this.textBox2.TabIndex = 5;

        // 
        // textBox3
        // 
        this.textBox3.Location = new System.Drawing.Point(120, 97);
        this.textBox3.Name = "textBox3";
        this.textBox3.Size = new System.Drawing.Size(330, 20);
        this.textBox3.TabIndex = 6;

        // 
        // textBox4
        // 
        this.textBox4.Location = new System.Drawing.Point(120, 137);
        this.textBox4.Name = "textBox4";
        this.textBox4.Size = new System.Drawing.Size(330, 20);
        this.textBox4.TabIndex = 10;

        // 
        // textBox5
        // 
        this.textBox5.Location = new System.Drawing.Point(120, 177); // Outra nova TextBox
        this.textBox5.Name = "textBox5";
        this.textBox5.Size = new System.Drawing.Size(330, 20);
        this.textBox5.TabIndex = 12;

        // 
        // comboBox1
        // 
        this.comboBox1.FormattingEnabled = true;
        this.comboBox1.Location = new System.Drawing.Point(120, 217); // Ajustado
        this.comboBox1.Name = "comboBox1";
        this.comboBox1.Size = new System.Drawing.Size(330, 21);
        this.comboBox1.TabIndex = 7;

        // 
        // button1
        // 
        this.button1.Location = new System.Drawing.Point(12, 260); // Ajustado
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(438, 40);
        this.button1.TabIndex = 8;
        this.button1.Text = "Adicionar";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);

        // 
        // FormAdicionarNo
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(500, 320);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.comboBox1);
        this.Controls.Add(this.textBox5); // Outra nova TextBox
        this.Controls.Add(this.textBox4);
        this.Controls.Add(this.textBox3);
        this.Controls.Add(this.textBox2);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.label6); // Outra nova Label
        this.Controls.Add(this.label5);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Name = "FormAdicionarNo";
        this.Text = "Adicionar No";
        this.ResumeLayout(false);
        this.PerformLayout();


    }

    private void button1_Click(object sender, EventArgs e)
    {
        // Verificar se algum campo não está preenchido
        if (string.IsNullOrWhiteSpace(textBox1.Text) ||
           string.IsNullOrWhiteSpace(textBox2.Text) ||
           string.IsNullOrWhiteSpace(textBox3.Text) ||
            string.IsNullOrWhiteSpace(textBox4.Text) ||
           comboBox1.SelectedItem == null ||
           !int.TryParse(textBox2.Text, out _))
        {
            MessageBox.Show("Por favor, preencha todos os campos antes de prosseguir.", "Campos não preenchidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
            // Obter a lista de conteúdos
            List<string> conteudos = ObterConteudosNos();

            AdicionarNo(conteudos);
            this.Close();
        }
    }


    // Método separado para obter a lista de conteúdos
    private List<string> ObterConteudosNos()
    {
        List<string> conteudos = null;
        string Cor2 = "NULL";
        if (!string.IsNullOrWhiteSpace(textBox5.Text)) {
            Cor2 = textBox5.Text;
        }
        conteudos = new List<string>
    {
        textBox1.Text, //nome
        textBox2.Text, //quantidade
        textBox3.Text, //tipo
        textBox4.Text, //cor1
        Cor2,          // cor 2
        comboBox1.SelectedItem.ToString() //loja
    };

        return conteudos;
    }

    private void AdicionarNo(List<string> conteudos)
    {
        using (SqlConnection connection = getSqlConn())
        {
            using (SqlCommand command = new SqlCommand("AddNo", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Adicionar parâmetros à stored procedure
                command.Parameters.AddWithValue("@Nome", conteudos[0]);
                command.Parameters.AddWithValue("@Quantidade", int.Parse(conteudos[1]));  // Convertendo para int
                command.Parameters.AddWithValue("@Tipo", conteudos[2]);
                command.Parameters.AddWithValue("@Cor1", conteudos[3]);
                command.Parameters.AddWithValue("@Cor2", conteudos[4]);
                command.Parameters.AddWithValue("@End_Loja", conteudos[5]);


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Nó adicionado com sucesso!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar nó: " + ex.Message);
                }


            }
        }
    }
    private void PreencherComboBoxLojas(List<string> lojas)
    {
        comboBox1.Items.Clear(); // Limpa os itens existentes

        foreach (string loja in lojas)
        {
            comboBox1.Items.Add(loja);
        }
    }

    private List<string> GetLojasAcademico()
    {
        List<string> lojasAcademico = new List<string>();

        try
        {
            using (SqlConnection conn = getSqlConn())
            {
                conn.Open();
                string query = "GetLojasAcademico"; // Nome da stored procedure

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lojasAcademico.Add(reader["End_Loja"].ToString());
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao buscar endereços das lojas acadêmicas: " + ex.Message);
        }

        return lojasAcademico;
    }

    private SqlConnection getSqlConn()
    {
        return new SqlConnection("data source = tcp:mednat.ieeta.pt\\SQLSERVER, 8101; Initial Catalog = p4g7; uid = p4g7; password = EuTuSQL19");
    }



}




/////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////


public partial class FormAdicionarAP : Form
{
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button button5;

    public FormAdicionarAP()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.button1 = new System.Windows.Forms.Button();
        this.button2 = new System.Windows.Forms.Button();

        this.SuspendLayout();

        // 
        // button1
        // 
        this.button1.Location = new System.Drawing.Point(50, 30);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(100, 30);
        this.button1.TabIndex = 0;
        this.button1.Text = "Caneta";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.Button1_Click);

        // 
        // button2
        // 
        this.button2.Location = new System.Drawing.Point(50, 70);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(100, 30);
        this.button2.TabIndex = 1;
        this.button2.Text = "Lápis";
        this.button2.UseVisualStyleBackColor = true;
        this.button2.Click += new System.EventHandler(this.Button2_Click);

        // 
        // FormAdicionarAA
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(200, 120);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.button2);
        this.Name = "FormAdicionarAP";
        this.Text = "Form com Botões";
        this.ResumeLayout(false);
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        this.Close();

        using (FormAdicionarCaneta form = new FormAdicionarCaneta())
        {
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }

    private void Button2_Click(object sender, EventArgs e)
    {
        this.Close();

        using (FormAdicionarLapis form = new FormAdicionarLapis())
        {
            if (form.ShowDialog() == DialogResult.OK)
            {
            }
        }
    }
}

public partial class FormAdicionarLapis : Form
{
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.TextBox textBox4;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Button button1;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;



    public FormAdicionarLapis()
    {
        InitializeComponent();
        List<string> lojas = GetLojasAcademico();

        PreencherComboBoxLojas(lojas);
    }

    private void InitializeComponent()
    {
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.textBox2 = new System.Windows.Forms.TextBox();
        this.textBox3 = new System.Windows.Forms.TextBox();
        this.textBox4 = new System.Windows.Forms.TextBox();
        this.comboBox1 = new System.Windows.Forms.ComboBox();
        this.button1 = new System.Windows.Forms.Button();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();

        this.SuspendLayout();

        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(12, 40);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(46, 13);
        this.label1.TabIndex = 0;
        this.label1.Text = "Nome :";

        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(12, 90);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(46, 13);
        this.label2.TabIndex = 1;
        this.label2.Text = "Quantidade :";

        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(12, 140);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(46, 13);
        this.label3.TabIndex = 2;
        this.label3.Text = "Marca :";

        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(12, 190);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(38, 13);
        this.label4.TabIndex = 3;
        this.label4.Text = "Dureza :";


        // label5
        // 
        this.label5.AutoSize = true;
        this.label5.Location = new System.Drawing.Point(12, 240);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(46, 13);
        this.label5.TabIndex = 9;
        this.label5.Text = "Loja :";

        // 
        // 
        // textBox1
        // 
        this.textBox1.Location = new System.Drawing.Point(120, 37); // Movendo a TextBox1 para frente
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(330, 20);
        this.textBox1.TabIndex = 4;

        // 
        // textBox2
        // 
        this.textBox2.Location = new System.Drawing.Point(120, 87); // Movendo a TextBox2 para frente
        this.textBox2.Name = "textBox2";
        this.textBox2.Size = new System.Drawing.Size(330, 20);
        this.textBox2.TabIndex = 5;

        // 
        // textBox3
        // 
        this.textBox3.Location = new System.Drawing.Point(120, 137); // Movendo a TextBox3 para frente
        this.textBox3.Name = "textBox3";
        this.textBox3.Size = new System.Drawing.Size(330, 20);
        this.textBox3.TabIndex = 6;

        // textBox4
        // 
        this.textBox4.Location = new System.Drawing.Point(120, 187);
        this.textBox4.Name = "textBox4";
        this.textBox4.Size = new System.Drawing.Size(330, 20);
        this.textBox4.TabIndex = 10;


        // 
        // comboBox1
        // 
        this.comboBox1.FormattingEnabled = true;
        this.comboBox1.Location = new System.Drawing.Point(120, 237);
        this.comboBox1.Name = "comboBox1";
        this.comboBox1.Size = new System.Drawing.Size(330, 21);
        this.comboBox1.TabIndex = 7;

        // 
        // button1
        // 
        this.button1.Location = new System.Drawing.Point(12, 270);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(438, 40); // Aumentando a altura do botão
        this.button1.TabIndex = 8;
        this.button1.Text = "Adicionar";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);


        // 
        // FormAdicionarLapis
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(500, 320); // Aumento do tamanho da janela
        this.Controls.Add(this.button1);
        this.Controls.Add(this.comboBox1);
        this.Controls.Add(this.textBox3);
        this.Controls.Add(this.textBox2);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.label5);
        this.Controls.Add(this.textBox4);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Name = "FormAdicionarLapis";
        this.Text = "Adicionar Lapis";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // Verificar se algum campo não está preenchido
        if (string.IsNullOrWhiteSpace(textBox1.Text) ||
            string.IsNullOrWhiteSpace(textBox2.Text) ||
            string.IsNullOrWhiteSpace(textBox3.Text) ||
            string.IsNullOrWhiteSpace(textBox4.Text) ||
            comboBox1.SelectedItem == null ||
            !int.TryParse(textBox2.Text, out _))
        {
            MessageBox.Show("Por favor, preencha todos os campos antes de prosseguir.", "Campos não preenchidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
            // Obter a lista de conteúdos
            List<string> conteudos = ObterConteudosLapis();

            AdicionarLapis(conteudos);
            this.Close();

        }
    }


    private List<string> ObterConteudosLapis()
    {
        List<string> conteudos = new List<string>
    {
        textBox1.Text, //nome
        textBox2.Text, //quantidade
        textBox3.Text, //marca
        textBox4.Text, //dureza
        comboBox1.SelectedItem.ToString() //loja
    };

        return conteudos;
    }

    private void AdicionarLapis(List<string> conteudos)
    {
        using (SqlConnection connection = getSqlConn())
        {
            using (SqlCommand command = new SqlCommand("AddLapis", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Adicionar parâmetros à stored procedure
                command.Parameters.AddWithValue("@Nome", conteudos[0]);
                command.Parameters.AddWithValue("@Quantidade", int.Parse(conteudos[1]));  // Convertendo para int
                command.Parameters.AddWithValue("@Marca", conteudos[2]);
                command.Parameters.AddWithValue("@Dureza", conteudos[3]);
                command.Parameters.AddWithValue("@End_Loja", conteudos[4]);


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Lápis adicionado com sucesso!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar lápis: " + ex.Message);
                }


            }
        }
    }


    private void PreencherComboBoxLojas(List<string> lojas)
    {
        comboBox1.Items.Clear(); // Limpa os itens existentes

        foreach (string loja in lojas)
        {
            comboBox1.Items.Add(loja);
        }
    }

    private List<string> GetLojasAcademico()
    {
        List<string> lojasAcademico = new List<string>();

        try
        {
            using (SqlConnection conn = getSqlConn())
            {
                conn.Open();
                string query = "GetLojasAcademico"; // Nome da stored procedure

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lojasAcademico.Add(reader["End_Loja"].ToString());
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao buscar endereços das lojas acadêmicas: " + ex.Message);
        }

        return lojasAcademico;
    }

    private SqlConnection getSqlConn()
    {
        return new SqlConnection("data source = tcp:mednat.ieeta.pt\\SQLSERVER, 8101; Initial Catalog = p4g7; uid = p4g7; password = EuTuSQL19");
    }



}
public partial class FormAdicionarCaneta : Form
{
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.TextBox textBox4;
    private System.Windows.Forms.TextBox textBox5;

    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Button button1;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;

    public FormAdicionarCaneta()
    {
        InitializeComponent();
        List<string> lojas = GetLojasAcademico();

        PreencherComboBoxLojas(lojas);
    }

    private void InitializeComponent()
    {
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.textBox2 = new System.Windows.Forms.TextBox();
        this.textBox3 = new System.Windows.Forms.TextBox();
        this.textBox4 = new System.Windows.Forms.TextBox();
        this.textBox5 = new System.Windows.Forms.TextBox(); // Outra nova TextBox
        this.comboBox1 = new System.Windows.Forms.ComboBox();
        this.button1 = new System.Windows.Forms.Button();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.label6 = new System.Windows.Forms.Label(); // Outra nova Label
        this.SuspendLayout();

        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(12, 20);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(38, 13);
        this.label1.TabIndex = 0;
        this.label1.Text = "Nome:";

        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(12, 60);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(68, 13);
        this.label2.TabIndex = 1;
        this.label2.Text = "Quantidade:";

        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(12, 100);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(31, 13);
        this.label3.TabIndex = 2;
        this.label3.Text = "Marca:";

        // 
        // label5
        // 
        this.label5.AutoSize = true;
        this.label5.Location = new System.Drawing.Point(12, 140);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(61, 13);
        this.label5.TabIndex = 9;
        this.label5.Text = "Tipo:";

        // 
        // label6
        // 
        this.label6.AutoSize = true;
        this.label6.Location = new System.Drawing.Point(12, 180); // Outra nova Label
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(61, 13);
        this.label6.TabIndex = 11;
        this.label6.Text = "Cor:";

        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(12, 220); // Ajustado
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(30, 13);
        this.label4.TabIndex = 3;
        this.label4.Text = "Loja:";

        // 
        // textBox1
        // 
        this.textBox1.Location = new System.Drawing.Point(120, 17);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(330, 20);
        this.textBox1.TabIndex = 4;

        // 
        // textBox2
        // 
        this.textBox2.Location = new System.Drawing.Point(120, 57);
        this.textBox2.Name = "textBox2";
        this.textBox2.Size = new System.Drawing.Size(330, 20);
        this.textBox2.TabIndex = 5;

        // 
        // textBox3
        // 
        this.textBox3.Location = new System.Drawing.Point(120, 97);
        this.textBox3.Name = "textBox3";
        this.textBox3.Size = new System.Drawing.Size(330, 20);
        this.textBox3.TabIndex = 6;

        // 
        // textBox4
        // 
        this.textBox4.Location = new System.Drawing.Point(120, 137);
        this.textBox4.Name = "textBox4";
        this.textBox4.Size = new System.Drawing.Size(330, 20);
        this.textBox4.TabIndex = 10;

        // 
        // textBox5
        // 
        this.textBox5.Location = new System.Drawing.Point(120, 177); // Outra nova TextBox
        this.textBox5.Name = "textBox5";
        this.textBox5.Size = new System.Drawing.Size(330, 20);
        this.textBox5.TabIndex = 12;

        // 
        // comboBox1
        // 
        this.comboBox1.FormattingEnabled = true;
        this.comboBox1.Location = new System.Drawing.Point(120, 217); // Ajustado
        this.comboBox1.Name = "comboBox1";
        this.comboBox1.Size = new System.Drawing.Size(330, 21);
        this.comboBox1.TabIndex = 7;

        // 
        // button1
        // 
        this.button1.Location = new System.Drawing.Point(12, 260); // Ajustado
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(438, 40);
        this.button1.TabIndex = 8;
        this.button1.Text = "Adicionar";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);

        // 
        // FormAdicionarNo
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(500, 320);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.comboBox1);
        this.Controls.Add(this.textBox5); // Outra nova TextBox
        this.Controls.Add(this.textBox4);
        this.Controls.Add(this.textBox3);
        this.Controls.Add(this.textBox2);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.label6); // Outra nova Label
        this.Controls.Add(this.label5);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Name = "FormAdicionarCaneta";
        this.Text = "Adicionar Caneta";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        // Verificar se algum campo não está preenchido
        if (string.IsNullOrWhiteSpace(textBox1.Text) ||
            string.IsNullOrWhiteSpace(textBox2.Text) ||
            string.IsNullOrWhiteSpace(textBox3.Text) ||
            string.IsNullOrWhiteSpace(textBox4.Text) ||
            string.IsNullOrWhiteSpace(textBox5.Text) ||
            comboBox1.SelectedItem == null ||
            !int.TryParse(textBox2.Text, out _))
        {
            MessageBox.Show("Por favor, preencha todos os campos antes de prosseguir.", "Campos não preenchidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
            // Obter a lista de conteúdos
            List<string> conteudos = ObterConteudosCaneta();

            AdicionarCaneta(conteudos);
            this.Close();
        }
    }


    private List<string> ObterConteudosCaneta()
    {
        List<string> conteudos = new List<string>
    {
        textBox1.Text, //nome
        textBox2.Text, //quantidade
        textBox3.Text, //marca
        textBox4.Text, //tipo
        textBox5.Text, //cor
        comboBox1.SelectedItem.ToString() //loja
    };

        return conteudos;
    }

    private void AdicionarCaneta(List<string> conteudos)
    {
        using (SqlConnection connection = getSqlConn())
        {
            using (SqlCommand command = new SqlCommand("AddCaneta", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Adicionar parâmetros à stored procedure
                command.Parameters.AddWithValue("@Nome", conteudos[0]);
                command.Parameters.AddWithValue("@Quantidade", int.Parse(conteudos[1]));  // Convertendo para int
                command.Parameters.AddWithValue("@Marca", conteudos[2]);
                command.Parameters.AddWithValue("@Tipo", conteudos[3]);
                command.Parameters.AddWithValue("@Cor", conteudos[4]);
                command.Parameters.AddWithValue("@End_Loja", conteudos[5]);



                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Caneta adicionado com sucesso!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar caneta: " + ex.Message);
                }


            }
        }
    }
    private void PreencherComboBoxLojas(List<string> lojas)
    {
        comboBox1.Items.Clear(); // Limpa os itens existentes

        foreach (string loja in lojas)
        {
            comboBox1.Items.Add(loja);
        }
    }

    private List<string> GetLojasAcademico()
    {
        List<string> lojasAcademico = new List<string>();

        try
        {
            using (SqlConnection conn = getSqlConn())
            {
                conn.Open();
                string query = "GetLojasAcademico"; // Nome da stored procedure

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lojasAcademico.Add(reader["End_Loja"].ToString());
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao buscar endereços das lojas acadêmicas: " + ex.Message);
        }

        return lojasAcademico;
    }

    private SqlConnection getSqlConn()
    {
        return new SqlConnection("data source = tcp:mednat.ieeta.pt\\SQLSERVER, 8101; Initial Catalog = p4g7; uid = p4g7; password = EuTuSQL19");
    }



}
