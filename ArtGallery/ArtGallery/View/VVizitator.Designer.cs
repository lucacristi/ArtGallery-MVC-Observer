namespace ArtGallery
{
    partial class VVizitator
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
            this.labelListaOpere = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.labelCriteriuFiltrare = new System.Windows.Forms.Label();
            this.comboBoxCriteriu = new System.Windows.Forms.ComboBox();
            this.textBoxInformatieCautata = new System.Windows.Forms.TextBox();
            this.labelInformatieCautata = new System.Windows.Forms.Label();
            this.buttonCauta = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonAutentificare = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TipOpera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Titlu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeArtist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnRealizare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenPictura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TehnicaPictura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipSculptura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelListaOpere
            // 
            this.labelListaOpere.AutoSize = true;
            this.labelListaOpere.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListaOpere.Location = new System.Drawing.Point(115, 27);
            this.labelListaOpere.Name = "labelListaOpere";
            this.labelListaOpere.Size = new System.Drawing.Size(276, 26);
            this.labelListaOpere.TabIndex = 1;
            this.labelListaOpere.Text = "LISTA OPERE DE ARTA";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(526, 345);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 2;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            // 
            // labelCriteriuFiltrare
            // 
            this.labelCriteriuFiltrare.AutoSize = true;
            this.labelCriteriuFiltrare.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCriteriuFiltrare.Location = new System.Drawing.Point(16, 404);
            this.labelCriteriuFiltrare.Name = "labelCriteriuFiltrare";
            this.labelCriteriuFiltrare.Size = new System.Drawing.Size(263, 29);
            this.labelCriteriuFiltrare.TabIndex = 3;
            this.labelCriteriuFiltrare.Text = "CRITERIU FILTRARE";
            // 
            // comboBoxCriteriu
            // 
            this.comboBoxCriteriu.FormattingEnabled = true;
            this.comboBoxCriteriu.Items.AddRange(new object[] {
            "Tip Opera",
            "Titlu Opera",
            "Nume Artist",
            "An Realizare",
            "Gen Pictura",
            "Tehnica Pictura",
            "Tip Sculptura"});
            this.comboBoxCriteriu.Location = new System.Drawing.Point(19, 445);
            this.comboBoxCriteriu.Name = "comboBoxCriteriu";
            this.comboBoxCriteriu.Size = new System.Drawing.Size(121, 24);
            this.comboBoxCriteriu.TabIndex = 4;
            this.comboBoxCriteriu.Text = "Tip Opera";
            // 
            // textBoxInformatieCautata
            // 
            this.textBoxInformatieCautata.Location = new System.Drawing.Point(19, 519);
            this.textBoxInformatieCautata.Name = "textBoxInformatieCautata";
            this.textBoxInformatieCautata.Size = new System.Drawing.Size(100, 22);
            this.textBoxInformatieCautata.TabIndex = 5;
            // 
            // labelInformatieCautata
            // 
            this.labelInformatieCautata.AutoSize = true;
            this.labelInformatieCautata.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInformatieCautata.Location = new System.Drawing.Point(16, 487);
            this.labelInformatieCautata.Name = "labelInformatieCautata";
            this.labelInformatieCautata.Size = new System.Drawing.Size(296, 29);
            this.labelInformatieCautata.TabIndex = 6;
            this.labelInformatieCautata.Text = "INFORMATIE CAUTATA";
            // 
            // buttonCauta
            // 
            this.buttonCauta.Location = new System.Drawing.Point(19, 563);
            this.buttonCauta.Name = "buttonCauta";
            this.buttonCauta.Size = new System.Drawing.Size(75, 23);
            this.buttonCauta.TabIndex = 7;
            this.buttonCauta.Text = "Cauta";
            this.buttonCauta.UseVisualStyleBackColor = true;
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(1032, 581);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 8;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            // 
            // buttonAutentificare
            // 
            this.buttonAutentificare.Location = new System.Drawing.Point(998, 12);
            this.buttonAutentificare.Name = "buttonAutentificare";
            this.buttonAutentificare.Size = new System.Drawing.Size(109, 41);
            this.buttonAutentificare.TabIndex = 9;
            this.buttonAutentificare.Text = "Autentificare";
            this.buttonAutentificare.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TipOpera,
            this.Titlu,
            this.NumeArtist,
            this.AnRealizare,
            this.GenPictura,
            this.TehnicaPictura,
            this.TipSculptura});
            this.dataGridView1.Location = new System.Drawing.Point(21, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1086, 258);
            this.dataGridView1.TabIndex = 10;
            // 
            // TipOpera
            // 
            this.TipOpera.HeaderText = "Tip Opera";
            this.TipOpera.Name = "TipOpera";
            this.TipOpera.Width = 90;
            // 
            // Titlu
            // 
            this.Titlu.HeaderText = "Titlu Opera";
            this.Titlu.Name = "Titlu";
            this.Titlu.Width = 150;
            // 
            // NumeArtist
            // 
            this.NumeArtist.HeaderText = "Nume Artist";
            this.NumeArtist.Name = "NumeArtist";
            this.NumeArtist.Width = 150;
            // 
            // AnRealizare
            // 
            this.AnRealizare.HeaderText = "An Realizare Opera";
            this.AnRealizare.Name = "AnRealizare";
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
            // VVizitator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 616);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonAutentificare);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonCauta);
            this.Controls.Add(this.labelInformatieCautata);
            this.Controls.Add(this.textBoxInformatieCautata);
            this.Controls.Add(this.comboBoxCriteriu);
            this.Controls.Add(this.labelCriteriuFiltrare);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.labelListaOpere);
            this.Name = "VVizitator";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelListaOpere;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label labelCriteriuFiltrare;
        private System.Windows.Forms.ComboBox comboBoxCriteriu;
        private System.Windows.Forms.TextBox textBoxInformatieCautata;
        private System.Windows.Forms.Label labelInformatieCautata;
        private System.Windows.Forms.Button buttonCauta;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonAutentificare;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipOpera;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titlu;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeArtist;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnRealizare;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenPictura;
        private System.Windows.Forms.DataGridViewTextBoxColumn TehnicaPictura;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipSculptura;
    }
}

