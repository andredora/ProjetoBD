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
                                string item = $"{reader["ID"]} - {reader["Nome"]}";
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

        }

        private void RemoverButtonAP_Click(object sender, EventArgs e)
        {

        }

        private void AdicionarButtonAP_Click(object sender, EventArgs e)
        {

        }

        private void FiltrarArtigoPapelaria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AdicionarAoTrajebuttonAA_Click(object sender, EventArgs e)
        {

        }

        private void label68_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        } // BAddPeca
    }
}