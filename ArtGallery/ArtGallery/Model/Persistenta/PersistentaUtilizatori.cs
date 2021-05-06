using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ArtGallery.Model.Persistenta
{
    class PersistentaUtilizatori
    {
        private readonly string tagUtilizator = "utilizator"; 
        private readonly string tagUsername = "username"; 
        private readonly string tagPassword = "password"; 
        private readonly string tagTipUtilizator = "tipUtilizator"; 

        private string numeFisier;

        public PersistentaUtilizatori()
        {
            this.numeFisier = "utilizatori.xml";
        }

        public PersistentaUtilizatori(string numeFisier)
        {
            this.numeFisier = numeFisier;
        }

        public bool AdaugareUtilizator(Utilizator utilizator)
        {
            try
            {
                XElement xElement = XElement.Load(@numeFisier);
                xElement.Add(new XElement(tagUtilizator,
                    new XElement(tagUsername, utilizator.GetUsername()),
                    new XElement(tagPassword, utilizator.GetPassword()),
                    new XElement(tagTipUtilizator, utilizator.GetTipUtilizator())
                    ));
                xElement.Save(@numeFisier);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool StergereUtilizator(string username)
        {
            try
            {
                XDocument xDocument = XDocument.Load(@numeFisier);
                xDocument.Root.Elements(tagUtilizator).Where(e => e.Element(tagUsername).Value == username).Remove();
                xDocument.Save(@numeFisier);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ActualizareUtilizator(string username, Utilizator utilizator)
        {
            try
            {
                XDocument xDocument = XDocument.Load(@numeFisier);
                var element = xDocument.Root.Elements(tagUtilizator).Where(e => e.Element(tagUsername).Value == username).Single();
                element.Element(tagUsername).Value = utilizator.GetUsername();
                element.Element(tagPassword).Value = utilizator.GetPassword();
                element.Element(tagTipUtilizator).Value = utilizator.GetTipUtilizator();
                xDocument.Save(@numeFisier);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Utilizator> ListareUtilizatori()
        {
            List<Utilizator> utilizatori = new List<Utilizator>();
            try
            {
                XDocument xDoc = XDocument.Load(@numeFisier);
                List<XElement> xElemente = xDoc.Root.Elements(tagUtilizator).ToList();
                foreach (XElement xElement in xElemente)
                {
                    string username = xElement.Element(tagUsername).Value;
                    string password = xElement.Element(tagPassword).Value;
                    string tipUtilizator = xElement.Element(tagTipUtilizator).Value;
                    
                    Utilizator utilizator= new Utilizator(username, password, tipUtilizator);
                    utilizatori.Add(utilizator);
                }
                return utilizatori;
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public Utilizator CautaUtilizator(string usernameUtilizator)
        {
            try
            {
                XDocument xDoc = XDocument.Load(@numeFisier);
                List<XElement> xElemente = xDoc.Root.Elements(tagUtilizator).ToList();
                foreach (XElement xElement in xElemente)
                {
                    string username = xElement.Element(tagUsername).Value;
                    if (username == usernameUtilizator)
                    {
                        string password = xElement.Element(tagPassword).Value;
                        string tipUtilizator = xElement.Element(tagTipUtilizator).Value;
                        
                        Utilizator utilizator = new Utilizator(username, password, tipUtilizator);
                        return utilizator;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Utilizator> FiltrareUtilizatoriUsername(string usernameUtilizator)
        {
            List<Utilizator> utilizatori = new List<Utilizator>();
            try
            {
                XDocument xDoc = XDocument.Load(@numeFisier);
                List<XElement> xElemente = xDoc.Root.Elements(tagUtilizator).ToList();
                foreach (XElement xElement in xElemente)
                {
                    string username = xElement.Element(tagUsername).Value;
                    if (username.Equals(usernameUtilizator))
                    {
                        string password = xElement.Element(tagPassword).Value;
                        string tipUtilizator = xElement.Element(tagTipUtilizator).Value;
                        Utilizator utilizator = new Utilizator(username, password, tipUtilizator);
                        utilizatori.Add(utilizator);
                    }
                }
                return utilizatori;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Utilizator> FiltrareUtilizatoriTip(string tipUtilizator)
        {
            List<Utilizator> utilizatori = new List<Utilizator>();
            try
            {
                XDocument xDoc = XDocument.Load(@numeFisier);
                List<XElement> xElemente = xDoc.Root.Elements(tagUtilizator).ToList();
                foreach (XElement xElement in xElemente)
                {
                    string tip = xElement.Element(tagTipUtilizator).Value;
                    if (tip.Equals(tipUtilizator))
                    {
                        string username = xElement.Element(tagUsername).Value;
                        string password = xElement.Element(tagPassword).Value;
                        Utilizator utilizator = new Utilizator(username, password, tipUtilizator);
                        utilizatori.Add(utilizator);
                    }
                }
                return utilizatori;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
