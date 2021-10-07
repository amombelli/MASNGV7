using System;
using System.Windows.Forms;

namespace AndrewsUtils
{
    public partial class FrmStartApp : Form
    {
        public FrmStartApp()
        {
            InitializeComponent();
        }

        private System.Windows.Forms.Control _container;
        private bool _ignoraButton = true;
        private bool _ignoraCheckBox = false;
        private bool _ignoraTextBox = false;
        private bool _ignoraComboBox = false;
        private bool _ignoraLabel = true;
        private bool _ignoraDateTimePicker = false;

        public void ListOfControls(System.Windows.Forms.Control container, bool ignoraButton = true, bool ignoraCk = false, bool ignoraTextBox = false, bool ignoraCombo = false, bool ignoraLabel = true, bool ignoraDateTimePicker = false)
        {
            _container = container;
            _ignoraButton = ignoraButton;
            _ignoraCheckBox = ignoraCk;
            _ignoraTextBox = ignoraTextBox;
            _ignoraComboBox = ignoraCombo;
            _ignoraLabel = ignoraLabel;
            _ignoraDateTimePicker = ignoraDateTimePicker;
            GetListOfControls();
        }

        private void GetListOfControls()
        {
            try
            {
                foreach (Control ctrl in _container.Controls)
                {
                    GetControl(ctrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void GetControl(Control ctrl)
        {
            switch (ctrl.GetType().Name)
            {
                case "TextBox":
                    Console.WriteLine(ctrl.Name + ".Text=");
                    break;
                case "ComboBox":
                    Console.WriteLine(ctrl.Name + ".Text=");
                    break;
                case "CheckBox":
                    Console.WriteLine(ctrl.Name + ".Checked=");
                    break;
                case "DateTimePicker":
                    Console.WriteLine(ctrl.Name + ".Text=");
                    break;
                case "Label":
                    Console.WriteLine(ctrl.Name + ".Text=");
                    break;
                case "Button":
                    Console.WriteLine(ctrl.Name + ".Enabled=");
                    break;

                default:
                    Console.WriteLine(string.Format("Tipo de datos {0} no manejado", ctrl.GetType().Name));
                    break;
            }

            if (ctrl.Controls.Count > 0)
            {
                ListOfControls(ctrl, _ignoraButton, _ignoraComboBox, _ignoraTextBox, _ignoraComboBox, _ignoraLabel, _ignoraDateTimePicker);
            }
        }

        private void FrmStartApp_Load(object sender, EventArgs e)
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            //var fxName = (System.Windows.Forms.Control) "tx";
            //ListOfControls();
        }
    }
}
