using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ArtGallery.Model.Persistenta
{
    class PersistentaOperaArta
    {
        private string numeFisier;

        public PersistentaOperaArta()
        {
            this.numeFisier = "opereArta.xml";
        }

        public PersistentaOperaArta(string numeFisier)
        {
            this.numeFisier = numeFisier;
        }

        public bool AdaugareOperaArta(OperaArta operaArta)
        {
            try
            {
                XElement xElement = XElement.Load(@numeFisier);

                if (operaArta is Tablou) {
                    Tablou tablou = (Tablou)operaArta;

                    xElement.Add(new XElement("operaArta",
                        new XElement("tipOpera", "tablou"),
                        new XElement("titlu", tablou.GetTitlu()),
                        new XElement("numeArtist", tablou.GetNumeArtist()),
                        new XElement("anRealizare", tablou.GetAnRealizare().ToString()),
                        new XElement("genPictura", tablou.GetGenPictura()),
                        new XElement("tehnica", tablou.GetTehnica())
                        ));
                }
                else if (operaArta is Sculptura) {
                    Sculptura sculptura = (Sculptura)operaArta;

                    xElement.Add(new XElement("operaArta",
                        new XElement("tipOpera", "sculptura"),
                        new XElement("titlu", sculptura.GetTitlu()),
                        new XElement("numeArtist", sculptura.GetNumeArtist()),
                        new XElement("anRealizare", sculptura.GetAnRealizare().ToString()),
                        new XElement("tip", sculptura.GetTip())
                        ));
                }
                else
                {
                    xElement.Add(new XElement("operaArta",
                        new XElement("tipOpera", "operaDeArta"),
                        new XElement("titlu", operaArta.GetTitlu()),
                        new XElement("numeArtist", operaArta.GetNumeArtist()),
                        new XElement("anRealizare", operaArta.GetAnRealizare().ToString())
                        ));
                }

                xElement.Save(@numeFisier);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool StergereOperaArta(string titlu, string numeArtist)
        {
            try
            {
                XDocument xDocument = XDocument.Load(@numeFisier);
                xDocument.Root.Elements("operaArta").Where(e => e.Element("titlu").Value.Equals(titlu) && e.Element("numeArtist").Value.Equals(numeArtist)).Remove();
                xDocument.Save(@numeFisier);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ActualizareOperaArta(string titlu, OperaArta operaArta)
        {
            try
            {
                XDocument xDocument = XDocument.Load(@numeFisier);
                var element = xDocument.Root.Elements("operaArta").Where(e => e.Element("titlu").Value.Equals(titlu)).Single();

                element.Element("titlu").Value = operaArta.GetTitlu();
                element.Element("numeArtist").Value = operaArta.GetNumeArtist();
                element.Element("anRealizare").Value = operaArta.GetAnRealizare().ToString();

                if (operaArta is Tablou)
                {
                    Tablou tablou = (Tablou)operaArta;

                    element.Element("genPictura").Value = tablou.GetGenPictura();
                    element.Element("tehnica").Value = tablou.GetTehnica();
                }

                else if (operaArta is Sculptura)
                {
                    Sculptura sculptura = (Sculptura)operaArta;

                    element.Element("tip").Value = sculptura.GetTip();
                }

                xDocument.Save(numeFisier);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<OperaArta> ListareOpere()
        {
            List<OperaArta> opereArta = new List<OperaArta>();
            try
            {
                XDocument xDoc = XDocument.Load(@numeFisier);
                List<XElement> xElemente = xDoc.Root.Elements("operaArta").ToList();
                foreach (XElement xElement in xElemente)
                {
                    string tipOpera = xElement.Element("tipOpera").Value;

                    string titlu = xElement.Element("titlu").Value;
                    string numeArtist = xElement.Element("numeArtist").Value;
                    int anRealizare = Convert.ToInt32(xElement.Element("anRealizare").Value);

                    if (tipOpera.Equals("operaDeArta"))
                    {               
                        OperaArta operaArta = new OperaArta(titlu, numeArtist, anRealizare);
                        opereArta.Add(operaArta);
                    }

                    if (tipOpera.Equals("tablou"))
                    {
                        string genPictura = xElement.Element("genPictura").Value;
                        string tehnica = xElement.Element("tehnica").Value;

                        OperaArta tablou = new Tablou(titlu, numeArtist, anRealizare, genPictura, tehnica);
                        opereArta.Add(tablou);
                    }

                    if (tipOpera.Equals("sculptura"))
                    {
                        string tip = xElement.Element("tip").Value;

                        OperaArta sculptura = new Sculptura(titlu, numeArtist, anRealizare, tip);
                        opereArta.Add(sculptura);
                    }
                    
                }
                return opereArta;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<OperaArta> FiltrareOpereTip(string tipOpera)
        {
            List<OperaArta> opereArta = new List<OperaArta>();
            try
            {
                XDocument xDoc = XDocument.Load(@numeFisier);
                List<XElement> xElemente = xDoc.Root.Elements("operaArta").ToList();

                foreach (XElement xElement in xElemente)
                {
                    string tip = xElement.Element("tipOpera").Value;


                    if (tip.Equals(tipOpera))
                    {

                        string numeArtist = xElement.Element("numeArtist").Value;
                        string titlu = xElement.Element("titlu").Value;
                        int anRealizare = Convert.ToInt32(xElement.Element("anRealizare").Value);

                        if (tipOpera.Equals("operaDeArta"))
                        {
                            OperaArta operaArta = new OperaArta(titlu, numeArtist, anRealizare);
                            opereArta.Add(operaArta);
                        }

                        if (tipOpera.Equals("tablou"))
                        {
                            string genPictura = xElement.Element("genPictura").Value;
                            string tehnica = xElement.Element("tehnica").Value;

                            OperaArta tablou = new Tablou(titlu, numeArtist, anRealizare, genPictura, tehnica);
                            opereArta.Add(tablou);
                        }

                        if (tipOpera.Equals("sculptura"))
                        {
                            string tipSculptura = xElement.Element("tip").Value;

                            OperaArta sculptura = new Sculptura(titlu, numeArtist, anRealizare, tipSculptura);
                            opereArta.Add(sculptura);
                        }
                    }
                }
                return opereArta;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<OperaArta> FiltrareOpereTitlu(string titluOpera)
        {
            List<OperaArta> opereArta = new List<OperaArta>();
            try
            {
                XDocument xDoc = XDocument.Load(@numeFisier);
                List<XElement> xElemente = xDoc.Root.Elements("operaArta").ToList();

                foreach (XElement xElement in xElemente)
                {
                    string titlu = xElement.Element("titlu").Value;

                    if (titlu.Contains(titluOpera))
                    {
                        string tipOpera = xElement.Element("tipOpera").Value;
                        string nume = xElement.Element("numeArtist").Value;

                        int anRealizare = Convert.ToInt32(xElement.Element("anRealizare").Value);
                        if (tipOpera.Equals("operaDeArta"))
                        {
                            OperaArta operaArta = new OperaArta(titlu, nume, anRealizare);
                            opereArta.Add(operaArta);
                        }

                        if (tipOpera.Equals("tablou"))
                        {
                            string genPictura = xElement.Element("genPictura").Value;
                            string tehnica = xElement.Element("tehnica").Value;

                            OperaArta tablou = new Tablou(titlu, nume, anRealizare, genPictura, tehnica);
                            opereArta.Add(tablou);
                        }

                        if (tipOpera.Equals("sculptura"))
                        {
                            string tip = xElement.Element("tip").Value;

                            OperaArta sculptura = new Sculptura(titlu, nume, anRealizare, tip);
                            opereArta.Add(sculptura);
                        }
                    }
                }
                return opereArta;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<OperaArta> FiltrareOpereArtist(string numeArtist)
        {
            List<OperaArta> opereArta = new List<OperaArta>();
            try
            {
                XDocument xDoc = XDocument.Load(@numeFisier);
                List<XElement> xElemente = xDoc.Root.Elements("operaArta").ToList();

                foreach (XElement xElement in xElemente)
                {
                    string nume = xElement.Element("numeArtist").Value;

                    if (nume.Contains(numeArtist))
                    {
                        string tipOpera = xElement.Element("tipOpera").Value;

                        string titlu = xElement.Element("titlu").Value;
                        int anRealizare = Convert.ToInt32(xElement.Element("anRealizare").Value);

                        if (tipOpera.Equals("operaDeArta"))
                        {
                            OperaArta operaArta = new OperaArta(titlu, nume, anRealizare);
                            opereArta.Add(operaArta);
                        }

                        if (tipOpera.Equals("tablou"))
                        {
                            string genPictura = xElement.Element("genPictura").Value;
                            string tehnica = xElement.Element("tehnica").Value;

                            OperaArta tablou = new Tablou(titlu, nume, anRealizare, genPictura, tehnica);
                            opereArta.Add(tablou);
                        }

                        if (tipOpera.Equals("sculptura"))
                        {
                            string tip = xElement.Element("tip").Value;

                            OperaArta sculptura = new Sculptura(titlu, nume, anRealizare, tip);
                            opereArta.Add(sculptura);
                        }
                    }
                }
                return opereArta;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<OperaArta> FiltrareOpereAn(string anRealizare)
        {
            List<OperaArta> opereArta = new List<OperaArta>();
            try
            {
                XDocument xDoc = XDocument.Load(@numeFisier);
                List<XElement> xElemente = xDoc.Root.Elements("operaArta").ToList();

                foreach (XElement xElement in xElemente)
                {

                    int an = Convert.ToInt32(xElement.Element("anRealizare").Value);

                    if (an==Convert.ToInt32(anRealizare))
                    {
                        string tipOpera = xElement.Element("tipOpera").Value;
                        string nume = xElement.Element("numeArtist").Value;
                        string titlu = xElement.Element("titlu").Value;

                        if (tipOpera.Equals("operaDeArta"))
                        {
                            OperaArta operaArta = new OperaArta(titlu, nume, an);
                            opereArta.Add(operaArta);
                        }

                        if (tipOpera.Equals("tablou"))
                        {
                            string genPictura = xElement.Element("genPictura").Value;
                            string tehnica = xElement.Element("tehnica").Value;

                            OperaArta tablou = new Tablou(titlu, nume, an, genPictura, tehnica);
                            opereArta.Add(tablou);
                        }

                        if (tipOpera.Equals("sculptura"))
                        {
                            string tip = xElement.Element("tip").Value;

                            OperaArta sculptura = new Sculptura(titlu, nume, an, tip);
                            opereArta.Add(sculptura);
                        }
                    }
                }
                return opereArta;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<OperaArta> FiltrareOpereGenPictura(string genPictura)
        {
            List<OperaArta> opereArta = new List<OperaArta>();
            try
            {
                XDocument xDoc = XDocument.Load(@numeFisier);
                List<XElement> xElemente = xDoc.Root.Elements("operaArta").ToList();

                foreach (XElement xElement in xElemente)
                {

                    string tipOpera = xElement.Element("tipOpera").Value;                    

                    if (tipOpera.Equals("tablou"))
                    {
                        string gen = xElement.Element("genPictura").Value;

                        if (gen.Equals(genPictura)){

                            string titlu = xElement.Element("titlu").Value;
                            string nume = xElement.Element("numeArtist").Value;
                            string tehnica = xElement.Element("tehnica").Value;
                            int an = Convert.ToInt32(xElement.Element("anRealizare").Value);

                            OperaArta tablou = new Tablou(titlu, nume, an, genPictura, tehnica);
                            opereArta.Add(tablou);
                        }                           
                    }
                }
                return opereArta;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<OperaArta> FiltrareOpereTehnicaPictura(string tehnicaPictura)
        {
            List<OperaArta> opereArta = new List<OperaArta>();
            try
            {
                XDocument xDoc = XDocument.Load(@numeFisier);
                List<XElement> xElemente = xDoc.Root.Elements("operaArta").ToList();

                foreach (XElement xElement in xElemente)
                {

                    string tipOpera = xElement.Element("tipOpera").Value;

                    if (tipOpera.Equals("tablou"))
                    {
                        string tehnica = xElement.Element("tehnica").Value;

                        if (tehnica.Equals(tehnicaPictura))
                        {
                            string titlu = xElement.Element("titlu").Value;
                            string nume = xElement.Element("numeArtist").Value;                            
                            int an = Convert.ToInt32(xElement.Element("anRealizare").Value);
                            string genPictura = xElement.Element("genPictura").Value;

                            OperaArta tablou = new Tablou(titlu, nume, an, genPictura, tehnica);
                            opereArta.Add(tablou);
                        }
                    }
                }
                return opereArta;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<OperaArta> FiltrareOpereTipSculptura(string tipSculptura)
        {
            List<OperaArta> opereArta = new List<OperaArta>();
            try
            {
                XDocument xDoc = XDocument.Load(@numeFisier);
                List<XElement> xElemente = xDoc.Root.Elements("operaArta").ToList();

                foreach (XElement xElement in xElemente)
                {

                    string tipOpera = xElement.Element("tipOpera").Value;

                    if (tipOpera.Equals("sculptura"))
                    {
                        string tip = xElement.Element("tip").Value;

                        if (tip.Equals(tipSculptura))
                        {
                            string titlu = xElement.Element("titlu").Value;
                            string nume = xElement.Element("numeArtist").Value;
                            int an = Convert.ToInt32(xElement.Element("anRealizare").Value);
                            
                            OperaArta sculptura = new Sculptura(titlu, nume, an, tip);
                            opereArta.Add(sculptura);
                        }
                    }
                }
                return opereArta;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public OperaArta CautaOpera(string titluOpera)
        {
            try
            {
                XDocument xDoc = XDocument.Load(@numeFisier);
                List<XElement> xElemente = xDoc.Root.Elements("operaArta").ToList();
                foreach (XElement xElement in xElemente)
                {
                    string titlu = xElement.Element("titlu").Value;

                    if (titlu.Equals(titluOpera))
                    {
                        string tipOpera = xElement.Element("tipOpera").Value;
                        string numeArtist = xElement.Element("numeArtist").Value;
                        int anRealizare = Convert.ToInt32(xElement.Element("anRealizare").Value);

                        if (tipOpera.Equals("operaDeArta"))
                        {
                            return new OperaArta(titlu, numeArtist, anRealizare);                            
                        }

                        if (tipOpera.Equals("tablou"))
                        {
                            string genPictura = xElement.Element("genPictura").Value;
                            string tehnica = xElement.Element("tehnica").Value;

                            return new Tablou(titlu, numeArtist, anRealizare, genPictura, tehnica);                            
                        }

                        if (tipOpera.Equals("sculptura"))
                        {
                            string tip = xElement.Element("tip").Value;

                            return new Sculptura(titlu, numeArtist, anRealizare, tip);                       
                        }                    
                    }                       
                    
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
