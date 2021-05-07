using ArtGallery.Model.Persistenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Model
{
    class ModelOpere : Opere
    {
        private OperaArta operaArta;
        private PersistentaOperaArta persistentaOpera;
        private string tipOperatie;
        private string informatieCautata;
        private Limba limba;

        public ModelOpere()
        {
            observers = new List<Observer>();
            operaArta = null;
            persistentaOpera = new PersistentaOperaArta();
            tipOperatie = "";
            informatieCautata = "";
            limba = new Limba();
        }

        public OperaArta GetOpera()
        {
            return operaArta;
        }

        public PersistentaOperaArta GetPersistentaOperaArta()
        {
            return persistentaOpera;
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

        public void SetTipOperatie(string tipOperatie)
        {
            this.tipOperatie = tipOperatie;
            Notify();
            operaArta = null;
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
