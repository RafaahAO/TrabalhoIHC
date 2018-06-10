namespace TrabalhoIHC
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.AUp = new System.Windows.Forms.Button();
            this.Up = new System.Windows.Forms.Button();
            this.Down = new System.Windows.Forms.Button();
            this.ADown = new System.Windows.Forms.Button();
            this.Filter = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.MainLabel = new System.Windows.Forms.Label();
            this.btn_F1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anoMesReferenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vencimentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Finalizado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Receita = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.financaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btn_F10 = new System.Windows.Forms.Button();
            this.btn_F8 = new System.Windows.Forms.Button();
            this.btn_F6 = new System.Windows.Forms.Button();
            this.btn_F4 = new System.Windows.Forms.Button();
            this.btn_F2 = new System.Windows.Forms.Button();
            this.btn_F9 = new System.Windows.Forms.Button();
            this.btn_F7 = new System.Windows.Forms.Button();
            this.btn_F5 = new System.Windows.Forms.Button();
            this.btn_F3 = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem9,
            this.menuItem5,
            this.menuItem1,
            this.menuItem13});
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 0;
            this.menuItem9.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem16,
            this.menuItem17});
            this.menuItem9.Text = "Categorias";
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 0;
            this.menuItem16.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem10,
            this.menuItem11,
            this.menuItem15,
            this.menuItem12});
            this.menuItem16.Text = "Categoria Despesas";
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 0;
            this.menuItem10.Text = "Adicionar";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 1;
            this.menuItem11.Text = "Editar";
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 2;
            this.menuItem15.Text = "Listar";
            this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 3;
            this.menuItem12.Text = "Remover";
            this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 1;
            this.menuItem17.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem18,
            this.menuItem19,
            this.menuItem20,
            this.menuItem21});
            this.menuItem17.Text = "Categoria Receitas";
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 0;
            this.menuItem18.Text = "Adicionar";
            this.menuItem18.Click += new System.EventHandler(this.menuItem18_Click);
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 1;
            this.menuItem19.Text = "Editar";
            this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 2;
            this.menuItem20.Text = "Listar";
            this.menuItem20.Click += new System.EventHandler(this.menuItem20_Click);
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 3;
            this.menuItem21.Text = "Remover";
            this.menuItem21.Click += new System.EventHandler(this.menuItem21_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 1;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem6,
            this.menuItem7,
            this.menuItem8,
            this.menuItem14});
            this.menuItem5.Text = "Contas";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 0;
            this.menuItem6.Text = "Adicionar";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 1;
            this.menuItem7.Text = "Editar";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 2;
            this.menuItem8.Text = "Remover";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 3;
            this.menuItem14.Text = "Listar";
            this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem3});
            this.menuItem1.Text = "Indicadores";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "Controle de Gastos";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click_1);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "Visão Global";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 3;
            this.menuItem13.Text = "Ajuda";
            this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
            // 
            // AUp
            // 
            this.AUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AUp.BackgroundImage")));
            this.AUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AUp.Location = new System.Drawing.Point(499, 138);
            this.AUp.Name = "AUp";
            this.AUp.Size = new System.Drawing.Size(39, 34);
            this.AUp.TabIndex = 1;
            this.AUp.UseVisualStyleBackColor = true;
            this.AUp.Click += new System.EventHandler(this.AUp_Click);
            // 
            // Up
            // 
            this.Up.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Up.BackgroundImage")));
            this.Up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Up.Location = new System.Drawing.Point(499, 178);
            this.Up.Name = "Up";
            this.Up.Size = new System.Drawing.Size(39, 34);
            this.Up.TabIndex = 2;
            this.Up.UseVisualStyleBackColor = true;
            this.Up.Click += new System.EventHandler(this.Up_Click);
            // 
            // Down
            // 
            this.Down.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Down.BackgroundImage")));
            this.Down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Down.Location = new System.Drawing.Point(499, 218);
            this.Down.Name = "Down";
            this.Down.Size = new System.Drawing.Size(39, 34);
            this.Down.TabIndex = 3;
            this.Down.UseVisualStyleBackColor = true;
            this.Down.Click += new System.EventHandler(this.Down_Click);
            // 
            // ADown
            // 
            this.ADown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ADown.BackgroundImage")));
            this.ADown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ADown.Location = new System.Drawing.Point(499, 258);
            this.ADown.Name = "ADown";
            this.ADown.Size = new System.Drawing.Size(39, 34);
            this.ADown.TabIndex = 4;
            this.ADown.UseVisualStyleBackColor = true;
            this.ADown.Click += new System.EventHandler(this.ADown_Click);
            // 
            // Filter
            // 
            this.Filter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Filter.BackgroundImage")));
            this.Filter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Filter.Location = new System.Drawing.Point(499, 298);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(39, 34);
            this.Filter.TabIndex = 5;
            this.Filter.UseVisualStyleBackColor = true;
            this.Filter.Click += new System.EventHandler(this.button1_Click);
            // 
            // Add
            // 
            this.Add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Add.BackgroundImage")));
            this.Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Add.Location = new System.Drawing.Point(499, 58);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(39, 34);
            this.Add.TabIndex = 6;
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Delete
            // 
            this.Delete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Delete.BackgroundImage")));
            this.Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Delete.Location = new System.Drawing.Point(499, 98);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(39, 34);
            this.Delete.TabIndex = 7;
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // MainLabel
            // 
            this.MainLabel.AutoSize = true;
            this.MainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.MainLabel.Location = new System.Drawing.Point(3, 9);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(195, 24);
            this.MainLabel.TabIndex = 8;
            this.MainLabel.Text = "Controle Financeiro";
            // 
            // btn_F1
            // 
            this.btn_F1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_F1.BackgroundImage")));
            this.btn_F1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_F1.Location = new System.Drawing.Point(582, 99);
            this.btn_F1.Name = "btn_F1";
            this.btn_F1.Size = new System.Drawing.Size(39, 33);
            this.btn_F1.TabIndex = 12;
            this.btn_F1.UseVisualStyleBackColor = true;
            this.btn_F1.Click += new System.EventHandler(this.btn_F1_Click);
            this.btn_F1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btn_F1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.Location = new System.Drawing.Point(604, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Filtros";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(585, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Pré-Definidos";
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.dataGridView1);
            this.MainPanel.Controls.Add(this.btn_F10);
            this.MainPanel.Controls.Add(this.btn_F8);
            this.MainPanel.Controls.Add(this.btn_F6);
            this.MainPanel.Controls.Add(this.btn_F4);
            this.MainPanel.Controls.Add(this.btn_F2);
            this.MainPanel.Controls.Add(this.btn_F9);
            this.MainPanel.Controls.Add(this.btn_F7);
            this.MainPanel.Controls.Add(this.btn_F5);
            this.MainPanel.Controls.Add(this.btn_F3);
            this.MainPanel.Controls.Add(this.label2);
            this.MainPanel.Controls.Add(this.label1);
            this.MainPanel.Controls.Add(this.btn_F1);
            this.MainPanel.Controls.Add(this.MainLabel);
            this.MainPanel.Controls.Add(this.Delete);
            this.MainPanel.Controls.Add(this.Add);
            this.MainPanel.Controls.Add(this.Filter);
            this.MainPanel.Controls.Add(this.ADown);
            this.MainPanel.Controls.Add(this.Down);
            this.MainPanel.Controls.Add(this.Up);
            this.MainPanel.Controls.Add(this.AUp);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(684, 431);
            this.MainPanel.TabIndex = 0;
            this.MainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPanel_Paint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.descricaoDataGridViewTextBoxColumn,
            this.anoMesReferenciaDataGridViewTextBoxColumn,
            this.vencimentoDataGridViewTextBoxColumn,
            this.valorDataGridViewTextBoxColumn,
            this.Finalizado,
            this.Receita});
            this.dataGridView1.DataSource = this.financaBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(7, 58);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(486, 365);
            this.dataGridView1.TabIndex = 30;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 30;
            // 
            // descricaoDataGridViewTextBoxColumn
            // 
            this.descricaoDataGridViewTextBoxColumn.DataPropertyName = "Descricao";
            this.descricaoDataGridViewTextBoxColumn.HeaderText = "Descricao";
            this.descricaoDataGridViewTextBoxColumn.Name = "descricaoDataGridViewTextBoxColumn";
            this.descricaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.descricaoDataGridViewTextBoxColumn.Width = 148;
            // 
            // anoMesReferenciaDataGridViewTextBoxColumn
            // 
            this.anoMesReferenciaDataGridViewTextBoxColumn.DataPropertyName = "AnoMesReferencia";
            this.anoMesReferenciaDataGridViewTextBoxColumn.HeaderText = "AnoMesReferencia";
            this.anoMesReferenciaDataGridViewTextBoxColumn.Name = "anoMesReferenciaDataGridViewTextBoxColumn";
            this.anoMesReferenciaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vencimentoDataGridViewTextBoxColumn
            // 
            this.vencimentoDataGridViewTextBoxColumn.DataPropertyName = "Vencimento";
            this.vencimentoDataGridViewTextBoxColumn.HeaderText = "Vencimento";
            this.vencimentoDataGridViewTextBoxColumn.Name = "vencimentoDataGridViewTextBoxColumn";
            this.vencimentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.vencimentoDataGridViewTextBoxColumn.Width = 65;
            // 
            // valorDataGridViewTextBoxColumn
            // 
            this.valorDataGridViewTextBoxColumn.DataPropertyName = "Valor";
            this.valorDataGridViewTextBoxColumn.HeaderText = "Valor";
            this.valorDataGridViewTextBoxColumn.Name = "valorDataGridViewTextBoxColumn";
            this.valorDataGridViewTextBoxColumn.ReadOnly = true;
            this.valorDataGridViewTextBoxColumn.Width = 75;
            // 
            // Finalizado
            // 
            this.Finalizado.DataPropertyName = "Pago";
            this.Finalizado.HeaderText = "Pago";
            this.Finalizado.Name = "Finalizado";
            this.Finalizado.ReadOnly = true;
            this.Finalizado.Width = 65;
            // 
            // Receita
            // 
            this.Receita.DataPropertyName = "Receita";
            this.Receita.HeaderText = "Receita";
            this.Receita.Name = "Receita";
            this.Receita.ReadOnly = true;
            this.Receita.Visible = false;
            // 
            // financaBindingSource
            // 
            this.financaBindingSource.DataSource = typeof(TrabalhoIHC.Model.Financa);
            // 
            // btn_F10
            // 
            this.btn_F10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_F10.BackgroundImage")));
            this.btn_F10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_F10.Location = new System.Drawing.Point(627, 259);
            this.btn_F10.Name = "btn_F10";
            this.btn_F10.Size = new System.Drawing.Size(39, 33);
            this.btn_F10.TabIndex = 29;
            this.btn_F10.UseVisualStyleBackColor = true;
            this.btn_F10.Click += new System.EventHandler(this.btn_F10_Click);
            this.btn_F10.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btn_F10_KeyDown);
            // 
            // btn_F8
            // 
            this.btn_F8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_F8.BackgroundImage")));
            this.btn_F8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_F8.Location = new System.Drawing.Point(627, 219);
            this.btn_F8.Name = "btn_F8";
            this.btn_F8.Size = new System.Drawing.Size(39, 33);
            this.btn_F8.TabIndex = 28;
            this.btn_F8.UseVisualStyleBackColor = true;
            this.btn_F8.Click += new System.EventHandler(this.btn_F8_Click);
            this.btn_F8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btn_F8_KeyDown);
            // 
            // btn_F6
            // 
            this.btn_F6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_F6.BackgroundImage")));
            this.btn_F6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_F6.Location = new System.Drawing.Point(627, 179);
            this.btn_F6.Name = "btn_F6";
            this.btn_F6.Size = new System.Drawing.Size(39, 33);
            this.btn_F6.TabIndex = 27;
            this.btn_F6.UseVisualStyleBackColor = true;
            this.btn_F6.Click += new System.EventHandler(this.btn_F6_Click);
            this.btn_F6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btn_F6_KeyDown);
            // 
            // btn_F4
            // 
            this.btn_F4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_F4.BackgroundImage")));
            this.btn_F4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_F4.Location = new System.Drawing.Point(627, 139);
            this.btn_F4.Name = "btn_F4";
            this.btn_F4.Size = new System.Drawing.Size(39, 33);
            this.btn_F4.TabIndex = 26;
            this.btn_F4.UseVisualStyleBackColor = true;
            this.btn_F4.Click += new System.EventHandler(this.btn_F4_Click);
            this.btn_F4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btn_F4_KeyDown);
            this.btn_F4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_F4_MouseDown);
            // 
            // btn_F2
            // 
            this.btn_F2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_F2.BackgroundImage")));
            this.btn_F2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_F2.Location = new System.Drawing.Point(627, 99);
            this.btn_F2.Name = "btn_F2";
            this.btn_F2.Size = new System.Drawing.Size(39, 33);
            this.btn_F2.TabIndex = 25;
            this.btn_F2.UseVisualStyleBackColor = true;
            this.btn_F2.Click += new System.EventHandler(this.btn_F2_Click);
            this.btn_F2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btn_F2_KeyDown);
            // 
            // btn_F9
            // 
            this.btn_F9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_F9.BackgroundImage")));
            this.btn_F9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_F9.Location = new System.Drawing.Point(582, 259);
            this.btn_F9.Name = "btn_F9";
            this.btn_F9.Size = new System.Drawing.Size(39, 33);
            this.btn_F9.TabIndex = 24;
            this.btn_F9.UseVisualStyleBackColor = true;
            this.btn_F9.Click += new System.EventHandler(this.btn_F9_Click);
            this.btn_F9.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btn_F9_KeyDown);
            // 
            // btn_F7
            // 
            this.btn_F7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_F7.BackgroundImage")));
            this.btn_F7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_F7.Location = new System.Drawing.Point(582, 219);
            this.btn_F7.Name = "btn_F7";
            this.btn_F7.Size = new System.Drawing.Size(39, 33);
            this.btn_F7.TabIndex = 23;
            this.btn_F7.UseVisualStyleBackColor = true;
            this.btn_F7.Click += new System.EventHandler(this.btn_F7_Click);
            this.btn_F7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btn_F7_KeyDown);
            // 
            // btn_F5
            // 
            this.btn_F5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_F5.BackgroundImage")));
            this.btn_F5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_F5.Location = new System.Drawing.Point(582, 179);
            this.btn_F5.Name = "btn_F5";
            this.btn_F5.Size = new System.Drawing.Size(39, 33);
            this.btn_F5.TabIndex = 22;
            this.btn_F5.UseVisualStyleBackColor = true;
            this.btn_F5.Click += new System.EventHandler(this.btn_F5_Click);
            this.btn_F5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btn_F5_KeyDown);
            // 
            // btn_F3
            // 
            this.btn_F3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_F3.BackgroundImage")));
            this.btn_F3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_F3.Location = new System.Drawing.Point(582, 139);
            this.btn_F3.Name = "btn_F3";
            this.btn_F3.Size = new System.Drawing.Size(39, 33);
            this.btn_F3.TabIndex = 21;
            this.btn_F3.UseVisualStyleBackColor = true;
            this.btn_F3.Click += new System.EventHandler(this.btn_F3_Click);
            this.btn_F3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btn_F3_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 431);
            this.Controls.Add(this.MainPanel);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "CF";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Enter += new System.EventHandler(this.Form1_Enter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem menuItem13;
        private System.Windows.Forms.Button AUp;
        private System.Windows.Forms.Button Up;
        private System.Windows.Forms.Button Down;
        private System.Windows.Forms.Button ADown;
        private System.Windows.Forms.Button Filter;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Label MainLabel;
        private System.Windows.Forms.Button btn_F1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button btn_F10;
        private System.Windows.Forms.Button btn_F8;
        private System.Windows.Forms.Button btn_F6;
        private System.Windows.Forms.Button btn_F4;
        private System.Windows.Forms.Button btn_F2;
        private System.Windows.Forms.Button btn_F9;
        private System.Windows.Forms.Button btn_F7;
        private System.Windows.Forms.Button btn_F5;
        private System.Windows.Forms.Button btn_F3;
        private System.Windows.Forms.MenuItem menuItem14;
        private System.Windows.Forms.MenuItem menuItem15;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource financaBindingSource;
        private System.Windows.Forms.MenuItem menuItem16;
        private System.Windows.Forms.MenuItem menuItem17;
        private System.Windows.Forms.MenuItem menuItem18;
        private System.Windows.Forms.MenuItem menuItem19;
        private System.Windows.Forms.MenuItem menuItem20;
        private System.Windows.Forms.MenuItem menuItem21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn anoMesReferenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vencimentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Finalizado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Receita;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
    }
}

