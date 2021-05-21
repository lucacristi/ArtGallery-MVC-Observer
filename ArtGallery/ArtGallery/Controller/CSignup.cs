using ArtGallery.Model;
using ArtGallery.Model.Persistenta;
using ArtGallery.View;
using System;
using System.Windows.Forms;

namespace ArtGallery.Controller
{
    public class CSignup : Observer
    {
        private VSignup vSignup;
        private ModelArtGallery model;

        public CSignup(VSignup vSignup)
        {
            this.vSignup = vSignup;
            this.model = vSignup.GetModelArtGallery();
            this.gestionareEvenimente();
        }

        public VSignup GetVSignup()
        {
            return this.vSignup;
        }

        private void gestionareEvenimente()
        {
            this.vSignup.GetButtonSignup().Click += new EventHandler(signup);
            this.vSignup.GetLabelBackToLogin().Click += new EventHandler(backToLogin);

            vSignup.GetButtonRomana().Click += new EventHandler(romana);
            vSignup.GetButtonEngleza().Click += new EventHandler(engleza);
            vSignup.GetButtonItaliana().Click += new EventHandler(italiana);
            vSignup.GetButtonSpaniola().Click += new EventHandler(spaniola);
        }

        private void signup(object sender, EventArgs e)
        {
            string username = this.vSignup.GetTextUsername().Text;
            string password = this.vSignup.GetTextPassword().Text;

            if (username.Length > 0 && password.Length > 0)
            {
                if (model.GetPersistentaUtilizator().CautaUtilizator(username) != null)
                {
                    MessageBox.Show("Exista deja un utilizator cu acest username!");
                }
                else
                {
                    Utilizator utilizator = new Utilizator(username, password, "angajat");
                    if (model.GetPersistentaUtilizator().AdaugareUtilizator(utilizator))
                    {
                        MessageBox.Show("Adaugare incheiata cu succes!");
                        vSignup.GetTextUsername().Text = "";
                        vSignup.GetTextPassword().Text = "";
                    }

                    else
                        MessageBox.Show("Nu s-a realizat adaugare in fisier!");
                }
            }
            else
            {
                MessageBox.Show("Nu s-a introdus username sau password!");
            }
        }
        private void backToLogin(object sender, EventArgs e)
        {
            this.vSignup.Hide();
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

        public void Update()
        {
            
        }
    }    
}
