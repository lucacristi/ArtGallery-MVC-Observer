namespace ArtGallery.View
{
    partial class VAdministrator
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
            this.buttonCautaOpere = new System.Windows.Forms.Button();
            this.labelInformatieCautata = new System.Windows.Forms.Label();
            this.textBoxInformatieCautata = new System.Windows.Forms.TextBox();
            this.comboBoxCriteriuOpere = new System.Windows.Forms.ComboBox();
            this.labelCriteriuFiltrareOpere = new System.Windows.Forms.Label();
            this.buttonRefreshOpere = new System.Windows.Forms.Button();
            this.labelListaOpere = new System.Windows.Forms.Label();
            this.dataGridViewOpere = new System.Windows.Forms.DataGridView();
            this.TipOpera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Titlu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeArtist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnRealizare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenPictura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TehnicaPictura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipSculptura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonRefreshUseri = new System.Windows.Forms.Button();
            this.labelListaUseri = new System.Windows.Forms.Label();
            this.dataGridViewUseri = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.labelTipUser = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.comboBoxTipUser = new System.Windows.Forms.ComboBox();
            this.buttonAdaugaUser = new System.Windows.Forms.Button();
            this.buttonStergeUser = new System.Windows.Forms.Button();
            this.buttonEditeazaUser = new System.Windows.Forms.Button();
            this.comboBoxCriteriuUseri = new System.Windows.Forms.ComboBox();
            this.labelCriteriuFiltrareUseri = new System.Windows.Forms.Label();
            this.labelDisplayUsername = new System.Windows.Forms.Label();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.labelInformatieUseri = new System.Windows.Forms.Label();
            this.textBoxInformatieUseri = new System.Windows.Forms.TextBox();
            this.buttonSearchUseri = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOpere)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUseri)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCautaOpere
            // 
            this.buttonCautaOpere.Location = new System.Drawing.Point(1037, 275);
            this.buttonCautaOpere.Name = "buttonCautaOpere";
            this.buttonCautaOpere.Size = new System.Drawing.Size(75, 33);
            this.buttonCautaOpere.TabIndex = 15;
            this.buttonCautaOpere.Text = "Cauta";
            this.buttonCautaOpere.UseVisualStyleBackColor = true;
            // 
            // labelInformatieCautata
            // 
            this.labelInformatieCautata.AutoSize = true;
            this.labelInformatieCautata.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInformatieCautata.Location = new System.Drawing.Point(1034, 199);
            this.labelInformatieCautata.Name = "labelInformatieCautata";
            this.labelInformatieCautata.Size = new System.Drawing.Size(296, 29);
            this.labelInformatieCautata.TabIndex = 14;
            this.labelInformatieCautata.Text = "INFORMATIE CAUTATA";
            // 
            // textBoxInformatieCautata
            // 
            this.textBoxInformatieCautata.Location = new System.Drawing.Point(1037, 231);
            this.textBoxInformatieCautata.Name = "textBoxInformatieCautata";
            this.textBoxInformatieCautata.Size = new System.Drawing.Size(189, 22);
            this.textBoxInformatieCautata.TabIndex = 13;
            // 
            // comboBoxCriteriuOpere
            // 
            this.comboBoxCriteriuOpere.FormattingEnabled = true;
            this.comboBoxCriteriuOpere.Items.AddRange(new object[] {
            "Tip Opera",
            "Titlu Opera",
            "Nume Artist",
            "An Realizare",
            "Gen Pictura",
            "Tehnica Pictura",
            "Tip Sculptura"});
            this.comboBoxCriteriuOpere.Location = new System.Drawing.Point(1037, 157);
            this.comboBoxCriteriuOpere.Name = "comboBoxCriteriuOpere";
            this.comboBoxCriteriuOpere.Size = new System.Drawing.Size(189, 24);
            this.comboBoxCriteriuOpere.TabIndex = 12;
            this.comboBoxCriteriuOpere.Text = "Tip Opera";
            // 
            // labelCriteriuFiltrareOpere
            // 
            this.labelCriteriuFiltrareOpere.AutoSize = true;
            this.labelCriteriuFiltrareOpere.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCriteriuFiltrareOpere.Location = new System.Drawing.Point(1034, 116);
            this.labelCriteriuFiltrareOpere.Name = "labelCriteriuFiltrareOpere";
            this.labelCriteriuFiltrareOpere.Size = new System.Drawing.Size(359, 29);
            this.labelCriteriuFiltrareOpere.TabIndex = 11;
            this.labelCriteriuFiltrareOpere.Text = "CRITERIU FILTRARE OPERE";
            // 
            // buttonRefreshOpere
            // 
            this.buttonRefreshOpere.Location = new System.Drawing.Point(424, 324);
            this.buttonRefreshOpere.Name = "buttonRefreshOpere";
            this.buttonRefreshOpere.Size = new System.Drawing.Size(75, 32);
            this.buttonRefreshOpere.TabIndex = 10;
            this.buttonRefreshOpere.Text = "Refresh";
            this.buttonRefreshOpere.UseVisualStyleBackColor = true;
            // 
            // labelListaOpere
            // 
            this.labelListaOpere.AutoSize = true;
            this.labelListaOpere.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListaOpere.Location = new System.Drawing.Point(106, 54);
            this.labelListaOpere.Name = "labelListaOpere";
            this.labelListaOpere.Size = new System.Drawing.Size(276, 26);
            this.labelListaOpere.TabIndex = 9;
            this.labelListaOpere.Text = "LISTA OPERE DE ARTA";
            // 
            // dataGridViewOpere
            // 
            this.dataGridViewOpere.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOpere.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TipOpera,
            this.Titlu,
            this.NumeArtist,
            this.AnRealizare,
            this.GenPictura,
            this.TehnicaPictura,
            this.TipSculptura});
            this.dataGridViewOpere.Location = new System.Drawing.Point(12, 102);
            this.dataGridViewOpere.Name = "dataGridViewOpere";
            this.dataGridViewOpere.RowTemplate.Height = 24;
            this.dataGridViewOpere.Size = new System.Drawing.Size(944, 207);
            this.dataGridViewOpere.TabIndex = 8;
            // 
            // TipOpera
            // 
            this.TipOpera.HeaderText = "Tip Opera";
            this.TipOpera.Name = "TipOpera";
            // 
            // Titlu
            // 
            this.Titlu.HeaderText = "Titlu Opera";
            this.Titlu.Name = "Titlu";
            // 
            // NumeArtist
            // 
            this.NumeArtist.HeaderText = "Nume Artist";
            this.NumeArtist.Name = "NumeArtist";
            this.NumeArtist.Width = 120;
            // 
            // AnRealizare
            // 
            this.AnRealizare.HeaderText = "An Realizare";
            this.AnRealizare.Name = "AnRealizare";
            this.AnRealizare.Width = 70;
            // 
            // GenPictura
            // 
            this.GenPictura.HeaderText = "Gen Pictura";
            this.GenPictura.Name = "GenPictura";
            this.GenPictura.Width = 90;
            // 
            // TehnicaPictura
            // 
            this.TehnicaPictura.HeaderText = "Tehnica Pictura";
            this.TehnicaPictura.Name = "TehnicaPictura";
            this.TehnicaPictura.Width = 90;
            // 
            // TipSculptura
            // 
            this.TipSculptura.HeaderText = "Tip Sculptura";
            this.TipSculptura.Name = "TipSculptura";
            this.TipSculptura.Width = 90;
            // 
            // buttonRefreshUseri
            // 
            this.buttonRefreshUseri.Location = new System.Drawing.Point(881, 712);
            this.buttonRefreshUseri.Name = "buttonRefreshUseri";
            this.buttonRefreshUseri.Size = new System.Drawing.Size(75, 32);
            this.buttonRefreshUseri.TabIndex = 18;
            this.buttonRefreshUseri.Text = "Refresh";
            this.buttonRefreshUseri.UseVisualStyleBackColor = true;
            // 
            // labelListaUseri
            // 
            this.labelListaUseri.AutoSize = true;
            this.labelListaUseri.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListaUseri.Location = new System.Drawing.Point(627, 402);
            this.labelListaUseri.Name = "labelListaUseri";
            this.labelListaUseri.Size = new System.Drawing.Size(226, 26);
            this.labelListaUseri.TabIndex = 17;
            this.labelListaUseri.Text = "LISTA UTILIZATORI";
            // 
            // dataGridViewUseri
            // 
            this.dataGridViewUseri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUseri.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dataGridViewUseri.Location = new System.Drawing.Point(513, 450);
            this.dataGridViewUseri.Name = "dataGridViewUseri";
            this.dataGridViewUseri.RowTemplate.Height = 24;
            this.dataGridViewUseri.Size = new System.Drawing.Size(443, 240);
            this.dataGridViewUseri.TabIndex = 16;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Username";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Password";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Tip User";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(137, 545);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(292, 30);
            this.txtPassword.TabIndex = 23;
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(137, 482);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(292, 30);
            this.txtUsername.TabIndex = 22;
            // 
            // labelTipUser
            // 
            this.labelTipUser.AutoSize = true;
            this.labelTipUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipUser.Location = new System.Drawing.Point(41, 601);
            this.labelTipUser.Name = "labelTipUser";
            this.labelTipUser.Size = new System.Drawing.Size(83, 25);
            this.labelTipUser.TabIndex = 21;
            this.labelTipUser.Text = "tip user";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Location = new System.Drawing.Point(20, 548);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(104, 25);
            this.labelPassword.TabIndex = 20;
            this.labelPassword.Text = "password";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.Location = new System.Drawing.Point(17, 485);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(107, 25);
            this.labelUsername.TabIndex = 19;
            this.labelUsername.Text = "username";
            // 
            // comboBoxTipUser
            // 
            this.comboBoxTipUser.FormattingEnabled = true;
            this.comboBoxTipUser.Items.AddRange(new object[] {
            "angajat",
            "administrator"});
            this.comboBoxTipUser.Location = new System.Drawing.Point(137, 605);
            this.comboBoxTipUser.Name = "comboBoxTipUser";
            this.comboBoxTipUser.Size = new System.Drawing.Size(292, 24);
            this.comboBoxTipUser.TabIndex = 24;
            this.comboBoxTipUser.Text = "angajat";
            // 
            // buttonAdaugaUser
            // 
            this.buttonAdaugaUser.Location = new System.Drawing.Point(513, 712);
            this.buttonAdaugaUser.Name = "buttonAdaugaUser";
            this.buttonAdaugaUser.Size = new System.Drawing.Size(83, 33);
            this.buttonAdaugaUser.TabIndex = 25;
            this.buttonAdaugaUser.Text = "Adauga";
            this.buttonAdaugaUser.UseVisualStyleBackColor = true;
            // 
            // buttonStergeUser
            // 
            this.buttonStergeUser.Location = new System.Drawing.Point(759, 712);
            this.buttonStergeUser.Name = "buttonStergeUser";
            this.buttonStergeUser.Size = new System.Drawing.Size(75, 32);
            this.buttonStergeUser.TabIndex = 26;
            this.buttonStergeUser.Text = "Sterge";
            this.buttonStergeUser.UseVisualStyleBackColor = true;
            // 
            // buttonEditeazaUser
            // 
            this.buttonEditeazaUser.Location = new System.Drawing.Point(632, 713);
            this.buttonEditeazaUser.Name = "buttonEditeazaUser";
            this.buttonEditeazaUser.Size = new System.Drawing.Size(75, 33);
            this.buttonEditeazaUser.TabIndex = 27;
            this.buttonEditeazaUser.Text = "Editeaza";
            this.buttonEditeazaUser.UseVisualStyleBackColor = true;
            // 
            // comboBoxCriteriuUseri
            // 
            this.comboBoxCriteriuUseri.FormattingEnabled = true;
            this.comboBoxCriteriuUseri.Items.AddRange(new object[] {
            "Username",
            "Tip User"});
            this.comboBoxCriteriuUseri.Location = new System.Drawing.Point(1039, 519);
            this.comboBoxCriteriuUseri.Name = "comboBoxCriteriuUseri";
            this.comboBoxCriteriuUseri.Size = new System.Drawing.Size(187, 24);
            this.comboBoxCriteriuUseri.TabIndex = 29;
            this.comboBoxCriteriuUseri.Text = "Username";
            // 
            // labelCriteriuFiltrareUseri
            // 
            this.labelCriteriuFiltrareUseri.AutoSize = true;
            this.labelCriteriuFiltrareUseri.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCriteriuFiltrareUseri.Location = new System.Drawing.Point(1034, 465);
            this.labelCriteriuFiltrareUseri.Name = "labelCriteriuFiltrareUseri";
            this.labelCriteriuFiltrareUseri.Size = new System.Drawing.Size(426, 29);
            this.labelCriteriuFiltrareUseri.TabIndex = 28;
            this.labelCriteriuFiltrareUseri.Text = "CRITERIU FILTRARE UTILIZATORI";
            // 
            // labelDisplayUsername
            // 
            this.labelDisplayUsername.AutoSize = true;
            this.labelDisplayUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDisplayUsername.Location = new System.Drawing.Point(1151, 20);
            this.labelDisplayUsername.Name = "labelDisplayUsername";
            this.labelDisplayUsername.Size = new System.Drawing.Size(128, 29);
            this.labelDisplayUsername.TabIndex = 41;
            this.labelDisplayUsername.Text = "username";
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Location = new System.Drawing.Point(1420, 718);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(69, 28);
            this.buttonLogOut.TabIndex = 42;
            this.buttonLogOut.Text = "Log out";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            // 
            // labelInformatieUseri
            // 
            this.labelInformatieUseri.AutoSize = true;
            this.labelInformatieUseri.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInformatieUseri.Location = new System.Drawing.Point(1032, 565);
            this.labelInformatieUseri.Name = "labelInformatieUseri";
            this.labelInformatieUseri.Size = new System.Drawing.Size(296, 29);
            this.labelInformatieUseri.TabIndex = 44;
            this.labelInformatieUseri.Text = "INFORMATIE CAUTATA";
            // 
            // textBoxInformatieUseri
            // 
            this.textBoxInformatieUseri.Location = new System.Drawing.Point(1037, 607);
            this.textBoxInformatieUseri.Name = "textBoxInformatieUseri";
            this.textBoxInformatieUseri.Size = new System.Drawing.Size(189, 22);
            this.textBoxInformatieUseri.TabIndex = 43;
            // 
            // buttonSearchUseri
            // 
            this.buttonSearchUseri.Location = new System.Drawing.Point(1039, 656);
            this.buttonSearchUseri.Name = "buttonSearchUseri";
            this.buttonSearchUseri.Size = new System.Drawing.Size(75, 34);
            this.buttonSearchUseri.TabIndex = 45;
            this.buttonSearchUseri.Text = "Cauta";
            this.buttonSearchUseri.UseVisualStyleBackColor = true;
            // 
            // VAdministrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1514, 757);
            this.Controls.Add(this.buttonSearchUseri);
            this.Controls.Add(this.labelInformatieUseri);
            this.Controls.Add(this.textBoxInformatieUseri);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.labelDisplayUsername);
            this.Controls.Add(this.comboBoxCriteriuUseri);
            this.Controls.Add(this.labelCriteriuFiltrareUseri);
            this.Controls.Add(this.buttonEditeazaUser);
            this.Controls.Add(this.buttonStergeUser);
            this.Controls.Add(this.buttonAdaugaUser);
            this.Controls.Add(this.comboBoxTipUser);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.labelTipUser);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.buttonRefreshUseri);
            this.Controls.Add(this.labelListaUseri);
            this.Controls.Add(this.dataGridViewUseri);
            this.Controls.Add(this.buttonCautaOpere);
            this.Controls.Add(this.labelInformatieCautata);
            this.Controls.Add(this.textBoxInformatieCautata);
            this.Controls.Add(this.comboBoxCriteriuOpere);
            this.Controls.Add(this.labelCriteriuFiltrareOpere);
            this.Controls.Add(this.buttonRefreshOpere);
            this.Controls.Add(this.labelListaOpere);
            this.Controls.Add(this.dataGridViewOpere);
            this.Name = "VAdministrator";
            this.Text = "VOperaArtaAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOpere)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUseri)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCautaOpere;
        private System.Windows.Forms.Label labelInformatieCautata;
        private System.Windows.Forms.TextBox textBoxInformatieCautata;
        private System.Windows.Forms.ComboBox comboBoxCriteriuOpere;
        private System.Windows.Forms.Label labelCriteriuFiltrareOpere;
        private System.Windows.Forms.Button buttonRefreshOpere;
        private System.Windows.Forms.Label labelListaOpere;
        private System.Windows.Forms.DataGridView dataGridViewOpere;
        private System.Windows.Forms.Button buttonRefreshUseri;
        private System.Windows.Forms.Label labelListaUseri;
        private System.Windows.Forms.DataGridView dataGridViewUseri;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label labelTipUser;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.ComboBox comboBoxTipUser;
        private System.Windows.Forms.Button buttonAdaugaUser;
        private System.Windows.Forms.Button buttonStergeUser;
        private System.Windows.Forms.Button buttonEditeazaUser;
        private System.Windows.Forms.ComboBox comboBoxCriteriuUseri;
        private System.Windows.Forms.Label labelCriteriuFiltrareUseri;
        private System.Windows.Forms.Label labelDisplayUsername;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipOpera;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titlu;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeArtist;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnRealizare;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenPictura;
        private System.Windows.Forms.DataGridViewTextBoxColumn TehnicaPictura;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipSculptura;
        private System.Windows.Forms.Label labelInformatieUseri;
        private System.Windows.Forms.TextBox textBoxInformatieUseri;
        private System.Windows.Forms.Button buttonSearchUseri;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}