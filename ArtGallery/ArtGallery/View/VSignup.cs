using ArtGallery.Controller;
using ArtGallery.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ArtGallery.View
{
    public partial class VSignup : Form, Observer
    {
        private ModelArtGallery model;
        private CSignup cSignup;

        public VSignup(ModelArtGallery model)
        {
            InitializeComponent();
            this.model = model;
            cSignup = new CSignup(this);
            this.model.Attach(this);
            this.model.Attach(this.cSignup);
            updateLanguage();

        }

        public CSignup GetCSignup()
        {
            return cSignup;
        }

        public ModelArtGallery GetModelArtGallery()
        {
            return model;
        }
        public TextBox GetTextUsername()
        {
            return this.textBoxUsername;
        }

        public TextBox GetTextPassword()
        {
            return this.textBoxPassword;
        }

        public Button GetButtonSignup()
        {
            return this.button1;
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

        public LinkLabel GetLabelBackToLogin()
        {
            return this.linkLabelLogin;
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
                this.label1.Text = date["inregistrare"];

                this.labelUsername.Text = date["username"];
                this.labelPass.Text = date["password"];

                this.button1.Text = date["inregistrare"];
                this.linkLabelLogin.Text = date["inapoi_la_login"];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
