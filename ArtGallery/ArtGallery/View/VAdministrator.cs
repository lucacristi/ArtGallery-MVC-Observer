using System.Windows.Forms;

namespace ArtGallery.View
{
    public partial class VAdministrator : Form
    {
        public VAdministrator()
        {
            InitializeComponent();
            this.dataGridViewOpere.AllowUserToAddRows = false;
            this.dataGridViewUseri.AllowUserToAddRows = false;

            for (int i = 0; i < dataGridViewOpere.ColumnCount; i++)
                this.dataGridViewOpere.Columns[i].ReadOnly = true;

            for (int i = 0; i < dataGridViewUseri.ColumnCount; i++)
                this.dataGridViewUseri.Columns[i].ReadOnly = true;
        }

        public ComboBox GetComboBoxCriteriuOpere()
        {
            return this.comboBoxCriteriuOpere;
        }
        public ComboBox GetComboBoxTipUtilizator()
        {
            return this.comboBoxTipUser;
        }
        public ComboBox GetComboBoxCriteriuUtilizatori()
        {
            return this.comboBoxCriteriuUseri;
        } 

        public TextBox GetTextInformatieOpere()
        {
            return this.textBoxInformatieCautata;
        }
        public TextBox GetTextBoxUsername()
        {
            return this.txtUsername;
        }
        public TextBox GetTextBoxPassword()
        {
            return this.txtPassword;
        }
        public TextBox GetTextBoxInformatieUtilizatori()
        {
            return this.textBoxInformatieUseri;
        }

        public Button GetButtonCautareOpere()
        {
            return this.buttonCautaOpere;
        }
        public Button GetButtonRefreshOpere()
        {
            return this.buttonRefreshOpere;
        }
        public Button GetButtonLogout()
        {
            return this.buttonLogOut;
        }
        public Button GetButtonRefreshUtilizatori()
        {
            return this.buttonRefreshUseri;
        }
        public Button GetButtonStergereUtilizator()
        {
            return this.buttonStergeUser;
        }
        public Button GetButtonAdaugaUtilizator()
        {
            return this.buttonAdaugaUser;
        }
        public Button GetButtonEditeazaUtilizator()
        {
            return this.buttonEditeazaUser;
        }
        public Button GetButtonCautaUtilizatori()
        {
            return this.buttonSearchUseri;
        }

        public Label GetUsernameLabel()
        {
            return this.labelDisplayUsername;
        }

        public DataGridView GetDataGridViewOpere()
        {
            return this.dataGridViewOpere;
        }
        public DataGridView GetDataGridViewUtilizatori()
        {
            return this.dataGridViewUseri;
        }
    }
}
