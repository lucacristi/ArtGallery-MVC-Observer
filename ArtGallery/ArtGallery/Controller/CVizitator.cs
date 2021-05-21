using System;
using System.Collections.Generic;
using ArtGallery.Model;
using ArtGallery.Model.Persistenta;
using System.Windows.Forms;
using ArtGallery.View;

namespace ArtGallery.Controller
{
    public class CVizitator : Observer
    {
        private readonly Dictionary<string, int> indecsiGrid;
        
        private VVizitator vVizitator;
        private ModelArtGallery model;

        public CVizitator(VVizitator vVizitator)
        {
            indecsiGrid = initializareIndecsi();
            this.vVizitator = vVizitator;
            this.model = vVizitator.GetModelArtGallery();
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

            vVizitator.GetButtonRomana().Click += new EventHandler(romana);
            vVizitator.GetButtonEngleza().Click += new EventHandler(engleza);
            vVizitator.GetButtonItaliana().Click += new EventHandler(italiana);
            vVizitator.GetButtonSpaniola().Click += new EventHandler(spaniola);
        }

        private void refresh(object sender, EventArgs e)
        {           
            model.SetTipOperatie("vizualizare");
        }

        private void cautare(object sender, EventArgs e)
        {
            int index = vVizitator.GetComboBoxCriteriu().SelectedIndex;
            string informatie = vVizitator.GetTextInformatie().Text;

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
            VWelcome vWelcome = new VWelcome(model);
            vWelcome.Show();            
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
