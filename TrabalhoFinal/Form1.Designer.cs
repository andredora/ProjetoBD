namespace TrabalhoFinal
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabControl = new TabControl();
            tabPage1 = new TabPage();
            label9 = new Label();
            comboBox4 = new ComboBox();
            PesquisarAA = new Button();
            button12 = new Button();
            label5 = new Label();
            FiltarTipoAcademico = new ComboBox();
            listBox1 = new ListBox();
            button2 = new Button();
            label2 = new Label();
            label1 = new Label();
            FiltrarArtigoAcademico = new ComboBox();
            FiltrarLojaAcademico = new ComboBox();
            LimparButton = new Button();
            PesquisarNomeAA = new TextBox();
            tabPage2 = new TabPage();
            button11 = new Button();
            listBox2 = new ListBox();
            button3 = new Button();
            button4 = new Button();
            label3 = new Label();
            label4 = new Label();
            FiltrarArtigoPapelaria = new ComboBox();
            FiltrarLojaPapelaria = new ComboBox();
            button5 = new Button();
            button6 = new Button();
            PesquisarNomePapelaria = new TextBox();
            tabPage3 = new TabPage();
            button13 = new Button();
            label6 = new Label();
            comboBox1 = new ComboBox();
            listBox3 = new ListBox();
            button7 = new Button();
            button8 = new Button();
            label7 = new Label();
            label8 = new Label();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            button9 = new Button();
            button10 = new Button();
            textBox1 = new TextBox();
            label10 = new Label();
            comboBox5 = new ComboBox();
            label11 = new Label();
            comboBox6 = new ComboBox();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage2);
            tabControl.Controls.Add(tabPage3);
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(984, 596);
            tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(comboBox4);
            tabPage1.Controls.Add(PesquisarAA);
            tabPage1.Controls.Add(button12);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(FiltarTipoAcademico);
            tabPage1.Controls.Add(listBox1);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(FiltrarArtigoAcademico);
            tabPage1.Controls.Add(FiltrarLojaAcademico);
            tabPage1.Controls.Add(LimparButton);
            tabPage1.Controls.Add(PesquisarNomeAA);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(976, 563);
            tabPage1.TabIndex = 0;
            tabPage1.Tag = "Artigos Académicos";
            tabPage1.Text = "Artigos Académicos";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(443, 79);
            label9.Name = "label9";
            label9.Size = new Size(93, 20);
            label9.TabIndex = 28;
            label9.Text = "Ordenar por:";
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(443, 102);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(151, 28);
            comboBox4.TabIndex = 27;
            // 
            // PesquisarAA
            // 
            PesquisarAA.Location = new Point(54, 80);
            PesquisarAA.Name = "PesquisarAA";
            PesquisarAA.Size = new Size(86, 27);
            PesquisarAA.TabIndex = 26;
            PesquisarAA.Text = "Pesquisar";
            PesquisarAA.UseVisualStyleBackColor = true;
            PesquisarAA.Click += PesquisarAA_Click_1;
            // 
            // button12
            // 
            button12.Location = new Point(604, 488);
            button12.Name = "button12";
            button12.Size = new Size(104, 49);
            button12.TabIndex = 25;
            button12.Text = "Alterar";
            button12.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(799, 15);
            label5.Name = "label5";
            label5.Size = new Size(108, 20);
            label5.TabIndex = 24;
            label5.Text = "Filtrar por Tipo";
            // 
            // FiltarTipoAcademico
            // 
            FiltarTipoAcademico.FormattingEnabled = true;
            FiltarTipoAcademico.Location = new Point(799, 38);
            FiltarTipoAcademico.Name = "FiltarTipoAcademico";
            FiltarTipoAcademico.Size = new Size(151, 28);
            FiltarTipoAcademico.TabIndex = 23;
            FiltarTipoAcademico.SelectedIndexChanged += FiltarTipoAcademico_SelectedIndexChanged;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(54, 153);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(373, 384);
            listBox1.TabIndex = 10;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.Location = new Point(714, 488);
            button2.Name = "button2";
            button2.Size = new Size(104, 49);
            button2.TabIndex = 9;
            button2.Text = "Remover";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(600, 15);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 7;
            label2.Text = "Filtrar Artigo";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(443, 15);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 6;
            label1.Text = "Filtrar por Loja";
            label1.Click += label1_Click;
            // 
            // FiltrarArtigoAcademico
            // 
            FiltrarArtigoAcademico.FormattingEnabled = true;
            FiltrarArtigoAcademico.Location = new Point(600, 38);
            FiltrarArtigoAcademico.Name = "FiltrarArtigoAcademico";
            FiltrarArtigoAcademico.Size = new Size(193, 28);
            FiltrarArtigoAcademico.TabIndex = 4;
            FiltrarArtigoAcademico.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // FiltrarLojaAcademico
            // 
            FiltrarLojaAcademico.FormattingEnabled = true;
            FiltrarLojaAcademico.Location = new Point(443, 38);
            FiltrarLojaAcademico.Name = "FiltrarLojaAcademico";
            FiltrarLojaAcademico.Size = new Size(151, 28);
            FiltrarLojaAcademico.TabIndex = 3;
            FiltrarLojaAcademico.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // LimparButton
            // 
            LimparButton.Location = new Point(146, 79);
            LimparButton.Name = "LimparButton";
            LimparButton.Size = new Size(86, 28);
            LimparButton.TabIndex = 2;
            LimparButton.Text = "Limpar";
            LimparButton.UseVisualStyleBackColor = true;
            LimparButton.Click += button2_Click;
            // 
            // PesquisarNomeAA
            // 
            PesquisarNomeAA.Location = new Point(54, 38);
            PesquisarNomeAA.Name = "PesquisarNomeAA";
            PesquisarNomeAA.PlaceholderText = "Pesquisar por nome ...";
            PesquisarNomeAA.Size = new Size(290, 27);
            PesquisarNomeAA.TabIndex = 0;
            PesquisarNomeAA.TextChanged += textBox1_TextChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(comboBox5);
            tabPage2.Controls.Add(button11);
            tabPage2.Controls.Add(listBox2);
            tabPage2.Controls.Add(button3);
            tabPage2.Controls.Add(button4);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(FiltrarArtigoPapelaria);
            tabPage2.Controls.Add(FiltrarLojaPapelaria);
            tabPage2.Controls.Add(button5);
            tabPage2.Controls.Add(button6);
            tabPage2.Controls.Add(PesquisarNomePapelaria);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(976, 563);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Artigos de papelaria";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            button11.Location = new Point(604, 488);
            button11.Name = "button11";
            button11.Size = new Size(104, 49);
            button11.TabIndex = 21;
            button11.Text = "Alterar";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(54, 153);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(373, 384);
            listBox2.TabIndex = 20;
            // 
            // button3
            // 
            button3.Location = new Point(714, 488);
            button3.Name = "button3";
            button3.Size = new Size(104, 49);
            button3.TabIndex = 19;
            button3.Text = "Remover";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(824, 488);
            button4.Name = "button4";
            button4.Size = new Size(104, 49);
            button4.TabIndex = 18;
            button4.Text = "Adicionar";
            button4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(600, 15);
            label3.Name = "label3";
            label3.Size = new Size(120, 20);
            label3.TabIndex = 17;
            label3.Text = "Filtrar por Artigo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(443, 15);
            label4.Name = "label4";
            label4.Size = new Size(106, 20);
            label4.TabIndex = 16;
            label4.Text = "Filtrar por Loja";
            // 
            // FiltrarArtigoPapelaria
            // 
            FiltrarArtigoPapelaria.FormattingEnabled = true;
            FiltrarArtigoPapelaria.Location = new Point(600, 38);
            FiltrarArtigoPapelaria.Name = "FiltrarArtigoPapelaria";
            FiltrarArtigoPapelaria.Size = new Size(193, 28);
            FiltrarArtigoPapelaria.TabIndex = 15;
            // 
            // FiltrarLojaPapelaria
            // 
            FiltrarLojaPapelaria.FormattingEnabled = true;
            FiltrarLojaPapelaria.Location = new Point(443, 38);
            FiltrarLojaPapelaria.Name = "FiltrarLojaPapelaria";
            FiltrarLojaPapelaria.Size = new Size(151, 28);
            FiltrarLojaPapelaria.TabIndex = 14;
            // 
            // button5
            // 
            button5.Location = new Point(146, 79);
            button5.Name = "button5";
            button5.Size = new Size(86, 28);
            button5.TabIndex = 13;
            button5.Text = "Limpar";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(54, 80);
            button6.Name = "button6";
            button6.Size = new Size(86, 27);
            button6.TabIndex = 12;
            button6.Text = "Pesquisar";
            button6.UseVisualStyleBackColor = true;
            // 
            // PesquisarNomePapelaria
            // 
            PesquisarNomePapelaria.Location = new Point(54, 38);
            PesquisarNomePapelaria.Name = "PesquisarNomePapelaria";
            PesquisarNomePapelaria.PlaceholderText = "Pesquisar por nome ...";
            PesquisarNomePapelaria.Size = new Size(290, 27);
            PesquisarNomePapelaria.TabIndex = 11;
            PesquisarNomePapelaria.TextChanged += textBox1_TextChanged_1;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label11);
            tabPage3.Controls.Add(comboBox6);
            tabPage3.Controls.Add(button13);
            tabPage3.Controls.Add(label6);
            tabPage3.Controls.Add(comboBox1);
            tabPage3.Controls.Add(listBox3);
            tabPage3.Controls.Add(button7);
            tabPage3.Controls.Add(button8);
            tabPage3.Controls.Add(label7);
            tabPage3.Controls.Add(label8);
            tabPage3.Controls.Add(comboBox2);
            tabPage3.Controls.Add(comboBox3);
            tabPage3.Controls.Add(button9);
            tabPage3.Controls.Add(button10);
            tabPage3.Controls.Add(textBox1);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(976, 563);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Traje";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            button13.Location = new Point(604, 488);
            button13.Name = "button13";
            button13.Size = new Size(104, 49);
            button13.TabIndex = 37;
            button13.Text = "Alterar";
            button13.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(799, 15);
            label6.Name = "label6";
            label6.Size = new Size(126, 20);
            label6.TabIndex = 36;
            label6.Text = "Filtrar por Género";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(799, 38);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 35;
            // 
            // listBox3
            // 
            listBox3.FormattingEnabled = true;
            listBox3.Location = new Point(54, 153);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(373, 384);
            listBox3.TabIndex = 34;
            // 
            // button7
            // 
            button7.Location = new Point(714, 488);
            button7.Name = "button7";
            button7.Size = new Size(104, 49);
            button7.TabIndex = 33;
            button7.Text = "Remover";
            button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(824, 488);
            button8.Name = "button8";
            button8.Size = new Size(104, 49);
            button8.TabIndex = 32;
            button8.Text = "Adicionar";
            button8.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(600, 15);
            label7.Name = "label7";
            label7.Size = new Size(137, 20);
            label7.TabIndex = 31;
            label7.Text = "Filtrar Universidade";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(443, 15);
            label8.Name = "label8";
            label8.Size = new Size(106, 20);
            label8.TabIndex = 30;
            label8.Text = "Filtrar por Loja";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(600, 38);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(193, 28);
            comboBox2.TabIndex = 29;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(443, 38);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(151, 28);
            comboBox3.TabIndex = 28;
            // 
            // button9
            // 
            button9.Location = new Point(146, 79);
            button9.Name = "button9";
            button9.Size = new Size(86, 28);
            button9.TabIndex = 27;
            button9.Text = "Limpar";
            button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            button10.Location = new Point(54, 79);
            button10.Name = "button10";
            button10.Size = new Size(86, 27);
            button10.TabIndex = 26;
            button10.Text = "Pesquisar";
            button10.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(54, 38);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Pesquisar por nome ...";
            textBox1.Size = new Size(290, 27);
            textBox1.TabIndex = 25;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(800, 15);
            label10.Name = "label10";
            label10.Size = new Size(93, 20);
            label10.TabIndex = 30;
            label10.Text = "Ordenar por:";
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(800, 38);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(151, 28);
            comboBox5.TabIndex = 29;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(443, 79);
            label11.Name = "label11";
            label11.Size = new Size(93, 20);
            label11.TabIndex = 39;
            label11.Text = "Ordenar por:";
            // 
            // comboBox6
            // 
            comboBox6.FormattingEnabled = true;
            comboBox6.Location = new Point(443, 102);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new Size(151, 28);
            comboBox6.TabIndex = 38;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 594);
            Controls.Add(tabControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Loja Académica";
            tabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TextBox PesquisarNomeAA;
        private Button LimparButton;
        private ComboBox FiltrarArtigoAcademico;
        private ComboBox FiltrarLojaAcademico;
        private Label label1;
        private Label label2;
        private Button button2;
        private ListBox listBox1;
        private ListBox listBox2;
        private Button button3;
        private Button button4;
        private Label label3;
        private Label label4;
        private ComboBox FiltrarArtigoPapelaria;
        private ComboBox FiltrarLojaPapelaria;
        private Button button5;
        private Button button6;
        private TextBox PesquisarNomePapelaria;
        private Label label5;
        private ComboBox FiltarTipoAcademico;
        private Label label6;
        private ComboBox comboBox1;
        private ListBox listBox3;
        private Button button7;
        private Button button8;
        private Label label7;
        private Label label8;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private Button button9;
        private Button button10;
        private TextBox textBox1;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button PesquisarAA;
        private Label label9;
        private ComboBox comboBox4;
        private Label label10;
        private ComboBox comboBox5;
        private Label label11;
        private ComboBox comboBox6;
    }
}
