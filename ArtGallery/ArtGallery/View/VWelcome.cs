using ArtGallery.Controller;
using ArtGallery.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ArtGallery.View
{
    public partial class VWelcome : Form, Observer
    {
        private ModelArtGallery model;
        private CWelcome controller;

        public VWelcome(ModelArtGallery model) 
        {
            InitializeComponent();
            this.model = model;
            controller = new CWelcome(this);
            this.model.Attach(this);
            this.model.Attach(controller);
            updateLanguage();
        }

        public ModelArtGallery GetModel()
        {
            return model;
        }

        public CWelcome GetCWelcome()
        {
            return controller;
        }

        public TextBox GetTextBoxUsername()
        {
            return this.textBoxUsername;
        }

        public TextBox GetTextBoxPassword()
        {
            return this.textBoxPassword;
        }

        public Button GetButtonLogin()
        {
            return this.buttonLogin;
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

        public LinkLabel GetLinkLabelContinuaCaVizitator()
        {
            return this.linkLabelContinueVizitator;
        }

        public LinkLabel GetLinkLabelSignUp()
        {
            return this.linkLabelSignUp;
        }

        public void Update()
        {            
            if (model.GetTipOperatie().ToLower() == "limba")
            {
                updateLanguage();
            }
        }

        private void updateLanguage()
        {
            try
            {
                Dictionary<string, string> date = this.model.GetLimba().CautareInformatie();
                this.labelWelcome.Text = date["bun_venit"];
                this.labelAutentificare.Text = date["autentificare"];

                this.labelUsername.Text = date["username"];
                this.labelPass.Text = date["password"];

                this.buttonLogin.Text = date["autentificare"];
                this.label1.Text = date["nu_ai_cont"];
                this.linkLabelSignUp.Text = date["inscrie_te"];
                this.label2.Text = date["sau"];
                this.linkLabelContinueVizitator.Text = date["continua_ca_vizitator"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
