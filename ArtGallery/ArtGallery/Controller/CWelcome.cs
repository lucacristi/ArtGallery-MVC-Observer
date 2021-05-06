using ArtGallery.Model;
using ArtGallery.Model.Persistenta;
using ArtGallery.View;
using System;
using System.Windows.Forms;

namespace ArtGallery.Controller
{
    class CWelcome
    {
        private VWelcome vWelcome;
        private PersistentaUtilizatori persistUtilizatori;

        public CWelcome()
        {
            this.vWelcome = new VWelcome();
            this.persistUtilizatori = new PersistentaUtilizatori();
            this.gestionareEvenimente();
        }

        public VWelcome GetVWelcome()
        {
            return this.vWelcome;
        }

        private void gestionareEvenimente()
        {
            this.vWelcome.GetButtonLogin().Click += new EventHandler(login);
            this.vWelcome.GetLinkLabelSignUp().Click += new EventHandler(signup);
            this.vWelcome.GetLinkLabelContinuaCaVizitator().Click += new EventHandler(continuaCaVizitator);
        }

        private void login(object sender, EventArgs e)
        {
            string username = this.vWelcome.GetTextBoxUsername().Text;
            string password = this.vWelcome.GetTextBoxPassword().Text;

            if (username.Length > 0 && password.Length > 0)
            {
                Utilizator utilizator = persistUtilizatori.CautaUtilizator(username);                
                if (utilizator != null)
                {
                    if (utilizator.GetTipUtilizator().Equals("administrator"))
                    {
                        if (password.Equals(utilizator.GetPassword()))
                        {
                            MessageBox.Show("Logare cu succes ca admin!");

                            this.vWelcome.Hide();
                            CAdministrator cAdministrator = new CAdministrator(utilizator.GetUsername());
                            cAdministrator.GetVAdministrator().Show();
                        }
                        else
                        {
                            MessageBox.Show("Parola incorecta!");
                            vWelcome.GetTextBoxPassword().Text = "";
                        }
                    }
                    else
                    {
                        if (password.Equals(utilizator.GetPassword()))
                        {
                            MessageBox.Show("Logare cu succes!");

                            this.vWelcome.Hide();
                            CAngajat cAngajat = new CAngajat(utilizator.GetUsername());
                            cAngajat.GetVAngajat().Show();
                        }
                        else
                        {
                            MessageBox.Show("Parola incorecta!");
                            vWelcome.GetTextBoxPassword().Text = "";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nume sau parola incorecta!");
                }
            }
            else
                MessageBox.Show("Nu s-a introdus numele sau parola");
        }

        private void signup(object sender, EventArgs e)
        {
            this.vWelcome.Hide();
            CSignup cSignup = new CSignup();
            cSignup.GetVSignup().Show();
        }

        private void continuaCaVizitator(object sender, EventArgs e)
        {
            this.vWelcome.Hide();
            CVizitator cVizitator = new CVizitator();
            cVizitator.GetVVizitator().Show();
        }
    }   
}
