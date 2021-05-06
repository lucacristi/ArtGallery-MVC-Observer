using System.Windows.Forms;

namespace ArtGallery.View
{
    public partial class VAngajat : Form
    {
        public VAngajat()
        {
            InitializeComponent();
            this.dataGridView1.AllowUserToAddRows = false;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                this.dataGridView1.Columns[i].ReadOnly = true;
        }

        public ComboBox GetComboBoxCriteriu()
        {
            return this.comboBoxCriteriu;
        }
        public ComboBox GetComboBoxTipOpera()
        {
            return this.comboBoxTipOpera;
        }

        public TextBox GetTextInformatie()
        {
            return this.textBoxInformatieCautata;
        }
        public TextBox GetTextTitlu()
        {
            return this.textBoxTitlu;
        }
        public TextBox GetTextNumeArtist()
        {
            return this.textBoxNumeArtist;
        }
        public TextBox GetTextAnRealizare()
        {
            return this.textBoxAnRealizare;
        }
        public TextBox GetTextGenTip()
        {
            return this.textBoxGen_Tip;
        }
        public TextBox GetTextTehnica()
        {
            return this.textBoxTehnica;
        }

        public Button GetButtonCautare()
        {
            return this.buttonCauta;
        }
        public Button GetButtonRefresh()
        {
            return this.buttonRefresh;
        }
        public Button GetButtonAdauga()
        {
            return this.buttonAdauga;
        }
        public Button GetButtonSterge()
        {
            return this.buttonSterge;
        }
        public Button GetButtonEditeaza()
        {
            return this.buttonEdit;
        }
        public Button GetButtonLogout()
        {
            return this.buttonLogout;
        }

        public Label GetUsernameLabel()
        {
            return this.labelDisplayUsername;
        }       
        public Label GetLabelGenTip()
        {
            return this.labelGen_Tip;
        }
        public Label GetLabelTehnica()
        {
            return this.labelTehnica;
        }

        public DataGridView GetDataGridViewOpere()
        {
            return this.dataGridView1;
        }                                                              
    }
}
