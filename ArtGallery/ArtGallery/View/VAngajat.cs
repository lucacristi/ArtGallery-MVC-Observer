using ArtGallery.Controller;
using ArtGallery.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ArtGallery.View
{
    public partial class VAngajat : Form, Observer
    {
        private ModelArtGallery model;
        private CAngajat cAngajat;

        public VAngajat(ModelArtGallery model)
        {
            InitializeComponent();
            this.dataGridView1.AllowUserToAddRows = false;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                this.dataGridView1.Columns[i].ReadOnly = true;
            this.model = model;
            cAngajat = new CAngajat(this);
            model.Attach(this);
            model.Attach(cAngajat);
            updateLanguage();
        }

        public CAngajat GetCAngajat()
        {
            return cAngajat;
        }

        public ModelArtGallery GetModelArtGallery()
        {
            return model;
        }

        public ComboBox GetComboBoxCriteriu()
        {
            return this.comboBoxCriteriu;
        }
        public ComboBox GetComboBoxTipOpera()
        {
            return this.comboBoxTipOpera;
        }

        public TextBox GetTextInformatie()
        {
            return this.textBoxInformatieCautata;
        }
        public TextBox GetTextTitlu()
        {
            return this.textBoxTitlu;
        }
        public TextBox GetTextNumeArtist()
        {
            return this.textBoxNumeArtist;
        }
        public TextBox GetTextAnRealizare()
        {
            return this.textBoxAnRealizare;
        }
        public TextBox GetTextGenTip()
        {
            return this.textBoxGen_Tip;
        }
        public TextBox GetTextTehnica()
        {
            return this.textBoxTehnica;
        }

        public Button GetButtonCautare()
        {
            return this.buttonCauta;
        }
        public Button GetButtonRefresh()
        {
            return this.buttonRefresh;
        }
        public Button GetButtonAdauga()
        {
            return this.buttonAdauga;
        }
        public Button GetButtonSterge()
        {
            return this.buttonSterge;
        }
        public Button GetButtonEditeaza()
        {
            return this.buttonEdit;
        }
        public Button GetButtonLogout()
        {
            return this.buttonLogout;
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
        public Label GetLabelGenTip()
        {
            return this.labelGen_Tip;
        }
        public Label GetLabelTehnica()
        {
            return this.labelTehnica;
        }

        public DataGridView GetDataGridViewOpere()
        {
            return this.dataGridView1;
        }

        public void Update()
        {
            if (model.GetTipOperatie().ToLower() == "selectie")
            {
                OperaArta opera = model.GetOpera();
                if (opera != null)
                {
                    if (opera is Tablou)
                    {
                        Tablou tablou = (Tablou)opera;
                       
                        this.textBoxGen_Tip.Text = tablou.GetGenPictura();
                        this.textBoxTehnica.Text = tablou.GetTehnica();
                    }
                    else if (opera is Sculptura)
                    {
                        Sculptura sculptura = (Sculptura)opera;
                        this.textBoxGen_Tip.Text = sculptura.GetTip();
                    }
                    this.textBoxTitlu.Text = (string)opera.GetTitlu();
                    this.textBoxNumeArtist.Text = (string)opera.GetNumeArtist();
                    this.textBoxAnRealizare.Text = opera.GetAnRealizare().ToString();
                }
                else
                {
                    this.textBoxTitlu.Text = "";
                    this.textBoxNumeArtist.Text = "";
                    this.textBoxAnRealizare.Text ="";
                }
            }
            else if (model.GetTipOperatie().ToLower() == "vizualizare")
            {
                List<OperaArta> listaOpere = model.GetPersistentaOperaArta().ListareOpere();
                this.setareTabel(listaOpere);
            }
            else if (model.GetTipOperatie().ToLower() == "adaugare")
            {
                textBoxTitlu.Text = "";
                textBoxNumeArtist.Text = "";
                textBoxAnRealizare.Text = "";
                textBoxGen_Tip.Text = "";
                textBoxTehnica.Text = "";
                List<OperaArta> listaOpere = this.model.GetPersistentaOperaArta().ListareOpere();
                this.setareTabel(listaOpere);
            }
            else if (model.GetTipOperatie().ToLower() == "actualizare")
            {
                textBoxTitlu.Text = "";
                textBoxNumeArtist.Text = "";
                textBoxAnRealizare.Text = "";
                textBoxGen_Tip.Text = "";
                textBoxTehnica.Text = "";
                List<OperaArta> listaOpere = this.model.GetPersistentaOperaArta().ListareOpere();
                this.setareTabel(listaOpere);
            }
            else if (model.GetTipOperatie().ToLower() == "stergere")
            {
                textBoxTitlu.Text = "";
                textBoxNumeArtist.Text = "";
                textBoxAnRealizare.Text = "";
                textBoxGen_Tip.Text = "";
                textBoxTehnica.Text = "";
                List<OperaArta> listaOpere = this.model.GetPersistentaOperaArta().ListareOpere();
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
            else if (this.model.GetTipOperatie().ToLower() == "limba")
            {
                updateLanguage();
            }
        }

        private void updateLanguage()
        {
            try
            {
                Dictionary<string, string> date = this.model.GetLimba().CautareInformatie();
                this.labelListaOpere.Text = date["lista_opere"];

                this.dataGridView1.Columns[0].HeaderText = date["tip_opera"];
                this.dataGridView1.Columns[1].HeaderText = date["titlu_opera"];
                this.dataGridView1.Columns[2].HeaderText = date["nume_artist"];
                this.dataGridView1.Columns[3].HeaderText = date["an_ralizare_opera"];
                this.dataGridView1.Columns[4].HeaderText = date["gen_pictura"];
                this.dataGridView1.Columns[5].HeaderText = date["tehnica_pictura"];
                this.dataGridView1.Columns[6].HeaderText = date["tip_sculptura"];

                buttonAdauga.Text = date["adauga"];
                buttonEdit.Text = date["editeaza"];
                buttonSterge.Text = date["sterge"];
                buttonRefresh.Text = date["actualizare"];

                this.labelCriteriuFiltrare.Text = date["criteriu_filtrare"];
                this.labelInformatieCautata.Text = date["informatie_cautata"];
                this.buttonCauta.Text = date["cauta"];

                labelTipOpera.Text = date["tip_opera"];
                labelTitlu.Text = date["titlu_opera"];
                labelNumeArtist.Text = date["nume_artist"];
                labelAnRealizare.Text = date["an_ralizare_opera"];
                labelGen_Tip.Text = date["gen_pictura"];
                labelTehnica.Text = date["tehnica_pictura"];

                this.comboBoxCriteriu.Items.Clear();
                this.comboBoxCriteriu.Items.Add(date["tip_opera"]);
                this.comboBoxCriteriu.Items.Add(date["titlu_opera"]);
                this.comboBoxCriteriu.Items.Add(date["nume_artist"]);
                this.comboBoxCriteriu.Items.Add(date["an_ralizare_opera"]);
                this.comboBoxCriteriu.Items.Add(date["gen_pictura"]);
                this.comboBoxCriteriu.Items.Add(date["tehnica_pictura"]);
                this.comboBoxCriteriu.Items.Add(date["tip_sculptura"]);

                buttonLogout.Text = date["deconectare"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void setareTabel(List<OperaArta> lista)
        {
            this.dataGridView1.Rows.Clear();
            if (lista != null)
            {
                foreach (OperaArta opera in lista)
                {
                    DataGridViewRow rand = new DataGridViewRow();
                    rand.CreateCells(this.dataGridView1);

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



                    this.dataGridView1.Rows.Add(rand);
                }
                if (lista.Count == 0)
                    MessageBox.Show("Nicio opera gasita", "Informare");
            }
        }
    }
}
