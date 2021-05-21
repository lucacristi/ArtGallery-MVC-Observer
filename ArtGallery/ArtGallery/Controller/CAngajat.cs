using ArtGallery.Model;
using ArtGallery.Model.Persistenta;
using ArtGallery.View;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace ArtGallery.Controller
{
    public class CAngajat : Observer
    {
        private readonly Dictionary<string, int> indecsiGrid;

        private string username;
        private VAngajat vAngajat;
        private ModelArtGallery model;

        public CAngajat(VAngajat vAngajat)
        {
            indecsiGrid = initializareIndecsi();
            this.vAngajat = vAngajat;
            model = vAngajat.GetModelArtGallery();
            gestionareEvenimente();
        }

        public VAngajat GetVAngajat()
        {
            return vAngajat;
        }

        private void gestionareEvenimente()
        {
            setUsername();

            vAngajat.GetButtonLogout().Click += new EventHandler(logout);
            vAngajat.GetButtonRefresh().Click += new EventHandler(refresh);
            vAngajat.GetButtonCautare().Click += new EventHandler(cautare);

            vAngajat.GetComboBoxTipOpera().SelectedIndexChanged += new EventHandler(selectieTipOpera);

            vAngajat.GetButtonAdauga().Click += new EventHandler(adaugare);
            vAngajat.GetButtonEditeaza().Click += new EventHandler(editare);
            vAngajat.GetButtonSterge().Click += new EventHandler(stergere);
            vAngajat.GetDataGridViewOpere().SelectionChanged += new EventHandler(selectieInGrid);

            vAngajat.GetButtonRomana().Click += new EventHandler(romana);
            vAngajat.GetButtonEngleza().Click += new EventHandler(engleza);
            vAngajat.GetButtonItaliana().Click += new EventHandler(italiana);
            vAngajat.GetButtonSpaniola().Click += new EventHandler(spaniola);
        }

        private void setUsername()
        {
            vAngajat.GetUsernameLabel().Text = "username: " + username;
        }

        private void logout(object sender, EventArgs e)
        {
            MessageBox.Show("Log out reusit!");
            vAngajat.Hide();
            new VWelcome(model).Show();            
        }

        private void refresh(object sender, EventArgs e)
        {
            model.SetTipOperatie("vizualizare");
        }

        private void cautare(object sender, EventArgs e)
        {
            int index = vAngajat.GetComboBoxCriteriu().SelectedIndex;
            string informatie = vAngajat.GetTextInformatie().Text;

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

        private void selectieTipOpera(object sender, EventArgs e)
        {
            int index = vAngajat.GetComboBoxTipOpera().SelectedIndex;

            clearFieldsContent();
            
            if (index == 0)
            {
                vAngajat.GetLabelGenTip().Visible = false;
                vAngajat.GetTextGenTip().Visible = false;
                vAngajat.GetLabelTehnica().Visible = false;
                vAngajat.GetTextTehnica().Visible = false;
            }
            if (index == 1)
            {
                vAngajat.GetLabelGenTip().Text = "Gen Pictura";
                vAngajat.GetLabelGenTip().Visible = true;
                vAngajat.GetTextGenTip().Visible = true;
                vAngajat.GetLabelTehnica().Visible = true;
                vAngajat.GetTextTehnica().Visible = true;
            }
            if (index == 2)
            {
                vAngajat.GetLabelGenTip().Text = "Tip Sculptura";
                vAngajat.GetLabelGenTip().Visible = true;
                vAngajat.GetTextGenTip().Visible = true;
                vAngajat.GetLabelTehnica().Visible = false;
                vAngajat.GetTextTehnica().Visible = false;
            }
        }

        private void adaugare(object sender, EventArgs e)
        {
            int indexTipOpera = vAngajat.GetComboBoxTipOpera().SelectedIndex;

            string titlu = vAngajat.GetTextTitlu().Text;
            string numeArtist = vAngajat.GetTextNumeArtist().Text;
            int anRealizare = Int32.MinValue;

            try
            {
                anRealizare = Convert.ToInt32(vAngajat.GetTextAnRealizare().Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Nu s-a introdus un an valid!");
                return;
            }


            if (titlu.Length > 0 && numeArtist.Length > 0 && anRealizare != Int32.MinValue)
            {
                if (model.GetPersistentaOperaArta().CautaOpera(titlu) != null)
                {
                    MessageBox.Show("Exista deja o opera cu titlul \"" + titlu + "\"");
                }
                else
                {                    
                    if (indexTipOpera == 0)
                    {
                        OperaArta operaArta = new OperaArta(titlu, numeArtist, anRealizare);
                        if (model.GetPersistentaOperaArta().AdaugareOperaArta(operaArta))
                        {
                            MessageBox.Show("Adaugare incheiata cu succes!");
                            clearFieldsContent();
                            model.SetTipOperatie("adaugare");
                        }
                        else
                        {
                            MessageBox.Show("Nu s-a realizat adaugare in fisier!");
                        }
                    }
                    if (indexTipOpera == 1)
                    {
                        string genPictura = vAngajat.GetTextGenTip().Text;
                        string tehnica = vAngajat.GetTextTehnica().Text;
                        if (genPictura.Length > 0 && tehnica.Length > 0)
                        {
                            OperaArta operaArta = new Tablou(titlu, numeArtist, anRealizare, genPictura, tehnica);
                            if (model.GetPersistentaOperaArta().AdaugareOperaArta(operaArta))
                            {
                                MessageBox.Show("Adaugare incheiata cu succes!");
                                clearFieldsContent();
                                model.SetTipOperatie("adaugare");
                            }
                            else
                            {
                                MessageBox.Show("Nu s-a realizat adaugare in fisier!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nu s-a introdus genul picturii sau tehnica!");
                        }
                    }
                    if (indexTipOpera == 2)
                    {
                        string tipSculptura = vAngajat.GetTextGenTip().Text;
                        if (tipSculptura.Length > 0)
                        {
                            OperaArta operaArta = new Sculptura(titlu, numeArtist, anRealizare, tipSculptura);
                            if (model.GetPersistentaOperaArta().AdaugareOperaArta(operaArta))
                            {
                                MessageBox.Show("Adaugare incheiata cu succes!");
                                clearFieldsContent();
                                model.SetTipOperatie("adaugare");
                            }
                            else
                            {
                                MessageBox.Show("Nu s-a realizat adaugare in fisier!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nu s-a introdus tipul sculpturii!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Nu s-a introdus titlu sau numele artistului!");
            }

        }

        private void editare(object sender, EventArgs e)
        {
            if (vAngajat.GetDataGridViewOpere().SelectedRows.Count == 0)
            {
                MessageBox.Show("Nu exista nicio opera selectata pentru a fi actualizata");
            }
            else
            {
                string titluOperaSelectat = (string)vAngajat.GetDataGridViewOpere().SelectedRows[0].Cells[indecsiGrid["TitluOpera"]].Value;

                int indexTipOpera = vAngajat.GetComboBoxTipOpera().SelectedIndex;
                string titlu = vAngajat.GetTextTitlu().Text;
                string numeArtist = vAngajat.GetTextNumeArtist().Text;
                int anRealizare = Int32.MinValue;

                try
                {
                    anRealizare = Convert.ToInt32(vAngajat.GetTextAnRealizare().Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Nu s-a introdus un an valid!");
                    return;
                }

                if (titlu.Length > 0 && numeArtist.Length > 0 && anRealizare != Int32.MinValue)
                {
                    if (model.GetPersistentaOperaArta().CautaOpera(titluOperaSelectat) == null)
                    {
                        MessageBox.Show("Nu exista o opera cu titlul \"" + titlu + "\"");
                    }
                    else
                    {
                        if (indexTipOpera == 0)
                        {
                            OperaArta operaArta = new OperaArta(titlu, numeArtist, anRealizare);
                            if (model.GetPersistentaOperaArta().ActualizareOperaArta(titluOperaSelectat, operaArta))
                            {
                                MessageBox.Show("Actualizare incheiata cu succes!");
                                model.SetTipOperatie("actualizare");
                                refresh(sender, e);
                            }

                            else
                            {
                                MessageBox.Show("Nu s-a realizat actualizarea fisierului!");
                            }
                        }
                        if (indexTipOpera == 1)
                        {
                            string genPictura = vAngajat.GetTextGenTip().Text;
                            string tehnica = vAngajat.GetTextTehnica().Text;
                            if (genPictura.Length > 0 && tehnica.Length > 0)
                            {
                                OperaArta operaArta = new Tablou(titlu, numeArtist, anRealizare, genPictura, tehnica);
                                if (model.GetPersistentaOperaArta().ActualizareOperaArta(titluOperaSelectat, operaArta))
                                {
                                    MessageBox.Show("Actualizare incheiata cu succes!");
                                    refresh(sender, e);
                                    model.SetTipOperatie("actualizare");
                                }
                                else
                                {
                                    MessageBox.Show("Nu s-a realizat actualizarea fisierului!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Nu s-a introdus genul picturii sau tehnica!");
                            }
                        }
                        if (indexTipOpera == 2)
                        {
                            string tipSculptura = vAngajat.GetTextGenTip().Text;
                            if (tipSculptura.Length > 0)
                            {
                                OperaArta operaArta = new Sculptura(titlu, numeArtist, anRealizare, tipSculptura);
                                if (model.GetPersistentaOperaArta().ActualizareOperaArta(titluOperaSelectat, operaArta))
                                {
                                    MessageBox.Show("Actualizare incheiata cu succes!");
                                    refresh(sender, e);
                                    model.SetTipOperatie("actualizare");
                                }
                                else
                                {
                                    MessageBox.Show("Nu s-a realizat actualizarea fisierului!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Nu s-a introdus tipul sculpturii!");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nu s-a introdus titlu sau numele artistului!");
                }
            }
        }

        private void stergere(object sender, EventArgs e)
        {
            if (vAngajat.GetDataGridViewOpere().SelectedRows.Count == 0)
            {
                MessageBox.Show("Nu exista nicio opera selectata pentru a fi stearsa");
            }
            else
            {
                string titluSelectat = (string)vAngajat.GetDataGridViewOpere().SelectedRows[0].Cells[indecsiGrid["TitluOpera"]].Value;
                string numeArtist = (string)vAngajat.GetDataGridViewOpere().SelectedRows[0].Cells[indecsiGrid["NumeArtist"]].Value;
                if (model.GetPersistentaOperaArta().StergereOperaArta(titluSelectat, numeArtist))
                {
                    MessageBox.Show("Stergere incheiata cu succes!");
                    refresh(sender, e);
                    model.SetTipOperatie("stergere");
                }
                else
                {
                    MessageBox.Show("Nu s-a realizat stergere in fisier!");
                    clearFieldsContent();
                }
            }
        }

        private void selectieInGrid(object sender, EventArgs e)
        {
            if (vAngajat.GetDataGridViewOpere().SelectedRows.Count == 0)
            {
                vAngajat.GetTextTitlu().Text = "";
                vAngajat.GetTextNumeArtist().Text = "";
                vAngajat.GetTextAnRealizare().Text = "";
            }
            else
            {
                string tipOpera = (string) vAngajat.GetDataGridViewOpere().SelectedRows[0].Cells[indecsiGrid["TipOpera"]].Value;

                string titlu = (string)vAngajat.GetDataGridViewOpere().SelectedRows[0].Cells[indecsiGrid["TitluOpera"]].Value;
                string numeArtist = (string)vAngajat.GetDataGridViewOpere().SelectedRows[0].Cells[indecsiGrid["NumeArtist"]].Value;
                int anRealizare = (int)vAngajat.GetDataGridViewOpere().SelectedRows[0].Cells[indecsiGrid["AnRealizare"]].Value;         

                if (tipOpera.Equals("Opera de Arta"))
                {
                    vAngajat.GetComboBoxTipOpera().SelectedIndex = 0;
                    model.SetOperaArta(new OperaArta(titlu, numeArtist, anRealizare));
                }
                else if (tipOpera.Equals("Tablou"))
                {
                    vAngajat.GetComboBoxTipOpera().SelectedIndex = 1;
                    vAngajat.GetLabelGenTip().Text = "Gen Pictura";
                    vAngajat.GetLabelGenTip().Visible = true;
                    vAngajat.GetTextGenTip().Visible = true;
                    vAngajat.GetLabelTehnica().Visible = true;
                    vAngajat.GetTextTehnica().Visible = true;

                    string genPictura = (string)vAngajat.GetDataGridViewOpere().SelectedRows[0].Cells[indecsiGrid["GenPictura"]].Value;
                    string tehnicaTablou = (string)vAngajat.GetDataGridViewOpere().SelectedRows[0].Cells[indecsiGrid["TehnicaTablou"]].Value;

                    model.SetOperaArta(new Tablou(titlu, numeArtist, anRealizare, genPictura, tehnicaTablou));

                }
                else if (tipOpera.Equals("Sculptura"))
                {
                    vAngajat.GetComboBoxTipOpera().SelectedIndex = 2;
                    vAngajat.GetLabelGenTip().Text = "Tip Sculptura";
                    vAngajat.GetLabelGenTip().Visible = true;
                    vAngajat.GetTextGenTip().Visible = true;
                    vAngajat.GetLabelTehnica().Visible = false;
                    vAngajat.GetTextTehnica().Visible = false;

                    string tipSculptura = (string)vAngajat.GetDataGridViewOpere().SelectedRows[0].Cells[indecsiGrid["TipSculptura"]].Value;

                    model.SetOperaArta(new Sculptura(titlu, numeArtist, anRealizare, tipSculptura));
                }
               
                model.SetTipOperatie("selectie");
            }
        }    

        private void clearFieldsContent()
        {
            vAngajat.GetTextTitlu().Text = "";
            vAngajat.GetTextNumeArtist().Text = "";
            vAngajat.GetTextAnRealizare().Text = "";
            vAngajat.GetTextGenTip().Text = "";
            vAngajat.GetTextTehnica().Text = "";
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

        private Dictionary<string, int> initializareIndecsi()
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
