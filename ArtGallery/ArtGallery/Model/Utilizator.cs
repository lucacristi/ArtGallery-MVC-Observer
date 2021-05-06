namespace ArtGallery.Model
{
    class Utilizator
    {
        private string username;
        private string password;
        private string tipUtilizator;

        public Utilizator() { }

        public Utilizator(string username, string password, string tipUtilizator)
        {
            this.username = username;
            this.password = password;
            this.tipUtilizator = tipUtilizator;
        }

        public string GetUsername()
        {
            return username;
        }

        public string GetPassword()
        {
            return password;
        }

        public string GetTipUtilizator()
        {
            return tipUtilizator;
        }

        public void SetUsername(string username)
        {
            this.username = username;
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }

        public void SetTipUtilizator(string tipUtilizator)
        {
            this.tipUtilizator = tipUtilizator;
        }
    }
}
