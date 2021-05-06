using ArtGallery.Model;
using ArtGallery.Model.Persistenta;
using ArtGallery.View;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ArtGallery.Controller
{
    class CAdministrator
    {
        private readonly Dictionary<string, int> indecsiGridPersoane;
        private string username;
        private VAdministrator vAdministrator;
        private PersistentaOperaArta persistentaOperaArta;
        private PersistentaUtilizatori persistentaUtilizatori;

        public CAdministrator()
        {
            indecsiGridPersoane = initializareIndecsiPersoane();
            this.vAdministrator = new VAdministrator();
            this.persistentaOperaArta = new PersistentaOperaArta();
            this.persistentaUtilizatori = new PersistentaUtilizatori();
            GestionareEvenimente();
        }

        public CAdministrator(string username)
        {
            indecsiGridPersoane = initializareIndecsiPersoane();
            this.username = username;
            vAdministrator = new VAdministrator();
            persistentaOperaArta = new PersistentaOperaArta();
            persistentaUtilizatori = new PersistentaUtilizatori();
            GestionareEvenimente();
        }

        public VAdministrator GetVAdministrator()
        {
            return this.vAdministrator;
        }

        private void GestionareEvenimente()
        {
            setUsername();

            vAdministrator.GetButtonLogout().Click += new EventHandler(logout);
            vAdministrator.GetButtonRefreshOpere().Click += new EventHandler(refreshOpere);
            vAdministrator.GetButtonCautareOpere().Click += new EventHandler(cautareOpere);

            vAdministrator.GetButtonRefreshUtilizatori().Click += new EventHandler(refreshUtilizatori);
            vAdministrator.GetButtonCautaUtilizatori().Click += new EventHandler(cautareUtilizatori);
            vAdministrator.GetButtonAdaugaUtilizator().Click += new EventHandler(adaugareUtilizator);
            vAdministrator.GetButtonEditeazaUtilizator().Click += new EventHandler(editareUtilizator);
            vAdministrator.GetButtonStergereUtilizator().Click += new EventHandler(stergereUtilizator);
            vAdministrator.GetDataGridViewUtilizatori().SelectionChanged += new EventHandler(selectieUtilizatoriInGrid);
        }

        private void setUsername()
        {
            vAdministrator.GetUsernameLabel().Text = "username: " + username;
        }

        private void logout(object sender, EventArgs e)
        {
            this.vAdministrator.Hide();
            CWelcome cWelcome = new CWelcome();
            cWelcome.GetVWelcome().Show();
        }

        private void refreshOpere(object sender, EventArgs e)
        {
            List<OperaArta> opere = persistentaOperaArta.ListareOpere();
            vAdministrator.GetDataGridViewOpere().Rows.Clear();
            if (opere != null)
            {
                foreach (OperaArta opera in opere)
                {
                    DataGridViewRow rand = new DataGridViewRow();
                    rand.CreateCells(vAdministrator.GetDataGridViewOpere());
                    rand.Cells[indecsiGridPersoane["TitluOpera"]].Value = opera.GetTitlu();
                    rand.Cells[indecsiGridPersoane["NumeArtist"]].Value = opera.GetNumeArtist();
                    rand.Cells[indecsiGridPersoane["AnRealizare"]].Value = opera.GetAnRealizare();
                    if (opera is Tablou)
                    {
                        rand.Cells[indecsiGridPersoane["TipOpera"]].Value = "tablou";
                        rand.Cells[indecsiGridPersoane["GenPictura"]].Value = ((Tablou)opera).GetGenPictura();
                        rand.Cells[indecsiGridPersoane["TehnicaTablou"]].Value = ((Tablou)opera).GetTehnica();
                    }
                    else if (opera is Sculptura)
                    {
                        rand.Cells[indecsiGridPersoane["TipOpera"]].Value = "sculptura";
                        rand.Cells[indecsiGridPersoane["TipSculptura"]].Value = ((Sculptura)opera).GetTip();
                    }
                    else
                    {
                        rand.Cells[indecsiGridPersoane["TipOpera"]].Value = "operaDeArta";
                    }
                    vAdministrator.GetDataGridViewOpere().Rows.Add(rand);
                }
            }
        }

        private void cautareOpere(object sender, EventArgs e)
        {
            int index = vAdministrator.GetComboBoxCriteriuOpere().SelectedIndex;
            string informatie = vAdministrator.GetTextInformatieOpere().Text;

            if (informatie.Length > 0)
            {
                switch (index)
                {
                    case 0:
                        cautareOpereDupaCriteriu(informatie, "tipOpera");
                        break;
                    case 1:
                        cautareOpereDupaCriteriu(informatie, "titluOpera");
                        break;
                    case 2:
                        cautareOpereDupaCriteriu(informatie, "numeArtist");
                        break;
                    case 3:
                        cautareOpereDupaCriteriu(informatie, "anRealizare");
                        break;
                    case 4:
                        cautareOpereDupaCriteriu(informatie, "genPictura");
                        break;
                    case 5:
                        cautareOpereDupaCriteriu(informatie, "tehnicaPictura");
                        break;
                    case 6:
                        cautareOpereDupaCriteriu(informatie, "tipSculptura");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Nu s-a introdus informatia cautata!");
            }
        }

        private void refreshUtilizatori(object sender, EventArgs e)
        {
            List<Utilizator> utilizatori = persistentaUtilizatori.ListareUtilizatori();
            vAdministrator.GetDataGridViewUtilizatori().Rows.Clear();
            if (utilizatori != null)
            {
                foreach (Utilizator utilizator in utilizatori)
                {
                    DataGridViewRow rand = new DataGridViewRow();
                    rand.CreateCells(vAdministrator.GetDataGridViewUtilizatori());
                    rand.Cells[0].Value = utilizator.GetUsername();
                    rand.Cells[1].Value = utilizator.GetPassword();
                    rand.Cells[2].Value = utilizator.GetTipUtilizator();
                    
                    vAdministrator.GetDataGridViewUtilizatori().Rows.Add(rand);
                }
            }
        }

        private void cautareUtilizatori(object sender, EventArgs e)
        {
            int index = vAdministrator.GetComboBoxCriteriuUtilizatori().SelectedIndex;
            string informatie = vAdministrator.GetTextBoxInformatieUtilizatori().Text;
            
            if (informatie.Length > 0)
            {
                if (index == 0)
                {
                    cautareUtilizatoriUsername(informatie);
                }
                else
                {
                    cautareUtilizatoriTip(informatie);
                }
            }
            else
            {
                MessageBox.Show("Nu s-a introdus informatia cautata!");
            }

        }

        private void adaugareUtilizator(object sender, EventArgs e)
        {

            string username = vAdministrator.GetTextBoxUsername().Text;
            string password = vAdministrator.GetTextBoxPassword().Text;       
            int indexTipUtilizator = vAdministrator.GetComboBoxTipUtilizator().SelectedIndex;

            if (username.Length > 0 && password.Length > 0)
            {
                if (persistentaUtilizatori.CautaUtilizator(username) != null)
                {
                    MessageBox.Show("Exista deja un utilizator cu username-ul \"" + username + "\"");
                }
                else
                {
                    if (indexTipUtilizator == 0)
                    {
                        Utilizator utilizator = new Utilizator(username, password, "angajat");
                        if (persistentaUtilizatori.AdaugareUtilizator(utilizator))
                        {
                            MessageBox.Show("Adaugare incheiata cu succes!");
                            clearFieldsContent();
                        }
                        else
                        {
                            MessageBox.Show("Nu s-a realizat adaugare in fisier!");
                        }
                    }
                    if (indexTipUtilizator == 1)
                    {
                        Utilizator utilizator = new Utilizator(username, password, "administrator");
                        if (persistentaUtilizatori.AdaugareUtilizator(utilizator))
                        {
                            MessageBox.Show("Adaugare incheiata cu succes!");
                            clearFieldsContent();
                        }
                        else
                        {
                            MessageBox.Show("Nu s-a realizat adaugare in fisier!");
                        }
                    }                    
                }
            }
            else
            {
                MessageBox.Show("Nu s-a introdus numele sau parola utilizatorului!");
            }

        }

        private void editareUtilizator(object sender, EventArgs e)
        {
            if (vAdministrator.GetDataGridViewUtilizatori().SelectedRows.Count == 0)
            {
                MessageBox.Show("Nu exista niciun utilizator selectat pentru a fi actualizat");
            }
            else
            {
                string selectedUsername = (string)vAdministrator.GetDataGridViewUtilizatori().SelectedRows[0].Cells[0].Value;

                string username = vAdministrator.GetTextBoxUsername().Text;
                string password = vAdministrator.GetTextBoxPassword().Text;
                int tipUtilizator = vAdministrator.GetComboBoxTipUtilizator().SelectedIndex;

                if (username.Length > 0 && password.Length > 0)
                {
                    if (persistentaUtilizatori.CautaUtilizator(selectedUsername) == null)
                    {
                        MessageBox.Show("Nu exista un utilizator cu acest username!");
                    }
                    else
                    {
                        Utilizator utilizator = new Utilizator(username, password, tipUtilizator==0?"angajat":"administrator");
                        if (persistentaUtilizatori.ActualizareUtilizator(selectedUsername, utilizator))
                        {
                            MessageBox.Show("Actualizare incheiata cu succes!");
                            clearFieldsContent();
                        }

                        else
                            MessageBox.Show("Nu s-a realizat actualizare in fisier!");
                    }
                }
                else
                    MessageBox.Show("Nu s-a introdus numele sau CNP-ul!");
            }
        }

        private void stergereUtilizator(object sender, EventArgs e)
        {
            if (vAdministrator.GetDataGridViewUtilizatori().SelectedRows.Count == 0)
            {
                MessageBox.Show("Nu exista niciun utilizator selectat pentru a fi sters");
            }
            else
            {
                string usernameSelectat = (string)vAdministrator.GetDataGridViewUtilizatori().SelectedRows[0].Cells[0].Value;
                if (persistentaUtilizatori.StergereUtilizator(usernameSelectat))
                {
                    MessageBox.Show("Stergere incheiata cu succes!");
                    refreshUtilizatori(sender, e);
                }
                else
                    MessageBox.Show("Nu s-a realizat stergere in fisier!");
            }
        }

        private void selectieUtilizatoriInGrid(object sender, EventArgs e)
        {
            if (vAdministrator.GetDataGridViewUtilizatori().SelectedRows.Count == 0)
            {
                vAdministrator.GetTextBoxUsername().Text = "";
                vAdministrator.GetTextBoxPassword().Text = "";
                vAdministrator.GetComboBoxTipUtilizator().SelectedIndex = 0;
            }
            else
            {
                string username = (string)vAdministrator.GetDataGridViewUtilizatori().SelectedRows[0].Cells[0].Value;
                string password = (string)vAdministrator.GetDataGridViewUtilizatori().SelectedRows[0].Cells[1].Value;
                string tipUtilizator = (string)vAdministrator.GetDataGridViewUtilizatori().SelectedRows[0].Cells[2].Value;
                vAdministrator.GetTextBoxUsername().Text = username;
                vAdministrator.GetTextBoxPassword().Text = password;
                vAdministrator.GetComboBoxTipUtilizator().SelectedIndex = tipUtilizator.Equals("angajat") ? 0 : 1;
            }
        }

        private void cautareUtilizatoriUsername(string informatie)
        {
            List<Utilizator> lista = persistentaUtilizatori.FiltrareUtilizatoriUsername(informatie);
            vAdministrator.GetDataGridViewUtilizatori().Rows.Clear();
            if (lista != null)
            {
                foreach (Utilizator utilizator in lista)
                {
                    DataGridViewRow rand = new DataGridViewRow();
                    rand.CreateCells(vAdministrator.GetDataGridViewUtilizatori());
                    rand.Cells[0].Value = utilizator.GetUsername();
                    rand.Cells[1].Value = utilizator.GetPassword();
                    rand.Cells[2].Value = utilizator.GetTipUtilizator();
                    vAdministrator.GetDataGridViewUtilizatori().Rows.Add(rand);
                }
            }
        }

        private void cautareUtilizatoriTip(string informatie)
        {
            List<Utilizator> lista = persistentaUtilizatori.FiltrareUtilizatoriTip(informatie);
            vAdministrator.GetDataGridViewUtilizatori().Rows.Clear();
            if (lista != null)
            {
                foreach (Utilizator utilizator in lista)
                {
                    DataGridViewRow rand = new DataGridViewRow();
                    rand.CreateCells(vAdministrator.GetDataGridViewUtilizatori());
                    rand.Cells[0].Value = utilizator.GetUsername();
                    rand.Cells[1].Value = utilizator.GetPassword();
                    rand.Cells[2].Value = utilizator.GetTipUtilizator();
                    vAdministrator.GetDataGridViewUtilizatori().Rows.Add(rand);
                }
            }
        }

        private void cautareOpereDupaCriteriu(string informatie, string criteriu)
        {
            List<OperaArta> opere = getListaOpereFiltrata(informatie, criteriu);
            vAdministrator.GetDataGridViewOpere().Rows.Clear();

            if (opere != null)
            {
                foreach (OperaArta opera in opere)
                {
                    DataGridViewRow rand = new DataGridViewRow();
                    rand.CreateCells(vAdministrator.GetDataGridViewOpere());
                    rand.Cells[indecsiGridPersoane["TitluOpera"]].Value = opera.GetTitlu();
                    rand.Cells[indecsiGridPersoane["NumeArtist"]].Value = opera.GetNumeArtist();
                    rand.Cells[indecsiGridPersoane["AnRealizare"]].Value = opera.GetAnRealizare();
                    if (opera is Tablou)
                    {
                        rand.Cells[indecsiGridPersoane["TipOpera"]].Value = "tablou";
                        rand.Cells[indecsiGridPersoane["GenPictura"]].Value = ((Tablou)opera).GetGenPictura();
                        rand.Cells[indecsiGridPersoane["TehnicaTablou"]].Value = ((Tablou)opera).GetTehnica();
                    }
                    else if (opera is Sculptura)
                    {
                        rand.Cells[indecsiGridPersoane["TipOpera"]].Value = "sculptura";
                        rand.Cells[indecsiGridPersoane["TipSculptura"]].Value = ((Sculptura)opera).GetTip();
                    }
                    else
                    {
                        rand.Cells[indecsiGridPersoane["TipOpera"]].Value = "operaDeArta";
                    }
                    vAdministrator.GetDataGridViewOpere().Rows.Add(rand);
                }
            }
            else
            {
                MessageBox.Show("Nu s-a gasit nicio opera!");
            }
        }

        private List<OperaArta> getListaOpereFiltrata(string informatie, string criteriu)
        {
            List<OperaArta> opere = new List<OperaArta>();

            switch (criteriu)
            {
                case "tipOpera":
                    opere = this.persistentaOperaArta.FiltrareOpereTip(informatie);
                    break;
                case "titluOpera":
                    opere = this.persistentaOperaArta.FiltrareOpereTitlu(informatie);
                    break;
                case "numeArtist":
                    opere = this.persistentaOperaArta.FiltrareOpereArtist(informatie);
                    break;
                case "anRealizare":
                    opere = this.persistentaOperaArta.FiltrareOpereAn(informatie);
                    break;
                case "genPictura":
                    opere = this.persistentaOperaArta.FiltrareOpereGenPictura(informatie);
                    break;
                case "tehnicaPictura":
                    opere = this.persistentaOperaArta.FiltrareOpereTehnicaPictura(informatie);
                    break;
                case "tipSculptura":
                    opere = this.persistentaOperaArta.FiltrareOpereTipSculptura(informatie);
                    break;
            }

            return opere;
        }

        private void clearFieldsContent()
        {
            vAdministrator.GetTextBoxUsername().Text = "";
            vAdministrator.GetTextBoxPassword().Text = "";           
        }
        private Dictionary<string, int> initializareIndecsiPersoane()
        {
            return new Dictionary<string, int>
            {
                ["TipOpera"] = 0,
                ["TitluOpera"] = 1,
                ["NumeArtist"] = 2,
                ["AnRealizare"] = 3,
                ["GenPictura"] = 4,
                ["TehnicaTablou"] = 5,
                ["TipSculptura"] = 6
            };
        }
    }
}
