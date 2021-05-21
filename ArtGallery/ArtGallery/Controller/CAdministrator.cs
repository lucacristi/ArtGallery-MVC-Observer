using ArtGallery.Model;
using ArtGallery.Model.Persistenta;
using ArtGallery.View;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ArtGallery.Controller
{
    public class CAdministrator : Observer
    {
        private readonly Dictionary<string, int> indecsiGridPersoane;
        private string username;

        private VAdministrator vAdministrator;
        private ModelArtGallery model;

        public CAdministrator(VAdministrator vAdministrator)
        {
            indecsiGridPersoane = initializareIndecsiPersoane();
            this.vAdministrator = vAdministrator;
            model = vAdministrator.GetModelArtGallery();
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

            vAdministrator.GetButtonRomana().Click += new EventHandler(romana);
            vAdministrator.GetButtonEngleza().Click += new EventHandler(engleza);
            vAdministrator.GetButtonItaliana().Click += new EventHandler(italiana);
            vAdministrator.GetButtonSpaniola().Click += new EventHandler(spaniola);
        }

        private void setUsername()
        {
            vAdministrator.GetUsernameLabel().Text = "username: " + username;
        }

        private void logout(object sender, EventArgs e)
        {
            this.vAdministrator.Hide();
            new VWelcome(model).Show();
           
        }

        private void refreshOpere(object sender, EventArgs e)
        {
            model.SetTipOperatie("vizualizare");
        }

        private void cautareOpere(object sender, EventArgs e)
        {
            int index = vAdministrator.GetComboBoxCriteriuOpere().SelectedIndex;
            string informatie = vAdministrator.GetTextInformatieOpere().Text;

            if (informatie.Length > 0)
            {
                model.SetInformatieCautata(informatie);
                switch (index)
                {
                    case 0:
                        model.SetTipOperatie("cautareTipOpera");
                        break;
                    case 1:
                        model.SetTipOperatie("cautareTitlu");
                        break;
                    case 2:
                        model.SetTipOperatie("cautareNumeArtist");
                        break;
                    case 3:
                        model.SetTipOperatie("cautareAnRealizare");
                        break;
                    case 4:
                        model.SetTipOperatie("cautareGenPictura");
                        break;
                    case 5:
                        model.SetTipOperatie("cautareTehnicaPictura");
                        break;
                    case 6:
                        model.SetTipOperatie("cautareTipSculptura");
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
            model.SetTipOperatie("vizualizareuseri");
        }

        private void cautareUtilizatori(object sender, EventArgs e)
        {
            int index = vAdministrator.GetComboBoxCriteriuUtilizatori().SelectedIndex;
            string informatie = vAdministrator.GetTextBoxInformatieUtilizatori().Text;
            
            if (informatie.Length > 0)
            {
                model.SetInformatieCautata(informatie);
                if (index == 0)
                {
                    model.SetTipOperatie("cautareusername");
                }
                else
                {
                    model.SetTipOperatie("cautaretipuser");
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
                if (model.GetPersistentaUtilizator().CautaUtilizator(username) != null)
                {
                    MessageBox.Show("Exista deja un utilizator cu username-ul \"" + username + "\"");
                }
                else
                {
                    if (indexTipUtilizator == 0)
                    {
                        Utilizator utilizator = new Utilizator(username, password, "angajat");
                        if (model.GetPersistentaUtilizator().AdaugareUtilizator(utilizator))
                        {
                            MessageBox.Show("Adaugare incheiata cu succes!");
                            model.SetTipOperatie("adaugareuseri");
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
                        if (model.GetPersistentaUtilizator().AdaugareUtilizator(utilizator))
                        {
                            MessageBox.Show("Adaugare incheiata cu succes!");
                            model.SetTipOperatie("adaugareuseri");
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
                    if (model.GetPersistentaUtilizator().CautaUtilizator(selectedUsername) == null)
                    {
                        MessageBox.Show("Nu exista un utilizator cu acest username!");
                    }
                    else
                    {
                        Utilizator utilizator = new Utilizator(username, password, tipUtilizator==0?"angajat":"administrator");
                        if (model.GetPersistentaUtilizator().ActualizareUtilizator(selectedUsername, utilizator))
                        {
                            MessageBox.Show("Actualizare incheiata cu succes!");
                            model.SetTipOperatie("actualizareuseri");
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
                if (model.GetPersistentaUtilizator().StergereUtilizator(usernameSelectat))
                {
                    MessageBox.Show("Stergere incheiata cu succes!");
                    model.SetTipOperatie("stergereuseri");
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
                model.SetUtilizator(new Utilizator(username, password, tipUtilizator));

                model.SetTipOperatie("selectieuseri");
            }
        }

        private void romana(object sender, EventArgs e)
        {
            this.model.SetLimba("romana");
            this.model.SetTipOperatie("limba");
        }

        private void engleza(object sender, EventArgs e)
        {
            this.model.SetLimba("engleza");
            this.model.SetTipOperatie("limba");
        }

        private void italiana(object sender, EventArgs e)
        {
            this.model.SetLimba("italiana");
            this.model.SetTipOperatie("limba");
        }

        private void spaniola(object sender, EventArgs e)
        {
            this.model.SetLimba("spaniola");
            this.model.SetTipOperatie("limba");
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

        public void Update()
        {
            
        }
    }
}
