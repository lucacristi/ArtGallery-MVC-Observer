using ArtGallery.Model.Persistenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Model
{
    public class ModelArtGallery : Opere
    {
        private OperaArta operaArta;
        private PersistentaOperaArta persistentaOpera;
        private Utilizator utilizator;
        private PersistentaUtilizatori persistentaUtilizatori;
        private string tipOperatie;
        private string informatieCautata;
        private Limba limba;

        public ModelArtGallery()
        {
            observers = new List<Observer>();
            operaArta = null;
            utilizator = null;
            persistentaOpera = new PersistentaOperaArta();
            persistentaUtilizatori = new PersistentaUtilizatori();
            tipOperatie = "";
            informatieCautata = "";
            limba = new Limba();
        }

        public OperaArta GetOpera()
        {
            return operaArta;
        }

        public Utilizator GetUtilizator()
        {
            return utilizator;
        }

        public PersistentaOperaArta GetPersistentaOperaArta()
        {
            return persistentaOpera;
        }

        public PersistentaUtilizatori GetPersistentaUtilizator()
        {
            return persistentaUtilizatori;
        }

        public string GetTipOperatie()
        {
            return tipOperatie;
        }

        public string GetInformatieCautata()
        {
            return informatieCautata;
        }

        public Limba GetLimba()
        {
            return limba;
        }

        public void SetOperaArta(OperaArta operaArta)
        {
            this.operaArta = operaArta;
        }

        public void SetUtilizator(Utilizator utilizator)
        {
            this.utilizator = utilizator;
        }

        public void SetTipOperatie(string tipOperatie)
        {
            this.tipOperatie = tipOperatie;
            Notify();
            operaArta = null;
            utilizator = null;
        }

        public void SetInformatieCautata(string informatieCautata)
        {
            this.informatieCautata = informatieCautata;
        }

        public void SetLimba(string limba)
        {
            this.limba.SetLimba(limba);
        }
    }
}
