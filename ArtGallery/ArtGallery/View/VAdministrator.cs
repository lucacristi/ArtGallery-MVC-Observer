using ArtGallery.Controller;
using ArtGallery.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ArtGallery.View
{
    public partial class VAdministrator : Form, Observer
    {
        private ModelArtGallery model;
        private CAdministrator cAdministrator;
        public VAdministrator(ModelArtGallery model)
        {
            InitializeComponent();
            this.dataGridViewOpere.AllowUserToAddRows = false;
            this.dataGridViewUseri.AllowUserToAddRows = false;

            for (int i = 0; i < dataGridViewOpere.ColumnCount; i++)
                this.dataGridViewOpere.Columns[i].ReadOnly = true;

            for (int i = 0; i < dataGridViewUseri.ColumnCount; i++)
                this.dataGridViewUseri.Columns[i].ReadOnly = true;
            this.model = model;
            cAdministrator = new CAdministrator(this);
            model.Attach(this);
            model.Attach(cAdministrator);
            updateLanguage();
        }

        public CAdministrator GetCAdministrator()
        {
            return cAdministrator;
        }

        public ModelArtGallery GetModelArtGallery()
        {
            return model;
        }

        public ComboBox GetComboBoxCriteriuOpere()
        {
            return this.comboBoxCriteriuOpere;
        }
        public ComboBox GetComboBoxTipUtilizator()
        {
            return this.comboBoxTipUser;
        }
        public ComboBox GetComboBoxCriteriuUtilizatori()
        {
            return this.comboBoxCriteriuUseri;
        } 

        public TextBox GetTextInformatieOpere()
        {
            return this.textBoxInformatieCautata;
        }
        public TextBox GetTextBoxUsername()
        {
            return this.txtUsername;
        }
        public TextBox GetTextBoxPassword()
        {
            return this.txtPassword;
        }
        public TextBox GetTextBoxInformatieUtilizatori()
        {
            return this.textBoxInformatieUseri;
        }

        public Button GetButtonCautareOpere()
        {
            return this.buttonCautaOpere;
        }
        public Button GetButtonRefreshOpere()
        {
            return this.buttonRefreshOpere;
        }
        public Button GetButtonLogout()
        {
            return this.buttonLogOut;
        }
        public Button GetButtonRefreshUtilizatori()
        {
            return this.buttonRefreshUseri;
        }
        public Button GetButtonStergereUtilizator()
        {
            return this.buttonStergeUser;
        }
        public Button GetButtonAdaugaUtilizator()
        {
            return this.buttonAdaugaUser;
        }
        public Button GetButtonEditeazaUtilizator()
        {
            return this.buttonEditeazaUser;
        }
        public Button GetButtonCautaUtilizatori()
        {
            return this.buttonSearchUseri;
        }

        public Button GetButtonRomana()
        {
            return buttonRomana;
        }

        public Button GetButtonEngleza()
        {
            return buttonEngleza;
        }

        public Button GetButtonItaliana()
        {
            return buttonItaliana;
        }

        public Button GetButtonSpaniola()
        {
            return buttonSpaniola;
        }

        public Label GetUsernameLabel()
        {
            return this.labelDisplayUsername;
        }

        public DataGridView GetDataGridViewOpere()
        {
            return this.dataGridViewOpere;
        }
        public DataGridView GetDataGridViewUtilizatori()
        {
            return this.dataGridViewUseri;
        }

        public void Update()
        {

            if (model.GetTipOperatie().ToLower() == "vizualizare")
            {
                List<OperaArta> listaOpere = model.GetPersistentaOperaArta().ListareOpere();
                this.setareTabel(listaOpere);
            }

            else if (model.GetTipOperatie().ToLower() == "cautaretipopera")
            {
                string informatieCautata = model.GetInformatieCautata();
                List<OperaArta> listaOpere = model.GetPersistentaOperaArta().FiltrareOpereTip(informatieCautata);
                this.setareTabel(listaOpere);
            }
            else if (model.GetTipOperatie().ToLower() == "cautaretitlu")
            {
                string informatieCautata = model.GetInformatieCautata();
                List<OperaArta> listaOpere = model.GetPersistentaOperaArta().FiltrareOpereTitlu(informatieCautata);
                this.setareTabel(listaOpere);
            }
            else if (model.GetTipOperatie().ToLower() == "cautarenumeartist")
            {
                string informatieCautata = model.GetInformatieCautata();
                List<OperaArta> listaOpere = model.GetPersistentaOperaArta().FiltrareOpereArtist(informatieCautata);
                this.setareTabel(listaOpere);
            }
            else if (model.GetTipOperatie().ToLower() == "cautareanrealizare")
            {
                string informatieCautata = model.GetInformatieCautata();
                List<OperaArta> listaOpere = model.GetPersistentaOperaArta().FiltrareOpereAn(informatieCautata);
                this.setareTabel(listaOpere);
            }
            else if (model.GetTipOperatie().ToLower() == "cautaregenpictura")
            {
                string informatieCautata = model.GetInformatieCautata();
                List<OperaArta> listaOpere = model.GetPersistentaOperaArta().FiltrareOpereGenPictura(informatieCautata);
                this.setareTabel(listaOpere);
            }
            else if (model.GetTipOperatie().ToLower() == "cautaretehnicapictura")
            {
                string informatieCautata = model.GetInformatieCautata();
                List<OperaArta> listaOpere = model.GetPersistentaOperaArta().FiltrareOpereTehnicaPictura(informatieCautata);
                this.setareTabel(listaOpere);
            }
            else if (model.GetTipOperatie().ToLower() == "cautaretipsculptura")
            {
                string informatieCautata = model.GetInformatieCautata();
                List<OperaArta> listaOpere = model.GetPersistentaOperaArta().FiltrareOpereTipSculptura(informatieCautata);
                this.setareTabel(listaOpere);
            }
            else if (model.GetTipOperatie().ToLower() == "limba")
            {
                updateLanguage();
            }
            if (model.GetTipOperatie().ToLower() == "selectieuseri")
            {
                Utilizator utilizator = model.GetUtilizator();
                if (utilizator != null)
                {                    
                    txtUsername.Text = (string)utilizator.GetUsername();
                    txtPassword.Text = (string)utilizator.GetPassword();
                    if (utilizator.GetTipUtilizator().Equals("administrator"))
                    {
                        comboBoxTipUser.SelectedIndex = 1;
                    }
                    else
                    {
                        comboBoxTipUser.SelectedIndex = 0;
                    }                    
                }
                else
                {
                    this.txtUsername.Text = "";
                    this.txtPassword.Text = "";
                    
                }
            }
            else if (model.GetTipOperatie().ToLower() == "vizualizareuseri")
            {
                List<Utilizator> listaUtilizatori = model.GetPersistentaUtilizator().ListareUtilizatori();
                setareTabelUtilizatori(listaUtilizatori);
            }
            else if (model.GetTipOperatie().ToLower() == "adaugareuseri")
            {
                txtUsername.Text = "";
                txtPassword.Text = "";                
                List<Utilizator> listaUtilizatori = this.model.GetPersistentaUtilizator().ListareUtilizatori();
                this.setareTabelUtilizatori(listaUtilizatori);
            }
            else if (model.GetTipOperatie().ToLower() == "actualizareuseri")
            {
                txtUsername.Text = "";
                txtPassword.Text = "";
                List<Utilizator> listaUtilizatori = this.model.GetPersistentaUtilizator().ListareUtilizatori();
                this.setareTabelUtilizatori(listaUtilizatori);
            }
            else if (model.GetTipOperatie().ToLower() == "stergereuseri")
            {
                txtUsername.Text = "";
                txtPassword.Text = "";
                List<Utilizator> listaUtilizatori = this.model.GetPersistentaUtilizator().ListareUtilizatori();
                this.setareTabelUtilizatori(listaUtilizatori);
            }
            else if (model.GetTipOperatie().ToLower() == "cautaretipuser")
            {
                string informatieCautata = model.GetInformatieCautata();
                List<Utilizator> listaUtilizatori = model.GetPersistentaUtilizator().FiltrareUtilizatoriTip(informatieCautata);
                this.setareTabelUtilizatori(listaUtilizatori);
            }
            else if (model.GetTipOperatie().ToLower() == "cautareusername")
            {
                string informatieCautata = model.GetInformatieCautata();
                List<Utilizator> listaUtilizatori = model.GetPersistentaUtilizator().FiltrareUtilizatoriUsername(informatieCautata);
                this.setareTabelUtilizatori(listaUtilizatori);
            }
        }

        private void updateLanguage()
        {
            try
            {
                //partea de opere
                Dictionary<string, string> date = this.model.GetLimba().CautareInformatie();
                this.labelListaOpere.Text = date["lista_opere"];
                this.dataGridViewOpere.Columns[0].HeaderText = date["tip_opera"];
                this.dataGridViewOpere.Columns[1].HeaderText = date["titlu_opera"];
                this.dataGridViewOpere.Columns[2].HeaderText = date["nume_artist"];
                this.dataGridViewOpere.Columns[3].HeaderText = date["an_ralizare_opera"];
                this.dataGridViewOpere.Columns[4].HeaderText = date["gen_pictura"];
                this.dataGridViewOpere.Columns[5].HeaderText = date["tehnica_pictura"];
                this.dataGridViewOpere.Columns[6].HeaderText = date["tip_sculptura"];
                this.dataGridViewOpere.Text = date["actualizare"];

                this.labelCriteriuFiltrareOpere.Text = date["criteriu_filtrare"];
                this.labelInformatieCautata.Text = date["informatie_cautata"];
                this.buttonCautaOpere.Text = date["cauta"];

                this.comboBoxCriteriuOpere.Items.Clear();
                this.comboBoxCriteriuOpere.Items.Add(date["tip_opera"]);
                this.comboBoxCriteriuOpere.Items.Add(date["titlu_opera"]);
                this.comboBoxCriteriuOpere.Items.Add(date["nume_artist"]);
                this.comboBoxCriteriuOpere.Items.Add(date["an_ralizare_opera"]);
                this.comboBoxCriteriuOpere.Items.Add(date["gen_pictura"]);
                this.comboBoxCriteriuOpere.Items.Add(date["tehnica_pictura"]);
                this.comboBoxCriteriuOpere.Items.Add(date["tip_sculptura"]);

                //partea de useri
                this.labelListaUseri.Text = date["lista_utilizatori"];
                labelUsername.Text = date["username"];
                labelPassword.Text = date["password"];
                labelTipUser.Text = date["tip_utilizator"];

                this.comboBoxTipUser.Items.Clear();
                this.comboBoxTipUser.Items.Add(date["angajat"]);
                this.comboBoxTipUser.Items.Add(date["administrator"]);

                this.dataGridViewUseri.Columns[0].HeaderText = date["username"];
                this.dataGridViewUseri.Columns[1].HeaderText = date["password"];
                this.dataGridViewUseri.Columns[2].HeaderText = date["tip_utilizator"];

                buttonAdaugaUser.Text = date["adauga"];
                buttonEditeazaUser.Text = date["editeaza"];
                buttonStergeUser.Text = date["sterge"];
                buttonRefreshUseri.Text = date["actualizare"];

                labelCriteriuFiltrareUseri.Text = date["criteriu_filtrare_utilizatori"];
                labelInformatieUseri.Text = date["informatie_cautata"];

                this.comboBoxCriteriuUseri.Items.Clear();
                this.comboBoxCriteriuUseri.Items.Add(date["username"]);
                this.comboBoxCriteriuUseri.Items.Add(date["tip_utilizator"]);

                this.buttonSearchUseri.Text = date["cauta"];
                this.buttonLogOut.Text = date["deconectare"];


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void setareTabel(List<OperaArta> lista)
        {
            this.dataGridViewOpere.Rows.Clear();
            if (lista != null)
            {
                foreach (OperaArta opera in lista)
                {
                    DataGridViewRow rand = new DataGridViewRow();
                    rand.CreateCells(this.dataGridViewOpere);

                    if (opera is Tablou)
                    {
                        Tablou tablou = (Tablou)opera;

                        rand.Cells[0].Value = "Tablou";
                        rand.Cells[4].Value = tablou.GetGenPictura();
                        rand.Cells[5].Value = tablou.GetTehnica();
                    }
                    else if (opera is Sculptura)
                    {
                        Sculptura sculptura = (Sculptura)opera;

                        rand.Cells[0].Value = "Sculptura";
                        rand.Cells[6].Value = sculptura.GetTip();
                    }
                    else
                    {
                        rand.Cells[0].Value = "Opera de Arta";
                    }

                    rand.Cells[1].Value = opera.GetTitlu();
                    rand.Cells[2].Value = opera.GetNumeArtist();
                    rand.Cells[3].Value = opera.GetAnRealizare();



                    this.dataGridViewOpere.Rows.Add(rand);
                }
                if (lista.Count == 0)
                    MessageBox.Show("Nicio opera gasita", "Informare");
            }
        }

        private void setareTabelUtilizatori(List<Utilizator> lista)
        {
            this.dataGridViewUseri.Rows.Clear();
            if (lista != null)
            {
                foreach (Utilizator utilizator in lista)
                {
                    DataGridViewRow rand = new DataGridViewRow();
                    rand.CreateCells(this.dataGridViewUseri);                   

                    rand.Cells[0].Value = utilizator.GetUsername();
                    rand.Cells[1].Value = utilizator.GetPassword();
                    rand.Cells[2].Value = utilizator.GetTipUtilizator();

                    this.dataGridViewUseri.Rows.Add(rand);
                }
                if (lista.Count == 0)
                    MessageBox.Show("Nicio opera gasita", "Informare");
            }
        }
    }
}
