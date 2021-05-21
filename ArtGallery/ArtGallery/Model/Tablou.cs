namespace ArtGallery.Model
{
    public class Tablou:OperaArta
    {
        private string genPictura;
        private string tehnica;

        public Tablou() { }

        public Tablou(Tablou tablou)
        {
            this.titlu = tablou.titlu;
            this.numeArtist = tablou.numeArtist;
            this.anRealizare = tablou.anRealizare;
        }

        public Tablou(string titlu, string numeArtist, int anRealizare, string genPictura, string tehnica)
        {
            this.titlu = titlu;
            this.numeArtist = numeArtist;
            this.anRealizare = anRealizare;
            this.genPictura = genPictura;
            this.tehnica = tehnica;
        }

        public string GetGenPictura()
        {
            return genPictura;
        }

        public string GetTehnica()
        {
            return tehnica;
        }

        public void SetGenPictura(string genPictura)
        {
            this.genPictura = genPictura;
        }

        public void SetTehnica(string tehnica)
        {
            this.tehnica = tehnica;
        }
    }
}
