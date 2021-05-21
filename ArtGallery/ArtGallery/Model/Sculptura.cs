namespace ArtGallery.Model
{
    public class Sculptura:OperaArta
    {
        private string tip;

        public Sculptura() { }

        public Sculptura(Sculptura sculptura)
        {
            this.titlu = sculptura.titlu;
            this.numeArtist = sculptura.numeArtist;
            this.anRealizare = sculptura.anRealizare;
            this.tip = sculptura.tip;
        }

        public Sculptura(string titlu, string numeArtist, int anRealizare, string tip)
        {
            this.titlu = titlu;
            this.numeArtist = numeArtist;
            this.anRealizare = anRealizare;
            this.tip = tip;
        }

        public string GetTip()
        {
            return tip;
        }

        public void SetTip(string tip)
        {
            this.tip = tip;
        }
    }
}
