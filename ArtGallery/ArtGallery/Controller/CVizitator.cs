using System;
using System.Collections.Generic;
using ArtGallery.Model;
using ArtGallery.Model.Persistenta;
using System.Windows.Forms;

namespace ArtGallery.Controller
{
    class CVizitator
    {
        private readonly Dictionary<string, int> indecsiGrid;
        
        private VVizitator vVizitator;
        private PersistentaOperaArta persistentaOperaArta;

        public CVizitator()
        {
            indecsiGrid = initializareIndecsi();
            this.vVizitator = new VVizitator();
            this.persistentaOperaArta = new PersistentaOperaArta();
            this.GestionareEvenimente();
        }

        public VVizitator GetVVizitator()
        {
            return vVizitator;
        }

        private void GestionareEvenimente()
        {
            vVizitator.GetButtonRefresh().Click += new EventHandler(refresh);
            vVizitator.GetButtonCautare().Click += new EventHandler(cautare);
            vVizitator.GetButtonBack().Click += new EventHandler(goBack);
            vVizitator.GetButtonAutentificare().Click += new EventHandler(goAutentificare);
        }

        private void refresh(object sender, EventArgs e)
        {
            List<OperaArta> opere = persistentaOperaArta.ListareOpere();
            vVizitator.GetDataGridViewOpere().Rows.Clear();
            if (opere != null)
            {
                foreach (OperaArta opera in opere)
                {
                    DataGridViewRow rand = new DataGridViewRow();
                    rand.CreateCells(vVizitator.GetDataGridViewOpere());
                    rand.Cells[indecsiGrid["TitluOpera"]].Value = opera.GetTitlu();
                    rand.Cells[indecsiGrid["NumeArtist"]].Value = opera.GetNumeArtist();
                    rand.Cells[indecsiGrid["AnRealizare"]].Value = opera.GetAnRealizare();
                    if (opera is Tablou)
                    {
                        rand.Cells[indecsiGrid["TipOpera"]].Value = "tablou";
                        rand.Cells[indecsiGrid["GenPictura"]].Value = ((Tablou)opera).GetGenPictura();
                        rand.Cells[indecsiGrid["TehnicaTablou"]].Value = ((Tablou)opera).GetTehnica();
                    }
                    else if (opera is Sculptura)
                    {
                        rand.Cells[indecsiGrid["TipOpera"]].Value = "sculptura";
                        rand.Cells[indecsiGrid["TipSculptura"]].Value = ((Sculptura)opera).GetTip();
                    }
                    else
                    {
                        rand.Cells[indecsiGrid["TipOpera"]].Value = "operaDeArta";
                    }
                    vVizitator.GetDataGridViewOpere().Rows.Add(rand);
                }
            }
        }

        private void cautare(object sender, EventArgs e)
        {
            int index = vVizitator.GetComboBoxCriteriu().SelectedIndex;
            string informatie = vVizitator.GetTextInformatie().Text;

            if (informatie.Length > 0)
            {
                switch (index)
                {
                    case 0:
                        cautareDupaCriteriu(informatie, "tipOpera");
                        break;
                    case 1:
                        cautareDupaCriteriu(informatie, "titluOpera");
                        break;
                    case 2:
                        cautareDupaCriteriu(informatie, "numeArtist");
                        break;
                    case 3:
                        cautareDupaCriteriu(informatie, "anRealizare");
                        break;
                    case 4:
                        cautareDupaCriteriu(informatie, "genPictura");
                        break;
                    case 5:
                        cautareDupaCriteriu(informatie, "tehnicaPictura");
                        break;
                    case 6:
                        cautareDupaCriteriu(informatie, "tipSculptura");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Nu s-a introdus informatia cautata!");
            }
        }

        private void cautareDupaCriteriu(string informatie, string criteriu)
        {
            List<OperaArta> opere = getListaFiltrata(informatie, criteriu);           
            vVizitator.GetDataGridViewOpere().Rows.Clear();

            if (opere != null)
            {
                foreach (OperaArta opera in opere)
                {
                    DataGridViewRow rand = new DataGridViewRow();
                    rand.CreateCells(vVizitator.GetDataGridViewOpere());
                    rand.Cells[indecsiGrid["TitluOpera"]].Value = opera.GetTitlu();
                    rand.Cells[indecsiGrid["NumeArtist"]].Value = opera.GetNumeArtist();
                    rand.Cells[indecsiGrid["AnRealizare"]].Value = opera.GetAnRealizare();
                    if (opera is Tablou)
                    {
                        rand.Cells[indecsiGrid["TipOpera"]].Value = "tablou";
                        rand.Cells[indecsiGrid["GenPictura"]].Value = ((Tablou)opera).GetGenPictura();
                        rand.Cells[indecsiGrid["TehnicaTablou"]].Value = ((Tablou)opera).GetTehnica();
                    }
                    else if (opera is Sculptura)
                    {
                        rand.Cells[indecsiGrid["TipOpera"]].Value = "sculptura";
                        rand.Cells[indecsiGrid["TipSculptura"]].Value = ((Sculptura)opera).GetTip();
                    }
                    else
                    {
                        rand.Cells[indecsiGrid["TipOpera"]].Value = "operaDeArta";
                    }
                    vVizitator.GetDataGridViewOpere().Rows.Add(rand);
                }
            }
            else
            {
                MessageBox.Show("Nu s-a gasit nicio opera!");
            }
        }

        private List<OperaArta> getListaFiltrata(string informatie, string criteriu)
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

        private void goBack(object sender, EventArgs e)
        {
            autentificare(sender, e);
        }

        private void goAutentificare(object sender, EventArgs e)
        {
            autentificare(sender, e);
        }

        private void autentificare(object sender, EventArgs e)
        {
            this.vVizitator.Hide();
            CWelcome cWelcome = new CWelcome();
            cWelcome.GetVWelcome().Show();
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
    }
}
