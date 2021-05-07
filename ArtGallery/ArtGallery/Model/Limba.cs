using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ArtGallery.Model
{
    class Limba
    {
        private string limba;

        public Limba()
        {
            limba = "romana";
        }

        public Limba(string limba)
        {
            this.limba = limba;
        }

        public string GetLimba()
        {
            return limba;
        }

        public void SetLimba(string limba)
        {
            this.limba = limba;
        }

        public Dictionary<string, string> CautareInformatie()
        {
            try
            {
                Dictionary<string, string> date = new Dictionary<string, string>();
                XDocument xDoc = XDocument.Load(@"informatii.xml");
                List<XElement> xElements = xDoc.Root.Elements(limba).ToList();
                foreach(XElement xElement in xElements)
                {
                    //view welcome
                    date.Add("bun_venit", xElement.Element("bun_venit").Value);
                    date.Add("autentificare", xElement.Element("autentificare").Value);
                    date.Add("nu_ai_cont", xElement.Element("nu_ai_cont").Value);
                    date.Add("inscrie_te", xElement.Element("inscrie_te").Value);
                    date.Add("sau", xElement.Element("sau").Value);
                    date.Add("continua_ca_vizitator", xElement.Element("continua_ca_vizitator").Value);
                    date.Add("username", xElement.Element("username").Value);
                    date.Add("password", xElement.Element("password").Value);

                    //view signUp
                    date.Add("inregistrare", xElement.Element("inregistrare").Value);
                    date.Add("inregistrare_btn", xElement.Element("inregistrare_btn").Value);
                    date.Add("inapoi_la_login", xElement.Element("inapoi_la_login").Value);
                    
                    //view vizitator
                    date.Add("lista_persoane", xElement.Element("lista_persoane").Value);
                    date.Add("tip_opera", xElement.Element("tip_opera").Value);
                    date.Add("titlu_opera", xElement.Element("titlu_opera").Value);
                    date.Add("nume_artist", xElement.Element("nume_artist").Value);
                    date.Add("an_ralizare_opera", xElement.Element("an_ralizare_opera").Value);
                    date.Add("gen_pictura", xElement.Element("gen_pictura").Value);
                    date.Add("tehnica_pictura", xElement.Element("tehnica_pictura").Value);
                    date.Add("tip_sculptura", xElement.Element("tip_sculptura").Value);
                    date.Add("criteriu_filtrare", xElement.Element("criteriu_filtrare").Value);
                    date.Add("informatie_cautata", xElement.Element("informatie_cautata").Value);
                    date.Add("cauta", xElement.Element("cauta").Value);
                    date.Add("inapoi", xElement.Element("inapoi").Value);
                    date.Add("actualizare", xElement.Element("actualizare").Value);

                    //view Angajat
                    date.Add("adauga", xElement.Element("adauga").Value);
                    date.Add("editeaza", xElement.Element("editeaza").Value);
                    date.Add("sterge", xElement.Element("sterge").Value);
                    date.Add("deconectare", xElement.Element("deconectare").Value);


                    //view Administrator
                    date.Add("criteriu_filtrare_opere", xElement.Element("criteriu_filtrare_opere").Value);
                    date.Add("criteriu_filtrare_utilizatori", xElement.Element("criteriu_filtrare_utilizatori").Value);                    
                    date.Add("tip_utilizator", xElement.Element("tip_utilizator").Value);
                }
                return date;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }
    }
}
