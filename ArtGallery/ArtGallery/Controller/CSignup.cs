using ArtGallery.Model;
using ArtGallery.Model.Persistenta;
using ArtGallery.View;
using System;
using System.Windows.Forms;

namespace ArtGallery.Controller
{
    class CSignup
    {
        private VSignup vSignup;
        private PersistentaUtilizatori utilizatorP;

        public CSignup()
        {
            this.vSignup = new VSignup();
            this.utilizatorP = new PersistentaUtilizatori();
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
        }

        private void signup(object sender, EventArgs e)
        {
            string username = this.vSignup.GetTextUsername().Text;
            string password = this.vSignup.GetTextPassword().Text;

            if (username.Length > 0 && password.Length > 0)
            {
                if (this.utilizatorP.CautaUtilizator(username) != null)
                {
                    MessageBox.Show("Exista deja un utilizator cu acest username!");
                }
                else
                {
                    Utilizator utilizator = new Utilizator(username, password, "angajat");
                    if (this.utilizatorP.AdaugareUtilizator(utilizator))
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
            CWelcome cWelcome = new CWelcome();
            cWelcome.GetVWelcome().Show();
        }
    }    
}
