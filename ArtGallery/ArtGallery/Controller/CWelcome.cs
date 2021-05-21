using ArtGallery.Model;
using ArtGallery.Model.Persistenta;
using ArtGallery.View;
using System;
using System.Windows.Forms;

namespace ArtGallery.Controller
{
    public class CWelcome : Observer
    {
        private VWelcome vWelcome;
        private ModelArtGallery model;

        public CWelcome(VWelcome vWelcome)
        {
            this.vWelcome = vWelcome;
            this.model = vWelcome.GetModel();
            this.gestionareEvenimente();
        }

        public VWelcome GetVWelcome()
        {
            return vWelcome;
        }

        private void gestionareEvenimente()
        {
            this.vWelcome.GetButtonLogin().Click += new EventHandler(login);
            this.vWelcome.GetLinkLabelSignUp().Click += new EventHandler(signup);
            this.vWelcome.GetLinkLabelContinuaCaVizitator().Click += new EventHandler(continuaCaVizitator);
            vWelcome.GetButtonRomana().Click += new EventHandler(romana);
            vWelcome.GetButtonEngleza().Click += new EventHandler(engleza);
            vWelcome.GetButtonItaliana().Click += new EventHandler(italiana);
            vWelcome.GetButtonSpaniola().Click += new EventHandler(spaniola);

        }

        private void login(object sender, EventArgs e)
        {
            string username = this.vWelcome.GetTextBoxUsername().Text;
            string password = this.vWelcome.GetTextBoxPassword().Text;

            if (username.Length > 0 && password.Length > 0)
            {
                Utilizator utilizator = model.GetPersistentaUtilizator().CautaUtilizator(username);                
                if (utilizator != null)
                {
                    if (utilizator.GetTipUtilizator().Equals("administrator"))
                    {
                        if (password.Equals(utilizator.GetPassword()))
                        {
                            MessageBox.Show("Logare cu succes ca admin!");

                            vWelcome.Hide();                
                            new VAdministrator(model).Show();
                            
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

                            vWelcome.Hide();
                            new VAngajat(model).Show();                            
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
            vWelcome.Hide();
            new VSignup(model).Show();
           
        }

        private void continuaCaVizitator(object sender, EventArgs e)
        {
            vWelcome.Hide();
            new VVizitator(model).Show();           
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
