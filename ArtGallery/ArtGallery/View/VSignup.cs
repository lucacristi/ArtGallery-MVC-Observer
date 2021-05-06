using System.Windows.Forms;

namespace ArtGallery.View
{
    public partial class VSignup : Form
    {
        public VSignup()
        {
            InitializeComponent();
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

        public LinkLabel GetLabelBackToLogin()
        {
            return this.linkLabelLogin;
        }
    }
}
